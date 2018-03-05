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
using System.Runtime.InteropServices;
using System.IO;

namespace TheCodeKing.Net.Messaging.Concrete.WindowsMessaging
{
    /// <summary>
    /// The native Win32 APIs used by the library.
    /// </summary>
    internal static class Native
    {
        /// <summary>
        /// The WM_COPYDATA constant.
        /// </summary>
        public const uint WM_COPYDATA = 0x4A;
        /// <summary>
        /// The struct used to marshal data between applications using
        /// the windows messaging API.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }
        /// <summary>
        /// Specifies how to send the message. This parameter can be one or
        /// more of the following values.
        /// </summary>
        [Flags]
        public enum SendMessageTimeoutFlags : uint
        {
            /// <summary>
            /// The calling thread is not prevented from processing other
            /// requests while waiting for the function to return.
            /// </summary>
            SMTO_NORMAL = 0x0000,
            /// <summary>
            /// Prevents the calling thread from processing any other
            /// requests until the function returns.
            /// </summary>
            SMTO_BLOCK = 0x0001,
            /// <summary>
            /// Returns without waiting for the time-out period to elapse 
            /// if the receiving thread appears to not respond or "hangs."
            /// </summary>
            SMTO_ABORTIFHUNG = 0x0002,
            /// <summary>
            /// Microsoft Windows 2000/Windows XP: Do not enforce the time-out 
            /// period as long as the receiving thread is processing messages.
            /// </summary>
            SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
        }
        /// <summary>
        /// Sends a native windows message to a specified window.
        /// </summary>
        /// <param name="hwnd">The window to which the message should be sent.</param>
        /// <param name="wMsg">The native windows message type.</param>
        /// <param name="wParam">A pointer to the wPAram data.</param>
        /// <param name="lParam">The struct containing lParam data</param>
        /// <param name="flags">The timeout flags.</param>
        /// <param name="timeout">The timeout value in miliseconds.</param>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static int SendMessageTimeout(
                    IntPtr hwnd,
                    uint wMsg,
                    IntPtr wParam,
                    ref COPYDATASTRUCT lParam,
                    SendMessageTimeoutFlags flags,
                    uint timeout,
                    out IntPtr result);
        
        /// <summary>
        /// A delegate used by the EnumChildWindows windows API to enumerate windows.
        /// </summary>
        /// <param name="hwnd">A pointer to a window that was found.</param>
        /// <param name="lParam">The lParam passed by the EnumChildWindows API.</param>
        /// <returns></returns>
        public delegate int EnumWindowsProc(IntPtr hwnd, IntPtr lParam);
        /// <summary>
        /// The API used to enumerate topvlevel windows.
        /// </summary>
        /// <param name="lpEnumFunc">The delegate called when a window is located.</param>
        /// <param name="lParam">The lParam passed to the deleage.</param>
        /// <returns></returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
        /// <summary>
        /// Gets a named window property for a given window address. 
        /// This returns zero if not found.
        /// </summary>
        /// <param name="hwnd">The window containing the property.</param>
        /// <param name="lpString">The property name to lookup.</param>
        /// <returns>The property data, or 0 if not found.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static int GetProp(IntPtr hwnd, string lpString);
        /// <summary>
        /// Sets a window proerty value.
        /// </summary>
        /// <param name="hwnd">The window on which to attach the property.</param>
        /// <param name="lpString">The property name.</param>
        /// <param name="hData">The property value.</param>
        /// <returns>A value indicating whether the function succeeded.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static int SetProp(IntPtr hwnd, string lpString, int hData);
        /// <summary>
        /// Removes a named property from a given window.
        /// </summary>
        /// <param name="hwnd">The window whose property should be removed.</param>
        /// <param name="lpString">The property name.</param>
        /// <returns>A value indicating whether the function succeeded.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static int RemoveProp(IntPtr hwnd, string lpString);
    }
}
