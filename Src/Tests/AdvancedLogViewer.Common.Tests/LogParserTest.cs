using AdvancedLogViewer.Common.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace AdvancedLogViewer.Common.Tests
{      
    /// <summary>
    ///This is a test class for LogParserTest and is intended
    ///to contain all LogParserTest Unit Tests
    ///</summary>
    [TestFixture]
    public class LogParserTest
    {        
        /// <summary>
        ///A test for LogParser Constructor
        ///</summary>
        [Test]
        public void LogParserConstructorTest()
        {
            string logFileName = logFileNameAllColumns;
            LogParser target = new LogParser(logFileName);

            Assert.AreNotEqual(null, target.AllLogPartsFileNames);
            Assert.AreEqual(false, target.DateIsParsed);
            Assert.AreEqual(false, target.LoadingInProgress);
            Assert.AreNotEqual(null, target.LogEntries);          
        }

        /// <summary>
        ///A test for LoadLogEntries with all columns in the log file (DateTime, Type, Class, ....)
        ///</summary>
        [Test]
        public void LoadLogEntriesAllColumnsTest()
        {
            string logFileName = this.logFileNameAllColumns;
            LogParser target = new LogParser(logFileName);
            target.LoadLogEntries();

            this.TestAllColumnsLoaded(target);
            
        }


        /// <summary>
        ///A test for LoadLogEntries with DateTime and Message columns only
        ///</summary>
        [Test]
        public void LoadLogEntriesDateAndMessageOnlyTest()
        {
            string logFileName = this.logFileNameDateAndMessageOnly;
            LogParser target = new LogParser(logFileName);
            target.LoadLogEntries();

            Assert.AreEqual(5, target.LogEntries.Count);
            Assert.IsTrue(target.DateIsParsed);
            Assert.IsFalse(target.LoadingInProgress);
            Assert.IsFalse(target.LogPattern.ContainsClass);
            Assert.IsFalse(target.LogPattern.ContainsThread);
            Assert.IsFalse(target.LogPattern.ContainsType);

            Assert.AreEqual(0, target.LogEntries[0].ItemNumber);
            Assert.AreEqual(1, target.LogEntries[0].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2-18-2010 05:21:24", "M-d-yyyy HH:mm:ss", CultureInfo.InvariantCulture), target.LogEntries[0].Date);
            Assert.IsNull(target.LogEntries[0].Thread);
            Assert.AreEqual(LogType.UNKNOWN, target.LogEntries[0].LogType);
            Assert.IsNull(target.LogEntries[0].Type);
            Assert.IsNull(target.LogEntries[0].Class);
            Assert.AreEqual(@"A InternalProgressReport call Searching for IP nodes; Determining connectivity for RNECAS-DEV2.swdev.local...
bbb
ccc
ddd", target.LogEntries[0].Message);


            Assert.AreEqual(1, target.LogEntries[1].ItemNumber);
            Assert.AreEqual(5, target.LogEntries[1].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2-18-2010 05:21:25", "M-d-yyyy HH:mm:ss", CultureInfo.InvariantCulture), target.LogEntries[1].Date);
            Assert.IsNull(target.LogEntries[1].Thread);
            Assert.AreEqual(LogType.UNKNOWN, target.LogEntries[1].LogType);
            Assert.IsNull(target.LogEntries[1].Type);
            Assert.IsNull(target.LogEntries[1].Class);
            Assert.AreEqual(@"B InternalProgressReport call Searching for IP nodes; Determining connectivity for RNECAS-DEV2.swdev.local...", target.LogEntries[1].Message);


            Assert.AreEqual(2, target.LogEntries[2].ItemNumber);
            Assert.AreEqual(6, target.LogEntries[2].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2-18-2010 05:21:26", "M-d-yyyy HH:mm:ss", CultureInfo.InvariantCulture), target.LogEntries[2].Date);
            Assert.IsNull(target.LogEntries[2].Thread);
            Assert.AreEqual(LogType.UNKNOWN, target.LogEntries[2].LogType);
            Assert.IsNull(target.LogEntries[2].Type);
            Assert.IsNull(target.LogEntries[2].Class);
            Assert.AreEqual(@"C InternalProgressReport call Searching for IP nodes; Determining connectivity for RNECAS-DEV2.swdev.local...
x1", target.LogEntries[2].Message);


            Assert.AreEqual(3, target.LogEntries[3].ItemNumber);
            Assert.AreEqual(8, target.LogEntries[3].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2-18-2010 05:21:27", "M-d-yyyy HH:mm:ss", CultureInfo.InvariantCulture), target.LogEntries[3].Date);
            Assert.IsNull(target.LogEntries[3].Thread);
            Assert.AreEqual(LogType.UNKNOWN, target.LogEntries[3].LogType);
            Assert.IsNull(target.LogEntries[3].Type);
            Assert.IsNull(target.LogEntries[3].Class);

            Assert.AreEqual(@"D InternalProgressReport call Searching for IP nodes; Determining connectivity for RNECAS-DEV2.swdev.local...
a", target.LogEntries[3].Message);


            Assert.AreEqual(4, target.LogEntries[4].ItemNumber);
            Assert.AreEqual(10, target.LogEntries[4].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2-18-2010 05:21:28", "M-d-yyyy HH:mm:ss", CultureInfo.InvariantCulture), target.LogEntries[4].Date);
            Assert.IsNull(target.LogEntries[4].Thread);
            Assert.AreEqual(LogType.UNKNOWN, target.LogEntries[4].LogType);
            Assert.IsNull(target.LogEntries[4].Type);
            Assert.IsNull(target.LogEntries[4].Class);

            Assert.AreEqual(@"E InternalProgressReport call Searching for IP nodes; Determining connectivity for RNECAS-DEV2.swdev.local...
b", target.LogEntries[4].Message);

        }


        /// <summary>
        ///A test for LoadLogEntries without Type column in the log file
        ///</summary>
        [Test]
        public void LoadLogEntriesWithoutTypeTest()
        {
            string logFileName = this.logFileNameWithoutType;
            LogParser target = new LogParser(logFileName);
            target.LoadLogEntries();

            Assert.AreEqual(5, target.LogEntries.Count);
            Assert.IsTrue(target.DateIsParsed);
            Assert.IsFalse(target.LoadingInProgress);
            Assert.IsFalse(target.LogPattern.ContainsClass);
            Assert.IsTrue(target.LogPattern.ContainsThread);
            Assert.IsFalse(target.LogPattern.ContainsType);

            Assert.AreEqual(0, target.LogEntries[0].ItemNumber);
            Assert.AreEqual(1, target.LogEntries[0].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2010-02-18 05:21:24,857", "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture), target.LogEntries[0].Date);
            Assert.AreEqual("30", target.LogEntries[0].Thread);
            Assert.AreEqual(LogType.UNKNOWN, target.LogEntries[0].LogType);
            Assert.IsNull(target.LogEntries[0].Type);
            Assert.IsNull(target.LogEntries[0].Class);
            Assert.AreEqual(@"A InternalProgressReport call Searching for IP nodes; Determining connectivity for RNECAS-DEV2.swdev.local...
bbb
ccc
ddd", target.LogEntries[0].Message);


            Assert.AreEqual(1, target.LogEntries[1].ItemNumber);
            Assert.AreEqual(5, target.LogEntries[1].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2010-02-18 05:21:24,906", "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture), target.LogEntries[1].Date);
            Assert.AreEqual("31", target.LogEntries[1].Thread);
            Assert.AreEqual(LogType.UNKNOWN, target.LogEntries[1].LogType);
            Assert.IsNull(target.LogEntries[1].Type);
            Assert.IsNull(target.LogEntries[1].Class);
            Assert.AreEqual("B InternalProgressReport call Searching for IP nodes; Determining connectivity for RNECAS-DEV2.swdev.local...", target.LogEntries[1].Message);


            Assert.AreEqual(2, target.LogEntries[2].ItemNumber);
            Assert.AreEqual(6, target.LogEntries[2].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2010-02-18 05:21:24,907", "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture), target.LogEntries[2].Date);
            Assert.AreEqual("32", target.LogEntries[2].Thread);
            Assert.AreEqual(LogType.UNKNOWN, target.LogEntries[2].LogType);
            Assert.IsNull(target.LogEntries[2].Type);
            Assert.IsNull(target.LogEntries[2].Class);
            Assert.AreEqual(@"C InternalProgressReport call Searching for IP nodes; Determining connectivity for RNECAS-DEV2.swdev.local...
x1", target.LogEntries[2].Message);


            Assert.AreEqual(3, target.LogEntries[3].ItemNumber);
            Assert.AreEqual(8, target.LogEntries[3].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2010-02-18 05:21:24,942", "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture), target.LogEntries[3].Date);
            Assert.AreEqual("33", target.LogEntries[3].Thread);
            Assert.AreEqual(LogType.UNKNOWN, target.LogEntries[3].LogType);
            Assert.IsNull(target.LogEntries[3].Type);
            Assert.IsNull(target.LogEntries[3].Class);
            Assert.AreEqual(@"D InternalProgressReport call Searching for IP nodes; Determining connectivity for RNECAS-DEV2.swdev.local...
a", target.LogEntries[3].Message);


            Assert.AreEqual(4, target.LogEntries[4].ItemNumber);
            Assert.AreEqual(10, target.LogEntries[4].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2010-02-18 05:21:24,942", "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture), target.LogEntries[4].Date);
            Assert.AreEqual("34", target.LogEntries[4].Thread);
            Assert.AreEqual(LogType.UNKNOWN, target.LogEntries[4].LogType);
            Assert.IsNull(target.LogEntries[4].Type);
            Assert.IsNull(target.LogEntries[4].Class);
            Assert.AreEqual(@"E InternalProgressReport call Searching for IP nodes; Determining connectivity for RNECAS-DEV2.swdev.local...
b", target.LogEntries[4].Message);
        }

        /// <summary>
        ///A test for LoadLogEntriesAsync
        ///</summary>
        [Test]
        public void LoadLogEntriesAsyncTest()
        {
            string logFileName = this.logFileNameAllColumns;
            LogParser target = new LogParser(logFileName);
            Thread thread = target.LoadLogEntriesAsync();
            thread.Join();
            Assert.IsFalse(target.LoadingInProgress);

            this.TestAllColumnsLoaded(target);
        }

        [Test]
        public void LoadLogWithFirstLineInWrongFormatTest()
        {
            string logFileName = this.logFileNameFirstLineInWrongFormat;
            LogParser target = new LogParser(logFileName);
            target.LoadLogEntries();

            Assert.AreEqual(3, target.LogEntries.Count);
            Assert.IsTrue(target.DateIsParsed);
            Assert.IsFalse(target.LoadingInProgress);
            Assert.IsTrue(target.LogPattern.ContainsClass);
            Assert.IsTrue(target.LogPattern.ContainsThread);
            Assert.IsTrue(target.LogPattern.ContainsType);

            Assert.AreEqual(0, target.LogEntries[0].ItemNumber);
            Assert.AreEqual(1, target.LogEntries[0].LineInFile);
            Assert.AreEqual("*** SolarWinds Alerting Engine v2010.1.0.0, .Net Runtime v2.0.50727 ***2010-05-13 14:14:15,967", target.LogEntries[0].DateText);
            Assert.AreEqual("MainTaskThread", target.LogEntries[0].Thread);
            Assert.AreEqual(LogType.INFO, target.LogEntries[0].LogType);
            Assert.AreEqual("All", target.LogEntries[0].Class);
            Assert.AreEqual(@"Alert Engine Starting. Running Version 2010.1.0.0.", target.LogEntries[0].Message);

            Assert.AreEqual(1, target.LogEntries[1].ItemNumber);
            Assert.AreEqual(2, target.LogEntries[1].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2010-05-13 17:15:58,236", "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture), target.LogEntries[1].Date);
            Assert.AreEqual("MainTaskThread", target.LogEntries[1].Thread);
            Assert.AreEqual(LogType.ERROR, target.LogEntries[1].LogType);
            Assert.AreEqual("All", target.LogEntries[1].Class);
            Assert.AreEqual(@"Error in SetupDBConnection System.Data.SqlClient.SqlException: SHUTDOWN is in progress.
Login failed for user 'SolarWindsNPM'.
A severe error occurred on the current command.  The results, if any, should be discarded.
   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj)
   at System.Data.SqlClient.TdsParser.Run(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj)
   at System.Data.SqlClient.SqlDataReader.ConsumeMetaData()
   at System.Data.SqlClient.SqlDataReader.get_MetaData()
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, DbAsyncResult result)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   at System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   at System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at AlertingEngine.SWAlertingEngine.SetupDBConnection(SqlConnection& DBConnection, SqlCommand& DBCommand, SqlDataReader& DBReader)", target.LogEntries[1].Message);            
        }

        [Test]
        public void LoadLogWithUtf8Text()
        {
            string logFileName = this.logFileNameUtf8;
            var target = new LogParser(logFileName);
            target.LoadLogEntries();

            Assert.AreEqual(1, target.LogEntries.Count);
            Assert.IsTrue(target.DateIsParsed);
            Assert.IsFalse(target.LoadingInProgress);
            Assert.IsTrue(target.LogPattern.ContainsClass);
            Assert.IsTrue(target.LogPattern.ContainsThread);
            Assert.IsTrue(target.LogPattern.ContainsType);

            Assert.AreEqual(0, target.LogEntries[0].ItemNumber);
            Assert.AreEqual(1, target.LogEntries[0].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2010-05-13 17:15:58,236", "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture), target.LogEntries[0].Date);
            Assert.AreEqual("MainTaskThread", target.LogEntries[0].Thread);
            Assert.AreEqual(LogType.ERROR, target.LogEntries[0].LogType);
            Assert.AreEqual("All", target.LogEntries[0].Class);
            Assert.AreEqual("Пожалуйста, укажите детали прибытия", target.LogEntries[0].Message);
        }

        /// <summary>
        ///A test for AbortLoading
        ///</summary>
        [Test]
        public void AbortLoadingTest()
        {
            string logFileName = this.logFileNameAllColumns;
            LogParser target = new LogParser(logFileName);
            target.LoadLogEntriesAsync();
            target.AbortLoading();
            Assert.IsFalse(target.LoadingInProgress);
        }
    

        private void TestAllColumnsLoaded(LogParser target)
        {
            Assert.AreEqual(5, target.LogEntries.Count);
            Assert.IsTrue(target.DateIsParsed);
            Assert.IsFalse(target.LoadingInProgress);
            Assert.IsTrue(target.LogPattern.ContainsClass);
            Assert.IsTrue(target.LogPattern.ContainsThread);
            Assert.IsTrue(target.LogPattern.ContainsType);

            Assert.AreEqual(0, target.LogEntries[0].ItemNumber);
            Assert.AreEqual(1, target.LogEntries[0].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2010-02-18 05:21:24,857", "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture), target.LogEntries[0].Date);
            Assert.AreEqual("30", target.LogEntries[0].Thread);
            Assert.AreEqual(LogType.DEBUG, target.LogEntries[0].LogType);
            Assert.AreEqual("DEBUG", target.LogEntries[0].Type);
            Assert.AreEqual("DiscoveryJob", target.LogEntries[0].Class);
            Assert.AreEqual(@"A InternalProgressReport call Searching for IP nodes; Determining connectivity for RNECAS-DEV2.swdev.local...
bbb
ccc
ddd", target.LogEntries[0].Message);


            Assert.AreEqual(1, target.LogEntries[1].ItemNumber);
            Assert.AreEqual(5, target.LogEntries[1].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2010-02-18 05:21:24,906", "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture), target.LogEntries[1].Date);
            Assert.AreEqual("30", target.LogEntries[1].Thread);
            Assert.AreEqual(LogType.ERROR, target.LogEntries[1].LogType);
            Assert.AreEqual("ERROR", target.LogEntries[1].Type);
            Assert.AreEqual("DiscoveryJob", target.LogEntries[1].Class);
            Assert.AreEqual("B InternalProgressReport call Searching for IP nodes; Determining connectivity for RNECAS-DEV2.swdev.local...", target.LogEntries[1].Message);


            Assert.AreEqual(2, target.LogEntries[2].ItemNumber);
            Assert.AreEqual(6, target.LogEntries[2].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2010-02-18 05:21:24,907", "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture), target.LogEntries[2].Date);
            Assert.AreEqual("30", target.LogEntries[2].Thread);
            Assert.AreEqual(LogType.FATAL, target.LogEntries[2].LogType);
            Assert.AreEqual("FATAL", target.LogEntries[2].Type);
            Assert.AreEqual("DiscoveryJob", target.LogEntries[2].Class);
            Assert.AreEqual(@"C InternalProgressReport call Searching for IP nodes; Determining connectivity for RNECAS-DEV2.swdev.local...
x1", target.LogEntries[2].Message);


            Assert.AreEqual(3, target.LogEntries[3].ItemNumber);
            Assert.AreEqual(8, target.LogEntries[3].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2010-02-18 05:21:24,942", "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture), target.LogEntries[3].Date);
            Assert.AreEqual("30", target.LogEntries[3].Thread);
            Assert.AreEqual(LogType.INFO, target.LogEntries[3].LogType);
            Assert.AreEqual("INFO", target.LogEntries[3].Type);
            Assert.AreEqual("DiscoveryJob", target.LogEntries[3].Class);
            Assert.AreEqual(@"D InternalProgressReport call Searching for IP nodes; Determining connectivity for RNECAS-DEV2.swdev.local...
a", target.LogEntries[3].Message);


            Assert.AreEqual(4, target.LogEntries[4].ItemNumber);
            Assert.AreEqual(10, target.LogEntries[4].LineInFile);
            Assert.AreEqual(DateTime.ParseExact("2010-02-18 05:21:24,942", "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture), target.LogEntries[4].Date);
            Assert.AreEqual("30", target.LogEntries[4].Thread);
            Assert.AreEqual(LogType.WARN, target.LogEntries[4].LogType);
            Assert.AreEqual("WARN", target.LogEntries[4].Type);
            Assert.AreEqual("DiscoveryJob", target.LogEntries[4].Class);
            Assert.AreEqual(@"E InternalProgressReport call Searching for IP nodes; Determining connectivity for RNECAS-DEV2.swdev.local...
b", target.LogEntries[4].Message);      
        }


        private readonly string logFileNameAllColumns = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestData\Logs\AllColumns.log");
        private readonly string logFileNameDateAndMessageOnly = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestData\Logs\DateAndMessageOnlyInstall.log");
        private readonly string logFileNameWithoutType = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestData\Logs\DiscoveryEngine.log");
        private readonly string logFileNameFirstLineInWrongFormat = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestData\Logs\FirstLineInWrongFormat.log");
        private readonly string logFileNameUtf8 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestData\Logs\UTF8.log");
    }
}
