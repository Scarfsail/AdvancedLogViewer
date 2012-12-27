using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Scarfsail.Common.BL;
using System.Xml.Linq;

namespace AdvancedLogViewer.BL.FindText
{
    public class SearchHistory : XmlSerializable<SearchHistory>
    {
        public void AddText(string text)
        {
            string existingText = this.TextList.FirstOrDefault(f => f.Equals(text, StringComparison.OrdinalIgnoreCase));
            if (existingText != null)
            {
                this.TextList.Remove(existingText);
            }

            this.TextList.Insert(0, text);
            
            if (this.TextList.Count > maxNumberOfTexts)
            {
                this.TextList.RemoveAt(this.TextList.Count - 1);
            }
        }

        public List<string> TextList { get; set; }
        
        protected override void LoadData(XElement xmlElement)
        {
            this.TextList = GetList<string>(element => element.Value, xmlElement, "TextList");
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddList<string>(item => new XElement("FindWhat",item), xmlElement, "TextList", this.TextList);
        }

        private const int maxNumberOfTexts = 20;
    }
}
