using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;

namespace Scarfsail.Common.BL
{
    public enum XmlSerializableFileCorruptedAction
    {
        ThrowError,
        ShowDialogAndLoadDefaults,
        LoadDefaultsSilently
    }

    public abstract class XmlSerializable<T>
                where T : XmlSerializable<T>, new()
    {


        public static T LoadFromFile(string fileName, XmlSerializableFileCorruptedAction whatToDoWhenCfgFileIsCorrupted)
        {
            XElement rootElement;

            try
            {
                rootElement = GetRootElement(fileName);
            }
            catch(Exception ex)
            {
                switch (whatToDoWhenCfgFileIsCorrupted)
                {
                    case XmlSerializableFileCorruptedAction.LoadDefaultsSilently:
                        rootElement = null;
                        break;
                    case XmlSerializableFileCorruptedAction.ShowDialogAndLoadDefaults:
                        rootElement = null;
                        MessageBox.Show(String.Format("Error while loading configuration file: '{0}'. {2}Error: {1}{2}Defaults used for the configuration.", fileName, ex.Message, Environment.NewLine), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case XmlSerializableFileCorruptedAction.ThrowError:
                        throw;
                    default:
                        throw new Exception(String.Format("Value of enum: '{0}' isn't supported in LoadFromFile method.", whatToDoWhenCfgFileIsCorrupted));
                }
                
            }

            T result = GetInstance(rootElement);
            result.fileName = fileName;
            
            return result;
        }

        public void Save()
        {
            XDocument doc = new XDocument();

            XElement root = this.GetXmlElement("Root");
           
            doc.Add(root);
            
            doc.Save(fileName);
        }

        public void ReloadFromFile()
        {
            this.LoadData(GetRootElement(this.fileName));
        }

        private static XElement GetRootElement(string fileName)
        {
            XElement rootElement = null;
            if (File.Exists(fileName))
            {
                var doc = XDocument.Load(fileName);
                rootElement = doc.Root;
            }
            return rootElement;
        }

        public XElement GetXmlElement(string elementName)
        {
            XElement result = new XElement(elementName);
            this.SaveData(result);
            return result;
        }

        public static T GetInstance(XElement element)
        {
            T result = new T();
            result.LoadData(element);
            return result;
        }

        public void InitDefaultValues()
        {
            this.LoadData(null);
        }
       
        protected abstract void LoadData(XElement xmlElement);
        
        protected abstract void SaveData(XElement xmlElement);



        protected static TResult GetAttrValue<TResult>(Func<string, TResult> convertor, XElement element, string attrName, TResult defaultValue)
        {
            XAttribute attr = element != null ? element.Attribute(attrName) : null;
            return attr != null ? convertor(attr.Value) : defaultValue;
        }

        protected static TResult GetAttrValue<TResult>(Func<string, TResult> convertor, XElement element, string attrName, TResult defaultValue, bool useDefaultWhenError)
        {
            try
            {
                XAttribute attr = element != null ? element.Attribute(attrName) : null;
                return attr != null ? convertor(attr.Value) : defaultValue;
            }
            catch
            {
                if (useDefaultWhenError)
                    return defaultValue;
                else
                    throw;
            }
        }
        protected static List<TListItem> GetList<TListItem>(Func<XElement, TListItem> convertor, XElement element, string listElementName)
        {
            XElement listElement;
            return GetList<TListItem>(convertor, element, listElementName, out listElement);
        }

        protected static List<TListItem> GetList<TListItem>(Func<XElement, TListItem> convertor, XElement element, string listElementName, out XElement listElement)
        {
            List<TListItem> result = new List<TListItem>();

            if (element != null)
            {
                listElement = element.Element(listElementName);
                if (listElement != null)
                {
                    foreach (XElement subElement in listElement.Elements())
                    {
                        result.Add(convertor(subElement));
                    }
                }
            }
            else
            {
                listElement = null;
            }
            return result;
        }

        protected static Dictionary<TKey, TValue> GetDictionary<TKey, TValue>(Func<XElement, KeyValuePair<TKey, TValue>> convertor, XElement element, string listElementName)
        {
            Dictionary<TKey, TValue> result = new Dictionary<TKey, TValue>();

            if (element != null)
            {
                XElement listElement = element.Element(listElementName);
                if (listElement != null)
                {
                    foreach (XElement subElement in listElement.Elements())
                    {
                        KeyValuePair<TKey, TValue> pair = convertor(subElement);
                        result.Add(pair.Key, pair.Value);
                    }
                }
            }
            return result;
        }

        

        protected static TResult GetSubElementValue<TResult>(Func<XElement, TResult> convertor, XElement element, string subElementName)
        {
            XElement subElement = element != null ? element.Element(subElementName) : null;
            return convertor(subElement);
        }
                
        protected static void AddAttrValue(XElement xmlElement, string attrName, string value)
        {
            xmlElement.Add(new XAttribute(attrName, value));
        }

        protected static XElement AddList<TListItem>(Func<TListItem, XElement> convertor, XElement baseElement, string listElementName, List<TListItem> list)
        {
            XElement listElement = new XElement(listElementName);
            foreach (TListItem item in list)
            {
                listElement.Add(convertor(item));
            }
            baseElement.Add(listElement);
            return listElement;
        }

        protected static void AddDictionary<TKey,TValue>(Func<KeyValuePair<TKey, TValue>, XElement> convertor, XElement baseElement, string listElementName, Dictionary<TKey, TValue> dictionary)
        {
            XElement listElement = new XElement(listElementName);
            foreach (KeyValuePair<TKey, TValue> item in dictionary)
            {
                listElement.Add(convertor(item));
            }
            baseElement.Add(listElement);
        }


        protected static void AddSubElementValue<TValue>(Func<TValue, XElement> convertor, XElement baseElement, TValue value)
        {
            baseElement.Add(convertor(value));
        }



        protected string fileName;
    }
}
