using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLogViewer.Common.Parser.LogPartsFileNameStrategies
{
    public class DotSuffixStrategy : LogPartsFileNameStrategy
    {
        public override ICollection<string> AddOtherLogParts(string baseFileName)
        {
            const int maxMissingExtensionsInRow = 5;
            var result = new List<string>();


            if (File.Exists(baseFileName))
                result.Add(baseFileName);

            int i = 1;
            int nonExistingExtensions = 0;
            while (true)
            {
                string fileName = baseFileName + "." + i.ToString();
                if (File.Exists(fileName))
                {
                    result.Add(fileName);
                    nonExistingExtensions = 0;
                }
                else
                {
                    nonExistingExtensions++;
                    if (nonExistingExtensions == maxMissingExtensionsInRow)
                        break;
                }

                i++;
            }
            return result;
        }
    }
}
