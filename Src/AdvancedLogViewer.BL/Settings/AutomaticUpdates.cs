using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using System.Xml.Linq;

namespace AdvancedLogViewer.BL.Settings
{
    public class AutomaticUpdates : XmlSerializable<AutomaticUpdates>
    {
        public bool EnableAutomaticCheck { get; set; }
        public int CheckInterval { get; set; }


        protected override void LoadData(XElement xmlElement)
        {
            this.EnableAutomaticCheck = GetAttrValue<bool>(s => Convert.ToBoolean(s), xmlElement, "EnableAutomaticCheck", true);
            this.CheckInterval = GetAttrValue<int>(s => Convert.ToInt32(s), xmlElement, "CheckInterval", 2);
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddAttrValue(xmlElement, "EnableAutomaticCheck", EnableAutomaticCheck.ToString());
            AddAttrValue(xmlElement, "CheckInterval", CheckInterval.ToString());
        }
    }
}
