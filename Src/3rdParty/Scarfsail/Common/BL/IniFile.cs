using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Scarfsail.Common.BL
{
    public class IniFile
    {
        public IniFile(string iniPath)
        {
            this.IniPath = iniPath;
        }

        public void WriteValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, this.IniPath);
        }

        public string ReadValue(string section, string key)
        {
            return this.ReadValue(section, key, String.Empty);
        }

        public string ReadValue(string section, string key, string defaultValue)
        {
            StringBuilder temp = new StringBuilder(1024);
            int i = GetPrivateProfileString(section, key, defaultValue, temp, 1024, this.IniPath);
            return temp.ToString();
        }

        public string IniPath { get; private set; }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
          string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
          string key, string def, StringBuilder retVal,
          int size, string filePath);
    }

}
