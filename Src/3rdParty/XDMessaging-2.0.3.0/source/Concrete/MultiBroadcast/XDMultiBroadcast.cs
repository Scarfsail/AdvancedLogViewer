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

namespace TheCodeKing.Net.Messaging.Concrete.MultiBroadcast
{
    /// <summary>
    /// An implementation of IXDBroadcast that encapsulates multiple broadcast instances
    /// so that messages can be send using multiple modes.
    /// </summary>
    internal sealed class XDMultiBroadcast : IXDBroadcast
    {
        /// <summary>
        /// The list of IXDBraodcast instances used to broadcast from this instance.
        /// </summary>
        private IEnumerable<IXDBroadcast> broadcastInstances;

        /// <summary>
        /// The constructor which takes an IEnumerable list of IXDBroadcast instances.
        /// </summary>
        /// <param name="broadcastInstances"></param>
        internal XDMultiBroadcast(IEnumerable<IXDBroadcast> broadcastInstances)
        {
            this.broadcastInstances = broadcastInstances;
        }
        /// <summary>
        /// The implementation of IXDBroadcast used to send messages in 
        /// multiple modes.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="message"></param>
        public void SendToChannel(string channel, string message)
        {
            foreach (IXDBroadcast broadcast in broadcastInstances)
            {
                broadcast.SendToChannel(channel, message);
            }
        }
    }
}
