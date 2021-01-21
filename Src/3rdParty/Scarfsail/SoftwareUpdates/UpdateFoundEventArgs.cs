using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Scarfsail.SoftwareUpdates.UI;
using System.IO;
using System.Diagnostics;


namespace Scarfsail.SoftwareUpdates
{
    public class UpdateFoundEventArgs : EventArgs
    {
        private string tmpPath;

        private UpdateDefinitionXml updateDefinition;

        public Version VersionFound { get { return this.updateDefinition.LatestVersion.Version; } }
        public Version CurrentVersion { get; private set; }


        internal UpdateFoundEventArgs(UpdateDefinitionXml updateDefinitionXml, Version currentVersion, string tmpPath)
        {
            this.updateDefinition = updateDefinitionXml;
            this.CurrentVersion = currentVersion;
            this.tmpPath = tmpPath;
        }



        public bool ShowUiAndAskForUpdateDownload(Form owner, string applicationName, string appPath, UpdateType updateType)
        {
            using (NewVersionFoundDialog dlg = new NewVersionFoundDialog(owner, updateDefinition, this.CurrentVersion, tmpPath, applicationName, updateType))
            {
                if (dlg.ShowDialog() != DialogResult.Yes)
                    return false;
            }

            using (DownloadFileProgressDialog dlg = new DownloadFileProgressDialog(owner))
            {
                string urlWithUpdate;
                switch (updateType)
                {
                    case UpdateType.MSI:
                        urlWithUpdate = updateDefinition.LatestVersion.UrlWithMsiUpdate;
                        break;
                    case UpdateType.Portable:
                        urlWithUpdate = updateDefinition.LatestVersion.UrlWithPortableUpdate;
                        break;
                    default:
                        throw new InvalidOperationException(String.Format("Update type: {0} is not supported.", updateType));
                }

                string localFileName = Path.Combine(tmpPath, Path.GetFileName(urlWithUpdate));
                if (File.Exists(localFileName))
                    File.Delete(localFileName);

                if (dlg.DownloadFile(urlWithUpdate, localFileName))
                {
                    switch (updateType)
                    {
                        case UpdateType.MSI: RunMsiInstaller(localFileName); break;
                        case UpdateType.Portable: UpdatePortable(localFileName, appPath); break;
                        default: throw new NotImplementedException("Update type: " + updateType + " is not supported.");
                    }
                    return true;
                }
                else
                    return false;
            }
        }

        private void RunMsiInstaller(string pathToMsi)
        {
            /*Process process = new Process();
            process.StartInfo.FileName = pathToMsi;
            process.StartInfo.Verb = "Open";

            process.Start();*/
            Process.Start("cmd.exe", "/c "+pathToMsi);
        }

        private void UpdatePortable(string portableUpdatePath, string updatedAppPath)
        {
            Process process = new Process();
            process.StartInfo.FileName = portableUpdatePath;
            process.StartInfo.Arguments = "\"" + updatedAppPath + "\"";

            process.Start();
        }
    }
}
