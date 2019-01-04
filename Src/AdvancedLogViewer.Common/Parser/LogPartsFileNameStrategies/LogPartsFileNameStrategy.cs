using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLogViewer.Common.Parser.LogPartsFileNameStrategies
{
    public abstract class LogPartsFileNameStrategy
    {
        public abstract ICollection<string> AddOtherLogParts(string baseFileName);
    }
}
