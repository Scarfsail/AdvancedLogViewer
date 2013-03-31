using AdvancedLogViewer.BL.Filters;
using AdvancedLogViewer.BL.Settings;
using AdvancedLogViewer.Common.Parser;
using AdvancedLogViewer.Common.Plugins;
using AdvancedLogViewer.Properties;
using AdvancedLogViewer.UI.Controls.Filters;
using AdvancedLogViewer.UI.Items;
using Scarfsail.Common.UI.Shortcuts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvancedLogViewer.UI.Controls
{
    public partial class LogListView : MyListView, ILogViewControl
    {
        private static Scarfsail.Logging.Log log = new Scarfsail.Logging.Log();

        private bool resizingColumns = false;
        private ILogListViewOwner owner;
        private LogEntry[] bookmarks = new LogEntry[9];

        public LogListView()
        {
            this.InitializeComponent();
            this.LogTypeColors = new Color[Enum.GetValues(typeof(LogType)).Length];
            //Get icons and colors
            foreach (LogType logType in Enum.GetValues(typeof(LogType)))
            {
                switch (logType)
                {
                    case LogType.VERBOSE:
                        this.logImageList.Images.Add(logType.ToString(), Resources.LogLevel_Verbose);
                        this.LogTypeColors[(int)logType] = Color.Green;
                        break;
                    case LogType.DEBUG:
                        this.logImageList.Images.Add(logType.ToString(), Resources.LogLevel_Debug);
                        this.LogTypeColors[(int)logType] = Color.Gray;
                        break;
                    case LogType.INFO:
                        this.logImageList.Images.Add(logType.ToString(), Resources.LogLevel_Info);
                        this.LogTypeColors[(int)logType] = Color.Blue;
                        break;
                    case LogType.WARN:
                        this.logImageList.Images.Add(logType.ToString(), Resources.LogLevel_Warn);
                        this.LogTypeColors[(int)logType] = Color.Orange;
                        break;
                    case LogType.ERROR:
                        this.logImageList.Images.Add(logType.ToString(), Resources.LogLevel_Error);
                        this.LogTypeColors[(int)logType] = Color.Red;
                        break;
                    case LogType.FATAL:
                        this.logImageList.Images.Add(logType.ToString(), Resources.LogLevel_Fatal);
                        this.LogTypeColors[(int)logType] = Color.Red;
                        break;
                    case LogType.TRACE:
                        this.logImageList.Images.Add(logType.ToString(), Resources.LogLevel_Trace);
                        this.LogTypeColors[(int)logType] = Color.Green;
                        break;
                    case LogType.UNKNOWN:
                    case LogType.NONE:
                        break;
                    default:
                        throw new Exception("Unsupported log type: " + logType.ToString());
                }
            }
            this.logImageList.Images.Add("ALL", Resources.LogLevel_All);

        }

        public Color[] LogTypeColors { get; private set; }

        public void Init(ILogListViewOwner owner)
        {
            this.owner = owner;
        }


        public void SetColumnsVisibility(LogParser logParser)
        {
            log.Debug("Setting columns visibility");
            if (!logParser.LogPattern.ContainsThread)
                this.Columns.Remove(threadColumn);
            else if (threadColumn.ListView == null)
                this.Columns.Insert(1, threadColumn);

            if (!logParser.LogPattern.ContainsType)
                this.Columns.Remove(typeColumn);
            else if (typeColumn.ListView == null)
                this.Columns.Insert(threadColumn.ListView == null ? 1 : 2, typeColumn);

            if (!logParser.LogPattern.ContainsClass)
                this.Columns.Remove(classColumn);
            else if (classColumn.ListView == null)
                this.Columns.Insert(this.Columns.Count - 1, classColumn);
        }

        public void SetColumnSizes()
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
                messageColumn.Width = this.Width - left - SystemInformation.VerticalScrollBarWidth - 5;
            }

            resizingColumns = false;
            this.ResumeLayout(false);
        }

        public void ToggleOrGotoBookmark(int bookmarkNumber)
        {
            if (this.bookmarks[bookmarkNumber] == null || this.bookmarks[bookmarkNumber] == this.GetSelectedListItem().LogItem)
                this.ToggleBookmark(bookmarkNumber);
            else
                this.GotoBookmark(bookmarkNumber);
        }

        public bool SetFirstEmptyBookmark()
        {
            for (int i = 1; i <= 9; i++)
            {
                if (this.bookmarks[i] == null)
                {
                    this.ToggleBookmark(i);
                    return true;
                }
            }
            MessageBox.Show("There are no free bookmarks.", "No free bookmarks", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        public void ShowFilterPopup(ColumnHeader column)
        {
            LogParser logParser = owner.LogParser;
            if (logParser == null)
                return;

            LogEntry selectedLogEntry = this.GetSelectedListItem() == null ? null : this.GetSelectedListItem().LogItem;

            if (column == dateColumn)
            {
                ShowPopupFilterEdit<FilterSettingsDateTime, FilterEntry.FilterItemDate, DateTime>(owner.FilterManager.CurrentFilter.DateTimeRange, selectedLogEntry != null ? selectedLogEntry.Date : DateTime.MinValue, column, null);
                return;
            }
            if (column == threadColumn)
            {
                ShowPopupFilterEdit<FilterSettingsText, FilterEntry.FilterItemText, string>(owner.FilterManager.CurrentFilter.Threads, selectedLogEntry != null ? selectedLogEntry.Thread : String.Empty, column, owner.GetDistinctValues.Threads);
                return;
            }
            if (column == typeColumn)
            {
                ShowPopupFilterEdit<FilterSettingsText, FilterEntry.FilterItemText, string>(owner.FilterManager.CurrentFilter.Types, selectedLogEntry != null ? selectedLogEntry.Type : String.Empty, column, owner.GetDistinctValues.Types);
                return;
            }
            if (column == classColumn)
            {
                ShowPopupFilterEdit<FilterSettingsText, FilterEntry.FilterItemText, string>(owner.FilterManager.CurrentFilter.Classes, selectedLogEntry != null ? selectedLogEntry.Class : String.Empty, column, owner.GetDistinctValues.Classes);
                return;
            }
            if (column == messageColumn)
            {
                ShowPopupFilterEdit<FilterSettingsMessage, FilterEntry.FilterItemMessage, string>(owner.FilterManager.CurrentFilter.Messages, selectedLogEntry != null ? selectedLogEntry.Message : String.Empty, column, null);
                return;
            }
        }

        private void ShowPopupFilterEdit<TControl, TItem, TContentType>(TItem filterItem, TContentType currentItemValue, ColumnHeader column, Func<List<string>> getDistinctValues)
            where TControl : FilterSettingsBaseControl<TItem, TContentType>, new()
            where TItem : FilterEntry.FilterItem
        {

            Point point = column.ListView.PointToScreen(new Point((int)column.Tag, 23));
            var dlg = new FilterPopup<TControl, TItem, TContentType>(filterItem, currentItemValue, column.Text.TrimEnd('*'), this.owner.Form, getDistinctValues);
            dlg.Left = point.X;
            dlg.Top = point.Y;
            dlg.Show(this);
            dlg.FormClosed += new FormClosedEventHandler(filterPopupDialog_FormClosed);
        }

        private void filterPopupDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)sender;
            if (frm.DialogResult == DialogResult.OK)
            {

                FilterEntry.FilterItem filterItem = ((IFilterPopup)frm).GetFilterItem();

                if (filterItem.GetType() != typeof(FilterEntry.FilterItemDate))
                {
                    if (!owner.FiltersEnabled)
                    {
                        if (filterItem != owner.FilterManager.CurrentFilter.Classes)
                            owner.FilterManager.CurrentFilter.Classes.Enabled = false;
                        if (filterItem != owner.FilterManager.CurrentFilter.Messages)
                            owner.FilterManager.CurrentFilter.Messages.Enabled = false;
                        if (filterItem != owner.FilterManager.CurrentFilter.Threads)
                            owner.FilterManager.CurrentFilter.Threads.Enabled = false;
                        if (filterItem != owner.FilterManager.CurrentFilter.Types)
                            owner.FilterManager.CurrentFilter.Types.Enabled = false;

                        owner.FiltersEnabled = true;
                        owner.Settings.MainFormUI.EnableFilter = owner.FiltersEnabled;
                    }
                }

                owner.FilterManager.Save();
                owner.ShowLoadedLog(false, true);
            }
        }

        public void IndicateCurrentFiltersInColumnHeaders()
        {
            char filterChar = '*';

            dateColumn.Text = dateColumn.Text.TrimEnd(filterChar);
            threadColumn.Text = threadColumn.Text.TrimEnd(filterChar);
            typeColumn.Text = typeColumn.Text.TrimEnd(filterChar);
            classColumn.Text = classColumn.Text.TrimEnd(filterChar);
            messageColumn.Text = messageColumn.Text.TrimEnd(filterChar);

            FilterEntry filter = owner.FilterManager.CurrentFilter;
            if (owner.FiltersEnabled || owner.FilterManager.CurrentFilter.DateTimeRange.Enabled)
            {

                if (filter.DateTimeRange.Enabled)
                    dateColumn.Text += filterChar;

                if (owner.FiltersEnabled)
                {
                    if (filter.Threads.Enabled && filter.Threads.Items.Count > 0)
                        threadColumn.Text += filterChar;

                    if (filter.Types.Enabled && filter.Types.Items.Count > 0)
                        typeColumn.Text += filterChar;

                    if (filter.Classes.Enabled && filter.Classes.Items.Count > 0)
                        classColumn.Text += filterChar;

                    if (filter.Messages.Enabled && filter.Messages.GetItemsWithColorHighlights(owner.ColorHighlightManager.CurrentGroup.Highlights).Count > 0)
                    {
                        messageColumn.Text += filterChar;
                    }
                }
            }
        }

        public void RegisterKeyboardShortcuts(ShortcutManager shortcutManager)
        {
            shortcutManager.Add(new ShortcutItem(Keys.D, () => this.ShowFilterPopup(dateColumn), "Show filter popup for Date column"));
            shortcutManager.Add(new ShortcutItem(Keys.H, () => this.ShowFilterPopup(threadColumn), "Show filter popup for tHread column"));
            shortcutManager.Add(new ShortcutItem(Keys.T, () => this.ShowFilterPopup(typeColumn), "Show filter popup for Type column"));
            shortcutManager.Add(new ShortcutItem(Keys.C, () => this.ShowFilterPopup(classColumn), "Show filter popup for Class column"));
            shortcutManager.Add(new ShortcutItem(Keys.M, () => this.ShowFilterPopup(messageColumn), "Show filter popup for Message column"));

        }

        public void JumpToSameNearestType(bool down)
        {
            LogListViewItem item = this.GetSelectedListItem();
            if (item == null)
                return;
            LogEntry selectedEntry = item.LogItem;
            int selectedIdx = owner.LogEntries.IndexOf(selectedEntry);

            if (selectedIdx < 0)
                return;

            if (down)
            {
                for (int i = selectedIdx + 1; i < owner.LogEntries.Count; i++)
                {
                    LogEntry entry = owner.LogEntries[i];
                    if (entry.LogType == selectedEntry.LogType)
                    {
                        this.GoToLogItem(entry);
                        break;
                    }
                }
            }
            else
            {
                for (int i = selectedIdx - 1; i > -1; i--)
                {
                    LogEntry entry = owner.LogEntries[i];
                    if (entry.LogType == selectedEntry.LogType)
                    {
                        this.GoToLogItem(entry);
                        break;
                    }
                }
            }
        }


        public Image GetImageForLogLevel(string logLevel)
        {
            int imgIdx;
            imgIdx = this.logImageList.Images.IndexOfKey(logLevel);
            if (imgIdx > -1)
                return logImageList.Images[imgIdx];
            else
                return Resources.logLevel_Unknown;
        }



        public void GoToLine(int line)
        {
            log.Debug("Go to line: " + line.ToString());
            if (this.VirtualListSize == 0)
                return;

            LogEntry entry = owner.LogEntries.Find(l => l.LineInFile >= line);

            if (entry != null)
                this.GoToLogItem(entry);
            else
                this.GoToLogItem(owner.LogEntries.Last());
        }


        public bool GoToLogItem(int index, bool selectOnlyOneItem)
        {
            log.Debug("Go to log item: " + index.ToString());
            if (this.VirtualListSize == 0)
                return false;

            if (index >= this.VirtualListSize)
                index = this.VirtualListSize - 1;

            if (index >= owner.LogEntries.Count)
                index = owner.LogEntries.Count - 1;

            if (selectOnlyOneItem)
            {
                while (this.SelectedIndices.Count > 0)
                {
                    this.Items[this.SelectedIndices[0]].Selected = false;
                }
            }

            this.Items[index].Selected = true;
            this.Items[index].Focused = true;
            this.EnsureVisible(index);
            return true;
        }

        public void GoToLogItem(DateTime dateTime, bool showErrorWhenNotFound)
        {
            log.Debug("Go to log item: " + dateTime.ToString());

            LogEntry logEntry = owner.LogEntries.FirstOrDefault(l => l.Date >= dateTime);

            if (logEntry != null)
            {
                this.GoToLogItem(logEntry);
            }
            else
            {
                if (showErrorWhenNotFound)
                    MessageBox.Show(String.Format("Item with date: {0} or higher doesn't exists in current list.", dateTime), "Item not found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public bool GoToLogItem(LogEntry logEntry)
        {
            int idx = owner.LogEntries.IndexOf(logEntry);
            if (idx == -1)
                return false;

            this.GoToLogItem(idx, true);
            return true;
        }

        public void GotoLogItemWithDialog()
        {
            int itemNumber = 1;
            DateTime dateTime = DateTime.Now;
            var selectedItem = this.GetSelectedListItem();

            if (selectedItem != null)
            {
                itemNumber = selectedItem.Index + 1;
                if (owner.LogParser.DateIsParsed && selectedItem.LogItem.Date != DateTime.MinValue)
                    dateTime = selectedItem.LogItem.Date;
            }

            using (GoToItem dlg = new GoToItem(itemNumber, dateTime, owner.LogParser.DateIsParsed))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    if (dlg.DateTimeSelected)
                    {
                        this.GoToLogItem(dlg.DateTime, true);
                    }
                    else
                    {
                        this.GoToLogItem(dlg.ItemNumber - 1, true);
                    }

                    this.Focus();
                }
            }

        }

        public void GotoBookmark(int bookmarkNumber)
        {
            if (bookmarkNumber < 1 || bookmarkNumber > this.bookmarks.Length)
                throw new ArgumentOutOfRangeException("bookmarkNumber", bookmarkNumber, "bookmarkNumber must be between 1 and " + this.bookmarks.Length);

            LogEntry logEntry = this.bookmarks[bookmarkNumber];

            if (logEntry == null)
            {
                MessageBox.Show("Bookmark number: " + bookmarkNumber.ToString() + " is not specified." + Environment.NewLine + "Press CTRL + SHIFT + number to set the bookmark on current line", "Bookmark not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!this.GoToLogItem(logEntry))
                    MessageBox.Show("Bookmark item isn't visible now. Change the filter to make bookmarked item visible and then you can goto the item.", "Bookmark item not visible", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ToggleBookmark(int bookmarkNumber)
        {
            if (bookmarkNumber < 1 || bookmarkNumber > this.bookmarks.Length)
                throw new ArgumentOutOfRangeException("bookmarkNumber", bookmarkNumber, "bookmarkNumber must be between 1 and " + this.bookmarks.Length);

            var selectedItem = this.GetSelectedListItem();
            if (selectedItem == null)
                return;

            bool resetBookmark = (selectedItem.LogItem.Bookmark == bookmarkNumber);

            if (this.bookmarks[bookmarkNumber] != null)
            {
                owner.SetBookmarkMenuItemText(bookmarkNumber, String.Empty);
                this.bookmarks[bookmarkNumber].Bookmark = 0;
                this.bookmarks[bookmarkNumber] = null;
            }

            if (selectedItem.LogItem.Bookmark > 0)
            {
                owner.SetBookmarkMenuItemText(selectedItem.LogItem.Bookmark, String.Empty);
                this.bookmarks[selectedItem.LogItem.Bookmark] = null;
                selectedItem.LogItem.Bookmark = 0;
            }

            if (!resetBookmark)
            {
                owner.SetBookmarkMenuItemText(bookmarkNumber, selectedItem.LogItem.DateText);
                selectedItem.LogItem.Bookmark = bookmarkNumber;
                this.bookmarks[bookmarkNumber] = selectedItem.LogItem;
            }
            this.Refresh();
        }

        internal LogListViewItem GetSelectedListItem()
        {
            return this.GetLogListItem(GetLogListItemType.Selected);
        }

        internal LogListViewItem GetLogListItem(GetLogListItemType type)
        {
            int idx;
            switch (type)
            {
                case GetLogListItemType.First:
                    if (this.Items.Count == 0)
                        idx = -1;
                    else
                        idx = 0;
                    break;
                case GetLogListItemType.Last:
                    idx = this.Items.Count - 1;
                    break;
                case GetLogListItemType.Selected:
                    if (this.SelectedIndices.Count == 0)
                        idx = -1;
                    else
                        idx = this.SelectedIndices[this.SelectedIndices.Count - 1];
                    break;
                default:
                    throw new NotImplementedException(String.Format("GetLogItemType: {0} isn't implemented.", type));
            }

            List<LogEntry> logEntries = owner.LogEntries;
            if (idx < 0 || idx >= this.VirtualListSize || logEntries.Count == 0)
                return null;

            if (idx >= logEntries.Count)
                idx = logEntries.Count - 1;

            return this.Items[idx] as LogListViewItem;
        }

        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);

            if (owner.LogParser == null)
                return;

            ColumnHeader column = this.Columns[e.Column];

            this.ShowFilterPopup(column);

        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            base.OnDrawColumnHeader(e);
            e.DrawDefault = true;
        }



        private static readonly Color colorHighlightText = Color.FromKnownColor(KnownColor.HighlightText);
        private static readonly Color colorWindowText = Color.FromKnownColor(KnownColor.WindowText);
        private static readonly TextFormatFlags flagsRightNoPrefix = TextFormatFlags.Right | TextFormatFlags.NoPrefix;
        private static readonly TextFormatFlags flagsWordEllSingleLineNoPrefix = TextFormatFlags.WordEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix;

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            base.OnDrawSubItem(e);

            if (e.ColumnIndex == 0)
            {
                e.DrawDefault = true;
            }
            else
            {
                Color colorOwnHighlightText = colorHighlightText;
                Color colorOwnWindowText = colorWindowText;

                if ((e.Item as LogListViewItem).HighlightSearchResult)
                {
                    colorOwnHighlightText = Color.Orange;
                    colorOwnWindowText = Color.Red;
                }

                Rectangle recBounds = new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 2, e.Bounds.Width - 1, e.Bounds.Height);
                if (owner.Settings.MainFormUI.TrimClassColumnFromLeft && (e.ColumnIndex == this.classColumn.Index))
                {
                    if (e.Item.Selected)
                    {
                        if (e.Item.ListView.Focused)
                        {
                            e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                            TextRenderer.DrawText(e.Graphics, e.Item.SubItems[e.ColumnIndex].Text, e.Item.ListView.Font, recBounds, colorOwnHighlightText, flagsRightNoPrefix);
                        }
                        else
                        {
                            e.Graphics.FillRectangle(SystemBrushes.ButtonFace, e.Bounds);
                            TextRenderer.DrawText(e.Graphics, e.Item.SubItems[e.ColumnIndex].Text, e.Item.ListView.Font, recBounds, colorOwnWindowText, flagsRightNoPrefix);
                        }
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(e.Item.BackColor), e.Bounds);
                        TextRenderer.DrawText(e.Graphics, e.Item.SubItems[e.ColumnIndex].Text, e.Item.ListView.Font, recBounds, e.Item.ForeColor, flagsRightNoPrefix);
                    }
                }
                else
                {
                    if (e.Item.Selected)
                    {
                        if (e.Item.ListView.Focused)
                        {
                            e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                            TextRenderer.DrawText(e.Graphics, e.Item.SubItems[e.ColumnIndex].Text, e.Item.ListView.Font, recBounds, colorOwnHighlightText, flagsWordEllSingleLineNoPrefix);
                        }
                        else
                        {
                            e.Graphics.FillRectangle(SystemBrushes.ButtonFace, e.Bounds);
                            TextRenderer.DrawText(e.Graphics, e.Item.SubItems[e.ColumnIndex].Text, e.Item.ListView.Font, recBounds, colorOwnWindowText, flagsWordEllSingleLineNoPrefix);
                        }
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(e.Item.BackColor), e.Bounds);
                        TextRenderer.DrawText(e.Graphics, e.Item.SubItems[e.ColumnIndex].Text, e.Item.ListView.Font, recBounds, e.Item.ForeColor, flagsWordEllSingleLineNoPrefix);
                    }
                }
            }
        }

        protected override void OnColumnWidthChanged(ColumnWidthChangedEventArgs e)
        {
            base.OnColumnWidthChanged(e);
            this.SetColumnSizes();
        }
    }
}
