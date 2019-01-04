using Scarfsail.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLogViewer.Common.Parser.LogPartsFileNameStrategies
{
    public static class LogPartsFileNameFinder
    {
        private static Log log = new Log();
        public static List<string> GetFileNameParts(string baseFileName)
        {
            log.Debug("GetFileNameParts()");

            var strategies = new LogPartsFileNameStrategy[] {
                new DotSuffixStrategy(),
                new NumericWildcardStrategy()
            };

            foreach (var strategy in strategies)
            {
                var result = strategy.AddOtherLogParts(baseFileName);
                if (result.Count() > 1)
                    return result;
            }

            log.Debug("GetFileNameParts() done.");
            return new List<string>() { baseFileName };

        }

    }
}
