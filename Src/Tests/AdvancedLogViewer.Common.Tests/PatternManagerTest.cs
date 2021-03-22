using AdvancedLogViewer.Common.Parser;
using System;
using System.Globalization;
using NUnit.Framework;

namespace AdvancedLogViewer.Common.Tests
{      
    /// <summary>
    ///This is a test class for LogEntryTest and is intended
    ///to contain all LogEntryTest Unit Tests
    ///</summary>
    [TestFixture]
    public class PatternManagerTest
    {
        /// <summary>
        ///A test for ParseDate
        ///</summary>
        [Test]
        public void GetPatternForLogTest()
        {
            LogPattern pattern1 = PatternManager.GetPatternForLog("DiscoveryEngine.log");
            LogPattern pattern2 = PatternManager.GetPatternForLog("DiscoveryEngine.log.1");
            Assert.AreEqual("DiscoveryEngine.log*", pattern2.FileMask);
            Assert.AreEqual(pattern1.FileMask, pattern2.FileMask);

            pattern1 = PatternManager.GetPatternForLog("Debug.log");
            Assert.AreEqual("Debug.log", pattern1.FileMask);

            pattern1 = PatternManager.GetPatternForLog("swDebug.log");
            Assert.AreEqual("*", pattern1.FileMask);

            //Test default parser
            pattern1 = PatternManager.GetPatternForLog("SomethingWhatShouldntExistsInParserDefinition-XYZ_BlaBlaBla");
            
            Assert.AreEqual("*", pattern1.FileMask);
            Assert.AreEqual(true, pattern1.ContainsClass);
            Assert.AreEqual(true, pattern1.ContainsThread);
            Assert.AreEqual(true, pattern1.ContainsType);
            Assert.AreEqual("yyyy-MM-dd HH:mm:ss,fff", pattern1.DateTimeFormat);            
        }
    }
}
