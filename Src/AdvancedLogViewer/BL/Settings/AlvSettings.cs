using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using System.Xml.Linq;
using System.IO;

namespace AdvancedLogViewer.BL.Settings
{
    public class AlvSettings:XmlSerializable<AlvSettings>
    {
        public MainFormUI MainFormUI { get; private set; }
        public RecentFiles RecentFiles { get; private set; }
        public TextDiff TextDiff { get; private set; }
        public TextEditor TextEditor { get; private set; }
        public AutomaticUpdates AutomaticUpdates { get; private set; }

        protected override void LoadData(XElement xmlElement)
        {
            this.MainFormUI = GetSubElementValue<MainFormUI>(f => MainFormUI.GetInstance(f), xmlElement, "MainFormUI");
            this.RecentFiles = GetSubElementValue<RecentFiles>(f => RecentFiles.GetInstance(f), xmlElement, "RecentFiles");
            this.TextDiff = GetSubElementValue<TextDiff>(f => TextDiff.GetInstance(f), xmlElement, "TextDiff");
            this.TextEditor = GetSubElementValue<TextEditor>(f => TextEditor.GetInstance(f), xmlElement, "TextEditor");
            this.AutomaticUpdates = GetSubElementValue<AutomaticUpdates>(f => AutomaticUpdates.GetInstance(f), xmlElement, "AutomaticUpdates");
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddSubElementValue<MainFormUI>(val => val.GetXmlElement("MainFormUI"), xmlElement, this.MainFormUI);
            AddSubElementValue<RecentFiles>(val => val.GetXmlElement("RecentFiles"), xmlElement, this.RecentFiles);
            AddSubElementValue<TextDiff>(val => val.GetXmlElement("TextDiff"), xmlElement, this.TextDiff);
            AddSubElementValue<TextEditor>(val => val.GetXmlElement("TextEditor"), xmlElement, this.TextEditor);
            AddSubElementValue<AutomaticUpdates>(val => val.GetXmlElement("AutomaticUpdates"), xmlElement, this.AutomaticUpdates);
        }
    }
}
