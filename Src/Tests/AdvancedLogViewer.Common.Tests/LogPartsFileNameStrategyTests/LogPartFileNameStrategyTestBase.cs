using AdvancedLogViewer.Common.Parser.LogPartsFileNameStrategies;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLogViewer.Common.Tests.LogPartsFileNameStrategyTests
{
    [TestFixture]
    public abstract class LogPartFileNameStrategyTestBase<TStrategy>
        where TStrategy: LogPartsFileNameStrategy, new()
    {
        private const string baseFileName = "FileName.log";
        

        [SetUp]
        public void SetUp()
        {
            var tempPath = Path.Combine(Path.GetTempPath(), "ALV", "LogPartsFileNameStrategyTest");
            if (Directory.Exists(tempPath))
            {
                Directory.Delete(tempPath, true);
            }
            Directory.CreateDirectory(tempPath);
            this.BaseName = Path.Combine(tempPath, baseFileName);
        }

        [Test]
        public void IfThereAreNoPartsOnlyBaseFileIsReturned()
        {
            var parts = CreateFilesAndRunStrategy(this.BaseName);
            Assert.AreEqual(parts.ElementAt(0), this.BaseName);

        }


        protected ICollection<string> CreateFilesAndRunStrategy(params string[] fileNames)
        {
            foreach (var fn in fileNames)
            {
                File.WriteAllText(fn, fn);
            }

            var strategy = new TStrategy();
            return strategy.AddOtherLogParts(fileNames[0]);
        }


        protected string BaseName { get; private set; }

    }


}
