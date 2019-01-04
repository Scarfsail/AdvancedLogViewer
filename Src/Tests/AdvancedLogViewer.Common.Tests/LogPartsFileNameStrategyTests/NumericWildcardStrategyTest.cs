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
    public class NumericWildcardStrategyTest : LogPartFileNameStrategyTestBase<NumericWildcardStrategy>
    {

        public NumericWildcardStrategyTest() : base("TestFile.log")
        {
        }

        [Test]
        public void MultipleFilesDistinguishedOnlyByNumberAreAllIdentifiedAsParts()
        {
            var fileNames = new[] { this.BaseName.Replace(".log", ".1.log"), this.BaseName.Replace(".log", ".2.log"), this.BaseName.Replace(".log", ".3.log") };
            var parts = this.CreateFilesAndRunStrategy(fileNames);

            foreach (var fn in fileNames)
            {
                Assert.Contains(fn, (ICollection)parts);
            }

        }

        [Test]
        public void BaseFileWithoutNumberShouldFindOtherNumberedParts()
        {
            var fileNames = new[] { this.BaseName, this.BaseName.Replace(".log", ".1.log"), this.BaseName.Replace(".log", ".2.log") };
            var parts = this.CreateFilesAndRunStrategy(fileNames);

            foreach (var fn in fileNames)
            {
                Assert.Contains(fn, (ICollection)parts);
            }
        }

        [Test]
        public void BaseFileWithoutNumberShouldntFindNonNumericParts()
        {
            var fileNames = new[] { this.BaseName, this.BaseName.Replace(".log", ".1.log"), this.BaseName.Replace(".log", ".web.log"), this.BaseName.Replace(".log", "1web.log") };
            var parts = this.CreateFilesAndRunStrategy(fileNames);

            Assert.AreEqual(2, parts.Count());

            foreach (var fn in fileNames.Take(2))
            {
                Assert.Contains(fn, (ICollection)parts);
            }

        }

        [Test]
        public void LookingForPartsInNonExistentDirectoryReturnsEmptyList()
        {
            var strategy = new NumericWildcardStrategy();
            var parts = strategy.AddOtherLogParts("nonsense");

            Assert.AreEqual(0, parts.Count());
        }

    }
}
