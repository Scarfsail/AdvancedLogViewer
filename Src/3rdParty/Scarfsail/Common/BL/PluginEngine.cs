using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Scarfsail.Common.BL
{
    public class PluginEngine
    {
        public static List<T> GetPlugins<T>(string assembliesPath)
        {
            List<T> list = new List<T>();

            //Get all plugins

            foreach (string file in Directory.GetFiles(assembliesPath, "*.dll"))
            {
                Assembly assembly = Assembly.LoadFile(file);
                foreach (Type t in assembly.GetTypes())
                {
                    if (t.IsClass)
                    {
                        if (typeof(T).IsAssignableFrom(t))
                        {
                            T instance = (T)Activator.CreateInstance(t);
                            list.Add(instance);
                        }
                    }
                }
            }

            return list;
        }
    }
}
