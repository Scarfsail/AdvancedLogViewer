using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using System.Xml.Linq;

namespace AdvancedLogViewer.BL.MessageContentExtraction
{
    internal class MessageContentExtractorConfig : XmlSerializable<MessageContentExtractorConfig>
    {
        public MessageContentExtractorAction DefaultAction { get; set; }
        public string FileExtension { get; set; }
        public List<CustomMessageExtractor> CustomExtractors { get; private set; }

        protected override void LoadData(XElement xmlElement)
        {
            this.DefaultAction = GetAttrValue<MessageContentExtractorAction>(s => (MessageContentExtractorAction)Convert.ToInt32(s), xmlElement, "DefaultAction", MessageContentExtractorAction.Copy);
            this.FileExtension = GetAttrValue<string>(s => s, xmlElement, "FileExtension", "txt");
            this.CustomExtractors = GetList<CustomMessageExtractor>(element => CustomMessageExtractor.GetInstance(element), xmlElement, "CustomExtractors");
            
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddAttrValue(xmlElement, "DefaultAction", Convert.ToInt32(this.DefaultAction).ToString());
            AddAttrValue(xmlElement, "FileExtension", this.FileExtension);
            AddList<CustomMessageExtractor>(item => item.GetXmlElement("CustomExtractor"), xmlElement, "CustomExtractors", this.CustomExtractors);
        }

        
    }
}
