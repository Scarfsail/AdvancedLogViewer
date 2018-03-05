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

namespace TheCodeKing.Net.Messaging.Concrete.MailSlot
{
    /// <summary>
    /// A class used for keeping a reference to the current thread 
    /// and read file handle.
    /// </summary>
    internal sealed class MailSlotThreadInfo
    {
        /// <summary>
        /// The file handle used by the current handle.
        /// </summary>
        public IntPtr FileHandle
        {
            get;
            set;
        }
        /// <summary>
        /// The current thread.
        /// </summary>
        public Thread Thread
        {
            get;
            set;
        }
        /// <summary>
        /// The channel name for this thread.
        /// </summary>
        public string ChannelName
        {
            get;
            private set;
        }

        /// <summary>
        /// Indicates whether the current file handle is valid.
        /// </summary>
        public bool HasValidFileHandle
        {
            get
            {
                return ((int)FileHandle) > 0;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="thread"></param>
        public MailSlotThreadInfo(string channelName, Thread thread)
        {
            this.Thread = thread;
            this.FileHandle = IntPtr.Zero;
            this.ChannelName = channelName;
        }

    }
}
