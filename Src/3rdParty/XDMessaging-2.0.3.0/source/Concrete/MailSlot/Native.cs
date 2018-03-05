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
using System.Threading;

namespace TheCodeKing.Net.Messaging.Concrete.MailSlot
{
    /// <summary>
    /// The native Win32 APIs used by the library.
    /// </summary>
    internal static class Native
    {
        /// <summary>
        /// Wait forever until mail arrives.
        /// </summary>
        public const int MAILSLOT_WAIT_FOREVER = -1;
        /// <summary>
        /// The read handle is invalid.
        /// </summary>
        public const int ERROR_INVALID_HANDLE = 6;
        /// <summary>
        /// The read buffer is not large enough for the current message.
        /// </summary>
        public const int ERROR_INSUFFICIENT_BUFFER = 122;
        /// <summary>
        /// Mailslot has closed, there is no more data to read.
        /// </summary>
        public const int ERROR_HANDLE_EOF = 38;

        /// <summary>
        /// The Win32 API for creating/openning a MailSlot for IPC communication.
        /// </summary>
        /// <param name="lpName">The MailSlot path.</param>
        /// <param name="nMaxMessageSize">The maximum size of the message.</param>
        /// <param name="lReadTimeout">The time a read operation can wait for a message to be written
        /// to the mailslot before a time-out occurs, in milliseconds.</param>
        /// <param name="lpSecurityAttributes">A pointer to a SECURITY_ATTRIBUTES structure.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateMailslot(string lpName, uint nMaxMessageSize,
           int lReadTimeout, IntPtr lpSecurityAttributes);

        /// <summary>
        /// The Win32 API for creating a handle to a MailSlot.
        /// </summary>
        /// <param name="fileName">The MailSlot path.</param>
        /// <param name="fileAccess">The requested access to the MailSlot.</param>
        /// <param name="fileShare">The requested sharing mode of the MailSlot.</param>
        /// <param name="securityAttributes">A pointer to a SECURITY_ATTRIBUTES structure</param>
        /// <param name="creationDisposition">An action to take on a file or device that exists or does not exist.</param>
        /// <param name="flags">The file or device attributes and flags.</param>
        /// <param name="template">A valid handle to a template file with the GENERIC_READ access right.</param>
        /// <returns></returns>
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFile(
            string fileName,
            [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess,
            [MarshalAs(UnmanagedType.U4)] FileShare fileShare,
            int securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            int flags,
            IntPtr template);

        /// <summary>
        /// The Win32 API used for reading data froma MailSlot.
        /// </summary>
        /// <param name="hFile">The MailSlot path.</param>
        /// <param name="lpBuffer">A buffer that receives the data read from the MailSlot.</param>
        /// <param name="nNumberOfBytesToRead">Indicates the number of bytes to read.</param>
        /// <param name="lpNumberOfBytesRead">Indicates the number of bytes that were read.</param>
        /// <param name="lpOverlapped">A pointer to an OVERLAPPED structure if openned with FILE_FLAG_OVERLAPPED</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadFile(
            IntPtr hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToRead,
            out uint lpNumberOfBytesRead,
            IntPtr lpOverlapped);

        /// <summary>
        /// TheWin32 API used for writting to the MailSlot.
        /// </summary>
        /// <param name="hFile">The MailSlot path.</param>
        /// <param name="lpBuffer">The buffer to write to the MailSlot.</param>
        /// <param name="nNumberOfBytesToWrite">The number of bytes to write from the buffer.</param>
        /// <param name="lpNumberOfBytesWritten">The number of bytes that were written.</param>
        /// <param name="lpOverlapped">A pointer to an OVERLAPPED structure if openned with FILE_FLAG_OVERLAPPED</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteFile(
                IntPtr hFile,
                byte[] lpBuffer,
                uint nNumberOfBytesToWrite,
                [In] ref uint lpNumberOfBytesWritten,
                IntPtr lpOverlapped);

        /// <summary>
        /// The Win32 used for checking a MailSlot for new messages.
        /// </summary>
        /// <param name="hMailslot">The MailSlot path.</param>
        /// <param name="lpMaxMessageSize">The maximum number of messages.</param>
        /// <param name="lpNextSize">The next of the next message.</param>
        /// <param name="lpMessageCount">The number of unread messages.</param>
        /// <param name="lpReadTimeout">The read time out if no message is found.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetMailslotInfo(IntPtr hMailslot, ref int lpMaxMessageSize,
           ref int lpNextSize, ref int lpMessageCount, ref int lpReadTimeout);

        /// <summary>
        /// The Win32 API used to close the MailSlot handle.
        /// </summary>
        /// <param name="handle">The MailSLot handle to be closed.</param>
        /// <returns></returns>
        [DllImport("kernel32", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr handle);
    }

}
