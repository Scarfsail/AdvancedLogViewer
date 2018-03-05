using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Scarfsail.SoftwareUpdates.UI
{
    public partial class DownloadFileProgressDialog : Form
    {
        WebClient webClient;
        public DownloadFileProgressDialog(Form owner)
        {
            this.Owner = owner;
            InitializeComponent();
            this.webClient = new WebClient();
            this.webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
            this.webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
        }

        void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Download failed: " + e.Error.Message);
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                this.Close();
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        public bool DownloadFile(string urlFileName, string localFileName)
        {
            this.progressBar.Value = 0;
            this.webClient.DownloadFileAsync(new Uri(urlFileName), localFileName);
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            return this.ShowDialog() == DialogResult.OK;
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }

                    
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DownloadFileProgressDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false; 
            if (this.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                e.Cancel = true;
                if (MessageBox.Show("Do you want to cancel download?", "Cancel download?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (this.webClient != null)
                        this.webClient.CancelAsync();
                }
                if (webClient == null)
                    e.Cancel = false;
               
            }
            if (!e.Cancel && this.webClient != null)
            {
                this.webClient.Dispose();
                this.webClient = null;
            }
        }
    }
}
