using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using System.Xml.Linq;
using System.Globalization;

namespace Scarfsail.SoftwareUpdates
{
    public class UpdateDefinitionXml : XmlSerializable<UpdateDefinitionXml>
    {
        public SettingsCategory Settings { get; private set; }
        public LatestVersionCategory LatestVersion { get; private set; }

        public class SettingsCategory : XmlSerializable<SettingsCategory>
        {
            public int DefinitionStructureVersion { get; private set; }

            protected override void LoadData(XElement xmlElement)
            {
                this.DefinitionStructureVersion = GetAttrValue<int>(s => Convert.ToInt32(s), xmlElement, "DefinitionStructureVersion", 1);
            }

            protected override void SaveData(XElement xmlElement)
            {
                throw new NotSupportedException("Saving is not supported by this class.");
            }
        }

        public class LatestVersionCategory : XmlSerializable<LatestVersionCategory>
        {
            public Version Version { get; private set; }
            public DateTime Date { get; private set; }
            public String UrlWithMsiUpdate { get; private set; }
            public String UrlWithZip { get; private set; }
            public String UrlWithPortableUpdate { get; private set; }
            public String UrlWithHistoryXml { get; private set; }
            public String MsiUrlWithPlatform { get; private set; }
            public String ZipUrlWithPlatform { get; private set; }
            

            protected override void LoadData(XElement xmlElement)
            {
                string versionStr = GetAttrValue<string>(s => s, xmlElement, "Version", null);
                if (String.IsNullOrEmpty(versionStr))
                    this.Version = null;
                else
                    this.Version = new Version(versionStr);

                string dateStr = GetAttrValue<string>(s => s, xmlElement, "Date", null);
                if (String.IsNullOrEmpty(dateStr))
                    this.Date = DateTime.MinValue;
                else
                    this.Date = DateTime.ParseExact(dateStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                var runtimeStr = Environment.Is64BitOperatingSystem ? "win-x64" : "win-x86";

                this.UrlWithMsiUpdate = GetAttrValue<string>(s => s, xmlElement, "MsiUrlWithPlatform", null).Replace("{$Version}", versionStr).Replace("${Runtime}", runtimeStr);
                this.UrlWithPortableUpdate = GetAttrValue<string>(s => s, xmlElement, "UrlWithPortableUpdate", null).Replace("{$Version}", versionStr).Replace("${Runtime}", runtimeStr);
                this.UrlWithZip = GetAttrValue<string>(s => s, xmlElement, "ZipUrlWithPlatform", null).Replace("{$Version}", versionStr).Replace("${Runtime}", runtimeStr);
                this.UrlWithHistoryXml = GetAttrValue<string>(s => s, xmlElement, "URLWithHistoryXml", null);
            }

            protected override void SaveData(XElement xmlElement)
            {
                throw new NotSupportedException("Saving is not supported by this class.");
            }
        }

        protected override void LoadData(XElement xmlElement)
        {
            this.Settings = GetSubElementValue<SettingsCategory>(f => SettingsCategory.GetInstance(f), xmlElement, "Settings");
            this.LatestVersion = GetSubElementValue<LatestVersionCategory>(f => LatestVersionCategory.GetInstance(f), xmlElement, "LatestVersion");
        }

        protected override void SaveData(XElement xmlElement)
        {
            throw new NotSupportedException("Saving is not supported by this class.");
        }
    }
}
