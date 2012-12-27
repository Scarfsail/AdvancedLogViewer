using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvancedLogViewer.BL;

namespace AdvancedLogViewer.UI
{
    public partial class MergeLogParts : Form
    {
        public MergeLogParts()
        {
            InitializeComponent();
        }

        public string MergeLogs(List<string> fileNames, IWin32Window owner)
        {
            string mergedFileName = String.Empty;
            foreach (string fileName in fileNames)
            {
                this.fileNames.Items.Add(fileName, true);
            }

            this.mergedFileNameTextBox.Text = this.GetMergedFileName();

            if (this.ShowDialog(owner) == DialogResult.Yes)
                mergedFileName = this.mergedFileNameTextBox.Text;

            return mergedFileName;
        }

        private string GetMergedFileName()
        {
            string result = this.fileNames.Items[0].ToString();
            result += ".Merged";
            return result;
        }

        private bool MergeIt()
        {
            MergeFiles mergeFiles = new MergeFiles(this.fileNames.CheckedItems.Cast<string>().Reverse().ToList(), this.mergedFileNameTextBox.Text);

            using (ProgressForm progress = new ProgressForm(mergeFiles.MergeAsync, mergeFiles.Cancel))
            {
                progress.Text = "Merging log files";

                mergeFiles.MergeProgress += new MergeProgressEventHandler((object sender1, MergeProgressEventArgs e1) => 
                    progress.UpdateProgress(e1.PercentComplete, "Current file:" + e1.CurrentFileName));


                mergeFiles.MergeComplete += new MergeCompleteEventHandler((object sender1, MergeCompleteEventArgs e1) => 
                    progress.Complete(e1.Successfuly));

                if (progress.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Selected log files are merged into one file.", "Merging finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Merging process was canceled.", "Merging canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void mergeAndOpenButton_Click(object sender, EventArgs e)
        {
            if (!this.MergeIt())
                this.DialogResult = DialogResult.Abort;
        }
    }
}
