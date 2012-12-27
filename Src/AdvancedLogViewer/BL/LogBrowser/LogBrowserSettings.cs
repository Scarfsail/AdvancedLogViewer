using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using System.Xml.Linq;
using System.IO;
using AdvancedLogViewer.Common;

namespace AdvancedLogViewer.BL.LogBrowser
{
    public class LogBrowserSettings : XmlSerializable<LogBrowserSettings>
    {      
        public string TopLevelFolders { get; set; }
        public bool ShowAndCloseOnDoubleClick { get; set; }
        public string LastRootFolder { get; set; }

        protected override void LoadData(XElement xmlElement)
        {
            this.TopLevelFolders = GetAttrValue<string>(s => s, xmlElement, "TopLevelFolders", "SolarWinds;LogFiles");
            this.ShowAndCloseOnDoubleClick = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "ShowAndCloseOnDoubleClick", true);
            this.LastRootFolder = GetAttrValue<string>(s => s, xmlElement, "LastRootFolder", null);
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddAttrValue(xmlElement, "TopLevelFolders", this.TopLevelFolders);
            AddAttrValue(xmlElement, "ShowAndCloseOnDoubleClick", this.ShowAndCloseOnDoubleClick.ToString());
            AddAttrValue(xmlElement, "LastRootFolder", this.LastRootFolder ?? String.Empty);
        }

        public static LogBrowserSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = LogBrowserSettings.LoadFromFile(Path.Combine(Globals.UserDataDir, "LogBrowser.xml"), XmlSerializableFileCorruptedAction.ShowDialogAndLoadDefaults);
                }
                return instance;
            }
        }


        private static LogBrowserSettings instance;
    }
}
