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
using System.Threading;

namespace AdvancedLogViewer.UI
{
    public partial class FindTextDlg : Form
    {
        private class CompiledSearchInput
        {
            public CompiledSearchInput(FindTextDlg compileFrom)
            {
                FindWhat = compileFrom.findWhatCombo.Text;

                //What to find
                FindIn = null;
                if (compileFrom.findInCombo.SelectedIndex > 0)
                {
                    FindIn = (compileFrom.findInCombo.SelectedItem as PatternItem).ItemType;
                }

                StringComparison = compileFrom.caseSensitiveCheckBox.Checked ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
                RegEx = compileFrom.useRegExCheckBox.Checked ? new Regex(FindWhat, compileFrom.caseSensitiveCheckBox.Checked ? RegexOptions.None : RegexOptions.IgnoreCase) : null;

            }
            public bool MatchPatternType(PatternItemType type)
            {
                return FindIn == null || FindIn == type;
            }

            public PatternItemType? FindIn { get; private set; }
            public string FindWhat { get; private set; }
            public Regex RegEx { get; private set; }
            public StringComparison StringComparison { get; private set; }
        }

        private static Scarfsail.Logging.Log log = new Scarfsail.Logging.Log();

        private string logFileName;
        private FindTextSettings settings;
        private string prevFindWhat = String.Empty;

        private List<LogEntry> foundEntries;
        private bool logHasBeenChanged = true;
        private bool markerksUpToDate = false;

        private FindDialogContext context;
        private CompiledSearchInput compiledSearchInput;
        private bool dialogWasShown = false;

        internal FindTextDlg(Form ownerForm, FindDialogContext context)
        {
            InitializeComponent();
            this.context = context;

            this.Owner = ownerForm;

            this.settings = FindTextSettings.LoadFromFile(Path.Combine(Globals.UserDataDir, "FindText.xml"), XmlSerializableFileCorruptedAction.ShowDialogAndLoadDefaults);

            this.LoadRecentTexts();

            this.findWhatCombo.Text = this.settings.FindWhat;
            //Note: FindIn is loaded for each different logfile
            this.useRegExCheckBox.Checked = this.settings.UseRegEx;
            this.caseSensitiveCheckBox.Checked = this.settings.CaseSensitive;
            this.dockedCheckBox.Checked = this.settings.Docked;
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
            SetVisibilityOfFoundResults(true);

            if (!markerksUpToDate)
                ShowMarkers();

            if (!dialogWasShown || this.dockedCheckBox.Checked)
                this.Location = context.GetPositionForSearchWindow(this.Width);

            dialogWasShown = true;
        }



        public void LogHasBeenChanged()
        {
            logHasBeenChanged = true;
            markerksUpToDate = false;

            if (this.Visible)
                ShowMarkers();
        }

        public void ResetSearchResults()
        {
            if (foundEntries != null)
            {
                foundEntries.ForEach(e => e.FoundOnLine = -1);
                foundEntries = null;
                compiledSearchInput = null;
                ReflectChangesInFoundList();
            }
            SetStatusText("Nothing has been searched.", Color.FromKnownColor(KnownColor.ControlText));
        }

        public void Find(string logFileName, IEnumerable<PatternItem> patternItems, bool searchDown)
        {
            if (this.logFileName != logFileName || this.findWhatCombo.Text == String.Empty)
            {
                this.ResetSearchResults();
                this.Show(logFileName, patternItems);
            }
            else
            {
                this.Find(searchDown);
            }
        }

        public void Find(bool searchDown)
        {
            LogListViewItem selectedItem = this.context.GetLogItem(GetLogListItemType.Selected);
            if (selectedItem == null)
                return;

            if (logHasBeenChanged || foundEntries == null)
            {
                this.foundEntries = FindItemsMatchingToSearchCriteria();
                logHasBeenChanged = false;
                ReflectChangesInFoundList();
            }

            if (this.foundEntries.Count == 0)
            {
                SetStatusText("Entered text wasn't found.", Color.Red);
            }
            else
            {
                Color statusColor = Color.Green;
                LogEntry logEntry = null;
                int i = foundEntries.IndexOf(selectedItem.LogItem);

                if (i == -1)
                {
                    i = searchDown ? -1 : foundEntries.Count;
                }
                else
                {
                    if (TryHighlightNextOccurenceInMessageDetail())
                        return;
                }

                bool found = false;
                if (searchDown)
                {
                    while (i + 1 < foundEntries.Count)
                    {
                        i++;
                        logEntry = foundEntries[i];
                        if (logEntry.LineInFile > selectedItem.LogItem.LineInFile)
                        {
                            found = true;
                            break;
                        }
                    }
                }
                else
                {
                    while (i - 1 >= 0)
                    {
                        i--;
                        logEntry = foundEntries[i];
                        if (logEntry.LineInFile < selectedItem.LogItem.LineInFile)
                        {
                            found = true;
                            break;
                        }
                    }
                }
                string currentStatusText;
                if (found)
                {
                    context.GoToLogItem(logEntry);
                    currentStatusText = String.Format("Selected {0} of {1}", i + 1, foundEntries.Count);
                    TryHighlightNextOccurenceInMessageDetail();
                }
                else
                {
                    statusColor = Color.DarkOrange;
                    currentStatusText = searchDown ? "Nothing, click on Find prev" : "Nothing, click on Find next";
                }
                SetStatusText(String.Format("Found {0} results.{1}{2}", foundEntries.Count, Environment.NewLine, currentStatusText), statusColor);
            }
        }

        private List<LogEntry> FindItemsMatchingToSearchCriteria()
        {
            Cursor origOwnerCursor = Owner.Cursor;
            Owner.Cursor = Cursors.WaitCursor;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                compiledSearchInput = new CompiledSearchInput(this);

                //Save to recent searches
                if (!this.prevFindWhat.Equals(compiledSearchInput.FindWhat, StringComparison.OrdinalIgnoreCase))
                {
                    this.settings.SearchHistory.AddText(compiledSearchInput.FindWhat);
                    this.LoadRecentTexts();
                }


                List<LogEntry> logEntries = this.context.GetLogEntries();

                List<LogEntry> foundEntriesList = new List<LogEntry>();
                for (int i = 0; i < logEntries.Count; i++)
                {
                    LogEntry logEntry = logEntries[i];
                    bool found =
                            (compiledSearchInput.MatchPatternType(PatternItemType.Date) && SearchText(compiledSearchInput, logEntry.DateText))
                            ||
                            (compiledSearchInput.MatchPatternType(PatternItemType.Thread) && SearchText(compiledSearchInput, logEntry.Thread))
                            ||
                            (compiledSearchInput.MatchPatternType(PatternItemType.Type) && SearchText(compiledSearchInput, logEntry.Type))
                            ||
                            (compiledSearchInput.MatchPatternType(PatternItemType.Class) && SearchText(compiledSearchInput, logEntry.Class))
                            ||
                            (compiledSearchInput.MatchPatternType(PatternItemType.Message) && SearchText(compiledSearchInput, logEntry.Message));

                    if (found)
                    {
                        logEntry.FoundOnLine = i;
                        foundEntriesList.Add(logEntry);
                    }
                }

                return foundEntriesList;

            }
            catch (Exception ex)
            {
                log.Error("Error during search: " + ex.ToString());
                MessageBox.Show(ex.Message, "Error during search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Owner.Cursor = origOwnerCursor;
                this.Cursor = Cursors.Default;
            }
            return new List<LogEntry>();
        }

        private bool TryHighlightNextOccurenceInMessageDetail()
        {
            int selLength;
            int selStart = context.LogMessageEdit.SelectionStart;
            if (context.LogMessageEdit.SelectionLength > 0)
                selStart++;

            selStart = SearchText(this.compiledSearchInput, context.LogMessageEdit.Text, selStart, out selLength);
            if (selStart > -1)
            {
                context.LogMessageEdit.SelectionStart = selStart;
                context.LogMessageEdit.SelectionLength = selLength;
                return true;
            }
            return false;
        }

        private bool SearchText(CompiledSearchInput input, string findWhere)
        {
            if (findWhere == null)
                return false;

            int length;
            return SearchText(input, findWhere, 0, out length) > -1;
        }

        private int SearchText(CompiledSearchInput input, string findWhere, int startIndex, out int length)
        {
            if (input.RegEx != null)
            {
                Match match = input.RegEx.Match(findWhere, startIndex);
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
                length = input.FindWhat.Length;
                return findWhere.IndexOf(input.FindWhat, startIndex, input.StringComparison);
            }
        }

        private void SetStatusText(string text, Color color)
        {
            this.statusLabel.ForeColor = color;
            this.statusLabel.Text = text;
        }

        private void SetVisibilityOfFoundResults(bool visible)
        {
            context.RepaintLogList();
            context.SetMarkersPanelVisibility(visible);
        }

        private void ReflectChangesInFoundList()
        {
            context.RepaintLogList();
            ShowMarkers();
        }

        private void ShowMarkers()
        {
            if (foundEntries == null)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object threadContext)
                {
                    context.ShowMarkers(0, new Dictionary<int, Color>());
                }));
            }
            else
            {
                Color color = Color.FromArgb(0xFF, 0xE4, 0xD0, 0x0A);
                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object threadContext)
                {
                    context.ShowMarkers(context.GetLogEntries().Count, foundEntries.ToDictionary(item => item.FoundOnLine, item => color));
                }));
            }
            markerksUpToDate = true;
        }



        public void SaveSettings()
        {
            this.settings.FindWhat = this.findWhatCombo.Text;
            this.settings.UseRegEx = this.useRegExCheckBox.Checked;
            this.settings.CaseSensitive = this.caseSensitiveCheckBox.Checked;
            this.settings.Docked = this.dockedCheckBox.Checked;
            //Note: Recent search list is updated on each search

            this.settings.Save();
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            Owner.Show();
            base.OnClosing(e);
            SetVisibilityOfFoundResults(false);
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
            this.findNextButton.Enabled = this.findWhatCombo.Text != String.Empty;
            this.findPrevButton.Enabled = this.findWhatCombo.Text != String.Empty;
        }


        private void FindTextDlg_Load(object sender, EventArgs e)
        {
            this.Owner.Resize += Owner_Resize;
            this.Owner.Move += Owner_Resize;
        }

        void Owner_Resize(object sender, EventArgs e)
        {
            if (this.Visible && this.dockedCheckBox.Checked)
                this.Location = context.GetPositionForSearchWindow(this.Width);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FindTextDlg_Deactivate(object sender, EventArgs e)
        {
            this.Opacity = 0.80;
        }

        private void FindTextDlg_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1.0;
        }

        private void findNextButton_Click(object sender, EventArgs e)
        {
            this.Find(true);
        }

        private void findPrevButton_Click(object sender, EventArgs e)
        {
            this.Find(false);
        }


        private void findInCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            this.settings.FindIn = this.findInCombo.SelectedItem.ToString();
            SearchConditionsChanged(sender, e);
        }

        private void SearchConditionsChanged(object sender, EventArgs e)
        {
            this.ResetSearchResults();
            this.UpdateUI();
        }

        private void dockedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (dockedCheckBox.Checked)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Location = context.GetPositionForSearchWindow(this.Width);
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                this.Location = context.GetPositionForSearchWindow(this.Width);
            }
        }

    }
}
