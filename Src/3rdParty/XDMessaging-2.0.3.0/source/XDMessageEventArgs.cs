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

namespace TheCodeKing.Net.Messaging
{
    /// <summary>
    /// The event args used by the message handler. This enables DataGram data 
    /// to be passed to the handler.
    /// </summary>
    public sealed class XDMessageEventArgs : EventArgs
    {
        /// <summary>
        /// Stores the DataGram containing message and channel data.
        /// </summary>
        private DataGram dataGram;
        /// <summary>
        /// Gets the DataGram associated with this instance.
        /// </summary>
        public DataGram DataGram
        {
            get
            {
                return dataGram;
            }
        }
        /// <summary>
        /// Constructor used to create a new instance from a DataGram struct.
        /// </summary>
        /// <param name="dataGram">The DataGram instance.</param>
        internal XDMessageEventArgs(DataGram dataGram)
        {
            this.dataGram = dataGram;
        }
    }
}
