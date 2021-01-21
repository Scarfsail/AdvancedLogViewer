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
                var pattern = "(?<=<!--GENERATED LINKS BEGIN-->\n)([\\s\\S]*)(?=\n<!--GENERATED LINKS END-->)";
                if (!Regex.Match(readmeMd, pattern).Success)
                {
                    base.Log.LogError("The readme.md doesn't contain following regex pattern: " + pattern, null);
                    return false;
                }
                var versionText =
                    $"You can download the latest release **{version}**:\n" +
                    "* MSI Installer: " +
                    $"[x86](Release/bin/AdvancedLogViewer_{version}_win-x86.msi?raw=true) or " +
                    $"[x64](Release/bin/AdvancedLogViewer_{version}_win-x64.msi?raw=true)" +
                    "\n* Portable ZIP: " +
                    $"[x86](Release/bin/AdvancedLogViewer_{version}_win-x86.zip?raw=true) or " +
                    $"[x64](Release/bin/AdvancedLogViewer_{version}_win-x64.zip?raw=true)";

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
