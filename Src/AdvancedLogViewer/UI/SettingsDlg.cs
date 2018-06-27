using System;
using System.Windows.Forms;
using AdvancedLogViewer.BL.Settings;

namespace AdvancedLogViewer.UI
{
    public partial class SettingsDlg : Form
    {
        public SettingsDlg(AlvSettings alvSettings, bool firstTimeShown)
        {
            InitializeComponent();

            this.settingsControl.Init(alvSettings, firstTimeShown);
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            this.settingsControl.Save();
        }
    }
}
