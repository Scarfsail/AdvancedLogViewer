using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using System.Xml.Linq;

namespace Scarfsail.SoftwareUpdates
{
    public class UpdatesHistoryInfo : XmlSerializable<UpdatesHistoryInfo>
    {
        public DateTime LastUpdateCheck { get; set; }
        public DateTime LastUpdateFound { get; set; }
        public DateTime LastUpdateError { get; set; }


        protected override void LoadData(XElement xmlElement)
        {
            this.LastUpdateCheck = GetAttrValue<DateTime>(s => Convert.ToDateTime(s), xmlElement, "LastUpdateCheck", DateTime.MinValue, true);
            this.LastUpdateFound = GetAttrValue<DateTime>(s => Convert.ToDateTime(s), xmlElement, "LastUpdateFound", DateTime.MinValue, true);
            this.LastUpdateError = GetAttrValue<DateTime>(s => Convert.ToDateTime(s), xmlElement, "LastUpdateError", DateTime.MinValue, true);
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddAttrValue(xmlElement, "LastUpdateCheck", LastUpdateCheck.ToString("s"));
            AddAttrValue(xmlElement, "LastUpdateFound", LastUpdateFound.ToString("s"));
            AddAttrValue(xmlElement, "LastUpdateError", LastUpdateError.ToString("s"));
        }
    }
}
