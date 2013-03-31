using AdvancedLogViewer.Common.Parser;
using AdvancedLogViewer.UI;
using AdvancedLogViewer.UI.Items;
using Scarfsail.Common.UI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvancedLogViewer.BL.FindText
{
    internal delegate LogListViewItem GetLogListItem(GetLogListItemType type);
    internal delegate List<LogEntry> GetLogEntries();
    internal delegate bool GotoLogItem(LogEntry logEntry);

    internal class FindDialogContext
    {
        public FindDialogContext(GetLogEntries getLogEntries, GetLogListItem getLogItemFnc, GotoLogItem goToLogItemFnc,
            RichTextBox logMessageEdit, Action repaintLogList, Action<bool> setMarkersPanelVisibility, Action<int, Dictionary<int, Color>> showMarkers,
            Func<int,Point> getPositionForSearchWindow)
        {
            this.GetLogEntries = getLogEntries;
            this.GetLogItem = getLogItemFnc;
            this.GoToLogItem = goToLogItemFnc;
            this.LogMessageEdit = logMessageEdit;
            this.RepaintLogList = repaintLogList;
            this.SetMarkersPanelVisibility = setMarkersPanelVisibility;
            this.ShowMarkers = showMarkers;
            this.GetPositionForSearchWindow = getPositionForSearchWindow;
        }

        public GetLogEntries GetLogEntries { get; private set; }
        public GetLogListItem GetLogItem { get; private set; }
        public GotoLogItem GoToLogItem { get; private set; }
        public RichTextBox LogMessageEdit { get; private set; }
        public Action RepaintLogList { get; private set; }
        public Action<bool> SetMarkersPanelVisibility { get; private set; }
        public Action<int, Dictionary<int, Color>> ShowMarkers { get; private set; }
        public Func<int, Point> GetPositionForSearchWindow { get; private set; }
    }

}
