using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using Scarfsail.Common.BL;
using System.Drawing;
using AdvancedLogViewer.Common.Parser;
using System.Windows.Forms;

namespace AdvancedLogViewer.BL.ColorHighlight
{
    public class ColorHighlightGroup : XmlSerializable<ColorHighlightGroup>
    {
        public override string ToString()
        {
            return this.GroupName;
        }

        public List<ColorHighlightEntry> Highlights { get; private set; }
        public string GroupName { get; set; }
        public Guid GroupId { get; private set; }

        public bool TryHighlightLogItem(LogEntry logItem, out Color logItemColor, out Color logItemTextColor)
        {
            foreach (ColorHighlightEntry highlight in this.Highlights)
            {
                if ((logItem.Thread != null && logItem.Thread.IndexOf(highlight.TextToHighlight, StringComparison.OrdinalIgnoreCase) > -1) ||
                    (logItem.Type != null && logItem.Type.IndexOf(highlight.TextToHighlight, StringComparison.OrdinalIgnoreCase) > -1) ||
                    (logItem.Message.IndexOf(highlight.TextToHighlight, StringComparison.OrdinalIgnoreCase) > -1))
                {
                    logItemColor = highlight.HighlightColor;
                    logItemTextColor = highlight.HighlightTextColor;
                    return true;
                }
            }
            logItemColor = Color.Empty;
            logItemTextColor = Color.Empty;
            return false;
        }

        public void HighlightTextInMessageDetail(RichTextBox messageDetail)
        {
            foreach (ColorHighlightEntry highlight in this.Highlights)
            {
                int idx = -1;
                while ((idx = messageDetail.Text.IndexOf(highlight.TextToHighlight, idx + 1, StringComparison.OrdinalIgnoreCase)) > -1)
                {
                    messageDetail.Select(idx, highlight.TextToHighlight.Length);
                    messageDetail.SelectionBackColor = highlight.HighlightColor;
                    messageDetail.SelectionColor = highlight.HighlightTextColor;
                }                               
            }            
        }

        protected override void LoadData(XElement xmlElement)
        {
            this.Highlights = GetList<ColorHighlightEntry>(element => ColorHighlightEntry.GetInstance(element), xmlElement, "Highlights");
            this.GroupName = GetAttrValue<string>(s => s, xmlElement, "Name", "New group");
            this.GroupId = GetAttrValue<Guid>(s => new Guid(s), xmlElement, "ID", Guid.NewGuid());
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddList<ColorHighlightEntry>(item => item.GetXmlElement("Highlight"), xmlElement, "Highlights", this.Highlights);
            AddAttrValue(xmlElement, "Name", this.GroupName);
            AddAttrValue(xmlElement, "ID", this.GroupId.ToString());
        }
    }
}
