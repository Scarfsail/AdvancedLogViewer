using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdvancedLogViewer.Common.Parser;
using System.Windows.Forms;

namespace AdvancedLogViewer.Common.Plugins
{
    public interface IAnalyseLogPlugin : IBasePlugin
    {
        void Execute(List<LogEntry> logEntries, IWin32Window owner, ILogViewControl logViewControl);        
    }
}
