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

namespace AdvancedLogViewer.UI
{
    public partial class ManageHighlights : Form
    {
        public ManageHighlights(ColorHighlightManager colorHighlightManager)
        {
            log.Debug("Creating ManageHighlights form");
            
            InitializeComponent();
            this.colorHighlightManager = colorHighlightManager;
            foreach (var group in colorHighlightManager.HighlightGroups)
            {
                this.groupsComboBox.Items.Add(group);
            }
            this.loading = true;
            this.groupsComboBox.SelectedItem = colorHighlightManager.CurrentGroup;
            this.loading = false;
            log.Debug("ManageHighlights form created");
        }

        private void LoadCurrentGroup()
        {
            log.Debug("Loading current group: "+colorHighlightManager.CurrentGroup.GroupName);
            this.richTextBox.Clear();
            foreach (var highlight in colorHighlightManager.CurrentGroup.Highlights)
            {
                ListViewItem item = new ListViewItem(highlight.TextToHighlight);
                this.richTextBox.SelectionBackColor = highlight.HighlightColor;
                this.richTextBox.SelectionColor = highlight.HighlightTextColor;

                this.richTextBox.AppendText(highlight.TextToHighlight + Environment.NewLine);
            }
            log.Debug("Group loaded");
        }
        
        
        private void okButton_Click(object sender, EventArgs e)
        {
            log.Debug("Saving data...");
            this.SaveCurrentGroup();
            this.colorHighlightManager.Save();
            log.Debug("Data saved...");
        }

        private void SaveCurrentGroup()
        {
            log.Debug("Saving current group: " + colorHighlightManager.CurrentGroup.GroupName);
            this.colorHighlightManager.CurrentGroup.Highlights.Clear();

            this.richTextBox.SelectionLength = 1;
            this.richTextBox.SelectionStart = 0;
            for (int i = 0; i < this.richTextBox.Lines.Length; i++)
            {
                if (String.IsNullOrEmpty(this.richTextBox.Lines[i]))
                    continue;

                ColorHighlightEntry highlight = new ColorHighlightEntry();
                this.richTextBox.SelectionStart = this.richTextBox.GetFirstCharIndexFromLine(i);
                highlight.HighlightColor = this.richTextBox.SelectionBackColor;
                highlight.HighlightTextColor = this.richTextBox.SelectionColor;

                highlight.TextToHighlight = this.richTextBox.Lines[i];
                this.colorHighlightManager.CurrentGroup.Highlights.Add(highlight);
            }
            log.Debug("Group saved");
        }

        private void richTextBox_SelectionChanged(object sender, EventArgs e)
        {
            this.colorPicker.SelectedColor = this.richTextBox.SelectionBackColor;
            this.colorPicker.SelectedForeColor = this.richTextBox.SelectionColor;
        }

        private void colorPicker_SelectedColorChanged(object sender, EventArgs e)
        {
            SetColorForSelectedLine(this.colorPicker.SelectedColor, true);
        }

        private void colorPicker_SelectedForeColorChanged(object sender, EventArgs e)
        {
            SetColorForSelectedLine(this.colorPicker.SelectedForeColor, false);
        }

        private void SetColorForSelectedLine(Color color, bool backgroundColor)
        {
            log.Debug("User changed color");
            if (richTextBox.TextLength == 0)
                return;

            this.richTextBox.SelectionChanged -= this.richTextBox_SelectionChanged;

            int origStart = richTextBox.SelectionStart;
            int origLength = richTextBox.SelectionLength;
            log.DebugFormat("origStart: {0}, origLength: {1}", origStart, origLength);

            int lineNumber = richTextBox.GetLineFromCharIndex(richTextBox.SelectionStart);
            string line = richTextBox.Lines[lineNumber];
            log.DebugFormat("lineNumber: {0}, line: {1}", lineNumber, line);

            richTextBox.SelectionStart = richTextBox.GetFirstCharIndexFromLine(lineNumber);
            richTextBox.SelectionLength = line.Length;

            log.DebugFormat("SelStart: {0}, SelLength: {1}", richTextBox.SelectionStart, richTextBox.SelectionLength);

            if (backgroundColor)
                richTextBox.SelectionBackColor = color;
            else
                richTextBox.SelectionColor = color;

            log.Debug("Changing selection back");
            richTextBox.SelectionStart = origStart;
            richTextBox.SelectionLength = origLength;

            this.richTextBox.SelectionChanged += new EventHandler(this.richTextBox_SelectionChanged);
        }


        private void addGroupButton_Click(object sender, EventArgs e)
        {
            log.Debug("addGroupButton_Click");
            using (InputBox dlg = new InputBox("Change group name", "Enter group name:"))
            {
                ColorHighlightGroup item = new ColorHighlightGroup();
                item.InitDefaultValues();
                dlg.Value = item.GroupName;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    item.GroupName = dlg.Value;
                    this.colorHighlightManager.HighlightGroups.Add(item);
                    this.groupsComboBox.Items.Add(item);
                    this.groupsComboBox.SelectedItem = item;
                    this.groupsComboBox.Focus();
                }
            }
        }

        private void removeGroupButton_Click(object sender, EventArgs e)
        {
            log.Debug("removeGroupButton_Click");
            if (this.colorHighlightManager.HighlightGroups.Count == 1)
            {
                MessageBox.Show("You can't delete last group.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ColorHighlightGroup item = (ColorHighlightGroup)this.groupsComboBox.SelectedItem;
                int prevIdx = this.groupsComboBox.SelectedIndex;
                this.colorHighlightManager.HighlightGroups.Remove(item);
                this.groupsComboBox.Items.Remove(item);
                this.groupsComboBox.SelectedItem = groupsComboBox.Items[prevIdx -1];
            }
        }

        private void renameGroupButton_Click(object sender, EventArgs e)
        {
            log.Debug("renameGroupButton_Click");
            ColorHighlightGroup item = (ColorHighlightGroup)this.groupsComboBox.SelectedItem;
            using (InputBox dlg = new InputBox("Change group name", "Enter group name:", item.GroupName))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    item.GroupName = dlg.Value;
                    this.groupsComboBox.Items[this.groupsComboBox.SelectedIndex] = item;
                }
            }
        }

        private void groupsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            log.Debug("groupsComboBox_SelectedIndexChanged");
            if (!loading)
                this.SaveCurrentGroup();
            this.colorHighlightManager.CurrentGroup = (ColorHighlightGroup)groupsComboBox.SelectedItem;
            this.LoadCurrentGroup();
        }

        private void ManageHighlights_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
                this.colorHighlightManager.ReloadFromFile();
        }

        ColorHighlightManager colorHighlightManager;
        private bool loading = false;
        private static Scarfsail.Logging.Log log = new Scarfsail.Logging.Log();





    }
}
