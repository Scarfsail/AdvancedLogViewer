using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLogViewer.Common.Parser
{
    public enum LogType
    {
        NONE = -2,
        UNKNOWN = -1,
        VERBOSE = 0,
        DEBUG = 1,
        INFO = 2,
        WARN = 3,
        ERROR = 4,
        FATAL = 5,
        TRACE = 6,
    }
}
