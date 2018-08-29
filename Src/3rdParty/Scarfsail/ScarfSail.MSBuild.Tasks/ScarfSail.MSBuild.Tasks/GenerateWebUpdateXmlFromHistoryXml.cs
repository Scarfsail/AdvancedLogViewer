using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Utilities;
using System.Reflection;
using Microsoft.Build.Framework;
using System.IO;
using System.Xml;

namespace ScarfSail.MSBuild.Tasks
{
    /// <summary>
    /// Get latest file name with specified mask
    /// </summary>
    public class GenerateWebUpdateXmlFromHistoryXml : Task
    {
        [Required]
        public string HistoryXml { get; set; }

        [Required]
        public string WebUpdateXml { get; set; }

        public override bool Execute()
        {
            try
            {
                XmlDocument history = new XmlDocument();
                history.Load(HistoryXml);

                XmlDocument webUpdate = new XmlDocument();
                webUpdate.Load(WebUpdateXml);

                XmlNode historyNode = history.SelectSingleNode("History/Version");
                XmlNode webNode = webUpdate.SelectSingleNode("SoftwareUpdate/LatestVersion");
                webNode.Attributes["Version"].Value = historyNode.Attributes["version"].Value;
                webNode.Attributes["Date"].Value = historyNode.Attributes["date"].Value;

                webUpdate.Save(WebUpdateXml);
                return true;
            }
            catch (Exception ex)
            {
                string message = string.Format("Error while updating XML: {0}", ex.Message);
                base.Log.LogError(message, null);
                return false;
            }
        }
    }
}
