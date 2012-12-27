using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdvancedLogViewer.Common.Plugins;
using AdvancedLogViewer.Common.Parser;
using System.Windows.Forms;

namespace AdvancedLogViewer.Plugins.BlackoutAnalyzer
{
    public class Plugin : IAnalyseLogPlugin
    {
        public Guid PluginGuid
        {
            get
            {
                return new Guid("8FD6D0DB-92F4-41b9-BD33-33B445BC14C5");
            }
        }

        public string PluginTitle
        {
            get
            {
                return "Blackout Analyzer";
            }
        }

        public void Execute(List<LogEntry> logEntries, IWin32Window owner, ILogViewControl logViewControl)
        {
            using (MainForm frm = new MainForm())
            {
                frm.Execute(logEntries);
                frm.ShowDialog();
            }

        }
    }
}
