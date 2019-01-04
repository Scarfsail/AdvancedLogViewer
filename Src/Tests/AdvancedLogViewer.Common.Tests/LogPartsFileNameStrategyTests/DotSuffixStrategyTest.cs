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
    public class DotSuffixStrategyTest : LogPartFileNameStrategyTestBase<DotSuffixStrategy>
    {
        public DotSuffixStrategyTest() : base("TestFile.log")
        {
        }

        [Test]
        public void BaseFileNameWithoutSuffixFindsPartsWithNumberedDotSuffix()
        {
            var fileNames = new[] { BaseName, BaseName + ".1", BaseName + ".2" };
            var parts = CreateFilesAndRunStrategy(fileNames);

            foreach (var fn in fileNames)
            {
                Assert.Contains(fn, (ICollection)parts);
            }
        }

        [Test]
        public void DotStrategyCanHandleUpto5MissingParts()
        {
            var fileNames = new[] { BaseName, BaseName + ".1", BaseName + ".5", BaseName + ".6" };
            var parts = CreateFilesAndRunStrategy(fileNames);

            foreach (var fn in fileNames)
            {
                Assert.Contains(fn, (ICollection)parts);
            }
        }

        [Test]
        public void DotStrategyCannotHandleMoreThan5MissingParts()
        {
            var fileNames = new[] { BaseName, BaseName + ".1", BaseName + ".7", BaseName + ".8" };
            var parts = CreateFilesAndRunStrategy(fileNames);

            Assert.AreEqual(2, parts.Count());
            foreach (var fn in fileNames.Take(2))
            {
                Assert.Contains(fn, (ICollection)parts);
            }
        }

    }
}
