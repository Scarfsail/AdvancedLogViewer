using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using System.Xml.Linq;

namespace AdvancedLogViewer.BL.Settings
{
    public class MainFormUI : XmlSerializable<MainFormUI>
    {
        public bool AutoScrollWhenAutoRefresh { get; set; }
        public bool AutoScrollShowTwoItems { get; set; }
        public bool AutoRefresh { get; set; }
        public int AutoRefreshPeriod { get; set; }
        public bool EnableFilter { get; set; }
        public bool EnableHighlights { get; set; }
        public bool ShowMarkers { get; set; }
        public bool StayOnTop { get; set; }
        public bool ExitAppOnESC { get; set; }
        public string LastRunVersion { get; set; }
        public bool AddOnlyBaseNameInRecentList { get; set; }
        public bool RememberFiltersEnabled { get; set; }
        public bool TrimClassColumnFromLeft { get; set; }
        public string SqlFilterText { get; set; }
        public bool ShowLogIcons { get; set; }
        public bool MessageWordWrap { get; set; }

        protected override void LoadData(XElement xmlElement)
        {
            this.AutoScrollWhenAutoRefresh = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "AutoScrollWhenAutoRefresh", true);
            this.AutoScrollShowTwoItems = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "AutoScrollShowTwoItems", false);
            this.AutoRefresh = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "AutoRefreshTimer", false);
            this.AutoRefreshPeriod = GetAttrValue<int>(s => Convert.ToInt32(s), xmlElement, "AutoRefreshPeriod", 1000);
            this.EnableFilter = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "EnableFilter", false);
            this.EnableHighlights = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "EnableHighlights", false);
            this.ShowMarkers = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "ShowMarkers", true);
            this.StayOnTop = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "StayOnTop", false);
            this.ExitAppOnESC = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "ExitAppOnESC", true);
            this.LastRunVersion = GetAttrValue<string>(s => s, xmlElement, "LastRunVersion", null);
            this.AddOnlyBaseNameInRecentList = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "AddOnlyBaseNameInRecentList", true);
            this.RememberFiltersEnabled = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "RememberFiltersEnabled", false);
            this.TrimClassColumnFromLeft = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "TrimClassColumnFromLeft", true);
            this.SqlFilterText = GetAttrValue(s => s, xmlElement, "SqlFilterText", String.Empty);
            this.ShowLogIcons = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "ShowLogIcons", true);
            this.MessageWordWrap = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "MessageWordWrap", false);
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddAttrValue(xmlElement, "AutoScrollWhenAutoRefresh", AutoScrollWhenAutoRefresh.ToString());
            AddAttrValue(xmlElement, "AutoScrollShowTwoItems", AutoScrollShowTwoItems.ToString());
            AddAttrValue(xmlElement, "AutoRefreshTimer", AutoRefresh.ToString());
            AddAttrValue(xmlElement, "AutoRefreshPeriod", AutoRefreshPeriod.ToString());
            AddAttrValue(xmlElement, "EnableFilter", EnableFilter.ToString());
            AddAttrValue(xmlElement, "EnableHighlights", EnableHighlights.ToString());
            AddAttrValue(xmlElement, "ShowMarkers", ShowMarkers.ToString());
            AddAttrValue(xmlElement, "StayOnTop", StayOnTop.ToString());
            AddAttrValue(xmlElement, "ExitAppOnESC", ExitAppOnESC.ToString());
            if (LastRunVersion != null)
                AddAttrValue(xmlElement, "LastRunVersion", LastRunVersion);
            AddAttrValue(xmlElement, "AddOnlyBaseNameInRecentList", AddOnlyBaseNameInRecentList.ToString());
            AddAttrValue(xmlElement, "RememberFiltersEnabled", RememberFiltersEnabled.ToString());
            AddAttrValue(xmlElement, "TrimClassColumnFromLeft", TrimClassColumnFromLeft.ToString());
            AddAttrValue(xmlElement, "SqlFilterText", SqlFilterText);
            AddAttrValue(xmlElement, "ShowLogIcons", ShowLogIcons.ToString());
            AddAttrValue(xmlElement, "MessageWordWrap", MessageWordWrap.ToString());
        }

        
    }
}

