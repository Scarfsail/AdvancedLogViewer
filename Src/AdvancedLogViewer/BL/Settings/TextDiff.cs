using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using System.Xml.Linq;
using System.IO;

namespace AdvancedLogViewer.BL.Settings
{
    public class TextDiff : XmlSerializable<TextDiff>
    {
        public string DiffPath { get; set; }
        public string DiffParameters { get; set; }


        protected override void LoadData(XElement xmlElement)
        {
            this.DiffPath = GetAttrValue<string>(s => s, xmlElement, "DiffPath", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Perforce\\p4merge.exe"));
            this.DiffParameters = GetAttrValue<string>(s => s, xmlElement, "DiffParameters", "%File1% %File2%");
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddAttrValue(xmlElement, "DiffPath", this.DiffPath);
            AddAttrValue(xmlElement, "DiffParameters", this.DiffParameters);
        }
    }
}
