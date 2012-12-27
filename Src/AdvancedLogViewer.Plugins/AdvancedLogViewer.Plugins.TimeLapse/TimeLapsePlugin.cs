using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdvancedLogViewer.Common.Plugins;
using System.Windows.Forms;
using AdvancedLogViewer.Common.Parser;

namespace AdvancedLogViewer.Plugins.TimeLapse
{
    public class TimeLapsePlugin : IAnalyseLogPlugin
    {
        static Guid myGuid = new Guid("C001A1F9-9FF9-4B84-9342-DA6D50CAA6D9");

        public void Execute(List<LogEntry> logEntries, IWin32Window owner, ILogViewControl logViewControl)
        {
            var frm = new AdvancedLogViewer.Plugins.TimeLapse.MainForm(owner);
            {
                frm.Execute(logEntries);
                frm.Show();
            }
        }

        public Guid PluginGuid
        {
            get { return myGuid; }
        }

        public string PluginTitle
        {
            get { return "Time Lapse Plugin"; }
        }
    }
}
