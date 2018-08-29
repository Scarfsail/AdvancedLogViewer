using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace ScarfSail.MSBuild.Tasks
{
    /// <summary>
    /// Get latest file name with specified mask
    /// </summary>
    public class GenerateHistoryMdFromHistoryXml : Task
    {
        [Required]
        public string HistoryXml { get; set; }

        [Required]
        public string HistoryMd { get; set; }

        public override bool Execute()
        {
            try
            {
                XmlDocument history = new XmlDocument();
                history.Load(this.HistoryXml);

                var readmeMd = new StringBuilder();

                foreach (XmlNode version in history.SelectNodes("History/Version"))
                {
                    readmeMd.AppendLine($"## {version.Attributes["version"].InnerText} - {version.Attributes["date"].InnerText}");
                    AppendChanges(version, readmeMd, "BigFeature", "Big features");
                    AppendChanges(version, readmeMd, "Feature", "Features");
                    AppendChanges(version, readmeMd, "Fix", "Fixes");
                }

                if (File.Exists(this.HistoryMd))
                    File.Delete(this.HistoryMd);

                File.WriteAllText(this.HistoryMd, readmeMd.ToString());

                return true;
            }
            catch (Exception ex)
            {
                string message = string.Format("Error while generating the md file: {0}", ex.Message);
                base.Log.LogError(message, null);
                return false;
            }
        }

        private void AppendChanges(XmlNode versionNode, StringBuilder readmeMd, string nodeName, string title)
        {
            var changes = versionNode.SelectNodes(nodeName);
            if (changes.Count > 0)
            {
                readmeMd.AppendLine($"#### {title}");
                foreach (XmlNode change in changes)
                {
                    readmeMd.AppendLine($"* {change.InnerText}");
                }
            }
        }
    }
}
