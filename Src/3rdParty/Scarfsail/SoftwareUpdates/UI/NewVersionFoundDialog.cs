using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Scarfsail.Common.UI;

namespace Scarfsail.SoftwareUpdates.UI
{
    public partial class NewVersionFoundDialog : Form
    {
        private UpdateDefinitionXml definitionXml;
        private Version currentVersion;
        private string tmpPath;
        string historyFileName = null;

        public NewVersionFoundDialog(Form owner, UpdateDefinitionXml updateDefinitionXml, Version currentVersion, string tmpPath, string applicationName, UpdateType updateType)
        {
            this.Owner = owner;
            InitializeComponent();

            this.definitionXml = updateDefinitionXml;
            this.currentVersion = currentVersion;
            this.tmpPath = tmpPath;

            this.newVersionReleasedLabel.Text = String.Format(this.newVersionReleasedLabel.Text, applicationName);
            switch (updateType)
            {
                case UpdateType.MSI:
                    this.updateTypeLabel.Text = "You have installed ALV. Your application will be updated by newer installation.";
                    break;
                case UpdateType.Portable:
                    this.updateTypeLabel.Text = "You have portable ALV. Only binaries will be updated without any changes in the system.";
                    break;
                default:
                    throw new InvalidOperationException(String.Format("Update type: {0} is not supported.", updateType));
            }
            
            this.installedVersionLabel.Text = currentVersion.ToString();
            this.newVersionLabel.Text = definitionXml.LatestVersion.Version.ToString();
        }

        private void whatsNewLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.historyFileName))
            {
                this.historyFileName = Path.Combine(tmpPath, "AlvHistory_" + definitionXml.LatestVersion.Version.ToString() + ".xml");
                if (File.Exists(this.historyFileName))
                    File.Delete(this.historyFileName);

                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(definitionXml.LatestVersion.UrlWithHistoryXml, this.historyFileName);
                }
            }
            
            using (ApplicationHistoryDlg dlg = new ApplicationHistoryDlg(this.historyFileName, this.currentVersion))
            {
                dlg.ShowDialog();
            }
        }
    }
}
