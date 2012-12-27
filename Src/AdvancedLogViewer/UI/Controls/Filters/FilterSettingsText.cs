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
using Scarfsail.Common.UI.Controls;

namespace AdvancedLogViewer.UI.Controls.Filters
{
    public partial class FilterSettingsText : FilterSettingsTextTimeNonGenerics
    {
        public FilterSettingsText()
        {
            InitializeComponent();

            NativeTabControl nativeTabControl = new NativeTabControl();
            nativeTabControl.AssignHandle(this.tabControl.Handle);
        }

        private List<string> distinctValuesList;
        private bool ignoreCheckEvent = false;
        private bool dontChangeToIndeterminateAutomatically = false;

        protected override void InternalLoadContent(FilterEntry.FilterItemText filterItem)
        {
            this.textEdit.TextChanged -= this.textEdit_TextChanged;

            this.textEdit.Lines = filterItem.TextLines.ToArray();
            this.textFromCurrentItemButton.Enabled = !String.IsNullOrEmpty(this.CurrentItemValue);

            this.textEdit.TextChanged += new System.EventHandler(this.textEdit_TextChanged);

            switch (filterItem.EditorToShow)
            {
                case FilterEntry.FilterItemText.EditorSelection.FreeMode:
                    this.tabControl.SelectedTab = freeDefinitionTabPage;
                    break;
                case FilterEntry.FilterItemText.EditorSelection.DistinctValues:
                    this.tabControl.SelectedTab = distinctValuesTabPage;
                    break;
                default:
                    throw new InvalidOperationException("Unsupported value: " + filterItem.EditorToShow);
            }
            if (filterItem.UseRegex)
                this.tabControl.SelectedTab = freeDefinitionTabPage;
            useRegexCheckBox.Checked = filterItem.UseRegex;
        }

        public override void SaveContent(FilterEntry.FilterItemText filterItem)
        {
            filterItem.EditorToShow = this.tabControl.SelectedTab == freeDefinitionTabPage ? FilterEntry.FilterItemText.EditorSelection.FreeMode : FilterEntry.FilterItemText.EditorSelection.DistinctValues;
            filterItem.UseRegex = useRegexCheckBox.Checked;

            base.SaveContent(filterItem);
            filterItem.SaveTextLines(this.textEdit.Lines.Where(s => !s.Equals(String.Empty)));
        }

        private void textEdit_TextChanged(object sender, EventArgs e)
        {
            this.enabledCheckBox.Checked = true;
        }

        private void textFromCurrentItemButton_Click(object sender, EventArgs e)
        {
            this.textEdit.Paste(this.CurrentItemValue);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == distinctValuesTabPage)
            {
                this.distinctValuesListBox.BeginUpdate();
                Cursor.Current = Cursors.WaitCursor;

                this.ignoreCheckEvent = true;
                if (this.distinctValuesList == null)
                {  //Load list and reflect checkboxes
                    this.distinctValuesList = this.GetDistinctValues();
                    int maxWidth = 0;
                    foreach (string value in this.distinctValuesList)
                    {
                        if (value == String.Empty)
                            continue;

                        int addedIdx = this.distinctValuesListBox.Items.Add(value);
                        maxWidth = Math.Max(TextRenderer.MeasureText(value, this.distinctValuesListBox.Font).Width, maxWidth);

                        bool exclude;
                        if (FindLineWithExactText(value, this.textEdit.Lines, out exclude) > -1)
                        {
                            this.distinctValuesListBox.SetItemCheckState(addedIdx, exclude ? CheckState.Indeterminate : CheckState.Checked);
                        }
                    }

                    maxWidth += 60;
                    DoMaxWidthChanged(maxWidth);
                }
                else //Just update checkboxes in the list
                {

                    for (int idx = 0; idx < this.distinctValuesListBox.Items.Count; idx++)
                    {
                        string value = (string)this.distinctValuesListBox.Items[idx];

                        bool exclude;
                        if (FindLineWithExactText(value, this.textEdit.Lines, out exclude) > -1)
                        {
                            this.distinctValuesListBox.SetItemCheckState(idx, exclude ? CheckState.Indeterminate : CheckState.Checked);
                        }
                        else
                        {
                            this.distinctValuesListBox.SetItemCheckState(idx, CheckState.Unchecked);
                        }
                    }
                }
                this.distinctValuesListBox.EndUpdate();
                this.ignoreCheckEvent = false;

                Cursor.Current = Cursors.Default;
            }
        }

        private int FindLineWithExactText(string textToFind, string[] lines, out bool exclude)
        {
            if (textToFind != string.Empty)
            {
                for (int lineNumber = 0; lineNumber < lines.Length; lineNumber++)
                {
                    string line = lines[lineNumber];
                    bool escapeFirst;
                    string text = AdvancedLogViewer.BL.Filters.FilterEntry.FilterItemText.GetTextFromLine(line, out exclude, out escapeFirst);
                    if (text.Equals(textToFind, StringComparison.OrdinalIgnoreCase))
                        return lineNumber;
                }
            }
            exclude = false;
            return -1;
        }

        private void distinctValuesListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (ignoreCheckEvent)
                return;

            //Add "Indeterminate" state between checked and unchecked
            if (!dontChangeToIndeterminateAutomatically)
            {
                if (e.CurrentValue == CheckState.Checked)
                    e.NewValue = CheckState.Indeterminate;
            }
            string changedText = (string)distinctValuesListBox.Items[e.Index];

            bool exclude;
            int line = FindLineWithExactText(changedText, this.textEdit.Lines, out exclude);


            //Reflect the change into free mode text editor
            List<string> lines = this.textEdit.Lines.Distinct(new StringIgnoreCaseEqualityComparer()).ToList();
            switch (e.NewValue)
            {
                case CheckState.Checked:
                    if (line == -1)
                        lines.Add(changedText);
                    else
                        lines[line] = changedText;
                    break;
                case CheckState.Indeterminate:
                    if (line == -1)
                        lines.Add('~' + changedText);
                    else
                        if (!exclude)
                            lines[line] = '~' + lines[line];
                    break;
                case CheckState.Unchecked:
                    if (line > -1)
                        lines.RemoveAt(line);
                    break;
                default:
                    break;
            }

            this.textEdit.Lines = lines.ToArray();
        }

        private void filterAllButton_Click(object sender, EventArgs e)
        {
            SetCheckStateForAll(CheckState.Checked);
        }

        private void negateAllButton_Click(object sender, EventArgs e)
        {
            SetCheckStateForAll(CheckState.Indeterminate);
        }

        private void unselectAllButton_Click(object sender, EventArgs e)
        {
            SetCheckStateForAll(CheckState.Unchecked);
        }

        private void SetCheckStateForAll(CheckState checkState)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.distinctValuesListBox.BeginUpdate();
            this.dontChangeToIndeterminateAutomatically = true;
            for (int idx = 0; idx < this.distinctValuesListBox.Items.Count; idx++)
            {
                this.distinctValuesListBox.SetItemCheckState(idx, checkState);
            }
            this.dontChangeToIndeterminateAutomatically = false;
            this.distinctValuesListBox.EndUpdate();
            Cursor.Current = Cursors.Default;
        }

        private void tabControl_Enter(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == distinctValuesTabPage)
                this.distinctValuesListBox.Focus();
            else

                this.textEdit.Focus();
        }

        private void useRegexCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (useRegexCheckBox.Checked)
            {
                hintLabel.Text = "Type regex to filter by.";
                tabControl.TabPages.Remove(distinctValuesTabPage);
                regeExHelpLink.Visible = true;
            }
            else
            {
                hintLabel.Text = "Start line with: ~ to negate.";
                tabControl.TabPages.Add(distinctValuesTabPage);
                regeExHelpLink.Visible = false;
            }

        }

        private void regeExHelpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WinFormHelper.GotoUrl("http://regexlib.com/CheatSheet.aspx");
        }


    }

    public class FilterSettingsTextTimeNonGenerics : FilterSettingsBaseControl<FilterEntry.FilterItemText, string> { }
}
