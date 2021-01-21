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

                foreach (XmlNode versionNode in history.SelectNodes("History/Version"))
                {
                    string version = versionNode.Attributes["version"].InnerText;
                    readmeMd.AppendLine($"## {version} - {versionNode.Attributes["date"].InnerText}");
                    if (new Version(version+".0") < new Version("9.0.0.0"))
                        readmeMd.AppendLine($"###### Download: [MSI](bin/AdvancedLogViewer_{version}.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_{version}.zip?raw=true)");
                    else
                        readmeMd.AppendLine($"###### Download: "+
                        "MSI: [x86](bin/AdvancedLogViewer_{version}_win-x86.msi?raw=true)  "+
                        "[x64](bin/AdvancedLogViewer_{version}_win-x64.msi?raw=true)  or  "+
                        "ZIP: [x86](bin/AdvancedLogViewer_{version}_win-x86.zip?raw=true) "+
                        "[x64](bin/AdvancedLogViewer_{version}_win-x64.zip?raw=true)"
                        );
                    this.AppendChanges(versionNode, readmeMd, "BigFeature", "Big features");
                    this.AppendChanges(versionNode, readmeMd, "Feature", "Features");
                    this.AppendChanges(versionNode, readmeMd, "Fix", "Fixes");
                    this.AppendChanges(versionNode, readmeMd, "Change", "Changes");
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
