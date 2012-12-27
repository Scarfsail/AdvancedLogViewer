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
using AdvancedLogViewer.BL.LogAdjuster;
using System.IO;

namespace AdvancedLogViewer.UI
{
    public partial class LogAdjustersDlg : Form
    {
        private LogAdjusters customLogAdjusters;
        private LogAdjusters systemLogAdjusters;
        private string openedLogFileName;

        private static Scarfsail.Logging.Log log = new Scarfsail.Logging.Log();

        public LogAdjustersDlg(LogAdjusters customLogAdjusters, LogAdjusters systemLogAdjusters, string openedLogFileName)
        {
            log.Debug("Creating LogAdjustersDlg form");

            InitializeComponent();
            this.customLogAdjusters = customLogAdjusters;
            this.systemLogAdjusters = systemLogAdjusters;
            this.openedLogFileName = openedLogFileName;

            this.LoadAdjusterIntoListView(customListView, customLogAdjusters);
            this.LoadAdjusterIntoListView(systemListView, systemLogAdjusters);

            log.Debug("LogAdjustersDlg form created");
        }

        private void LoadAdjusterIntoListView(ListView listView, LogAdjusters logAdjusters)
        {
            listView.BeginUpdate();
            listView.Items.Clear();

            foreach (LogAdjuster logAdjuster in logAdjusters)
            {
                listView.Items.Add(logAdjuster.LogFileName).SubItems.Add(logAdjuster.ConfigFileName);
            }
            listView.EndUpdate();
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            log.Debug("Saving data...");

            this.customLogAdjusters.ClearAllLogAdjusters();

            foreach (ListViewItem item in this.customListView.Items)
            {
                LogAdjuster logAdjuster = new LogAdjuster(item.Text, item.SubItems[1].Text);
                this.customLogAdjusters.AddLogAdjuster(logAdjuster);
            }

            this.customLogAdjusters.Save();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (logFileOpenDialog.ShowDialog() == DialogResult.OK)
            {
                if (GetListViewItemForLogFileName(this.customListView, this.logFileOpenDialog.FileName, null, true) != null)
                    return;

                this.configFileOpenDialog.Title = "Select Config file for Log: " + this.logFileOpenDialog.FileName;
                if (configFileOpenDialog.ShowDialog() == DialogResult.OK)
                {
                   ListViewItem item = this.customListView.Items.Add(logFileOpenDialog.FileName);
                   item.SubItems.Add(configFileOpenDialog.FileName);
                   item.Selected = true;
                   item.Focused = true;
                   item.EnsureVisible();
                }
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = this.customListView.SelectedItems[0];
            this.logFileOpenDialog.InitialDirectory = Path.GetDirectoryName(selectedItem.SubItems[0].Text);
            this.logFileOpenDialog.FileName = Path.GetFileName(selectedItem.SubItems[0].Text);

            this.configFileOpenDialog.InitialDirectory = Path.GetDirectoryName(selectedItem.SubItems[1].Text);
            this.configFileOpenDialog.FileName = Path.GetFileName(selectedItem.SubItems[1].Text);

            if (logFileOpenDialog.ShowDialog() == DialogResult.OK)
            {
                if (GetListViewItemForLogFileName(this.customListView, this.logFileOpenDialog.FileName, selectedItem, true) != null)
                    return;

                this.configFileOpenDialog.Title = "Select Config file for Log: " + this.logFileOpenDialog.FileName;
                if (configFileOpenDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedItem.SubItems[0].Text = logFileOpenDialog.FileName;
                    selectedItem.SubItems[1].Text = configFileOpenDialog.FileName;
                }
            }
        }

        private ListViewItem GetListViewItemForLogFileName(ListView listView,string logFileName, ListViewItem exceptThisItem, bool showMessageWhenExists)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Text.Equals(logFileName, StringComparison.OrdinalIgnoreCase) && item != exceptThisItem)
                {
                    if (showMessageWhenExists)
                        MessageBox.Show(String.Format("For log File: '{0}' is already defined Config file. Please edit the existing one or add different Log file name.", logFileName), "Log file duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return item;
                }
            }
            return null;
        }

        private void customListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.editBtn.Enabled = this.customListView.SelectedItems.Count > 0;
            this.deleteBtn.Enabled = this.customListView.SelectedItems.Count > 0;
        }

        private void systemListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.copyAsCustomBtn.Enabled = this.systemListView.SelectedItems.Count > 0;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete selected association between Log File and Config file?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.customListView.SelectedItems[0].Remove();
        }

        private void copyAsCustomBtn_Click(object sender, EventArgs e)
        {
            ListViewItem item = this.systemListView.SelectedItems[0];
            if (GetListViewItemForLogFileName(this.customListView, item.SubItems[0].Text, null, true) != null)
                return;

            ListViewItem newItem = this.customListView.Items.Add(item.SubItems[0].Text);
            newItem.SubItems.Add(item.SubItems[1].Text);
            newItem.Selected = true;
            newItem.Focused = true;
            item.EnsureVisible();
            customListView.Focus();
        }

        private void LogAdjustersDlg_Shown(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.openedLogFileName))
            {
                ListViewItem selectedItem = GetListViewItemForLogFileName(this.customListView, this.openedLogFileName, null, false);
                this.configFileOpenDialog.Title = "Select Config file for Log: " + this.openedLogFileName;

                if (selectedItem != null)
                {
                    this.configFileOpenDialog.InitialDirectory = Path.GetDirectoryName(selectedItem.SubItems[1].Text);
                    this.configFileOpenDialog.FileName = Path.GetFileName(selectedItem.SubItems[1].Text);

                    if (configFileOpenDialog.ShowDialog() == DialogResult.OK)
                    {
                        selectedItem.SubItems[1].Text = this.configFileOpenDialog.FileName;
                    }                    
                }
                else
                {
                    ListViewItem systemItem = GetListViewItemForLogFileName(this.systemListView, this.openedLogFileName, null, false);
                    if (systemItem != null)
                    {
                        this.configFileOpenDialog.InitialDirectory = Path.GetDirectoryName(systemItem.SubItems[1].Text);
                        this.configFileOpenDialog.FileName = Path.GetFileName(systemItem.SubItems[1].Text);
                    }

                    if (configFileOpenDialog.ShowDialog() == DialogResult.OK)
                    {
                        selectedItem = this.customListView.Items.Add(this.openedLogFileName);
                        selectedItem.SubItems.Add(configFileOpenDialog.FileName);
                    }                    
                }
                if (selectedItem != null)
                {
                    selectedItem.Selected = true;
                    selectedItem.Focused = true;
                    selectedItem.EnsureVisible();
                }
            }
        }
    }
}
