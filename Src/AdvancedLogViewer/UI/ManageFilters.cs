using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvancedLogViewer.BL.Filters;
using Scarfsail.Common.UI;
using AdvancedLogViewer.Common.Parser;
using AdvancedLogViewer.UI.Controls.Filters;

namespace AdvancedLogViewer.UI
{
    public partial class ManageFilters : Form
    {
        private FilterManager filterManager;
        private bool loading = false;
        private LogEntry currentLogEntry;
        private GetDistinctValues getDistinctValues;
        private static Scarfsail.Logging.Log log = new Scarfsail.Logging.Log();

        public ManageFilters(FilterManager filterManager, bool dateTimeFunctionsEnabled, LogEntry currentLogEntry, GetDistinctValues getDistinctValues)
        {
            log.Debug("Creating ManageFilters form");
            InitializeComponent();
            this.filterManager = filterManager;
            this.filterSettingsDateTime.DateTimeFunctionsEnabled = dateTimeFunctionsEnabled;
            this.currentLogEntry = currentLogEntry;
            this.getDistinctValues = getDistinctValues;

            foreach (var filter in this.filterManager.Filters)
            {
                this.filtersComboBox.Items.Add(filter);
            }
            this.loading = true;
            this.filtersComboBox.SelectedItem = this.filterManager.CurrentFilter;
            this.loading = false;

            log.Debug("ManageFilters form created");
        }


        private void LoadCurrentGroup()
        {
            FilterEntry filter = filterManager.CurrentFilter;

            log.Debug("Loading current filter: " + filter.FilterName);
            filterSettingsDateTime.LoadContent(filter.DateTimeRange, currentLogEntry == null ? DateTime.MinValue : currentLogEntry.Date, null);

            filterSettingsThreads.LoadContent(filter.Threads, currentLogEntry == null ? String.Empty : currentLogEntry.Thread, getDistinctValues.Threads);
            filterSettingsTypes.LoadContent(filter.Types, currentLogEntry == null ? String.Empty : currentLogEntry.Type, getDistinctValues.Types);
            filterSettingsClasses.LoadContent(filter.Classes, currentLogEntry == null ? String.Empty : currentLogEntry.Class, getDistinctValues.Classes);

            filterSettingsMessages.LoadContent(filter.Messages, currentLogEntry == null ? String.Empty : currentLogEntry.Message, null);
            
            log.Debug("Filter loaded");
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            log.Debug("Saving data...");
            try
            {

                FilterEntry filter = filterManager.CurrentFilter;
                this.SaveCurrentFilter();
                this.filterManager.Save();
                log.Debug("Data saved...");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cant't save filter: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void SaveCurrentFilter()
        {
            FilterEntry filter = filterManager.CurrentFilter;
            log.Debug("Saving current filter: " + filter.FilterName);

            filterSettingsDateTime.SaveContent(filter.DateTimeRange);
            filterSettingsThreads.SaveContent(filter.Threads);
            filterSettingsTypes.SaveContent(filter.Types);
            filterSettingsClasses.SaveContent(filter.Classes);
            filterSettingsMessages.SaveContent(filter.Messages);

            log.Debug("Filter saved");
        }

        private void addFilterButton_Click(object sender, EventArgs e)
        {
            log.Debug("addFilterButton_Click");
            using (InputBox dlg = new InputBox("Change filter name", "Enter filter name:"))
            {
                FilterEntry item = new FilterEntry();
                item.InitDefaultValues();
                dlg.Value = item.FilterName;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    item.FilterName = dlg.Value;
                    this.filterManager.Filters.Add(item);
                    this.filtersComboBox.Items.Add(item);
                    this.filtersComboBox.SelectedItem = item;
                    this.filtersComboBox.Focus();
                }
            }
        }

        private void removeFilterButton_Click(object sender, EventArgs e)
        {
            log.Debug("removeFilterButton_Click");
            if (this.filterManager.Filters.Count == 1)
            {
                MessageBox.Show("You can't delete last filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FilterEntry item = (FilterEntry)this.filtersComboBox.SelectedItem;
                int prevIdx = this.filtersComboBox.SelectedIndex;
                this.filterManager.Filters.Remove(item);
                this.filtersComboBox.Items.Remove(item);
                this.filtersComboBox.SelectedItem = filtersComboBox.Items[prevIdx - 1];
            }
        }

        private void renameFilterButton_Click(object sender, EventArgs e)
        {
            log.Debug("renameFilterButton_Click");
            FilterEntry item = (FilterEntry)this.filtersComboBox.SelectedItem;
            using (InputBox dlg = new InputBox("Change filter name", "Enter filter name:", item.FilterName))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    item.FilterName = dlg.Value;
                    this.filtersComboBox.Items[this.filtersComboBox.SelectedIndex] = item;
                }
            }
        }

        private void filtersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            log.Debug("filtersComboBox_SelectedIndexChanged");
            if (!loading)
                this.SaveCurrentFilter();
            this.filterManager.CurrentFilter = (FilterEntry)filtersComboBox.SelectedItem;
            this.LoadCurrentGroup();
        }

        private void ManageFilters_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
                this.filterManager.ReloadFromFile();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }
    }
}
