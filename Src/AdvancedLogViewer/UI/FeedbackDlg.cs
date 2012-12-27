using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvancedLogViewer.BL;
using Scarfsail.Common.UI;
using Scarfsail.Common.UI.Controls;
using AdvancedLogViewer.BL.Settings;
using System.Diagnostics;
using AdvancedLogViewer.BL.FindText;
using AdvancedLogViewer.BL.LogBrowser;
using Scarfsail.Common.Utils;

namespace AdvancedLogViewer.UI
{
    public partial class FeedbackDlg : Form
    {
        public FeedbackDlg()
        {
            InitializeComponent();
        }

        private void ForumLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WinFormHelper.GotoUrl("http://forum.salplachta.net");
        }
    }
}
