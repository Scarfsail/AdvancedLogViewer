using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Scarfsail.Common.BL;

namespace Scarfsail.Common.UI
{
    public partial class ApplicationHistoryDlg : Form
    {
        public ApplicationHistoryDlg(string pathToHistoryXml, Version sinceVersion)
        {
            InitializeComponent();
            string html = ApplicationHistoryXml2Html.GetHtmlFromXml(pathToHistoryXml, sinceVersion);
            this.webBrowser.DocumentText = html;
            if (sinceVersion != null)
                this.Text = "List of changes against version " + sinceVersion.ToString();
        }

    }
}
