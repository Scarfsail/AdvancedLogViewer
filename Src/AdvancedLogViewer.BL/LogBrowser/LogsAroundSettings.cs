using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using System.Xml.Linq;
using System.IO;
using AdvancedLogViewer.Common;

namespace AdvancedLogViewer.BL.LogsAround
{
    public class LogsAroundSettings : XmlSerializable<LogsAroundSettings>
    {      
        public string TopLevelFolders { get; set; }
        public bool ShowAndCloseOnDoubleClick { get; set; }

        protected override void LoadData(XElement xmlElement)
        {
            this.TopLevelFolders = GetAttrValue<string>(s => s, xmlElement, "TopLevelFolders", "SolarWinds;LogFiles");
            this.ShowAndCloseOnDoubleClick = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "ShowAndCloseOnDoubleClick", true);
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddAttrValue(xmlElement, "TopLevelFolders", this.TopLevelFolders);
            AddAttrValue(xmlElement, "ShowAndCloseOnDoubleClick", this.ShowAndCloseOnDoubleClick.ToString());
        }

        public static LogsAroundSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = LogsAroundSettings.LoadFromFile(Path.Combine(Globals.UserDataDir, "LogsAround.xml"));
                }
                return instance;
            }
        }


        private static LogsAroundSettings instance;
    }
}
