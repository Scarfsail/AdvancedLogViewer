using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using System.Xml.Linq;
using System.IO;

namespace AdvancedLogViewer.BL.Settings
{
    public class TextEditor : XmlSerializable<TextEditor>
    {
        public string TextEditorPath { get; set; }
        public string TextEditorParameteres { get; set; }


        protected override void LoadData(XElement xmlElement)
        {
            this.TextEditorPath = GetAttrValue<string>(s => s, xmlElement, "TextEditPath", "notepad.exe");
            this.TextEditorParameteres = GetAttrValue<string>(s => s, xmlElement, "TextEditParameters", "\"%FileName%\"");
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddAttrValue(xmlElement, "TextEditPath", this.TextEditorPath);
            AddAttrValue(xmlElement, "TextEditParameters", this.TextEditorParameteres);
        }
    }
}
