using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvancedLogViewer.UI.Items;
using AdvancedLogViewer.BL.Comm.Messages;

namespace AdvancedLogViewer.UI.Controls
{
    public partial class LogViewerControl : UserControl
    {
        private static Scarfsail.Logging.Log log = new Scarfsail.Logging.Log();

        public LogViewerControl()
        {
            InitializeComponent();
        }

        private void logListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (this.logParser == null)
                return;

            ColumnHeader column = logListView.Columns[e.Column];

            this.showFilterPopup(column);
        }

        private void logListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            this.SetSizes();
        }

        private void logListView_DoubleClick(object sender, EventArgs e)
        {
            //TODO: Bookmark click
        }

        private void logListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void logListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawDefault = true;
            }
            else
            {
                Rectangle recBounds = new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 2, e.Bounds.Width - 1, e.Bounds.Height);
                if (settings.MainFormUI.TrimClassColumnFromLeft && (e.ColumnIndex == this.classColumn.Index))
                {
                    if (e.Item.Selected)
                    {
                        if (e.Item.ListView.Focused)
                        {
                            e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                            TextRenderer.DrawText(e.Graphics, e.Item.SubItems[e.ColumnIndex].Text, e.Item.ListView.Font, recBounds, Color.FromKnownColor(KnownColor.HighlightText), TextFormatFlags.Right | TextFormatFlags.NoPrefix);
                        }
                        else
                        {
                            e.Graphics.FillRectangle(SystemBrushes.ButtonFace, e.Bounds);
                            TextRenderer.DrawText(e.Graphics, e.Item.SubItems[e.ColumnIndex].Text, e.Item.ListView.Font, recBounds, Color.FromKnownColor(KnownColor.WindowText), TextFormatFlags.Right | TextFormatFlags.NoPrefix);
                        }
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(e.Item.BackColor), e.Bounds);
                        TextRenderer.DrawText(e.Graphics, e.Item.SubItems[e.ColumnIndex].Text, e.Item.ListView.Font, recBounds, e.Item.ForeColor, TextFormatFlags.Right | TextFormatFlags.NoPrefix);
                    }
                }
                else
                {
                    if (e.Item.Selected)
                    {
                        if (e.Item.ListView.Focused)
                        {
                            e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                            TextRenderer.DrawText(e.Graphics, e.Item.SubItems[e.ColumnIndex].Text, e.Item.ListView.Font, recBounds, Color.FromKnownColor(KnownColor.HighlightText), TextFormatFlags.WordEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix);
                        }
                        else
                        {
                            e.Graphics.FillRectangle(SystemBrushes.ButtonFace, e.Bounds);
                            TextRenderer.DrawText(e.Graphics, e.Item.SubItems[e.ColumnIndex].Text, e.Item.ListView.Font, recBounds, Color.FromKnownColor(KnownColor.WindowText), TextFormatFlags.WordEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix);
                        }
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(e.Item.BackColor), e.Bounds);
                        TextRenderer.DrawText(e.Graphics, e.Item.SubItems[e.ColumnIndex].Text, e.Item.ListView.Font, recBounds, e.Item.ForeColor, TextFormatFlags.WordEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix);
                    }
                }
            }
        }

        private void logListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //Unselect more than 2 selected items
            if (logListView.SelectedIndices.Count > 2)
            {
                this.prevSelectedListItem.Selected = false;
            }

            RefreshMessageDetail(e.Item as LogListViewItem, false);

            if (e.IsSelected)
                this.prevSelectedListItem = e.Item;


            if (e.IsSelected && e.Item != null)
            {
                foreach (Guid id in this.synchronizeAnotherLogs)
                {
                    this.GoToSameTimeInAnotherLog(id);
                }
            }

            if (e.IsSelected && logListView.SelectedIndices.Count == 2 && this.logParser.DateIsParsed)
            {
                this.timeSpanBetweenTwoItems.Visible = true;
                DateTime date1 = ((LogListViewItem)logListView.Items[logListView.SelectedIndices[0]]).LogItem.Date;
                DateTime date2 = ((LogListViewItem)logListView.Items[logListView.SelectedIndices[1]]).LogItem.Date;
                TimeSpan timeSpan = date1 > date2 ? date1 - date2 : date2 - date1;
                this.timeSpanBetweenTwoItems.Text = "Time span: " + String.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
            }
            else
            {
                this.timeSpanBetweenTwoItems.Visible = false;
            }

            if (!lastChangeReaded)
                SetChangeReadedStatus(e.Item);
        }

        private void logListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            try
            {
                e.Item = new LogListViewItem(this.logEntries.ElementAt(e.ItemIndex), this.enableHighlightsButton.Checked ? this.ColorHighlightManager.CurrentGroup : null);
            }
            catch (Exception ex)
            {
                ShowAndLogError("Exception while retrieving virtual item: " + ex.ToString());

            }
        }

        private void logListView_VirtualItemsSelectionRangeChanged(object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                if (logListView.SelectedIndices.Count > 1)
                {
                    for (int i = this.logListView.SelectedIndices.Count - 2; i > 0; i--)
                    {
                        this.logListView.Items[this.logListView.SelectedIndices[i]].Selected = false;
                    }

                    ListViewItem item = this.logListView.Items[e.EndIndex];
                    this.logListView_ItemSelectionChanged(this.logListView, new ListViewItemSelectionChangedEventArgs(item, item.Index, true));
                }
            }
        }

        private void markerPanel_Click(object sender, EventArgs e)
        {
            log.Debug("Marker panel click");
            this.GoToLogItem(e.LineNumber, true);
        }

        private void logMessageEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                logMessageEdit.SelectAll();
                e.Handled = true;
            }
        }

        private void setAsIncludeFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetSelectedMessageAsFilter(false, false);
        }

        private void setAsExcludeFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetSelectedMessageAsFilter(false, true);
        }

        private void addAsIncludeFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetSelectedMessageAsFilter(true, false);
        }

        private void addAsExcludeFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetSelectedMessageAsFilter(true, true);
        }

        private void SetSelectedMessageAsFilter(bool addToExisting, bool exclude)
        {
            if ((logMessageEdit.Text == string.Empty) || (this.logMessageEdit.SelectedText == string.Empty))
            {
                MessageBox.Show("Please select text which should be added to message filter.", "Select text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string filterItem = this.logMessageEdit.SelectedText;


            List<string> list;
            if (addToExisting)
                list = this.FilterManager.CurrentFilter.Messages.TextLines.ToList();
            else
                list = new List<string>();

            if (exclude)
                list.Insert(0, '~' + filterItem);
            else
                list.Add(filterItem);

            this.FilterManager.CurrentFilter.Messages.Enabled = true;
            this.FilterManager.CurrentFilter.Messages.SaveTextLines(list);

            this.enableFiltersButton.Checked = true;
            this.settings.MainFormUI.EnableFilter = this.enableFiltersButton.Checked;

            this.FilterManager.Save();
            this.ShowLoadedLog(false);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((logMessageEdit.Text == string.Empty) || (this.logMessageEdit.SelectedText == string.Empty))
            {
                MessageBox.Show("Please select text which you want to copy into clipboard.", "Select text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Clipboard.SetText(logMessageEdit.SelectedText);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.logMessageEdit.SelectAll();
        }

        private void logViewContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (this.GetSelectedListItem() == null)
            {
                e.Cancel = true;
                return;
            }

            //Synchronization with another LogViewers

            //Remove current instaces from menu
            for (int i = this.goToSameTimeInAnotherLogMenuItem.DropDownItems.Count - 1; i > 1; i--)
            {
                this.goToSameTimeInAnotherLogMenuItem.DropDownItems.RemoveAt(i);
            }

            for (int i = this.synchronizeAnotherLogToolStripMenuItem.DropDownItems.Count - 1; i > 1; i--)
            {
                this.synchronizeAnotherLogToolStripMenuItem.DropDownItems.RemoveAt(i);
            }


            //Get other instances of LogViewer
            List<LogViewerInstance> instances = this.CommManager.GetListOfOtherInstances().Where(lvi => lvi.LogFileName != String.Empty).ToList();


            //Check currently sychronized instances, if doesn't exits, remove it from synchronization list
            for (int i = this.synchronizeAnotherLogs.Count - 1; i >= 0; i--)
            {
                if (!instances.Exists(instance => instance.ID == this.synchronizeAnotherLogs[i]))
                    this.synchronizeAnotherLogs.RemoveAt(i);
            }

            //Populate menu items
            foreach (var instance in instances)
            {
                //Go to
                LogViewerInstanceToolStripItem menuItem = new LogViewerInstanceToolStripItem(instance);
                menuItem.Click += new EventHandler(goToItemInAnotherLogMenuItem_Click);
                this.goToSameTimeInAnotherLogMenuItem.DropDownItems.Add(menuItem);

                //Synchronize
                menuItem = new LogViewerInstanceToolStripItem(instance);
                menuItem.Click += new EventHandler(synchronizeAnotherLogMenuItem_Click);
                menuItem.Checked = this.synchronizeAnotherLogs.IndexOf(instance.ID) > -1;
                this.synchronizeAnotherLogToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }

        private void synchronizeAnotherLogMenuItem_Click(object sender, EventArgs e)
        {
            LogViewerInstance instance = ((LogViewerInstanceToolStripItem)sender).LogInstance;

            if (this.synchronizeAnotherLogs.IndexOf(instance.ID) > -1)
            {
                this.synchronizeAnotherLogs.Remove(instance.ID);
            }
            else
            {
                this.synchronizeAnotherLogs.Add(instance.ID);
                this.GoToSameTimeInAnotherLog(instance.ID);
            }
        }

        private void goToItemInAnotherLogMenuItem_Click(object sender, EventArgs e)
        {
            this.GoToSameTimeInAnotherLog(((LogViewerInstanceToolStripItem)sender).LogInstance.ID);
        }

        private void GoToSameTimeInAnotherLog(Guid anotherLogID)
        {
            LogListViewItem selectedItem = GetSelectedListItem();
            if (selectedItem == null)
                return;

            this.CommManager.GoToTimeInAnotherLog(anotherLogID, selectedItem.LogItem.Date);
        }

        private void openLogAndJumpToTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lastGoToDateFile))
            {
                this.openFileDialog.InitialDirectory = Path.GetDirectoryName(lastGoToDateFile);
            }
            else if (!String.IsNullOrEmpty(this.fileName))
                this.openFileDialog.InitialDirectory = Path.GetDirectoryName(this.fileName);


            if (this.openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.lastGoToDateFile = this.openFileDialog.FileName;
                Process.Start(Application.ExecutablePath, String.Format("{0}{1}{0} {0}{2}{0}", '"', this.openFileDialog.FileName, GetSelectedListItem().LogItem.Date.ToString(CommManager.CommDateFormat)));
            }
        }

        private void openLogAndSynchronizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("Priority: low");
        }

        private void openInExternalTextEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogListViewItem item = GetSelectedListItem();
            if (item == null)
                return;
            OpenLogFileInTextEditor(item.LogItem.LineInFile);
        }


        private void SetSizes()
        {
            if (resizingColumns)
                return;

            resizingColumns = true;

            log.Debug("Setting sizes");
            this.SuspendLayout();

            int left = 1;
            const int space = 0;

            dateColumn.Tag = left;
            left += space + dateColumn.Width;


            if (this.threadColumn.ListView != null)
            {
                threadColumn.Tag = left;
                left += space + threadColumn.Width;
            }

            if (this.typeColumn.ListView != null)
            {
                typeColumn.Tag = left;
                left += space + typeColumn.Width;
            }

            if (this.classColumn.ListView != null)
            {
                classColumn.Tag = left;
                left += space + classColumn.Width;
            }

            if (this.messageColumn.ListView != null)
            {
                messageColumn.Tag = left;
                messageColumn.Width = this.logListView.Width - left - SystemInformation.VerticalScrollBarWidth - 5;
            }

            resizingColumns = false;
            this.ResumeLayout(false);
        }

        private LogListViewItem GetSelectedListItem()
        {
            return this.GetLogListItem(GetLogListItemType.Selected);
        }

        private LogListViewItem GetLogListItem(GetLogListItemType type)
        {
            int idx;
            switch (type)
            {
                case GetLogListItemType.First:
                    if (logListView.Items.Count == 0)
                        idx = -1;
                    else
                        idx = 0;
                    break;
                case GetLogListItemType.Last:
                    idx = logListView.Items.Count - 1;
                    break;
                case GetLogListItemType.Selected:
                    if (logListView.SelectedIndices.Count == 0)
                        idx = -1;
                    else
                        idx = logListView.SelectedIndices[logListView.SelectedIndices.Count - 1];
                    break;
                default:
                    throw new NotImplementedException(String.Format("GetLogItemType: {0} isn't implemented.", type));
            }

            if (idx < 0 || idx >= this.logListView.VirtualListSize || this.logEntries.Count == 0)
                return null;

            if (idx >= this.logEntries.Count)
                idx = this.logEntries.Count - 1;

            return logListView.Items[idx] as LogListViewItem;
        }

        private void RefreshMessageDetail(LogListViewItem listItem, bool forceRefresh)
        {
            if (listItem == null)
            {
                logMessageEdit.Text = String.Empty;
                currentItemStatus.Text = String.Empty;
                currentLineStatus.Text = String.Empty;
                return;
            }
            if (logMessageEdit.Visible)
            {
                if (forceRefresh || prevSelectedListItem == null || prevSelectedListItem.Index != listItem.Index)
                {
                    LogEntry logEntry = listItem.LogItem;
                    logMessageEdit.Text = "";
                    logMessageEdit.SelectionColor = SystemColors.GrayText;
                    logMessageEdit.AppendText(logParser.GetFormattedMessageDetailHeader(logEntry));
                    logMessageEdit.SelectionColor = SystemColors.WindowText;
                    logMessageEdit.AppendText(logEntry.Message);


                    if (settings.MainFormUI.EnableHighlights)
                        ColorHighlightManager.CurrentGroup.HighlightTextInMessageDetail(logMessageEdit);

                    logMessageEdit.SelectionStart = 0;
                    logMessageEdit.SelectionLength = 0;
                }

            }
            currentItemStatus.Text = "Current item: " + (listItem.Index + 1).ToString();
            currentLineStatus.Text = "Line: " + listItem.LogItem.LineInFile;
        }

    }
}
