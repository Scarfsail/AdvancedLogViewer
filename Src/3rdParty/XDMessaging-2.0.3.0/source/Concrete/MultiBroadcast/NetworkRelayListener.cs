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
using TheCodeKing.Net.Messaging.Concrete.MultiBroadcast;

namespace TheCodeKing.Net.Messaging.Concrete
{
    /// <summary>
    /// The implementation used to listen for and relay network messages for all
    /// instances of IXDListener.
    /// </summary>
    internal sealed class NetworkRelayListener : IDisposable
    {
        /// <summary>
        /// The instance used to broadcast network messages on the local machine.
        /// </summary>
        private IXDBroadcast nativeBroadcast;
        /// <summary>
        /// The instance of MailSlot used to receive network messages from other machines.
        /// </summary>
        private IXDListener propagateListener;
        /// <summary>
        /// The base Network propagation channel name.
        /// </summary>
        private const string NetworkPropagateChannel = "System.PropagateBroadcast";

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="nativeBroadcast"></param>
        /// <param name="propagateListener"></param>
        internal NetworkRelayListener(IXDBroadcast nativeBroadcast, IXDListener propagateListener)
        {
            if (nativeBroadcast == null)
            {
                throw new ArgumentNullException("nativeBroadcast");
            }
            if (propagateListener == null)
            {
                throw new ArgumentNullException("propagateListener");
            }
            this.nativeBroadcast = nativeBroadcast;
            this.propagateListener = propagateListener;
            // listen on the network channel for this mode
            this.propagateListener.RegisterChannel(NetworkRelayBroadcast.GetPropagateNetworkMailSlotName(nativeBroadcast));
            this.propagateListener.MessageReceived += new XDListener.XDMessageHandler(OnMessageReceived);
        }

        /// <summary>
        /// Handles messages received from other machines on the network and dispatches them locally.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMessageReceived(object sender, XDMessageEventArgs e)
        {
            // network message is of format machine:channel:message
            if (e.DataGram.IsValid)
            {
                using (DataGram machineInfo = DataGram.ExpandFromRaw(e.DataGram.Message))
                {
                    if (machineInfo.IsValid)
                    {
                        // don't relay if the message was broadcast on this machine
                        if (machineInfo.Channel != Environment.MachineName)
                        {
                            using (DataGram dataGram = DataGram.ExpandFromRaw(machineInfo.Message))
                            {
                                if (dataGram.IsValid)
                                {
                                    // propagate the message on this machine using the same mode as the sender
                                    nativeBroadcast.SendToChannel(dataGram.Channel, dataGram.Message);
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Implementation of IDisposable used to clean up the listener instance.
        /// </summary>
        public void Dispose()
        {
            if (propagateListener != null)
            {
                propagateListener.Dispose();
                propagateListener = null;
            }
        }

    }
}
