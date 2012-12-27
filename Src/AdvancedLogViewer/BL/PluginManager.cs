using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Common.BL;
using AdvancedLogViewer.Common.Plugins;

namespace AdvancedLogViewer.BL
{
    public static class PluginManager
    {
        public static Dictionary<Guid, TPluginType> GetPlugins<TPluginType>(string pluginsPath)
            where TPluginType:IBasePlugin
        {
            Dictionary<Guid, TPluginType> result = new Dictionary<Guid, TPluginType>();
            
            //Get all plugins of required plugin type
            foreach (TPluginType plugin in PluginEngine.GetPlugins<TPluginType>(pluginsPath))
            {
                result.Add(plugin.PluginGuid, plugin);
            }

            return result;
        }
    }
}
