using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvancedLogViewer.BL.Filters;
using Scarfsail.Common.Utils;

namespace AdvancedLogViewer.UI.Controls.Filters
{
    public partial class FilterSettingsMessage : FilterSettingsMessageNonGenerics
    {
        public FilterSettingsMessage()
        {
            InitializeComponent();
        }

        protected override void InternalLoadContent(FilterEntry.FilterItemMessage filterItem)
        {
            this.textEdit.TextChanged -= this.ValuesChanged;
            this.includeItemsFromColorHighlightCheckBox.CheckedChanged -= this.ValuesChanged;

            this.textEdit.Lines = filterItem.TextLines.ToArray();
            this.includeItemsFromColorHighlightCheckBox.Checked = filterItem.IncludeItemsFromColorHighlight;
            this.textFromCurrentItemButton.Enabled = !String.IsNullOrEmpty(this.CurrentItemValue);
            this.useRegexCheckBox.Checked = filterItem.UseRegex;

            this.textEdit.TextChanged += new EventHandler(this.ValuesChanged);
            this.includeItemsFromColorHighlightCheckBox.CheckedChanged += new EventHandler(this.ValuesChanged);
        }

        public override void SaveContent(FilterEntry.FilterItemMessage filterItem)
        {
            base.SaveContent(filterItem);
            
            filterItem.UseRegex = useRegexCheckBox.Checked;
            filterItem.SaveTextLines(this.textEdit.Lines.Where(s => !s.Equals(String.Empty)));

            filterItem.IncludeItemsFromColorHighlight = this.includeItemsFromColorHighlightCheckBox.Checked;
        }

        private void ValuesChanged(object sender, EventArgs e)
        {
            this.enabledCheckBox.Checked = true;
        }

        private void textFromCurrentItemButton_Click(object sender, EventArgs e)
        {
            this.textEdit.Paste(this.CurrentItemValue);
        }

        private void useRegexCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (useRegexCheckBox.Checked)
            {
                hintLabel.Text = "Type regex to filter by.";
                regeExHelpLink.Visible = true;
            }
            else
            {
                hintLabel.Text = "Start line with: ~ to negate.";
                regeExHelpLink.Visible = false;
            }
        }

        private void regeExHelpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WinFormHelper.GotoUrl("http://regexlib.com/CheatSheet.aspx");
        }

    }

    public class FilterSettingsMessageNonGenerics : FilterSettingsBaseControl<FilterEntry.FilterItemMessage, string> { }

}
