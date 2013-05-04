using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AdvancedLogViewer.Common.Parser
{
    public class LogPattern
    {

        private static Dictionary<string, PatternItemType> patternTextToType = new Dictionary<string, PatternItemType>(){
                                                                              {"Date", PatternItemType.Date},
                                                                              {"Time", PatternItemType.Time},
                                                                              {"Thread", PatternItemType.Thread},
                                                                              {"Type", PatternItemType.Type},
                                                                              {"Class", PatternItemType.Class},
                                                                              {"Message", PatternItemType.Message}};

        private static Dictionary<string, string> patternTextWithDescription = new Dictionary<string, string>(){
                                                                              {"{Date}", "Date part of date time"},
                                                                              {"{Time}", "Time part of date time"},
                                                                              {"{Thread}", "Thread identification"},
                                                                              {"{Type}", "Type of log item (Debug, Error, ...)"},
                                                                              {"{Class}", "Class name"},
                                                                              {"{Message}", "Log message, when continue on next line, it's automatically recognized."}};

        private string fileMask;
        private string patternText;
        private string messageHeaderFormatString;
        private string wholeEntryFormatString;
        private string dateTimeFormat;


        /*
        {Date}
        {Time}
        {Thread}
        {Type}
        {Class}
        {Message}
        Example: {Date} {Time} [{Thread}] {Type}$Spaces${Class} - {Message}
                 0         10        20        30        40        50        60        70
                 01234567890123456789012345678901234567890123456789012345678901234567890123
                 2010-01-22 11:05:31,764 [1] INFO  Program - Configuration Wizard Starting.
        */
        internal LogPattern(string[] patternLineParts)
        {
            //Get pattern text for current file           
            this.FileMask = patternLineParts[0]; //Save file Mask

            this.PatternText = patternLineParts[1]; //Validate, Parse and save Pattern text

            if (patternLineParts.Length > 2)
                this.DateTimeFormat = patternLineParts[2];
            else
                this.DateTimeFormat = null;
        }

        public LogPattern()
        {
            this.FileMask = "New parser pattern";
            this.PatternText = "{Date} {Time} {Message}";
            this.DateTimeFormat = "";
        }

        public LogPattern(LogPattern copyFrom)
        {
            this.FileMask = "Copy of " + copyFrom.FileMask;
            this.PatternText = copyFrom.PatternText;
            this.DateTimeFormat = copyFrom.DateTimeFormat;
        }

        public string GetFormattedDetailHeader(string dateTimeText, string thread, string type, string className)
        {
            return string.Format(this.messageHeaderFormatString, dateTimeText, thread, type, className);
        }

        public string GetFormattedWholeEntry(string dateTimeText, string thread, string type, string className, string message)
        {
            return string.Format(this.wholeEntryFormatString, dateTimeText, thread, type, className, message);
        }

        public override string ToString()
        {
            return this.FileMask;
        }


        public PatternItem[] PatternItems { get; private set; }

        public bool ContainsThread { get; private set; }
        public bool ContainsType { get; private set; }
        public bool ContainsClass { get; private set; }


        /// <summary>
        /// Returns list of available columns in LogEntry for SQL quering
        /// </summary>
        /// <returns></returns>
        public List<ColumnDescription> GetAvailableColumns()
        {
            return LogEntry.GetAvailableColumns(ContainsThread, ContainsType, ContainsClass);
        }
        

        public string FileMask
        {
            get
            {
                return this.fileMask;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("Pattern file mask has to contains at least one character.");

                this.fileMask = value;
            }
        }

        public string PatternText
        {
            get
            {
                return this.patternText;
            }

            set
            {
                //Parse pattern
                PatternItem patternEntry = null;
                string text = String.Empty;
                bool spaces = false;
                List<PatternItem> patternItemsList = new List<PatternItem>();

                this.ContainsThread = false;
                this.ContainsType = false;
                this.ContainsClass = false;

                bool containsDateOrTime = false;
                bool containsMessage = false;

                for (int i = 0; i < value.Length; i++)
                {
                    char chr = value[i];
                    if (chr == '{')
                    {
                        if (text == "$Spaces$")
                        {
                            text = " ";
                            spaces = true;
                        }

                        PatternItem previousPatternEntry = patternEntry;
                        patternEntry = new PatternItem();

                        if (previousPatternEntry != null)
                            previousPatternEntry.EndsWith = text;
                        else
                            patternEntry.StartsWith = text;
                        
                        patternEntry.DoLTrim = spaces;
                        spaces = false;

                        text = String.Empty;
                        continue;
                    }

                    if (chr == '}')
                    {
                        PatternItemType type;
                        if (!patternTextToType.TryGetValue(text, out type))
                            throw new Exception("Unkown pattern type: " + text);

                        patternEntry.ItemType = type;
                        patternItemsList.Add(patternEntry);

                        text = String.Empty;

                        //Public info about patterns
                        this.ContainsThread |= patternEntry.ItemType == PatternItemType.Thread;
                        this.ContainsType |= patternEntry.ItemType == PatternItemType.Type;
                        this.ContainsClass |= patternEntry.ItemType == PatternItemType.Class;

                        //Private check of required patterns
                        containsDateOrTime |= (patternEntry.ItemType == PatternItemType.Date) || (patternEntry.ItemType == PatternItemType.Time);
                        containsMessage |= patternEntry.ItemType == PatternItemType.Message;

                        continue;
                    }

                    text += chr;
                }

                //Check if there are required pattern items
                if (!containsDateOrTime)
                    throw new Exception("Pattern text has to contains Time or Date pattern");

                if (!containsMessage)
                    throw new Exception("Pattern text has to contains Message pattern");

                BuildFormatStringForLogEntry(value, out this.messageHeaderFormatString, out this.wholeEntryFormatString);
                

                //Save value
                this.patternText = value;
                this.PatternItems = patternItemsList.ToArray();
            }
        }
        //0 = dateTimeText, 1 = thread, 2 = type, 3 = className, 4 = message
        private void BuildFormatStringForLogEntry(string patternText, out string headerFormat, out string wholeEntryFormat)
        {
            string formatString = patternText.Replace("$Spaces$", " ");

            int dateIdx = patternText.IndexOf("{Date}");
            int timeIdx = patternText.IndexOf("{Time}");
            if (dateIdx == -1)
                formatString = formatString.Replace("{Time}", "{0}");
            else
                if (timeIdx == -1)
                    formatString = formatString.Replace("{Date}", "{0}");
                else
                {
                    int idxA;
                    int idxB;
                    if (dateIdx < timeIdx)
                    {
                        idxA = dateIdx;
                        idxB = timeIdx + "{Time}".Length - 1;
                    }
                    else
                    {
                        idxA = timeIdx;
                        idxB = dateIdx + "{Date}".Length - 1;
                    }
                    formatString = formatString.Remove(idxA, (idxB - idxA + 1));
                    formatString = formatString.Insert(idxA, "{0}");
                }

            wholeEntryFormat = formatString.Replace("{Thread}", "{1}").Replace("{Type}", "{2}").Replace("{Class}", "{3}").Replace("{Message}", "{4}");
            headerFormat = wholeEntryFormat.Replace("{4}", Environment.NewLine);
        }

        public string DateTimeFormat
        {
            get
            {
                return this.dateTimeFormat;
            }
            set
            {
                if (value == String.Empty)
                    this.dateTimeFormat = null;
                else
                    this.dateTimeFormat = value;
            }
        }

        public static Dictionary<string, string> PatternTextWithDescription
        {
            get
            {
                return patternTextWithDescription;
            }
        }

        internal string GetLineForFile()
        {
            return (this.FileMask + "|" + this.PatternText) + (!String.IsNullOrEmpty(this.DateTimeFormat) ? ("|" + this.DateTimeFormat) : "");

        }
    }
}
