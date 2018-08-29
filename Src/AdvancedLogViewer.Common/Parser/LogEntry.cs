using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;


namespace AdvancedLogViewer.Common.Parser
{
    public class LogEntry
    {
        internal bool SaveValue(PatternItemType valueType, string value)
        {
            try
            {
                switch (valueType)
                {
                    case PatternItemType.Date:
                        this.DateText = value;
                        break;
                    case PatternItemType.Time:
                        this.DateText = this.DateText + " " + value;
                        break;
                    case PatternItemType.Thread:
                        this.Thread = value;
                        break;
                    case PatternItemType.Type:
                        this.Type = value;
                        break;
                    case PatternItemType.Class:
                        this.Class = value;
                        break;
                    case PatternItemType.Message:
                        message += value;
                        break;
                    default:
                        throw new ArgumentException("Unkown value type:" + valueType.ToString(), "valueType");
                }
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                return false; //Some error in conversion
            }

            return true;
        }

        public bool SaveCustomValue(string customFieldKey, string value)
        {
            CustomFields[customFieldKey] = value;
            return true;
        }

        private int foundOnLine = -1;

        public int FoundOnLine { get { return foundOnLine; } set { foundOnLine = value; } }

        public string DateText { get; private set; }

        public string Thread { get; private set; }

        public string Type { get; private set; }

        private static Dictionary<string, LogType> stringToLogTypeCache = new Dictionary<string, LogType>();

        public LogType LogType
        {
            get
            {
                if (this.logType == LogType.NONE)
                {
                    if (string.IsNullOrEmpty(this.Type))
                    {
                        this.logType = LogType.UNKNOWN;
                    }
                    else
                    {
                        if (!stringToLogTypeCache.TryGetValue(this.Type, out this.logType))
                        {
                            if (!Enum.TryParse(this.Type, out this.logType))
                            {
                                this.logType = LogType.UNKNOWN;
                            }

                            stringToLogTypeCache.Add(this.Type, this.logType);
                        }
                    }
                }
                return this.logType;
            }
        }

        public string Class { get; private set; }

        public string Message
        {
            get
            {
                return message;
            }
        }

        public DateTime Date { get; private set; }

        public int LineInFile { get; internal set; }

        public int ItemNumber { get; internal set; }

        /// <summary>Bookmark number. Range: 1..9, when is zero, bookmark isn't set for this item.</summary>
        public int Bookmark { get; set; }

        public IDictionary<string, string> CustomFields { get; internal set; } = new Dictionary<string, string>();

        public static List<ColumnDescription> GetAvailableColumns(bool includeThread, bool includeType, bool includeClass)
        {
            var result = new List<ColumnDescription>();

            result.Add(new ColumnDescription("DateText", typeof(string)));
            if (includeThread)
                result.Add(new ColumnDescription("Thread", typeof(string)));
            if (includeType)
                result.Add(new ColumnDescription("Type", typeof(string)));
            if (includeClass)
                result.Add(new ColumnDescription("Class", typeof(string)));
            result.Add(new ColumnDescription("Message", typeof(string)));
            result.Add(new ColumnDescription("LineInFile", typeof(int)));
            result.Add(new ColumnDescription("ItemNumber", typeof(int)));
            result.Add(new ColumnDescription("Bookmark", typeof(int)));

            return result;
        }

        internal bool ParseDate(string primaryFormat, string[] additionalFormats)
        {
            DateTime date;
            if (DateTime.TryParseExact(this.DateText, primaryFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                this.Date = date;
                return true;
            }
            if (additionalFormats != null)
            {
                foreach (string additionalFormat in additionalFormats)
                {
                    if (DateTime.TryParseExact(this.DateText, additionalFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        this.Date = date;
                        return true;
                    }
                }
            }

            this.Date = DateTime.MinValue;
            return false;            
        }


        private string message = String.Empty;
        private LogType logType = LogType.NONE;
    }
}
