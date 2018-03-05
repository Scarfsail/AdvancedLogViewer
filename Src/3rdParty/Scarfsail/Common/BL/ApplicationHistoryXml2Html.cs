using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Globalization;

namespace Scarfsail.Common.BL
{
    public static class ApplicationHistoryXml2Html
    {
        private enum ChangeType
        {
            BigFeature,
            Feature,
            Fix,
            Change
        }
        public static string GetHtmlFromXml(string pathToHistoryXml, Version sinceVersion)
        {
            return GetHtmlFromXml(pathToHistoryXml, sinceVersion, 0);
        }

        public static string GetHtmlFromXml(string pathToHistoryXml, Version sinceVersion, int versionsAgo)
        {
            StringBuilder html = new StringBuilder();
            XDocument doc = XDocument.Load(pathToHistoryXml);
            AppendCss(html);
            bool versionAdded = false;

            int versionsShown = 0;
            foreach (XElement versionElement in doc.Root.Elements("Version"))
            {
                if (sinceVersion != null)
                {
                    Version version = new Version(versionElement.Attribute("version").Value);
                    if (version <= sinceVersion)
                        break;
                }
                if (versionsAgo > 0 && versionsShown >= versionsAgo)
                    break;

                versionAdded = true;
                AppendVersionHeader(html, versionElement);

                foreach (XElement feature in versionElement.Elements("BigFeature"))
                {
                    AppendChange(html, ChangeType.BigFeature, feature.Value);
                }
                foreach (XElement feature in versionElement.Elements("Feature"))
                {
                    AppendChange(html, ChangeType.Feature, feature.Value);
                }
                foreach (XElement feature in versionElement.Elements("Fix"))
                {
                    AppendChange(html, ChangeType.Fix, feature.Value);
                }
                foreach (XElement feature in versionElement.Elements("Change"))
                {
                    AppendChange(html, ChangeType.Change, feature.Value);
                }

                AppendVersionFooter(html);
                versionsShown++;
            }

            if (!versionAdded)
            {
                html.AppendLine("No changes since version: " + sinceVersion.ToString());
            }

            return html.ToString();
        }

        private static void AppendCss(StringBuilder html)
        {
            html.Append(
@"
  <style type='text/css'>
  .versionHeader
  {
    font-size: 9pt;
    font-family: Arial, sans-serif;
  }
  .changeRow
  {
    font-size: 9pt;
    font-family: Arial, sans-serif;
  }
  .bold
  {
    font-weight:bold;
  }
  .bigFeatureChange
  { 
    color: limeGreen;
  }

  .featureChange
  { 
    color: green;
  }
  .fixChange
  { 
    color: red;
  }
  .changeChange
  { 
    color: orange;
  }
</style>
");
        }

        private static void AppendChange(StringBuilder html, ChangeType changeType, string text)
        {
            string changeTypeHtml;
            switch (changeType)
            {
                case ChangeType.BigFeature:
                    changeTypeHtml = "<td class='bigFeatureChange' valign='top' width='50px'>Feature</td>";
                    break;
                case ChangeType.Feature:
                    changeTypeHtml = "<td class='featureChange' valign='top' width='50px'>Feature</td>";
                    break;
                case ChangeType.Fix:
                    changeTypeHtml = "<td class='fixChange' valign='top' width='50px'>Fix</td>";
                    break;
                case ChangeType.Change:
                    changeTypeHtml = "<td class='changeChange' valign='top' width='50px'>Change</td>";
                    break;
                default:
                    throw new InvalidOperationException(String.Format("Change type: {0} is not supported.", changeType));

            }

            string bold = (changeType == ChangeType.BigFeature ? " bold" : "");
            html.AppendLine("<tr class='changeRow"+bold+"'>");
            html.Append(changeTypeHtml);
            html.Append("<td>" + text.Replace("\n", "<br/>") + "</td>");
            html.AppendLine("</tr>");
        }

        private static void AppendVersionFooter(StringBuilder html)
        {
            html.AppendLine("</Table>");
            html.AppendLine("<br/>");
        }

        private static void AppendVersionHeader(StringBuilder html, XElement versionElement)
        {
            html.AppendLine(String.Format("<span class='versionHeader'><b>{0}</b> - {1}</span>",
                versionElement.Attribute("version").Value,
                DateTime.ParseExact(versionElement.Attribute("date").Value, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToShortDateString()));
            html.AppendLine("<Table>");
        }

    }
}
