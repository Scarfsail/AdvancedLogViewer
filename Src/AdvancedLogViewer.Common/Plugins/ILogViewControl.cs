using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdvancedLogViewer.Common.Parser;
using System.Windows.Forms;

namespace AdvancedLogViewer.Common.Plugins
{
    public interface ILogViewControl
    {

        bool GoToLogItem(int index, bool selectOnlyOneItem);
        void GoToLogItem(DateTime dateTime, bool showErrorWhenNotFound);
        bool GoToLogItem(LogEntry logEntry);
    }
}
