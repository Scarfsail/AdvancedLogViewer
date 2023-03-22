using System;
using System.Security;
using System.Collections;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Text;

// The Org.Mentalis.Utilities namespace implements several useful utilities that are missing from the standard .NET framework.
namespace Scarfsail.Common.BL
{
    public static class FileAssociation
    {
        // Associate file extension with progID, description, icon and application
        public static void Associate(string extension,
               string progID, string description, string icon, int iconIndex, string application)
        {
            Registry.ClassesRoot.CreateSubKey(extension).SetValue("", progID);
            if (progID != null && progID.Length > 0)
            {
                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(progID))
                {
                    if (description != null)
                        key.SetValue("", description);
                    if (icon != null)
                        key.CreateSubKey("DefaultIcon").SetValue("", ToShortPathName(icon) + "," + iconIndex);
                    if (application != null)
                        key.CreateSubKey(@"Shell\Open\Command").SetValue("",
                                    ToShortPathName(application) + " \"%1\"");
                }
            }
            // Tell explorer the file association has been changed
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }

        public static void Remove(string extension, string progID)
        {
            Registry.ClassesRoot.DeleteSubKeyTree(extension);
            Registry.ClassesRoot.DeleteSubKeyTree(progID);
            
            // Tell explorer the file association has been changed
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }

        // Return true if extension already associated in registry
        public static bool IsAssociated(string extension, string progID)
        {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(extension, false);
            if (key == null)
                return false;

            return key.GetValue("")?.Equals(progID) ?? false;
        }

        [DllImport("Kernel32.dll")]
        private static extern uint GetShortPathName(string lpszLongPath,
            [Out] StringBuilder lpszShortPath, uint cchBuffer);

        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        // Return short path format of a file name
        private static string ToShortPathName(string longName)
        {
            StringBuilder s = new StringBuilder(1000);
            uint iSize = (uint)s.Capacity;
            uint iRet = GetShortPathName(longName, s, iSize);
            return s.ToString();
        }
    }
}
