using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using System.Xml.Linq;
using AdvancedLogViewer.BL.ColorHighlight;
using System.Text.RegularExpressions;

namespace AdvancedLogViewer.BL.Filters
{
    public class FilterEntry : XmlSerializable<FilterEntry>
    {
        public abstract class FilterItem
        {
            public bool Enabled { get; set; }
            protected string AttributeName { get; private set; }
            protected virtual bool EnabledByDefault { get { return true; } }

            public FilterItem(XElement xmlElement, string attributeName)
            {
                this.AttributeName = attributeName;
                this.Enabled = GetAttrValue<bool>(s => Boolean.Parse(s), xmlElement, "FilterBy" + attributeName, EnabledByDefault);
                this.InternalLoadFromElement(xmlElement);
            }

            public void Save(XElement xmlElement)
            {
                AddAttrValue(xmlElement, "FilterBy" + AttributeName, this.Enabled.ToString());
                InternalSaveToElement(xmlElement);
            }

            protected abstract void InternalLoadFromElement(XElement xmlElement);
            protected abstract void InternalSaveToElement(XElement xmlElement);
        }

        public class FilterItemDate : FilterItem
        {
            public FilterItemDate(XElement xmlElement, string attributeName) : base(xmlElement, attributeName) { }

            public DateTime From { get; set; }
            public DateTime To { get; set; }
            public bool FromEnabled { get; set; }
            public bool ToEnabled { get; set; }

            protected override bool EnabledByDefault { get { return false; } }

            private DateTime ConvertStringToDateTime(string dateTimeStr)
            {
                DateTime result = DateTime.Parse(dateTimeStr);
                if (result != DateTime.MinValue)
                    return result.ToLocalTime();
                else
                    return new DateTime(result.Ticks, DateTimeKind.Local);
            }

            protected override void InternalLoadFromElement(XElement xmlElement)
            {
                this.Enabled = false; //We don't want to store Load Enabled information for DateRange when new log is loaded
                this.From = GetAttrValue<DateTime>(s => ConvertStringToDateTime(s), xmlElement, AttributeName + "From", DateTime.MinValue);
                this.To = GetAttrValue<DateTime>(s => ConvertStringToDateTime(s), xmlElement, AttributeName + "To", DateTime.MinValue);
                this.FromEnabled = GetAttrValue<bool>(s => bool.Parse(s), xmlElement, AttributeName + "FromEnabled", true);
                this.ToEnabled = GetAttrValue<bool>(s => bool.Parse(s), xmlElement, AttributeName + "ToEnabled", true);
            }

            protected override void InternalSaveToElement(XElement xmlElement)
            {
                AddAttrValue(xmlElement, AttributeName + "From", this.From.ToUniversalTime().ToString("s"));
                AddAttrValue(xmlElement, AttributeName + "To", this.To.ToUniversalTime().ToString("s"));
                AddAttrValue(xmlElement, AttributeName + "FromEnabled", this.FromEnabled.ToString());
                AddAttrValue(xmlElement, AttributeName + "ToEnabled", this.ToEnabled.ToString());
            }

            public bool Match(DateTime dateTime)
            {
                return !this.Enabled || ((!this.FromEnabled || dateTime >= this.From) && (!this.ToEnabled || dateTime <= this.To));
            }
        }

        public class FilterItemText : FilterItem
        {
            public enum EditorSelection
            {
                FreeMode = 1,
                DistinctValues=2
            }

            public FilterItemText(XElement xmlElement, string attributeName) : base(xmlElement, attributeName) { }
            public List<KeyValuePair<bool, string>> Items { get; private set; }
            public IEnumerable<string> TextLines { get; private set; }
            public EditorSelection EditorToShow { get; set; }
            private bool useRegex;
            public bool UseRegex 
            {
                get
                {
                    return this.useRegex;
                }
                set
                {
                    this.useRegex = value;
                    if (value)
                        this.CompileRegex();
                }
            }
            private Regex regex;

            public void SaveTextLines(IEnumerable<string> textLines)
            {
                if (this.UseRegex)
                {
                    CompileRegex(textLines);
                    this.TextLines = textLines;
                    foreach (string line in textLines)
                    {
                        this.Items.Add(new KeyValuePair<bool, string>(false, line));
                    }
                }
                else
                {
                    this.TextLines = textLines;
                    this.Items.Clear();
                    foreach (string line in textLines)
                    {
                        bool exclude;
                        bool escapeFirst;
                        string text = GetTextFromLine(line, out exclude, out escapeFirst);
                        this.Items.Add(new KeyValuePair<bool, string>(!exclude, text));
                    }
                }
            }

            private void CompileRegex()
            {
                CompileRegex(this.TextLines);
            }

            private void CompileRegex(IEnumerable<string> lines)
            {
                if (lines == null || lines.Count() == 0)
                {
                    this.regex = null;
                }
                else
                {
                    string expression = String.Join(" ", lines.ToArray());
                    this.regex = new Regex(expression, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                }
            }

            public static string GetTextFromLine(string line, out bool exclude, out bool escape)
            {
                if (line.Length > 0)
                {
                    exclude = line[0] == '~';
                    escape = line[0] == '\\';
                    return exclude || escape ? line.Remove(0,1) : line;
                }
                else
                {
                    exclude = false;
                    escape = false;
                    return String.Empty;
                }
            }

            protected override void InternalLoadFromElement(XElement xmlElement)
            {
                this.Items = new List<KeyValuePair<bool, string>>();

                XElement xmlListElement;
                List<string> lines = GetList<string>(s => s.Value, xmlElement, AttributeName, out xmlListElement);
                this.EditorToShow = (EditorSelection)GetAttrValue<int>(s=> Convert.ToInt32(s), xmlListElement, "EditorToShow", (int)EditorSelection.FreeMode);
                this.UseRegex = GetAttrValue<bool>(s => Boolean.Parse(s), xmlListElement, "UseRegex", false);
                this.SaveTextLines(lines);
            }

            protected override void InternalSaveToElement(XElement xmlElement)
            {
                XElement xmlListElement = AddList<string>(item => new XElement("Item", item), xmlElement, AttributeName, this.TextLines.ToList());
                AddAttrValue(xmlListElement, "EditorToShow", ((int)EditorToShow).ToString());
                AddAttrValue(xmlListElement, "UseRegex", this.UseRegex.ToString());
            }

            public bool Match(string matchWith)
            {
                return this.Match(matchWith, this.Items);
            }

            public bool Match(string matchWith, List<KeyValuePair<bool, string>> items)
            {
                if (!this.Enabled || items.Count == 0)
                    return true;

                if (UseRegex)
                {
                    return (regex == null) || (regex.Match(matchWith).Success);
                }
                else
                {
                    bool someInclude = false;

                    foreach (KeyValuePair<bool, string> compareWithItem in items)
                    {
                        if (matchWith.IndexOf(compareWithItem.Value, StringComparison.OrdinalIgnoreCase) > -1)
                            return compareWithItem.Key;
                        someInclude |= compareWithItem.Key;
                    }

                    return !someInclude;
                }                
            }
        }

        public class FilterItemMessage : FilterItemText
        {
            public FilterItemMessage(XElement xmlElement, string attributeName) 
                : base(xmlElement, attributeName) { }


            public bool IncludeItemsFromColorHighlight { get; set; }

            protected override void InternalLoadFromElement(XElement xmlElement)
            {
                base.InternalLoadFromElement(xmlElement);

                this.IncludeItemsFromColorHighlight = GetAttrValue<bool>(s => Boolean.Parse(s), xmlElement, "IncludeItemsFromColorHighlight" + AttributeName, false);
            }

            protected override void InternalSaveToElement(XElement xmlElement)
            {
                base.InternalSaveToElement(xmlElement);

                AddAttrValue(xmlElement, "IncludeItemsFromColorHighlight" + AttributeName, this.IncludeItemsFromColorHighlight.ToString());
            }

            public List<KeyValuePair<bool, string>> GetItemsWithColorHighlights(List<ColorHighlightEntry> colorHighlights)
            {
                List<KeyValuePair<bool, string>> filterMessages;
                if (this.IncludeItemsFromColorHighlight && !this.UseRegex)
                {
                    filterMessages = new List<KeyValuePair<bool, string>>(this.Items);
                    colorHighlights.ForEach(h => filterMessages.Add(new KeyValuePair<bool, string>(true, h.TextToHighlight)));
                }
                else
                {
                    filterMessages = this.Items;
                }
                return filterMessages;
            }
        }
        
        public string FilterName { get; set; }
        public Guid FilterId { get; private set; }

        public FilterItemDate DateTimeRange { get; private set; }
        public FilterItemText Threads { get; private set; }
        public FilterItemText Types { get; private set; }
        public FilterItemText Classes { get; private set; }
        public FilterItemMessage Messages { get; private set; }

        public override string ToString()
        {
            return this.FilterName;
        }

        protected override void LoadData(XElement xmlElement)
        {
            this.FilterName = GetAttrValue<string>(s => s, xmlElement, "Name", "New filter");
            this.FilterId = GetAttrValue<Guid>(s => new Guid(s), xmlElement, "ID", Guid.NewGuid());

            this.Threads = new FilterItemText(xmlElement, "Threads");
            this.Types = new FilterItemText(xmlElement, "Types");
            this.Classes = new FilterItemText(xmlElement, "Classes");
            this.Messages = new FilterItemMessage(xmlElement, "Messages");

            this.DateTimeRange = new FilterItemDate(xmlElement, "DateTime");
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddAttrValue(xmlElement, "Name", this.FilterName);
            AddAttrValue(xmlElement, "ID", this.FilterId.ToString());

            this.Threads.Save(xmlElement);
            this.Types.Save(xmlElement);
            this.Classes.Save(xmlElement);
            this.Messages.Save(xmlElement);
            this.DateTimeRange.Save(xmlElement);
        }
    }
}
