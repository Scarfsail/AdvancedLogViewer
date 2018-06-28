using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows;
using AdvancedLogViewer.BL;
using AdvancedLogViewer.BL.LogBrowser;
using AdvancedLogViewer.BL.Settings;
using Scarfsail.Common.BL;
using Scarfsail.Logging;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SystemFonts = System.Drawing.SystemFonts;
using UserControl = System.Windows.Controls.UserControl;

namespace AdvancedLogViewer.WPF
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        private static readonly Log log = new Log();
        private AlvSettings settings;
        private TotalCmdIntegration totalCmd;
        private LogBrowserSettings logBrowser;
        private bool alvWasAssociated;

        public SettingsControl()
        {
            InitializeComponent();
        }

        public void Init(AlvSettings alvSettings, bool firstTimeShown)
        {
            log.Debug("Creating SettingsControl form");

            this.settings = alvSettings;
            this.totalCmd = new TotalCmdIntegration();
            this.logBrowser = LogBrowserSettings.Instance;

            //Load values from filter entry
            this.ShowMarkersCheckBox.IsChecked = this.settings.MainFormUI.ShowMarkers;
            this.ExitAppOnEscCheckBox.IsChecked = this.settings.MainFormUI.ExitAppOnESC;
            this.AutoScrollCheckBox.IsChecked = this.settings.MainFormUI.AutoScrollWhenAutoRefresh;
            this.AutoScrollShowTwoItemsCheckBox.IsChecked = this.settings.MainFormUI.AutoScrollShowTwoItems;
            this.AutoRefreshPeriodEdit.Value = this.settings.MainFormUI.AutoRefreshPeriod;
            this.AddOnlyBaseNameInRecentListCheckBox.IsChecked = this.settings.MainFormUI.AddOnlyBaseNameInRecentList;
            this.RememberFiltersEnabledCheckBox.IsChecked = this.settings.MainFormUI.RememberFiltersEnabled;
            this.TrimClassColumnFromLeftCheckBox.IsChecked = this.settings.MainFormUI.TrimClassColumnFromLeft;
            this.ShowLogIconsCheckBox.IsChecked = this.settings.MainFormUI.ShowLogIcons;
            this.MessageWordWrapCheckBox.IsChecked = this.settings.MainFormUI.MessageWordWrap;
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                FontComboBox.Items.Add(font.Name);
            }

            FontComboBox.SelectedValue = this.settings.MainFormUI.MessageFontFamily;
            FontSize.Value = this.settings.MainFormUI.MessageFontSize;

            this.ExtDiffPathEdit.Text = settings.TextDiff.DiffPath;
            this.ExtDiffParametersEdit.Text = settings.TextDiff.DiffParameters;

            this.ExtTextEditPathEdit.Text = settings.TextEditor.TextEditorPath;
            this.ExtTextEditParametersEdit.Text = settings.TextEditor.TextEditorParameteres;

            this.TopLevelFolders.Text = this.logBrowser.TopLevelFolders;
            this.OpenAndExitOnDoubleClickCheckBox.IsChecked = this.logBrowser.ShowAndCloseOnDoubleClick;

            this.IntegrateWithTotalCmdCheckBox.IsChecked = this.totalCmd.IsLogViewerIntegrated;
            if (this.totalCmd.IsInstalled)
            {
                this.IntegrateWithTotalCmdCheckBox.IsEnabled = true;
                this.TotalCmdStatusLabel.Content = "Total Commander is installed on this computer.";
            }
            else
            {
                this.IntegrateWithTotalCmdCheckBox.IsEnabled = false;
                this.TotalCmdStatusLabel.Content = "Total Commander wasn't found on this computer.";
            }

            try
            {
                alvWasAssociated = FileAssociation.IsAssociated(".log", "AdvancedLogViewer");
                AssociateWithAlvCheckBox.IsChecked = alvWasAssociated || firstTimeShown;
            }
            catch
            {
                MessageBox.Show("Can't get information about associated application with LOG extension. Run ALV as Administrator.", "Administration rights required", MessageBoxButton.OK, MessageBoxImage.Error);
                AssociateWithAlvCheckBox.IsEnabled = false;
            }
            this.AutomaticUpdateEnabledCheckBox.IsChecked = this.settings.AutomaticUpdates.EnableAutomaticCheck;
            this.AutomaticUpdateCheckPeriodEdit.Value = this.settings.AutomaticUpdates.CheckInterval;

            log.Debug("SettingsDlg form created");
        }

        private void extDiffBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = this.ExtDiffPathEdit.Text;
            dlg.Title = "Select external diff tool executable";
            if (dlg.ShowDialog() == true)
            {
                this.ExtDiffPathEdit.Text = dlg.FileName;
            }
        }

        private void extTextEditBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = this.ExtTextEditPathEdit.Text;
            dlg.Title = "Select external text editor executable";
            if (dlg.ShowDialog() == true)
            {
                this.ExtTextEditPathEdit.Text = dlg.FileName;
            }
        }

        public void Save()
        {
            log.Debug("Saving data...");

            //Save values from UI
            this.settings.MainFormUI.ShowMarkers = this.ShowMarkersCheckBox.IsChecked.GetValueOrDefault();
            this.settings.MainFormUI.ExitAppOnESC = this.ExitAppOnEscCheckBox.IsChecked.GetValueOrDefault();
            this.settings.MainFormUI.AutoScrollWhenAutoRefresh = this.AutoScrollCheckBox.IsChecked.GetValueOrDefault();
            this.settings.MainFormUI.AutoScrollShowTwoItems = this.AutoScrollShowTwoItemsCheckBox.IsChecked.GetValueOrDefault();
            this.settings.MainFormUI.AutoRefreshPeriod = Convert.ToInt32(this.AutoRefreshPeriodEdit.Value);
            this.settings.MainFormUI.AddOnlyBaseNameInRecentList = this.AddOnlyBaseNameInRecentListCheckBox.IsChecked.GetValueOrDefault();
            this.settings.MainFormUI.RememberFiltersEnabled = this.RememberFiltersEnabledCheckBox.IsChecked.GetValueOrDefault();
            this.settings.MainFormUI.TrimClassColumnFromLeft = this.TrimClassColumnFromLeftCheckBox.IsChecked.GetValueOrDefault();
            this.settings.MainFormUI.ShowLogIcons = this.ShowLogIconsCheckBox.IsChecked.GetValueOrDefault();
            this.settings.MainFormUI.MessageWordWrap = this.MessageWordWrapCheckBox.IsChecked.GetValueOrDefault();
            this.settings.MainFormUI.MessageFontFamily = this.FontComboBox.SelectedValue.ToString();
            this.settings.MainFormUI.MessageFontSize = (float)this.FontSize.Value.GetValueOrDefault();

            this.settings.TextDiff.DiffPath = this.ExtDiffPathEdit.Text;
            this.settings.TextDiff.DiffParameters = this.ExtDiffParametersEdit.Text;

            this.settings.TextEditor.TextEditorPath = this.ExtTextEditPathEdit.Text;
            this.settings.TextEditor.TextEditorParameteres = this.ExtTextEditParametersEdit.Text;

            this.settings.AutomaticUpdates.EnableAutomaticCheck = this.AutomaticUpdateEnabledCheckBox.IsChecked.GetValueOrDefault();
            this.settings.AutomaticUpdates.CheckInterval = Convert.ToInt32(this.AutomaticUpdateCheckPeriodEdit.Value);

            this.settings.Save();

            //Browse for logs around
            this.logBrowser.TopLevelFolders = this.TopLevelFolders.Text;
            this.logBrowser.ShowAndCloseOnDoubleClick = this.OpenAndExitOnDoubleClickCheckBox.IsChecked.GetValueOrDefault();
            this.logBrowser.Save();

            log.Debug("Data saved...");

            if (this.totalCmd.IsInstalled && this.totalCmd.IsLogViewerIntegrated != this.IntegrateWithTotalCmdCheckBox.IsChecked)
            {
                log.Debug("Saving TotalCmd settings");
                log.Debug("Checking if TotalCmd is running...");
                bool totalCmdRunning = false;

                while (Process.GetProcessesByName("TOTALCMD").Count(p => p.MainModule.ModuleName.Equals("TOTALCMD.EXE", StringComparison.OrdinalIgnoreCase)) > 0)
                {
                    if (MessageBox.Show("Total Commander is running, please close it and then click on Retry. Isn't possible to save Total Commander configuration when is running.", "Total Commander", MessageBoxButton.OKCancel, MessageBoxImage.Warning) != MessageBoxResult.OK)
                    {
                        totalCmdRunning = true;
                        break;
                    }
                }
                if (!totalCmdRunning)
                {
                    if (this.IntegrateWithTotalCmdCheckBox.IsChecked.GetValueOrDefault())
                        this.totalCmd.IntegrateLogViewer();
                    else
                        this.totalCmd.UnIntegrateLogViewer();
                    log.Debug("TotalCmd settigns saved");
                }
                else
                {
                    MessageBox.Show("Total Commander configuration wasn't saved because Total Commander is running. Rest of the configuration was saved successfuly.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    log.Debug("TotalCmd isn't saved because Total Commander is running");
                }
            }
            if (this.AssociateWithAlvCheckBox.IsEnabled && this.AssociateWithAlvCheckBox.IsChecked != alvWasAssociated)
            {

                try
                {
                    string executable = Assembly.GetExecutingAssembly().Location;
                    if (this.AssociateWithAlvCheckBox.IsChecked.GetValueOrDefault())
                        FileAssociation.Associate(".log", "AdvancedLogViewer", "Log file", executable, 0, executable);
                    else
                        FileAssociation.Remove(".log", "AdvancedLogViewer");
                }
                catch
                {
                    MessageBox.Show("Can'setassociation for the LOG extension. Run ALV as Administrator.", "Administration rights required", MessageBoxButton.OK, MessageBoxImage.Warning);
                }


            }
        }

        public void DefaultFont_Click(object sender, EventArgs e)
        {
            FontComboBox.SelectedValue = SystemFonts.DefaultFont.Name;
            FontSize.Value = SystemFonts.DefaultFont.SizeInPoints;
        }
    }
}
