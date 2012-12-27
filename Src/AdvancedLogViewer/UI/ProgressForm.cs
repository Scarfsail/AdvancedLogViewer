using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvancedLogViewer.UI
{
    public partial class ProgressForm : Form
    {
        public ProgressForm(MethodInvoker callAfterShow, MethodInvoker callWhenCancel)
        {
            InitializeComponent();
            this.progressBar.Maximum = 100;
            this.statusText.Text = String.Empty;
            this.callAfterShow = callAfterShow;
            this.callWhenCancel = callWhenCancel;
        }

        public void UpdateProgress(int percentComplete, string statusText)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => this.UpdateProgress(percentComplete, statusText)));
            }
            else
            {
                this.progressBar.Value = percentComplete;
                this.statusText.Text = statusText;
            }
        }

        public void Complete(bool successfuly)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => this.Complete(successfuly)));
            }
            else
            {
                this.DialogResult = successfuly ? DialogResult.OK : DialogResult.Abort;
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.callWhenCancel();
        }

        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = this.DialogResult == DialogResult.None;
        }

        private MethodInvoker callAfterShow;
        private MethodInvoker callWhenCancel;

        private void ProgressForm_Shown(object sender, EventArgs e)
        {
            this.callAfterShow();
        }

    }
}
