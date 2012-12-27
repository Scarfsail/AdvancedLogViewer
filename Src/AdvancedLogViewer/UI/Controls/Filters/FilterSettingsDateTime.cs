using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvancedLogViewer.BL.Filters;

namespace AdvancedLogViewer.UI.Controls.Filters
{
    public partial class FilterSettingsDateTime : FilterSettingsDateTimeNonGenerics
    {
        public FilterSettingsDateTime()
        {
            InitializeComponent();
        }

        public bool DateTimeFunctionsEnabled
        {
            get
            {
                return this.enabledCheckBox.Enabled;
            }

            set
            {
                this.enabledCheckBox.Enabled = value;
                
                this.dateTimeFrom.Enabled = value;
                this.dateTimeTo.Enabled = value;
                this.dateTimeToCheckBox.Enabled = value;
                this.dateTimeFromCheckBox.Enabled = value;
                this.Enabled = value;
            }
        }

        protected override void InternalLoadContent(FilterEntry.FilterItemDate filterItem)
        {
            this.filterItem = filterItem;

            if (DateTimeFunctionsEnabled)
            {
                this.dateTimeTo.ValueChanged -= this.dateTime_ValueChanged;
                this.dateTimeFrom.ValueChanged -= this.dateTime_ValueChanged;

                this.enabledCheckBox.Checked = filterItem.Enabled;
                this.dateTimeFrom.Value = filterItem.From == DateTime.MinValue ? DateTime.Now : filterItem.From;
                this.dateTimeTo.Value = filterItem.To == DateTime.MinValue ? DateTime.Now : filterItem.To;
                this.dateTimeFromCheckBox.Checked = filterItem.FromEnabled;
                this.dateTimeToCheckBox.Checked = filterItem.ToEnabled;
                this.SetEnabledState();

                this.dateTimeTo.ValueChanged += new System.EventHandler(this.dateTime_ValueChanged);
                this.dateTimeFrom.ValueChanged += new System.EventHandler(this.dateTime_ValueChanged);

            }
        }

        public override void SaveContent(FilterEntry.FilterItemDate filterItem)
        {
            base.SaveContent(filterItem);

            if (DateTimeFunctionsEnabled)
            {
                filterItem.Enabled = this.enabledCheckBox.Checked;
                filterItem.From = this.dateTimeFrom.Value;
                filterItem.To = this.dateTimeTo.Value;
                filterItem.FromEnabled = this.dateTimeFromCheckBox.Checked;
                filterItem.ToEnabled = this.dateTimeToCheckBox.Checked;
            }

        }

        private void timeFromNowButton_Click(object sender, EventArgs e)
        {
            this.dateTimeFrom.Value = DateTime.Now;
        }

        private void timeFromCurrentItemButton_Click(object sender, EventArgs e)
        {
            this.dateTimeFrom.Value = this.CurrentItemValue;
        }

        private void timeToNowButton_Click(object sender, EventArgs e)
        {
            this.dateTimeTo.Value = DateTime.Now;
        }


        private void timeToCurrentItemButton_Click(object sender, EventArgs e)
        {
            this.dateTimeTo.Value = this.CurrentItemValue;
        }

        private void dateTimeFromCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!dateTimeFromCheckBox.Checked)
                dateTimeToCheckBox.Checked = true;

            this.SetEnabledState();
        }

        private void dateTimeToCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!dateTimeToCheckBox.Checked)
                dateTimeFromCheckBox.Checked = true;

            this.SetEnabledState();
        }

        private void SetEnabledState()
        {
            this.dateTimeFrom.Enabled = dateTimeFromCheckBox.Checked;
            this.timeFromNowButton.Enabled = dateTimeFromCheckBox.Checked;
            this.timeFromCurrentItemButton.Enabled = dateTimeFromCheckBox.Checked && this.CurrentItemValue != DateTime.MinValue;

            this.dateTimeTo.Enabled = dateTimeToCheckBox.Checked;
            this.timeToNowButton.Enabled = dateTimeToCheckBox.Checked;
            this.timeToCurrentItemButton.Enabled = dateTimeToCheckBox.Checked && this.CurrentItemValue != DateTime.MinValue;
        
        }

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            this.enabledCheckBox.Checked = true;
        }
                
        
        private FilterEntry.FilterItemDate filterItem;


    }

    public class FilterSettingsDateTimeNonGenerics : FilterSettingsBaseControl<FilterEntry.FilterItemDate, DateTime> { }

}
