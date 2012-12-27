using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvancedLogViewer.BL.Comm.Messages;

namespace AdvancedLogViewer.UI.Items
{
    class LogViewerInstanceToolStripItem : ToolStripMenuItem
    {
        public LogViewerInstanceToolStripItem(LogViewerInstance logViewerInstance)
        {
            this.LogInstance = logViewerInstance;
            this.Text = LogInstance.LogFileName;
        }
        
        public LogViewerInstance LogInstance { get; private set; }
    }
}
