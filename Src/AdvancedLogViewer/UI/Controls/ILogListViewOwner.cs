using AdvancedLogViewer.BL.ColorHighlight;
using AdvancedLogViewer.BL.Filters;
using AdvancedLogViewer.BL.Settings;
using AdvancedLogViewer.Common.Parser;
using AdvancedLogViewer.UI.Controls.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvancedLogViewer.UI.Controls
{
    public interface ILogListViewOwner
    {
        AlvSettings Settings { get; }
        FilterManager FilterManager { get; }
        LogParser LogParser { get; }
        List<LogEntry> LogEntries { get; }
        void ShowLoadedLog(bool loadingInProgress, bool resetSearchResults);
        bool FiltersEnabled { get; set; }
        GetDistinctValues GetDistinctValues { get; }
        ColorHighlightManager ColorHighlightManager { get; }
        void SetBookmarkMenuItemText(int bookmarkNumber, string text);
        Form Form { get; }
    }
}
