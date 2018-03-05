/*=============================================================================
*
*	(C) Copyright 2007, Michael Carlisle (mike.carlisle@thecodeking.co.uk)
*
*   http://www.TheCodeKing.co.uk
*  
*	All rights reserved.
*	The code and information is provided "as-is" without waranty of any kind,
*	either expressed or implied.
*
*=============================================================================
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TheCodeKing.Net.Messaging.Concrete.WindowsMessaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace TheCodeKing.Net.Messaging.Concrete.MailSlot
{
    /// <summary>
    /// Implementation of IXDListener. This uses a Mutex to synchronize access
    /// to the MailSlot for a particular channel, such that only one listener will
    /// pickup messages on a single machine per channel.
    /// </summary>
    internal sealed class XDMailSlotListener : IXDListener
    {
        /// <summary>
        /// Indicates whether the object has been disposed.
        /// </summary>
        private bool disposed;
        /// <summary>
        /// Lock object used for synchronizing access to the activeThreads list.
        /// </summary>
        private object lockObj = new object();
        /// <summary>
        /// The unique name of the Mutex used for locking access to the MailSlot for a named
        /// channel.
        /// </summary>
        private const string mutexNetworkDispatcher = @"Global\XDMailSlotListener";
        /// <summary>
        /// The base name of the MailSlot on the current machine.
        /// </summary>
        private static readonly string mailSlotIdentifier = string.Concat(@"\\.", XDMailSlotBroadcast.SlotLocation);
        /// <summary>
        /// A hash table of Thread instances used for reading the MailSlot
        /// for specific channels.
        /// </summary>
        private Dictionary<string, MailSlotThreadInfo> activeThreads;
        /// <summary>
        /// The delegate used to dispatch the MessageReceived event.
        /// </summary>
        public event XDListener.XDMessageHandler MessageReceived;
        /// <summary>
        /// Records the last unique message id received.
        /// </summary>
        private string lastMessageId;
        /// <summary>
        /// The default constructor.
        /// </summary>
        internal XDMailSlotListener()
        {
            this.activeThreads = new Dictionary<string, MailSlotThreadInfo>(StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// The worker thread entry point for polling the MailSlot. Threads will queue until a Mutex becomes
        /// available for a particular channel. 
        /// </summary>
        /// <param name="state"></param>
        private void MailSlotChecker(object state)
        {
            MailSlotThreadInfo info = (MailSlotThreadInfo)state;
            bool isOwner = false;
            string mutextKey = string.Concat(mutexNetworkDispatcher, ".", info.ChannelName);
            using (Mutex mutex = new Mutex(true, mutextKey, out isOwner))
            {
                // if doesn't own mutex then wait
                if (!isOwner)
                {
                    try
                    {
                        mutex.WaitOne();
                        isOwner = true;
                    }
                    catch (ThreadInterruptedException) { } // shut down thread
                    catch (AbandonedMutexException)
                    {
                        // This thread is now the owner
                        isOwner = true;
                    }
                }

                if (isOwner)
                {
                    // enter message read loop
                    ProcessMessages(info);

                    // if this thread owns mutex then release it
                    mutex.ReleaseMutex();
                }
            }
        }

        /// <summary>
        /// This helper method puts the thread into a read message
        /// loop.
        /// </summary>
        /// <param name="info"></param>
        private void ProcessMessages(MailSlotThreadInfo info)
        {
            int bytesToRead = 512, maxMessageSize = 0, messageCount = 0, readTimeout = 0;
            // for as long as thread is alive and the channel is registered then act as the MailSlot reader
            while (!disposed && activeThreads.ContainsKey(info.ChannelName))
            {
                // if the channel mailslot is not open try to open it
                if (!info.HasValidFileHandle)
                {
                    info.FileHandle = Native.CreateMailslot(string.Concat(mailSlotIdentifier, info.ChannelName), 0, Native.MAILSLOT_WAIT_FOREVER, IntPtr.Zero);
                }

                // if there is a valid read handle try to read messages
                if (info.HasValidFileHandle)
                {
                    byte[] buffer = new byte[bytesToRead];
                    uint bytesRead = 0;
                    // this blocks until a message is received, the message cannot be buffered with overlap structure
                    // so the bytes array must be larger than the current item in order to read the complete message
                    while (Native.ReadFile(info.FileHandle, buffer, (uint)bytesToRead, out bytesRead, IntPtr.Zero))
                    {
                        ProcessMessage(buffer, bytesRead);
                        // reset buffer size
                        bytesToRead = 512;
                        buffer = new byte[bytesToRead];
                    }
                    int code = Marshal.GetLastWin32Error();
                    switch (code)
                    {
                        case Native.ERROR_INSUFFICIENT_BUFFER:
                            // insufficent buffer size, we need to the increase buffer size to read the current item
                            Native.GetMailslotInfo(info.FileHandle, ref maxMessageSize, ref bytesToRead, ref messageCount, ref readTimeout);
                            break;
                        case Native.ERROR_INVALID_HANDLE:
                            // close handle if invalid
                            if (info.HasValidFileHandle)
                            {
                                Native.CloseHandle(info.FileHandle);
                                info.FileHandle = IntPtr.Zero;
                            }
                            break;
                        case Native.ERROR_HANDLE_EOF:
                            // read handle has been closed
                            info.FileHandle = IntPtr.Zero;
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Extracts the message for the buffer and raises the MessageReceived event.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="bytesRead"></param>
        private void ProcessMessage(byte[] buffer, uint bytesRead)
        {
            BinaryFormatter b = new BinaryFormatter();
            string rawMessage = string.Empty;
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(buffer, 0, (int)bytesRead);
                stream.Flush();
                // reset the stream cursor back to the beginning
                stream.Seek(0, SeekOrigin.Begin);
                try
                {
                    rawMessage = (string)b.Deserialize(stream);
                }
                catch (SerializationException) { } // if something goes wrong such as handle is closed,
                                                   // we will not process this message
            }
            // mailslot message format is id:channel:message
            using (DataGram dataGramId = DataGram.ExpandFromRaw(rawMessage))
            {
                // only dispatch event if this is a new message
                // this filters out mailslot duplicates which are sent once per protocol
                if (dataGramId.IsValid && dataGramId.Channel != lastMessageId)
                {
                    // remember we have seen this message
                    lastMessageId = dataGramId.Channel;
                    using (DataGram dataGram = DataGram.ExpandFromRaw(dataGramId.Message))
                    {
                        if (dataGram.IsValid)
                        {
                            OnMessageReceived(dataGram);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method processes the message and triggers the MessageReceived event. 
        /// </summary>
        /// <param name="dataGram"></param>
        private void OnMessageReceived(DataGram dataGram)
        {
            if (MessageReceived != null)
            {
                // trigger this async
                MessageReceived.Invoke(this, new XDMessageEventArgs(dataGram));
            }
        }
        /// <summary>
        /// Create a new listener thread which will try and obtain the mutex. If it can't
        /// because another process is already polling this channel then it will wait until 
        /// it can gain an exclusive lock.
        /// </summary>
        /// <param name="channelName"></param>
        public void RegisterChannel(string channelName)
        {
            MailSlotThreadInfo channelThread;
            if (!activeThreads.TryGetValue(channelName, out channelThread))
            {
                // only lock if changing
                lock (lockObj)
                {
                    // double check has not been modified before lock
                    if (!activeThreads.TryGetValue(channelName, out channelThread))
                    {
                        channelThread = StartNewThread(channelName);
                        activeThreads[channelName] = channelThread;
                    }

                }
            }
        }
        /// <summary>
        /// Unregisters the current instance from the given channel. No more messages will be 
        /// processed, and another process will be allowed to obtain the listener lock.
        /// </summary>
        /// <param name="channelName"></param>
        public void UnRegisterChannel(string channelName)
        {
            MailSlotThreadInfo info = null;
            if (activeThreads.TryGetValue(channelName, out info))
            {
                // only lock if changing
                lock (lockObj)
                {
                    // double check has not been modified before lock
                    if (activeThreads.TryGetValue(channelName, out info))
                    {
                        // removing form hash shuts down the thread loop
                        activeThreads.Remove(channelName);
                    }
                }
                if (info!=null)
                {
                    // close any read handles
                    if (info.HasValidFileHandle)
                    {
                        Native.CloseHandle(info.FileHandle);
                    }
                    if (info.Thread.IsAlive)
                    {
                        // interrupt incase of asleep thread
                        info.Thread.Interrupt();
                    }
                    if (info.Thread.IsAlive)
                    {
                        // attempt to join thread
                        if (!info.Thread.Join(500))
                        {
                            // if no response within timeout, force abort
                            info.Thread.Abort();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Helper method starts up a new listener thread for a given channel.
        /// </summary>
        /// <param name="channelName">The channel name.</param>
        /// <returns></returns>
        private MailSlotThreadInfo StartNewThread(string channelName)
        {
            // create and start the thread at low priority
            Thread thread = new Thread(new ParameterizedThreadStart(MailSlotChecker));
            thread.Priority = ThreadPriority.Lowest;
            thread.IsBackground = true;
            MailSlotThreadInfo info = new MailSlotThreadInfo(channelName, thread);
            thread.Start(info);
            return info;
        }
        /// <summary>
        /// Deconstructor, cleans unmanaged resources only
        /// </summary>
        ~XDMailSlotListener()
        {
            Dispose(false);
        }

        /// <summary>
        /// Dispose implementation which ensures all resources are destroyed.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Dispose implementation, which ensures the native window is destroyed
        /// </summary>
        private void Dispose(bool disposeManaged)
        {
            if (!disposed)
            {
                disposed = true;
                if (disposeManaged)
                {
                    if (MessageReceived != null)
                    {
                        // remove all handlers
                        Delegate[] del = MessageReceived.GetInvocationList();
                        foreach (TheCodeKing.Net.Messaging.XDListener.XDMessageHandler msg in del)
                        {
                            MessageReceived -= msg;
                        }
                    }
                    if (activeThreads != null)
                    {
                        // grab a reference to the current list of threads
                        var values = new List<MailSlotThreadInfo>(activeThreads.Values);
       
                        // removing the channels, will cause threads to terminate
                        activeThreads.Clear();
                        // shut down listener threads
                        foreach (MailSlotThreadInfo info in values)
                        {
                            // close any read handles
                            if (info.HasValidFileHandle)
                            {
                                Native.CloseHandle(info.FileHandle);
                            }

                            // ensure threads shut down 
                            if (info.Thread.IsAlive)
                            {
                                // interrupt incase of asleep thread
                                info.Thread.Interrupt();
                            }
                            // try to join thread
                            if (info.Thread.IsAlive)
                            {
                                if (!info.Thread.Join(500))
                                {
                                    // last resort abort thread
                                    info.Thread.Abort();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
