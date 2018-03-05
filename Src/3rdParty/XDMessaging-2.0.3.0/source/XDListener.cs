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
using System.Windows.Forms;
using TheCodeKing.Net.Messaging.Concrete.IOStream;
using TheCodeKing.Net.Messaging.Concrete.WindowsMessaging;
using System.Diagnostics;
using TheCodeKing.Net.Messaging.Concrete.MultiBroadcast;
using TheCodeKing.Net.Messaging.Concrete;

namespace TheCodeKing.Net.Messaging
{
    /// <summary>
    /// An implementation of IXDListener used to send and recieve messages interprocess, using the Windows
    /// Messaging XDTransportMode. Applications may leverage this instance to register listeners on pseudo 'channels', and 
    /// receive messages broadcast using a concrete IXDBroadcast implementation on the same machine. Non-form based 
    /// application are not supported by this implementation.
    /// </summary>
    public sealed class XDListener : NativeWindow, IXDListener
    {
        // Flag as to whether dispose has been called
        private bool disposed = false;
        private NetworkRelayListener networkRelay;

        /// <summary>
        /// Creates a concrete IXDListener which uses the XDTransportMode.WindowsMessaging implementaion. This method
        /// is now deprecated and XDListener.CreateInstance(XDTransportMode.WindowsMessaging) should be used instead.
        /// </summary>
        [Obsolete("Use the static CreateListener method to create a particular implementation of IXDListener.")]
        public XDListener()
            :this(true)
        {
        }

        /// <summary>
        /// The non-obsolete constructor used internally for creating new instances of XDListener.
        /// </summary>
        /// <param name="nonObsolete"></param>
        internal XDListener(bool nonObsolete)
        {
            // create a top-level native window
            CreateParams p = new CreateParams();
            p.Width = 0;
            p.Height = 0;
            p.X = 0;
            p.Y = 0;
            p.Caption = string.Concat("TheCodeKing.Net.XDServices.",Guid.NewGuid().ToString());
            p.Parent = IntPtr.Zero;
            base.CreateHandle(p);

            this.networkRelay = new NetworkRelayListener(XDBroadcast.CreateBroadcast(XDTransportMode.WindowsMessaging), 
                                                            XDListener.CreateListener(XDTransportMode.MailSlot));
        }

        /// <summary>
        /// The delegate used for handling cross AppDomain communications.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args containing the DataGram data.</param>
        public delegate void XDMessageHandler(object sender, XDMessageEventArgs e);

        /// <summary>
        /// The event fired when messages are received.
        /// </summary>
        public event XDMessageHandler MessageReceived;

        /// <summary>
        /// Creates an concrete implementation of IXDListener to listen for messages using
        /// either a specific XDTransportMode.
        /// </summary>
        /// <param name="transport"></param>
        /// <returns></returns>
        public static IXDListener CreateListener(XDTransportMode transport)
        {
            switch (transport)
            {
                case XDTransportMode.IOStream:
                    return new XDIOStreamListener();
                case XDTransportMode.MailSlot:
                    return new TheCodeKing.Net.Messaging.Concrete.MailSlot.XDMailSlotListener();
                default:
                    return new XDListener(true);
            }
        }

        /// <summary>
        /// Registers the instance to recieve messages from a named channel.
        /// </summary>
        /// <param name="channelName">The channel name to listen on.</param>
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
            Native.SetProp(this.Handle, GetChannelKey(channelName), (int)this.Handle);
        }
        /// <summary>
        /// Unregisters the channel name with the instance, so that messages from this 
        /// channel will no longer be received.
        /// </summary>
        /// <param name="channelName">The channel name to stop listening for.</param>
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
            Native.RemoveProp(this.Handle, GetChannelKey(channelName));
        }
        /// <summary>
        /// The native window message filter used to catch our custom WM_COPYDATA
        /// messages containing cross AppDomain messages. All other messages are ignored.
        /// </summary>
        /// <param name="msg">A representation of the native Windows Message.</param>
        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg);
            if (msg.Msg == Native.WM_COPYDATA)
            {
                // we can free any unmanaged resources immediately in the dispose, managed channel and message 
                // data will still be retained in the object passed to the event
                using (DataGram dataGram = DataGram.FromPointer(msg.LParam))
                {
                    if (MessageReceived != null && dataGram.IsValid)
                    {
                        MessageReceived.Invoke(this, new XDMessageEventArgs(dataGram));
                    }
                }
            }
        }

        /// <summary>
        /// Gets a channel key string associated with the channel name. This is used as the 
        /// property name attached to listening windows in order to identify them as
        /// listeners. Using the key instead of user defined channel name avoids protential 
        /// property name clashes. 
        /// </summary>
        /// <param name="channelName">The channel name for which a channel key is required.</param>
        /// <returns>The string channel key.</returns>
        internal static string GetChannelKey(string channelName)
        {
            return string.Format("TheCodeKing.Net.XDServices.{0}", channelName);
        }

        /// <summary>
        /// Deconstructor, cleans unmanaged resources only
        /// </summary>
        ~XDListener()
        {
            Dispose(false);
        }

        /// <summary>
        /// Dispose implementation, which ensures the native window is destroyed
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Dispose implementation which ensures the native window is destroyed, and
        /// managed resources detached.
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
                        foreach (XDMessageHandler msg in del)
                        {
                            MessageReceived -= msg;
                        }
                    }
                    if (this.Handle != IntPtr.Zero)
                    {
                        this.DestroyHandle();
                        this.Dispose();
                    }
                }
            }
        }
    }
}
