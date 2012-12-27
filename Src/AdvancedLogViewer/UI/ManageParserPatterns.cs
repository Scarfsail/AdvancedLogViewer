using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvancedLogViewer.BL;
using AdvancedLogViewer.BL.ColorHighlight;
using Scarfsail.Common.UI;
using Scarfsail.Common.UI.Controls;
using AdvancedLogViewer.Common.Parser;

namespace AdvancedLogViewer.UI
{
    public delegate void TryLogPatternOnLogFile(LogPattern logPattern);

    public partial class ManageParserPatterns : Form
    {
        private PatternManager patternManager;

        private TryLogPatternOnLogFile tryLogPatternOnCurrentLogFileCallBack;
        private string logFileName;

        private Dictionary<string, string> dateFormatElements = new Dictionary<string, string>()
        {
            {"d", "The day of the month. Single-digit days will not have a leading zero."},
            {"dd", "The day of the month. Single-digit days will have a leading zero."},
            {"ddd", "The abbreviated name of the day of the week, as defined in AbbreviatedDayNames."},
            {"dddd", "The full name of the day of the week, as defined in DayNames."},
            {"M", "The numeric month. Single-digit months will not have a leading zero."},
            {"MM", "The numeric month. Single-digit months will have a leading zero."},
            {"MMM", "The abbreviated name of the month, as defined in AbbreviatedMonthNames."},
            {"MMMM", "The full name of the month, as defined in MonthNames."},
            {"y", "The year without the century. If the year without the century is less than 10, the year is displayed with no leading zero."},
            {"yy", "The year without the century. If the year without the century is less than 10, the year is displayed with a leading zero."},
            {"yyyy", "The year in four digits, including the century."},
            {"gg", "The period or era. This pattern is ignored if the date to be formatted does not have an associated period or era string."},
            {"h", "The hour in a 12-hour clock. Single-digit hours will not have a leading zero."},
            {"hh", "The hour in a 12-hour clock. Single-digit hours will have a leading zero."},
            {"H", "The hour in a 24-hour clock. Single-digit hours will not have a leading zero."},
            {"HH", "The hour in a 24-hour clock. Single-digit hours will have a leading zero."},
            {"m", "The minute. Single-digit minutes will not have a leading zero."},
            {"mm", "The minute. Single-digit minutes will have a leading zero."},
            {"s", "The second. Single-digit seconds will not have a leading zero."},
            {"ss", "The second. Single-digit seconds will have a leading zero."},
            {"f", "The fraction of a second in single-digit precision. The remaining digits are truncated."},
            {"ff", "The fraction of a second in double-digit precision. The remaining digits are truncated."},
            {"fff", "The fraction of a second in three-digit precision. The remaining digits are truncated."},
            {"ffff", "The fraction of a second in four-digit precision. The remaining digits are truncated."},
            {"fffff", "The fraction of a second in five-digit precision. The remaining digits are truncated."},
            {"ffffff", "The fraction of a second in six-digit precision. The remaining digits are truncated."},
            {"fffffff", "The fraction of a second in seven-digit precision. The remaining digits are truncated."},
            {"t", "The first character in the AM/PM designator defined in AMDesignator or PMDesignator, if any."},
            {"tt", "The AM/PM designator defined in AMDesignator or PMDesignator, if any."},
            {"z", "The time zone offset (+ or - followed by the hour only). Single-digit hours will not have a leading zero. For example, Pacific Standard Time is -8."},
            {"zz", "The time zone offset (+ or - followed by the hour only). Single-digit hours will have a leading zero. For example, Pacific Standard Time is -08."},
            {"zzz", "The full time zone offset (+ or - followed by the hour and minutes). Single-digit hours and minutes will have leading zeros. For example, Pacific Standard Time is -08:00."}
        };

        public ManageParserPatterns(TryLogPatternOnLogFile tryLogPatternOnCurrentLogFileCallBack, string logFileName)
        {
            InitializeComponent();
            this.patternManager = new PatternManager();

            this.tryLogPatternOnCurrentLogFileCallBack = tryLogPatternOnCurrentLogFileCallBack;
            this.tryOnCurrentLogButton.Enabled = tryLogPatternOnCurrentLogFileCallBack != null;
            this.viewCurrentLogAsTextButton.Enabled = !String.IsNullOrEmpty(logFileName);
            this.logFileName = logFileName;

            //Bind them into ListBoxes
            this.customPatternsListBox.DataSource = this.patternManager.CustomPatterns;
            if (this.customPatternsListBox.Items.Count == 0)
                this.customPatternsListBox_SelectedIndexChanged(this.customPatternsListBox, null);

            this.systemPatternsListBox.DataSource = this.patternManager.SystemPatterns;

            foreach (var item in LogPattern.PatternTextWithDescription)
            {
                this.patternTextPatternsListView.Items.Add(new ListViewItem(new string[] { item.Key, item.Value }));
            }
            
            foreach (var item in this.dateFormatElements)
            {
                this.dateFormatPatternsListView.Items.Add(new ListViewItem(new string[] { item.Key, item.Value }));
            }

            patternTextPatternsListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            patternTextPatternsListView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            dateFormatPatternsListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            dateFormatPatternsListView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            
        }
        
        
        private void LoadParsersToListBox(List<LogPattern> logPatterns, ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (var logPattern in logPatterns)
            {
                listBox.Items.Add(logPattern);
            }
        }

        private LogPattern GetSelectedItem()
        {
            if (this.customPatternsListBox.SelectedIndex > -1)
                return this.customPatternsListBox.SelectedItem as LogPattern;

            return this.systemPatternsListBox.SelectedItem as LogPattern;
        }

        private void LoadSelectedItem()
        {
            LogPattern item = this.GetSelectedItem();
            if (item != null)
            {
                this.fileMaskEdit.Text = item.FileMask;
                this.patternEdit.Text = item.PatternText;
                this.dateFormatEdit.Text = item.DateTimeFormat;
                this.editSelectedPatternGroupBox.Enabled = true;

                bool enableEdit = this.SelectedItemIsCustom;
                this.fileMaskEdit.Enabled = enableEdit;
                this.patternEdit.Enabled = enableEdit;
                this.dateFormatEdit.Enabled = enableEdit;
                this.patternTextPatternsListView.Enabled = enableEdit;
                this.dateFormatPatternsListView.Enabled = enableEdit;
            }
            else
            {
                this.fileMaskEdit.Text = String.Empty;
                this.patternEdit.Text = String.Empty;
                this.dateFormatEdit.Text = String.Empty;
                this.editSelectedPatternGroupBox.Enabled = false;
            }
        }

        private bool SelectedItemIsCustom
        {
            get
            {
                return this.customPatternsListBox.SelectedIndex > -1;
            }
        }

        private void RefreshCustomPatterns()
        {
            object prevSelected = customPatternsListBox.SelectedItem;
            
            ((CurrencyManager)customPatternsListBox.BindingContext[customPatternsListBox.DataSource]).Refresh();

            if (prevSelected != customPatternsListBox.SelectedItem)
            {
                this.customPatternsListBox_SelectedIndexChanged(this.customPatternsListBox, null);
            }
        }

        private void AddNewCustomLogPattern(LogPattern logPattern)
        {
            this.patternManager.CustomPatterns.Add(logPattern);
            this.RefreshCustomPatterns();
            this.customPatternsListBox.SelectedItem = logPattern;
            this.fileMaskEdit.Focus();
        }

        
        private void okButton_Click(object sender, EventArgs e)
        {
            this.patternManager.SaveCustomPatterns();
        }

        private void fileMaskEdit_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //Check if the file mask doesn't already exists
                /*
                if (this.patternManager.CustomPatterns.Exists(m => m.FileMask.Equals(this.fileMaskEdit.Text, StringComparison.OrdinalIgnoreCase)))
                    throw new Exception("This file mask already exists in custom patterns. File mask has to be unique.");
                
                if (this.patternManager.SystemPatterns.Exists(m => m.FileMask.Equals(this.fileMaskEdit.Text, StringComparison.OrdinalIgnoreCase)))
                    throw new Exception("This file mask already exists in system patterns. File mask has to be unique.");
                */

                //Try to save it into LogPattern item
                this.GetSelectedItem().FileMask = this.fileMaskEdit.Text;
                this.RefreshCustomPatterns();
                fileMaskError.SetError(fileMaskEdit, "");

            }
            catch (Exception ex)
            {
                fileMaskError.SetError(fileMaskEdit, ex.Message);
                e.Cancel = true;
            }
        }

        private void patternEdit_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.GetSelectedItem().PatternText = this.patternEdit.Text;
                patternError.SetError(patternEdit, "");
            }
            catch (Exception ex)
            {
                patternError.SetError(patternEdit, ex.Message);
                e.Cancel = true;
            }
        }

        private void dateFormatEdit_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.GetSelectedItem().DateTimeFormat = this.dateFormatEdit.Text;
                dateFormatError.SetError(dateFormatEdit, "");
            }
            catch (Exception ex)
            {
                dateFormatError.SetError(dateFormatEdit, ex.Message);
                e.Cancel = true;
            }
        }

        private void customPatternsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.customPatternsListBox.SelectedIndex > -1)
                this.systemPatternsListBox.SelectedIndex = -1;
            
            //Enable / disable buttons
            this.removeButton.Enabled = this.customPatternsListBox.SelectedIndex > -1;
            this.moveUpButton.Enabled = this.customPatternsListBox.SelectedIndex > 0;
            this.moveDownButton.Enabled = (this.customPatternsListBox.SelectedIndex > -1) && (this.customPatternsListBox.SelectedIndex < this.customPatternsListBox.Items.Count - 1);
            
            this.LoadSelectedItem();
        }
        
        private void systemPatternsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.systemPatternsListBox.SelectedIndex > -1)
                this.customPatternsListBox.SelectedIndex = -1;

            this.LoadSelectedItem();
        }

        private void addNewButton_Click(object sender, EventArgs e)
        {
            this.AddNewCustomLogPattern(new LogPattern());
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            LogPattern pattern = this.GetSelectedItem();
            if (pattern == null)
                return;

            if (MessageBox.Show(String.Format("Do you want to remove {0} pattern?", pattern), "Remove custom pattern", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.patternManager.CustomPatterns.Remove(pattern);
                this.RefreshCustomPatterns();
            }
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            LogPattern pattern = this.GetSelectedItem();
            if (pattern == null)
                return;

            int index = this.patternManager.CustomPatterns.IndexOf(pattern);
            if (index == 0)
                return;
            this.patternManager.CustomPatterns.RemoveAt(index);

            this.patternManager.CustomPatterns.Insert(index - 1, pattern);

            this.RefreshCustomPatterns();
            this.customPatternsListBox.SelectedItem = pattern;
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            LogPattern pattern = this.GetSelectedItem();
            if (pattern == null)
                return;

            int index = this.patternManager.CustomPatterns.IndexOf(pattern);
            if (index == this.patternManager.CustomPatterns.Count-1)
                return;
            this.patternManager.CustomPatterns.RemoveAt(index);

            this.patternManager.CustomPatterns.Insert(index + 1, pattern);

            this.RefreshCustomPatterns();
            this.customPatternsListBox.SelectedItem = pattern;
        }

        private void createCopyButton_Click(object sender, EventArgs e)
        {
            this.AddNewCustomLogPattern(new LogPattern(this.GetSelectedItem()));
        }

        private void patternTextPatternsListView_DoubleClick(object sender, EventArgs e)
        {
            if (patternTextPatternsListView.SelectedItems.Count == 0)
                return;

            patternEdit.Paste(patternTextPatternsListView.SelectedItems[0].Text);
        }

        private void dateFormatPatternsListView_DoubleClick(object sender, EventArgs e)
        {
            if (dateFormatPatternsListView.SelectedItems.Count == 0)
                return;

            dateFormatEdit.Paste(dateFormatPatternsListView.SelectedItems[0].Text);
        }

        private void tryOnCurrentLogButton_Click(object sender, EventArgs e)
        {
            if (this.tryLogPatternOnCurrentLogFileCallBack != null)
                this.tryLogPatternOnCurrentLogFileCallBack(this.GetSelectedItem());
        }

        private void viewCurrentLogAsTextButton_Click(object sender, EventArgs e)
        {
            ViewLogAsText dlg = new ViewLogAsText();
            dlg.Owner = this;
            dlg.LoadFile(this.logFileName, 10);
            dlg.Show(this);
        }



        
    }
}



