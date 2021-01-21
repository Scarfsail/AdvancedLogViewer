using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using Microsoft.Win32;
using System.IO;
using Scarfsail.Logging;

namespace AdvancedLogViewer.BL
{
    public class TotalCmdIntegration
    {
        private static readonly Log log = new();
        public TotalCmdIntegration()
        {
            string iniLocation = this.GetTotalCmdMainIniFileLocation();
            if (!String.IsNullOrEmpty(iniLocation))
                this.mainIniFile = new IniFile(iniLocation);
        }

        public bool IsInstalled
        {
            get
            {
                return this.mainIniFile != null;
            }
        }

        public bool IsLogViewerIntegrated
        {
            get
            {
                if (this.IsInstalled)
                {
                    string viewerPath = this.mainIniFile.ReadValue("Configuration", "Viewer");
                    return viewerPath.Equals(this.LogViewerExePath, StringComparison.OrdinalIgnoreCase);
                }

                return false;
            }
        }

        public void IntegrateLogViewer()
        {
            if (!this.IsInstalled || this.IsLogViewerIntegrated)
                return;
            string originalValue = this.mainIniFile.ReadValue("Configuration", "Viewer");
            if (!String.IsNullOrEmpty(originalValue))
                this.mainIniFile.WriteValue("Configuration", "ViewerBeforeALV", originalValue);
            this.mainIniFile.WriteValue("Configuration", "Viewer", this.LogViewerExePath);
        }

        public void UnIntegrateLogViewer()
        {
            if (!this.IsInstalled || !this.IsLogViewerIntegrated)
                return;

            string originalValue = this.mainIniFile.ReadValue("Configuration", "ViewerBeforeALV");
            this.mainIniFile.WriteValue("Configuration", "Viewer", originalValue);
        }

        private string GetTotalCmdMainIniFileLocation()
        {
            //Try CurrentUser registry
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Ghisler\Total Commander"))
                {
                    if (key != null)
                    {
                        object obj = key.GetValue("IniFileName");
                        if (obj != null)
                            return Environment.ExpandEnvironmentVariables(obj.ToString());
                    }
                }

                //Try LocalMachine registry
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Ghisler\Total Commander"))
                {
                    if (key != null)
                    {
                        object obj = key.GetValue("IniFileName");
                        if (obj != null)
                            return Environment.ExpandEnvironmentVariables(obj.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error while getting info about TotalCmd from registry: " + ex.Message);
            }
            //Try Current user's app data folder
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GHISLER", "wincmd.ini");
            if (File.Exists(path))
                return path;

            //Try Windows folder
            path = Path.Combine(Environment.ExpandEnvironmentVariables("%WinDir%"), "wincmd.ini");
            if (File.Exists(path))
                return path;

            return String.Empty;
        }

        private string LogViewerExePath
        {
            get
            {
                return System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            }
        }

        private IniFile mainIniFile = null;

    }
}
