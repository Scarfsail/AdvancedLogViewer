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
using System.Diagnostics;

namespace TheCodeKing.Net.Messaging.Concrete.WindowsMessaging
{
    /// <summary>
    /// The implementation of IXDBroadcast used to broadcast messages acorss appDomain and process boundaries
    /// using the XDTransportMode.WindowsMessaging implementation. Non-form based application are not supported.
    /// </summary>
    internal sealed class XDWindowsMessaging : IXDBroadcast
    {
        public void SendToChannel(string channelName, string message)
        {
            if (string.IsNullOrEmpty(channelName))
            {
                throw new ArgumentNullException(channelName, "The channel name must be defined");
            }
            if (message == null)
            {
                throw new ArgumentNullException(message, "The messsage packet cannot be null");
            }
            if (string.IsNullOrEmpty(channelName))
            {
                throw new ArgumentException("The channel name may not contain the ':' character.", "channelName");
            }
            // create a DataGram instance, and ensure memory is freed
            using (DataGram dataGram = new DataGram(channelName, message))
            {
                // Allocate the DataGram to a memory address contained in COPYDATASTRUCT
                Native.COPYDATASTRUCT dataStruct = dataGram.ToStruct();
                // Use a filter with the EnumWindows class to get a list of windows containing
                // a property name that matches the destination channel. These are the listening
                // applications.
                WindowEnumFilter filter = new WindowEnumFilter(XDListener.GetChannelKey(channelName));
                WindowsEnum winEnum = new WindowsEnum(filter.WindowFilterHandler);
                foreach (IntPtr hWnd in winEnum.Enumerate())
                {
                    IntPtr outPtr = IntPtr.Zero;
                    // For each listening window, send the message data. Return if hang or unresponsive within 1 sec.
                    Native.SendMessageTimeout(hWnd, Native.WM_COPYDATA, IntPtr.Zero, ref dataStruct, Native.SendMessageTimeoutFlags.SMTO_ABORTIFHUNG, 1000, out outPtr);
                }
            }
        }
    }
}
