using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using Scarfsail.Common.BL;

namespace AdvancedLogViewer.BL.ColorHighlight
{
    public class ColorHighlightManager:XmlSerializable<ColorHighlightManager>
    {

        public List<ColorHighlightGroup> HighlightGroups { get; private set; }
        public ColorHighlightGroup CurrentGroup { get; set; }


        protected override void LoadData(XElement xmlElement)
        {
            this.HighlightGroups = GetList<ColorHighlightGroup>(element => ColorHighlightGroup.GetInstance(element), xmlElement, "Groups");
            if (this.HighlightGroups.Count == 0)
            {   
                //Default group when file is empty or doesn't exists
                ColorHighlightGroup group = new ColorHighlightGroup(); //Default highlight group
                group.InitDefaultValues();
                this.HighlightGroups.Add(group);
                this.CurrentGroup = group;
            }
            else
            {
                this.CurrentGroup = this.HighlightGroups.First(g => g.GroupId == GetAttrValue<Guid>(s => new Guid(s), xmlElement, "CurrentGroup", Guid.NewGuid()));
            }
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddList<ColorHighlightGroup>(item => item.GetXmlElement("Group"), xmlElement, "Groups", this.HighlightGroups);
            AddAttrValue(xmlElement, "CurrentGroup", this.CurrentGroup.GroupId.ToString());
        }
    }
}
