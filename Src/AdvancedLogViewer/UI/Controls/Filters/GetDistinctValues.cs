using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLogViewer.UI.Controls.Filters
{
    public struct GetDisctinctValues
    {
        public Func<List<string>> Threads;
        public Func<List<string>> Types;
        public Func<List<string>> Classes;
    }
}
