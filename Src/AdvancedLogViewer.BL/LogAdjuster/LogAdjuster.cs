using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace AdvancedLogViewer.BL.LogAdjuster
{
    public class LogAdjuster : XmlSerializable<LogAdjuster>
    {
        public struct Logger
        {
            public string Name;
            public string Path;
            public string ActiveLevel;
        }

        public LogAdjuster()
        {

        }

        public LogAdjuster(string logFileName, string configFileName)
        {
            this.LoadData(null); //Init default values
            this.LogFileName = logFileName;
            this.ConfigFileName = configFileName;
        }

        private string[] logLevelsList;
        private string logLevels;

        public string LogFileName { get; private set; }
        public string ConfigFileName { get; set; }
        

        public string LogLevels
        {
            get { return this.logLevels; }
            set { this.logLevels = value; this.logLevelsList = null; }
        }

        public string[] LogLevelsList
        {
            get
            {
                if (this.logLevelsList == null)
                {
                    this.logLevelsList = this.LogLevels.Split(';');
                }
                return this.logLevelsList;
            }
        }

        /// <summary>
        /// Returns list of loggers. On first position is always root logger (if not found, exception is thrown). 
        /// On following places are additional loggers
        /// </summary>
        public List<Logger> GetActiveLogLevels()
        {
            XmlDocument doc = GetXmlConfigDocument();

            string attrValueName = "value";
            
            //Root logger
            string path = "/configuration/log4net/root/level";

            XmlNode node = GetXmlNode(doc, path);
            XmlAttribute rootAttr = GetXmlAttribute(doc, node, attrValueName);
            List<Logger> result = new List<Logger>();

            result.Add(new Logger() { Name = "", Path = path, ActiveLevel = rootAttr.Value });


            //Additional loggers (optional)
            path = "/configuration/log4net/logger";
            XmlNodeList nodes = doc.SelectNodes(path);
            foreach (XmlNode loggerNode in nodes)
            {
                XmlAttribute attr = loggerNode.Attributes["name"];
                if (attr == null)
                    continue;
                
                string name = attr.Value;
                XmlNode levelNode = loggerNode.SelectSingleNode("level");
                if (levelNode == null)
                    continue;

                attr = levelNode.Attributes["value"];
                if (attr == null)
                    continue;
                string value = attr.Value;

                result.Add(new Logger() { Name = name, Path = path + "[@name='" + name + "']/level", ActiveLevel = value });
            }
            return result;
        }

        private XmlDocument GetXmlConfigDocument()
        {
            if (!File.Exists(this.ConfigFileName))
                throw new InvalidOperationException(String.Format("Config file: '{0}' doesn't exist. Please reconfigure Log Adjuster for current log file.", this.ConfigFileName));

            XmlDocument doc = new XmlDocument();
            doc.Load(this.ConfigFileName);
            return doc;
        }

        private XmlNode GetXmlNode(XmlDocument doc, string path)
        {
            XmlNode node = doc.SelectSingleNode(path);
            if (node == null)
                throw new InvalidOperationException(String.Format("Path: '{0}' in config file: '{1}' doesn't exist. Please reconfigure Log Adjuster for current log file.", path, this.ConfigFileName));

            return node;
        }

        private XmlAttribute GetXmlAttribute(XmlDocument doc, XmlNode node, string attrName)
        {
            XmlAttribute attr = node.Attributes[attrName];
            if (attr == null)
                throw new InvalidOperationException(String.Format("Attribute: '{0}' under node: '{1}' in config file: '{2}' doesn't exist. Please reconfigure Log Adjuster for current log file.", attrName, node.Name, this.ConfigFileName));

            return attr;
        }

        public void SetActiveLogLevel(string path, string logLevel)
        {
            XmlDocument doc = GetXmlConfigDocument();
            XmlNode node = GetXmlNode(doc, path);
            XmlAttribute attr = GetXmlAttribute(doc, node, "value");
                        
            attr.Value = logLevel;
            doc.Save(this.ConfigFileName);
        }
  
        protected override void LoadData(XElement xmlElement)
        {
            this.LogFileName = GetFullPath(GetAttrValue<string>(s => s, xmlElement, "LogFileName", "None"));
            this.ConfigFileName = GetFullPath(GetAttrValue<string>(s => s, xmlElement, "ConfigFileName", "None"));
            this.LogLevels = GetAttrValue<string>(s => s, xmlElement, "LogLevels", "ALL;TRACE;VERBOSE;DEBUG;INFO;WARN;ERROR;FATAL");
        }


        private static string programFilesFolder = Environment.GetEnvironmentVariable("PROGRAMFILES(X86)") ?? Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        private static string appDataFolder= Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        private string GetFullPath(string pathWithVariables)
        {
            return pathWithVariables.
                Replace("%PROGRAMFILES%", programFilesFolder).
                Replace("%COMMONAPPDATA%", appDataFolder);
        }

        protected override void SaveData(XElement xmlElement)
        {
            AddAttrValue(xmlElement, "LogFileName", this.LogFileName);
            AddAttrValue(xmlElement, "ConfigFileName", this.ConfigFileName);
            AddAttrValue(xmlElement, "LogLevels", this.LogLevels);
        }
    }
}
