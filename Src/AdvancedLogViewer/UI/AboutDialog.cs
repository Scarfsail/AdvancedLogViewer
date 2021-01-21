using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using AdvancedLogViewer.Common;
using Scarfsail.Common.Utils;
using System.Diagnostics;

namespace AdvancedLogViewer.UI
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
            Assembly assembly = Assembly.GetExecutingAssembly();
            this.productIconPicture.Image = Icon.ExtractAssociatedIcon(Process.GetCurrentProcess().MainModule.FileName).ToBitmap();
            this.productNameLabel.Text = this.ProductName;
            this.productVersionLabel.Text = this.ProductVersion;
            this.productAuthorLabel.Text = this.CompanyName;
            this.usersConfigurationLocationLabel.Text = Globals.UserDataDir;
        }

        private T GetAssemblyAttribute<T>(Assembly assembly)            
        {
            object[] attrs = assembly.GetCustomAttributes(typeof(T), false);
            if (attrs.Length == 0)
                return default(T);

            return (T)attrs[0];
        }

        private void webLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WinFormHelper.GotoUrl("https://github.com/Scarfsail/AdvancedLogViewer");
        }

        private void forumLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WinFormHelper.GotoUrl("https://github.com/Scarfsail/AdvancedLogViewer/issues");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WinFormHelper.GotoUrl("http://salplachta.net/AdvancedLogViewer/Donate.aspx");
        }
    }
}
