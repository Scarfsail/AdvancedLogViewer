using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using System.Xml.Linq;
using System.Collections;

namespace AdvancedLogViewer.BL.LogAdjuster
{
    public class LogAdjusters : XmlSerializable<LogAdjusters>, IEnumerable<LogAdjuster>
    {
        public LogAdjusters()
        {

        }

        private Dictionary<string, LogAdjuster> logAdjusters;

        public LogAdjuster GetLogAdjuster(string logFileName)
        {
            LogAdjuster logAdjuster;
            if (!logAdjusters.TryGetValue(logFileName.ToUpperInvariant(), out logAdjuster))
                return null;

            return logAdjuster;
        }

        public void AddLogAdjuster(LogAdjuster logAdjuster)
        {
            if (String.IsNullOrEmpty(logAdjuster.LogFileName))
                throw new InvalidOperationException("LogFileName in logAdjuster can't be null or empty.");

            string fileName = logAdjuster.LogFileName.ToUpperInvariant();
            if (this.logAdjusters.ContainsKey(fileName))
                throw new ArgumentException(string.Format("LogAdjuster for Log File: '{0}' is already in this collection.", fileName));

            this.logAdjusters.Add(fileName, logAdjuster);
        }
        public void ClearAllLogAdjusters()
        {
            this.logAdjusters.Clear();
        }

        /*
        public void RemoveLogAdjuster(LogAdjuster logAdjuster)
        {
            string fileName = logAdjuster.LogFileName.ToUpperInvariant();
            if (!this.logAdjusters.ContainsKey(fileName))
                throw new ArgumentException(string.Format("LogAdjuster for Log File: '{0}' is not in this collection.", fileName));

            this.logAdjusters.Remove(fileName);
        }
        */
        protected override void LoadData(XElement xmlElement)
        {
            this.logAdjusters = GetDictionary<string, LogAdjuster>(delegate(XElement element)
                                {
                                    LogAdjuster adjuster = LogAdjuster.GetInstance(element);
                                    return new KeyValuePair<string, LogAdjuster>(adjuster.LogFileName.ToUpperInvariant(), adjuster);
                                },
                                xmlElement, "LogAdjusters");
        }
                
        protected override void SaveData(XElement xmlElement)
        {
            AddDictionary<string, LogAdjuster>(pair => pair.Value.GetXmlElement("LogAdjuster"), xmlElement, "LogAdjusters", logAdjusters);
        }

        public IEnumerator<LogAdjuster> GetEnumerator()
        {
            return this.logAdjusters.Values.GetEnumerator();            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.logAdjusters.Values.GetEnumerator();            
        }
    }
}
