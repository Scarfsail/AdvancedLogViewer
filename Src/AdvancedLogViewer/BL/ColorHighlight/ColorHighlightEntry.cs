using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Drawing;
using Scarfsail.Common.BL;

namespace AdvancedLogViewer.BL.ColorHighlight
{
    public class ColorHighlightEntry : XmlSerializable<ColorHighlightEntry>
    {
        public string TextToHighlight { get; set; }
        public Color HighlightColor { get; set; }
        public Color HighlightTextColor { get; set; }
        
        protected override void LoadData(XElement xmlElement)
        {
            this.TextToHighlight = GetAttrValue<string>(s => s, xmlElement, "Text", "");
            this.HighlightColor = GetAttrValue<Color>(s => Color.FromArgb(Convert.ToInt32(s)), xmlElement, "Color", Color.Green);
            this.HighlightTextColor = GetAttrValue<Color>(s => Color.FromArgb(Convert.ToInt32(s)), xmlElement, "TextColor", Color.Black);
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddAttrValue(xmlElement, "Text", this.TextToHighlight);
            AddAttrValue(xmlElement, "Color", this.HighlightColor.ToArgb().ToString());
            AddAttrValue(xmlElement, "TextColor", this.HighlightTextColor.ToArgb().ToString());
        }
    }
}
