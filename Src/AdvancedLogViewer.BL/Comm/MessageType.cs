using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLogViewer.BL.Comm
{
    enum MessageType
    {
        GetInstance = 1,
        ReturnInstance = 2,
        GoToDateTime = 3,
        ReturnCurrentLogFileName = 4,
        ProcessAppArgs = 5
    }
}
