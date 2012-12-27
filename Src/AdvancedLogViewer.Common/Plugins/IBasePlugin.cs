using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLogViewer.Common.Plugins
{
    public interface IBasePlugin
    {
        Guid PluginGuid { get; }
        string PluginTitle { get; }
    }
}
