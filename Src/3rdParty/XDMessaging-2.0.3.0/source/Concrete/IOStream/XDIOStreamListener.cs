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
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using TheCodeKing.Net.Messaging.Concrete.MultiBroadcast;

namespace TheCodeKing.Net.Messaging.Concrete.IOStream
{
    /// <summary>
    /// A concrete implementation of IXDListener which can be used to listen for messages
    /// broadcast using the XDIOStreamBroadcast implementation. A Mutex is used to ensure 
    /// a single clean up thread removes messages after the specified timeout period. Dispose
    /// should be called to shut down the listener cleanly and free up resources.
    /// </summary>
    internal sealed class XDIOStreamListener : IXDListener
    {
        // Flag as to whether dispose has been called
        private bool disposed = false;
        /// <summary>
        /// A list of FileSystemWatcher instances used for each registered channel.
        /// </summary>
        private Dictionary<string, FileSystemWatcher> watcherList;
        /// <summary>
        /// A lock object used to ensure changes to watcherList are thread-safe.
        /// </summary>
        private object lockObj = new object();

        /// <summary>
        /// An instance of NetworkRelayListener used to listen for messages sent across the network, so
        /// they can be dispatched locally. A Mutex ensures only one instance is active at any one time for this mode.
        /// </summary>
        private NetworkRelayListener networkRelay;

        /// <summary>
        /// Default constructor.
        /// </summary>
        internal XDIOStreamListener()
        {
            this.watcherList = new Dictionary<string, FileSystemWatcher>(StringComparer.InvariantCultureIgnoreCase);

            // ensure there is a network watcher for this mode, the implementation ensures only one is active at
            // any one time
            this.networkRelay = new NetworkRelayListener(XDBroadcast.CreateBroadcast(XDTransportMode.IOStream),
                                            XDListener.CreateListener(XDTransportMode.MailSlot));
        }

        /// <summary>
        /// The MessageReceived event used to broadcast the message to attached instances within the current appDomain.
        /// </summary>
        public event XDListener.XDMessageHandler MessageReceived;

        /// <summary>
        /// Sets up a new FileSystemWatcher so that messages can be received on a particular 'channel'.
        /// </summary>
        /// <param name="channelName"></param>
        public void RegisterChannel(string channelName)
        {
            if (string.IsNullOrEmpty(channelName))
            {
                throw new ArgumentNullException(channelName, "The channel name cannot be null or empty.");
            }
            if (disposed)
            {
                throw new ObjectDisposedException("IXDListener", "This instance has been disposed.");
            }
            FileSystemWatcher watcher = EnsureWatcher(channelName);
            watcher.EnableRaisingEvents = true;
        }
        /// <summary>
        /// Disables any FileSystemWatcher for a particular channel so that messages are no longer received.
        /// </summary>
        /// <param name="channelName"></param>
        public void UnRegisterChannel(string channelName)
        {
            if (string.IsNullOrEmpty(channelName))
            {
                throw new ArgumentNullException(channelName, "The channel name cannot be null or empty.");
            }
            if (disposed)
            {
                throw new ObjectDisposedException("IXDListener", "This instance has been disposed.");
            }
            FileSystemWatcher watcher = EnsureWatcher(channelName);
            watcher.EnableRaisingEvents = false;
        }

        /// <summary>
        /// Provides a thread safe method to lookup/create a instance of FileSystemWatcher for a particular channel.
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        private FileSystemWatcher EnsureWatcher(string channelName)
        {
            FileSystemWatcher watcher = null;
            // try to get a reference to the watcher used for the current watcher
            if (!watcherList.TryGetValue(channelName, out watcher))
            {
                // if no watcher then lock the list
                lock (lockObj)
                {
                    // whilst locked double check if the item has been added since the lock was applied
                    if (!watcherList.TryGetValue(channelName, out watcher))
                    {
                        // create a new watcher for the given channel, by default this is not enabled.
                        string folder = XDIOStreamBroadcast.GetChannelDirectory(channelName);
                        watcher = new FileSystemWatcher(folder, "*.msg");
                        watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite;
                        watcher.Changed += new FileSystemEventHandler(OnMessageReceived);
                        watcherList.Add(channelName, watcher);
                    }
                }
            }
            return watcher;
        }

        /// <summary>
        /// The FileSystemWatcher event that is triggered when a new file is created in the channel temporary
        /// directory. This dispatches the MessageReceived event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMessageReceived(object sender, FileSystemEventArgs e)
        {
            // if a new file is added to the channel directory
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                try 
                {
                    // check if file exists
                    if (File.Exists(e.FullPath))
                    {
                        string rawmessage = null;
                        // try to load the file in shared access mode
                        using (FileStream stream = File.Open(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                rawmessage = reader.ReadToEnd();
                            }
                        }

                        using (DataGram dataGram = DataGram.ExpandFromRaw(rawmessage))
                        {
                            if (dataGram.IsValid)
                            {
                                // dispatch the message received event
                                MessageReceived(this, new XDMessageEventArgs(dataGram));
                            }
                        }
                    }
                }
                catch (FileNotFoundException) 
                {
                    // if for any reason the file was deleted before the message could be read from the file,
                    // then can safely ignore this message
                }
                catch (UnauthorizedAccessException ue)
                {
                    throw new UnauthorizedAccessException(string.Format("Unable to bind to channel as access is denied." +
                        " Ensure the process has read/write access to the directory '{0}'.", e.FullPath), ue);
                }
                catch (IOException ie)
                {
                    throw new IOException(string.Format("There was an unexpected IO error binding to a channel." +
                        " Ensure the process is unable to read/write to directory '{0}'.", e.FullPath), ie);
                }
            }
        }

        /// <summary>
        /// Deconstructor, cleans unmanaged resources only
        /// </summary>
        ~XDIOStreamListener()
        {
            Dispose(false);
        }

        /// <summary>
        /// Dispose implementation which ensures all FileSystemWatchers
        /// are shut down and handlers detatched.
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
                    if (networkRelay != null)
                    {
                        networkRelay.Dispose();
                        networkRelay = null;
                    }

                    if (MessageReceived != null)
                    {
                        // remove all handlers
                        Delegate[] del = MessageReceived.GetInvocationList();
                        foreach (TheCodeKing.Net.Messaging.XDListener.XDMessageHandler msg in del)
                        {
                            MessageReceived -= msg;
                        }
                    }
                    if (watcherList != null)
                    {
                        // shut down watchers
                        foreach (FileSystemWatcher watcher in watcherList.Values)
                        {
                            watcher.EnableRaisingEvents = false;
                            watcher.Changed -= new FileSystemEventHandler(OnMessageReceived);
                            watcher.Dispose();
                        }
                        watcherList.Clear();
                        watcherList = null;
                    }
                }
            }
        }
    }
}
