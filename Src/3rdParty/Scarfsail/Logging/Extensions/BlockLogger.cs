using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Scarfsail.Logging;

namespace Scarfsail.Logging
{
    /// <summary>
    /// Class intended to log function blocks like methods or some blocks inside methods
    /// </summary>
    public class BlockLogger
    {
        private Log log;
        private Action<string> logMessage;
        private string blockName;
        protected bool isLoggingEnabled;
        protected bool endWasCalled = false;
        private Action<BlockLoggerParams> fillResults;

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal BlockLogger(Log log, LogSeverity severity, string blockName, Action<BlockLoggerParams> fillParams, int callerLevel = 2)
        {
            isLoggingEnabled = GetIsLoggingEnabled(log, severity);
            if (!isLoggingEnabled)
                return;

            this.log = log;
            this.logMessage = GetLogMessageMethod(log, severity);
            this.blockName = blockName ?? new StackFrame(callerLevel, false).GetMethod().Name;
            this.fillResults = null;

            //Log the start
            string baseMessage = String.Format("Entered method: '{0}'", this.blockName);
            if (fillParams != null)
            {
                var bp = new BlockLoggerParams(log);
                fillParams(bp);
                baseMessage += " with parameters: " + bp.Text;
            }

            logMessage(baseMessage);
        }


        /// <summary>
        /// In case the End method is called without any parameters (without results), this text will be used
        public void SetResultInformation(Action<BlockLoggerParams> fillResults)
        {
            this.fillResults = fillResults;
        }

        public void End()
        {
            End(this.fillResults);
        }

        public void End(Action<BlockLoggerParams> fillResultText)
        {
            if (!isLoggingEnabled || endWasCalled)
                return;

            endWasCalled = true;
            string results = null;
            if (fillResultText != null)
            {
                var bp = new BlockLoggerParams(log);
                fillResultText(bp);
                results = bp.Text;
            }

            string baseMsg = String.Format("Finished method: '{0}'", blockName);

            if (results != null)
            {
                logMessage(baseMsg + " with results: " + results);
            }
            else
            {
                logMessage(baseMsg);
            }
        }


        private static Action<string> GetLogMessageMethod(Log log, LogSeverity logSeverity)
        {
            switch (logSeverity)
            {
                case LogSeverity.VERBOSE: return log.Verbose;
                case LogSeverity.DEBUG: return log.Debug;
                case LogSeverity.INFO: return log.Info;
                case LogSeverity.WARNING: return log.Warn;
                case LogSeverity.FATAL: return log.Fatal;
                case LogSeverity.ERROR: return log.Error;
                default:
                    throw new InvalidOperationException("Unsupported log severity: " + logSeverity.ToString());
            }
        }

        internal static bool GetIsLoggingEnabled(Log log, LogSeverity severity)
        {
            switch (severity)
            {
                case LogSeverity.VERBOSE: return log.IsVerboseEnabled;
                case LogSeverity.DEBUG: return log.IsDebugEnabled;
                case LogSeverity.INFO: return log.IsInfoEnabled;
                case LogSeverity.WARNING: return log.IsWarnEnabled;
                case LogSeverity.FATAL: return log.IsFatalEnabled;
                case LogSeverity.ERROR: return log.IsErrorEnabled;
                default:
                    throw new InvalidOperationException("Unsupported log severity: " + severity.ToString());
            }
        }
    }

    public static class LogBlockLoggerExtensions
    {
        /// <summary>
        /// Creates block logger with block name=caller method name and log severity set to DEBUG
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static BlockLogger EnterBlock(this Log log)
        {
            return new BlockLogger(log, LogSeverity.DEBUG, null, null);
        }

        /// <summary>
        /// Creates block logger with logSeverity=DEBUG, block name=caller method name and log level=DEBUG
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static BlockLogger EnterBlock(this Log log, Action<BlockLoggerParams> fillParams = null)
        {
            return new BlockLogger(log, LogSeverity.DEBUG, null, fillParams);
        }

        /// <summary>
        /// Creates block logger with block name=caller method name and optional parameters
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static BlockLogger EnterBlock(this Log log, LogSeverity logSeverity, Action<BlockLoggerParams> fillParams = null)
        {
            return new BlockLogger(log, logSeverity, null, fillParams);

        }
        /// <summary>
        /// Creates block logger with log severity=DEBUG defined block name and optional parameters
        /// </summary>
        public static BlockLogger EnterBlock(this Log log, string blockName, Action<BlockLoggerParams> fillParams = null)
        {
            return new BlockLogger(log, LogSeverity.DEBUG, blockName, fillParams);
        }

        /// <summary>
        /// Creates block logger with defined logSeverity, block name and optional parameters
        /// </summary>
        public static BlockLogger EnterBlock(this Log log, LogSeverity logSeverity, string blockName, Action<BlockLoggerParams> fillParams = null)
        {
            return new BlockLogger(log, logSeverity, blockName, fillParams);
        }
    }

}
