using Scarfsail.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdvancedLogViewer.Common.Parser.LogPartsFileNameStrategies
{
    public class NumericWildcardStrategy : LogPartsFileNameStrategy
    {
        private static Log log = new Log();

        public override ICollection<string> AddOtherLogParts(string baseFileName)
        {
            try
            {
                string logDirectory = Path.GetDirectoryName(baseFileName);
                string logFilename = Path.GetFileName(baseFileName);
                var relatedLogsSearchPattern = Regex.Replace(logFilename, @".\d+", "*");

                if (relatedLogsSearchPattern.Equals(logFilename, StringComparison.OrdinalIgnoreCase))
                {
                    relatedLogsSearchPattern = logFilename.Replace(".log", "*.log");
                }

                DirectoryInfo logDirectoryInfo = new DirectoryInfo(logDirectory);
                FileInfo[] logPartsInfos = logDirectoryInfo.GetFiles(relatedLogsSearchPattern, SearchOption.TopDirectoryOnly);
                var pattern = relatedLogsSearchPattern.Replace("*", @"(|.\d+)");

                var orderedLogParts = logPartsInfos
                    .OrderByDescending(fi => fi.LastWriteTimeUtc)
                    .ThenBy(fi => fi.Name)
                    .Where(fi => Regex.Match(fi.Name, pattern).Success)
                    .Select(fi => fi.FullName)
                    .ToArray();


                return orderedLogParts;

            }
            catch (Exception ex)
            {
                log.Debug($"Could not query directory for base log filename {baseFileName} for related log parts.", ex);
            }

            return new string[0];
        }
    }
}
