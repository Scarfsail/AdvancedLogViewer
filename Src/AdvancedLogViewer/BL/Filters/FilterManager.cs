using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using Scarfsail.Common.BL;

namespace AdvancedLogViewer.BL.Filters
{
    public class FilterManager : XmlSerializable<FilterManager>
    {
        public List<FilterEntry> Filters { get; private set; }
        public FilterEntry CurrentFilter { get; set; }


        protected override void LoadData(XElement xmlElement)
        {
            this.Filters = GetList<FilterEntry>(element => FilterEntry.GetInstance(element), xmlElement, "Filters");
            if (this.Filters.Count == 0)
            {   
                //Default filter when file is empty or doesn't exists
                FilterEntry filter = new FilterEntry(); //Default filter
                filter.InitDefaultValues();
                this.Filters.Add(filter);
                this.CurrentFilter = filter;
            }
            else
            {
                this.CurrentFilter = this.Filters.First(f => f.FilterId == GetAttrValue<Guid>(s => new Guid(s), xmlElement, "CurrentFilter", Guid.NewGuid()));
            }
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddList<FilterEntry>(item => item.GetXmlElement("Filter"), xmlElement, "Filters", this.Filters);
            AddAttrValue(xmlElement, "CurrentFilter", this.CurrentFilter.FilterId.ToString());
        }
    }
}
