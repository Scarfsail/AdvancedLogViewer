using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using AdvancedLogViewer.Common.Parser;
using AdvancedLogViewer.UI.Items;
using System.Text.RegularExpressions;
using AdvancedLogViewer.Common;
using AdvancedLogViewer.BL.FindText;
using Scarfsail.Common.BL;

namespace AdvancedLogViewer.UI
{
    internal delegate LogListViewItem GetLogListItem(GetLogListItemType type);
    internal delegate List<LogEntry> GetLogEntries();
    internal delegate bool GotoLogItem(int index);
    
    public partial class FindTextDlg : Form
    {
        private GetLogEntries GetLogEntries;
        private GetLogListItem GetLogItem;
        private GotoLogItem GoToLogItem;
        private RichTextBox logMessageEdit;
        private string logFileName;
        private FindTextSettings settings;
        private string prevFindWhat = String.Empty;
        private static Scarfsail.Logging.Log log = new Scarfsail.Logging.Log();


        internal FindTextDlg(Form ownerForm, GetLogEntries getLogEntries, GetLogListItem getLogItemFnc, GotoLogItem goToLogItemFnc, RichTextBox logMessageEdit)
        {
            InitializeComponent();
            this.Owner = ownerForm;
            this.GetLogEntries = getLogEntries;
            this.GetLogItem = getLogItemFnc;
            this.GoToLogItem = goToLogItemFnc;
            this.logMessageEdit = logMessageEdit;
            this.settings = FindTextSettings.LoadFromFile(Path.Combine(Globals.UserDataDir, "FindText.xml"), XmlSerializableFileCorruptedAction.ShowDialogAndLoadDefaults);

            this.LoadRecentTexts();

            this.findWhatCombo.Text = this.settings.FindWhat;
            //Note: FindIn is loaded for each different logfile
            this.useRegExCheckBox.Checked = this.settings.UseRegEx;
            this.caseSensitiveCheckBox.Checked = this.settings.CaseSensitive;
            this.searchFromCurrentPositionCheckBox.Checked = this.settings.SearchFromCurrentPosition;
        }

        public void Show(string logFileName, IEnumerable<PatternItem> patternItems)
        {
            if (this.logFileName != logFileName)
            {
                this.logFileName = logFileName;

                //Populate "Find in" combo box and select last or default value
                bool selected = false;

                this.findInCombo.Items.Clear();
                string allFieldsText = "<All fields>";
                this.findInCombo.Items.Add(allFieldsText);
                if (allFieldsText.Equals(this.settings.FindIn))
                {
                    this.findInCombo.SelectedIndex = 0;
                    selected = true;
                }
                foreach (PatternItem item in patternItems)
                {
                    this.findInCombo.Items.Add(item);
                    if (!selected && item.ToString().Equals(this.settings.FindIn))
                    {
                        this.findInCombo.SelectedItem = item;
                        selected = true;
                    }
                }

                if (!selected)
                    this.findInCombo.SelectedItem = patternItems.First(i => i.ItemType == PatternItemType.Message);
            }

            if (this.Visible)
                base.Show();
            else
                base.Show(this.Owner);
            this.findWhatCombo.Focus();
            this.findWhatCombo.SelectAll();
        }

        public void Find(string logFileName, IEnumerable<PatternItem> patternItems, bool searchDown)
        {
            if (this.logFileName != logFileName || this.findWhatCombo.Text == String.Empty)
            {
                this.Show(logFileName, patternItems);
            }
            else
            {
                this.Find(searchDown, false);
            }
        }

        public void SaveSettings()
        {
            this.settings.FindWhat = this.findWhatCombo.Text;
            this.settings.UseRegEx = this.useRegExCheckBox.Checked;
            this.settings.CaseSensitive = this.caseSensitiveCheckBox.Checked;
            this.settings.SearchFromCurrentPosition = this.searchFromCurrentPositionCheckBox.Checked;            
            //Note: Recent search list is updated on each search
            
            this.settings.Save();
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            Owner.Show();
            base.OnClosing(e);
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            try
            {
                if ((System.Windows.Forms.Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                {
                    if (msg.WParam.ToInt32() == (int)Keys.F3)
                    {
                        if (this.findPrevButton.Enabled)
                            this.findPrevButton.PerformClick();
                        return true;
                    }
                }

                if (msg.WParam.ToInt32() == (int)Keys.F3)
                {
                    if (this.findNextButton.Enabled)
                        this.findNextButton.PerformClick();
                    return true;
                }
            }
            catch (Exception Ex)
            {
                this.ShowAndLogError("Key Overrided Events Error:" + Ex.Message);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }



        private bool Find(bool searchDown, bool thisIsSecondSearch)
        {
            Cursor origOwnerCursor = Owner.Cursor;
            Owner.Cursor = Cursors.WaitCursor;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                List<LogEntry> logEntries = this.GetLogEntries();

                LogListViewItem selectedItem = thisIsSecondSearch ? this.GetLogItem(searchDown ? GetLogListItemType.First : GetLogListItemType.Last) : this.GetLogItem(GetLogListItemType.Selected);
                if (selectedItem == null)
                    return false;

                this.statusLabel.LinkColor = SystemColors.ControlText;
                this.statusLabel.Text = "Searching ...";
                this.statusLabel.Tag = -3;
                this.statusLabel.Visible = true;
                this.Update();

                int index = selectedItem.Index;
                string findWhat = this.findWhatCombo.Text;

                if (!this.prevFindWhat.Equals(findWhat, StringComparison.OrdinalIgnoreCase))
                {
                    this.settings.SearchHistory.AddText(findWhat);
                    this.LoadRecentTexts();
                }

                PatternItemType? findIn = null;
                if (this.findInCombo.SelectedIndex > 0)
                {
                    findIn = (this.findInCombo.SelectedItem as PatternItem).ItemType;
                }

                StringComparison stringComparison = this.caseSensitiveCheckBox.Checked ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
                Regex regex = this.useRegExCheckBox.Checked ? new Regex(findWhat, this.caseSensitiveCheckBox.Checked ? RegexOptions.None : RegexOptions.IgnoreCase) : null;

                bool found = false;
                int i = searchDown ? index - 1 : index + 1;
                while (searchDown ? ++i < logEntries.Count : --i >= 0)
                {
                    LogEntry logEntry = logEntries.ElementAt(i);

                    //Search for other columns than Message (we search in current item only when we search for message too, otherwise we search from next item)
                    if (i != index)
                    {
                        if (!found && (findIn == null || findIn == PatternItemType.Date))
                            if (SearchText(findWhat, logEntry.DateText, regex, stringComparison) > -1)
                                found = true;

                        if (!found && (findIn == null || findIn == PatternItemType.Thread) && logEntry.Thread != null)
                            if (SearchText(findWhat, logEntry.Thread, regex, stringComparison) > -1)
                                found = true;

                        if (!found && (findIn == null || findIn == PatternItemType.Type) && logEntry.Type != null)
                            if (SearchText(findWhat, logEntry.Type, regex, stringComparison) > -1)
                                found = true;

                        if (!found && (findIn == null || findIn == PatternItemType.Class) && logEntry.Class != null)
                            if (SearchText(findWhat, logEntry.Class, regex, stringComparison) > -1)
                                found = true;
                    }


                    //Search in message (we search message in current item for next occurence of searched text)
                    if (!found && (findIn == PatternItemType.Message || findIn == null))
                    {
                        int prevMessageFoundPos = (i == index && this.logMessageEdit.SelectionLength > 0) ? this.logMessageEdit.SelectionStart - logMessageEdit.GetFirstCharIndexFromLine(1) : -1;
                        int length;
                        int textPos = SearchText(findWhat, logEntry.Message, prevMessageFoundPos + 1, regex, stringComparison, out length);
                        if (textPos > -1)
                        {
                            if (i != index)
                            {
                                GoToLogItem(i);
                            }

                            //Select text                            
                            logMessageEdit.SelectionStart = textPos + logMessageEdit.GetFirstCharIndexFromLine(1);
                            logMessageEdit.SelectionLength = length;
                            logMessageEdit.ScrollToCaret();
                            found = true;
                            break;
                        }
                        else
                        {
                            found = false;
                        }
                    }

                    if (found)
                    {
                        GoToLogItem(i);
                        break;
                    }
                }

                if (found)
                {
                    if (this.Visible)
                    {
                        this.statusLabel.LinkColor = Color.Green;
                        this.statusLabel.Text = "Text found, click to &select the item";
                        this.statusLabel.Tag = i + 1; //Zero means: Text not found. So we have to put there item number+1.
                        this.statusLabel.Visible = true;
                    }
                }
                else
                {
                    if (this.Visible)
                    {
                        if (!thisIsSecondSearch)
                        {
                            this.statusLabel.LinkColor = Color.Orange;
                            this.statusLabel.Text = "Not found, &search from " + (searchDown ? "first" : "last") + " item";
                            this.statusLabel.Tag = searchDown ? -1 : -2;
                        }
                        else
                        {
                            this.statusLabel.Text = "Searched text was not found.";
                            this.statusLabel.LinkColor = Color.Red;
                            this.statusLabel.Tag = 0;
                        }
                        this.statusLabel.Visible = true;
                    }
                    else
                    {
                        if (!thisIsSecondSearch)
                        {
                            string msg = "Searched text: '" + this.findWhatCombo.Text + "' was not found.\n";
                            msg += searchDown ? "Continue search from first item of the log ?" : "Continue search from last item of the log ?";

                            if (MessageBox.Show(msg, "Not found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                this.Find(searchDown, true);
                        }
                        else
                        {
                            MessageBox.Show("Searched text was not found anywhere.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                return found;
            }
            catch (Exception ex)
            {
                log.Error("Error during search: " + ex.ToString());
                MessageBox.Show(ex.Message, "Error during search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if ((int)this.statusLabel.Tag == -3)
                    this.statusLabel.Visible = false;

                Owner.Cursor = origOwnerCursor;
                this.Cursor = Cursors.Default;
            }
        }

        private int SearchText(string findWhat, string findWhere, Regex regEx, StringComparison stringComparison)
        {
            int length;
            return SearchText(findWhat, findWhere, 0, regEx, stringComparison, out length);
        }

        private int SearchText(string findWhat, string findWhere, int startIndex, Regex regEx, StringComparison stringComparison, out int length)
        {
            if (regEx != null)
            {
                Match match = regEx.Match(findWhere, startIndex);
                if (match.Success)
                {
                    length = match.Length;
                    return match.Index;
                }
                else
                {
                    length = -1;
                    return -1;
                }
            }
            else
            {
                length = findWhat.Length;
                return findWhere.IndexOf(findWhat, startIndex, stringComparison);
            }
        }

        private void LoadRecentTexts()
        {
            this.findWhatCombo.BeginUpdate();
            int selStart = this.findWhatCombo.SelectionStart;
            int selLength = this.findWhatCombo.SelectionLength;
            this.findWhatCombo.Items.Clear();

            foreach (string text in this.settings.SearchHistory.TextList)
            {
                this.findWhatCombo.Items.Add(text);
            }
            this.findWhatCombo.SelectionStart = selStart;
            this.findWhatCombo.SelectionLength = selLength;
            this.findWhatCombo.EndUpdate();
        }

        private void ShowAndLogError(string errorMessage)
        {
            log.Error(errorMessage);
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UpdateUI()
        {
            this.statusLabel.Visible = false;
            this.findNextButton.Enabled = this.findWhatCombo.Text != String.Empty;
            this.findPrevButton.Enabled = (this.findWhatCombo.Text != String.Empty) && (this.searchFromCurrentPositionCheckBox.Checked);
        }


        private void FindTextDlg_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(this.Owner.Location.X + (this.Owner.Width - this.Width) / 2, this.Owner.Location.Y + (this.Owner.Height - this.Height) / 2);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FindTextDlg_Deactivate(object sender, EventArgs e)
        {
            this.Opacity = 0.75;
        }

        private void FindTextDlg_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1.0;
        }

        private void findNextButton_Click(object sender, EventArgs e)
        {
            bool found = this.Find(true, false);
            if (!this.searchFromCurrentPositionCheckBox.Checked && !found)
                this.Find(true, true);
        }

        private void findPrevButton_Click(object sender, EventArgs e)
        {
            this.Find(false, false);
        }
        
        
        private void findInCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            this.settings.FindIn = this.findInCombo.SelectedItem.ToString();
            this.UpdateUI();
        }

        private void SearchConditionsChanged(object sender, EventArgs e)
        {
            this.UpdateUI();
        }

        private void searchFromCurrentPositionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (searchFromCurrentPositionCheckBox.Checked)
            {
                this.findPrevButton.Enabled = (this.findWhatCombo.Text != String.Empty) && (this.searchFromCurrentPositionCheckBox.Checked);
                this.findNextButton.Text = "Find &next";
            }
            else
            {
                this.findPrevButton.Enabled = false;
                this.findNextButton.Text = "Find";
            }
        }

        private void statusLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int tag = (int)statusLabel.Tag;
            if (tag == 0)
            {
                MessageBox.Show("Searched text was not found anywhere.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                if (tag > 0)
                {
                    this.GoToLogItem(tag - 1);
                }
                else
                    if (tag == -3)
                    {
                        //Do nothing, it's "Searching..." text
                    }
                    else
                    {
                        this.Find(tag == -1, true);
                    }
        }



    }
}
