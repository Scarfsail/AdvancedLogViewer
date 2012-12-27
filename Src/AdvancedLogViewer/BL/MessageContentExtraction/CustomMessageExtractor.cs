using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace AdvancedLogViewer.BL.MessageContentExtraction
{
    class CustomMessageExtractor : XmlSerializable<CustomMessageExtractor>
    {
        public CustomMessageExtractor()
        {

        }

        public static CustomMessageExtractor CreateDefaultInstance()
        {
            CustomMessageExtractor instance = new CustomMessageExtractor();
            instance.LoadData(null);
            return instance;
        }

        public CustomMessageExtractor(CustomMessageExtractor copyFrom)
        {
            this.ExtractorName = "Copy of " + copyFrom.ExtractorName;
            this.RegexToExtract = copyFrom.RegexToExtract;
            this.DefaultAction = copyFrom.DefaultAction;
            this.FileExtension = copyFrom.FileExtension;
        }


        public string ExtractorName 
        {
            get
            {
                return this.extractorName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("Extractor name has to be specified.");

                this.extractorName = value;

            }
        }
        
        public string RegexToExtract
        {
            get
            {
                return this.regexToExtract;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("Regex has to be specified.");

                Regex regex = new Regex(value);
                this.regexToExtract = value;
            }
        }
        
        public MessageContentExtractorAction DefaultAction { get; set; }


        public string FileExtension
        {
            get
            {
                return this.fileExtension;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("File extension has to be specified.");

                this.fileExtension = value;

            }
        }

        public override string ToString()
        {
            return this.ExtractorName;
        }
        
        protected override void LoadData(XElement xmlElement)
        {
            this.extractorName = GetAttrValue<string>(s => s, xmlElement, "ExtractorName", "Custom extractor");
            this.regexToExtract = GetAttrValue<string>(s => s, xmlElement, "Regex", "SomeTextBegin(?<GroupToCapture>.*)SomeTextEnd");
            this.DefaultAction = GetAttrValue<MessageContentExtractorAction>(s => (MessageContentExtractorAction)Convert.ToInt32(s), xmlElement, "DefaultAction", MessageContentExtractorAction.Default);
            this.fileExtension = GetAttrValue<string>(s => s, xmlElement, "FileExtension", "txt");           
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddAttrValue(xmlElement, "ExtractorName", this.ExtractorName);
            AddAttrValue(xmlElement, "Regex", this.RegexToExtract);
            AddAttrValue(xmlElement, "DefaultAction", Convert.ToInt32(this.DefaultAction).ToString());
            AddAttrValue(xmlElement, "FileExtension", this.FileExtension);
        }

        private string extractorName;
        private string regexToExtract;
        private string fileExtension;
    }
}
