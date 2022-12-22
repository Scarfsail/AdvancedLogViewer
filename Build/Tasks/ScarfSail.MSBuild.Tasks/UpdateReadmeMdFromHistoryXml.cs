using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace ScarfSail.MSBuild.Tasks
{
    /// <summary>
    /// Get latest file name with specified mask
    /// </summary>
    public class UpdateReadmeMdFromHistoryXml : Task
    {
        [Required]
        public string HistoryXml { get; set; }

        [Required]
        public string ReadmeMd { get; set; }

        public override bool Execute()
        {
            try
            {
                XmlDocument history = new XmlDocument();
                history.Load(this.HistoryXml);

                var latestVersion = history.SelectNodes("History/Version").Item(0);
                var readmeMd = File.ReadAllText(this.ReadmeMd);
                string version = latestVersion.Attributes["version"].InnerText;
                var pattern = "(?s)<!--GENERATED LINKS BEGIN-->(.*?)<!--GENERATED LINKS END-->";
                if (!Regex.Match(readmeMd, pattern).Success)
                {
                    base.Log.LogError("The readme.md doesn't contain following regex pattern: " + pattern, null);
                    return false;
                }
                var versionText =
                    $"<!--GENERATED LINKS BEGIN-->" +
                    "You can download the latest release **{version}**:\n" +
                    "* MSI Installer: " +
                    $"[x86](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/{version}/AdvancedLogViewer_{version}_win-x86.msi) or " +
                    $"[x64](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/{version}/AdvancedLogViewer_{version}_win-x64.msi)" +
                    "\n* Portable ZIP: " +
                    $"[x86](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/{version}/AdvancedLogViewer_{version}_win-x86.zip) or " +
                    $"[x64](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/{version}/AdvancedLogViewer_{version}_win-x64.zip)" +
                    "<!--GENERATED LINKS END-->";

                readmeMd = Regex.Replace(readmeMd, pattern, versionText);

                if (File.Exists(this.ReadmeMd))
                    File.Delete(this.ReadmeMd);

                File.WriteAllText(this.ReadmeMd, readmeMd);

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
