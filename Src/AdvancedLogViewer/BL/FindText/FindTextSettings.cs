using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using System.Xml.Linq;

namespace AdvancedLogViewer.BL.FindText
{
    public class FindTextSettings : XmlSerializable<FindTextSettings>
    {      
        public string FindWhat { get; set; }
        public string FindIn { get; set; }
        public bool UseRegEx { get; set; }
        public bool CaseSensitive { get; set; }
        public bool Docked { get; set; }

        public SearchHistory SearchHistory { get; private set; }

        protected override void LoadData(XElement xmlElement)
        {
            this.FindWhat = GetAttrValue<string>(s => s, xmlElement, "FindWhat", String.Empty);
            this.FindIn = GetAttrValue<string>(s => s, xmlElement, "FindIn", String.Empty);
            this.UseRegEx = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "UseRegEx", false);
            this.CaseSensitive = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "CaseSensitive", false);
            this.Docked = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "Docked", true);

            this.SearchHistory = GetSubElementValue<SearchHistory>(f => SearchHistory.GetInstance(f), xmlElement, "SearchHistory");
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddAttrValue(xmlElement, "FindWhat", this.FindWhat);
            AddAttrValue(xmlElement, "FindIn", this.FindIn);
            AddAttrValue(xmlElement, "UseRegEx", this.UseRegEx.ToString());
            AddAttrValue(xmlElement, "CaseSensitive", this.CaseSensitive.ToString());
            AddAttrValue(xmlElement, "Docked", this.Docked.ToString());

            AddSubElementValue<SearchHistory>(val => val.GetXmlElement("SearchHistory"), xmlElement, this.SearchHistory);
        }

    }
}
