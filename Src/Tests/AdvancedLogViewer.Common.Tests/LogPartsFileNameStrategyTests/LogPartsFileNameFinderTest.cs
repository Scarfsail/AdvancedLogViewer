using AdvancedLogViewer.Common.Parser.LogPartsFileNameStrategies;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLogViewer.Common.Tests.LogPartsFileNameStrategyTests
{
    [TestFixture]
    public class LogPartsFileNameFinderTest : LogPartFileNameStrategyTestBase<DotSuffixStrategy>
    {

        [Test]
        public void FirstStrategySecondStrategyShouldBeUsedWhenMatchingFilesExist()
        {
            var fileNames = new[] { BaseName, BaseName + ".1", BaseName + ".2" };
            foreach (var fn in fileNames)
            {
                File.WriteAllText(fn, fn);
            }

            var parts = LogPartsFileNameFinder.GetFileNameParts(fileNames[0]);

            foreach (var fn in fileNames)
            {
                Assert.Contains(fn, (ICollection)parts);
            }

        }

        [Test]
        public void SecondStrategySecondStrategyShouldBeUsedWhenMatchingFilesExist()
        {
            var fileNames = new[] { this.BaseName.Replace(".log", ".1.log"), this.BaseName.Replace(".log", ".2.log"), this.BaseName.Replace(".log", ".3.log") };
            foreach (var fn in fileNames)
            {
                File.WriteAllText(fn, fn);
            }

            var parts = LogPartsFileNameFinder.GetFileNameParts(fileNames[0]);

            foreach (var fn in fileNames)
            {
                Assert.Contains(fn, (ICollection)parts);
            }

        }
    }
}
