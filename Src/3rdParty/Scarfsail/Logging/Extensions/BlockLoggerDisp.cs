using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Scarfsail.Logging;

namespace Scarfsail.Logging
{
    public class BlockLoggerDisp : BlockLogger, IDisposable
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal BlockLoggerDisp(Log log, LogSeverity severity, string blockName, Action<BlockLoggerParams> fillParams)
            :base(log, severity, blockName, fillParams, 3)
        {

        }

        public void Dispose()
        {
            this.End();
        }
    }


    public static class LogBlockLoggerDispExtensions
    {

        /// <summary>
        /// Creates block logger with block name=caller method name and log severity set to DEBUG
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static BlockLoggerDisp EnterBlockDisp(this Log log)
        {
            return new BlockLoggerDisp(log, LogSeverity.DEBUG, null, null);
        }

        /// <summary>
        /// Creates block logger with logSeverity=DEBUG, block name=caller method name and log level=DEBUG
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static BlockLoggerDisp EnterBlockDisp(this Log log, Action<BlockLoggerParams> fillParams = null)
        {
            return new BlockLoggerDisp(log, LogSeverity.DEBUG, null, fillParams);
        }

        /// <summary>
        /// Creates block logger with block name=caller method name and optional parameters
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static BlockLoggerDisp EnterBlockDisp(this Log log, LogSeverity logSeverity, Action<BlockLoggerParams> fillParams = null)
        {
            return new BlockLoggerDisp(log, logSeverity, null, fillParams);

        }
        /// <summary>
        /// Creates block logger with log severity=DEBUG defined block name and optional parameters
        /// </summary>
        public static BlockLoggerDisp EnterBlockDisp(this Log log, string blockName, Action<BlockLoggerParams> fillParams = null)
        {
            return new BlockLoggerDisp(log, LogSeverity.DEBUG, blockName, fillParams);
        }

        /// <summary>
        /// Creates block logger with defined logSeverity, block name and optional parameters
        /// </summary>
        public static BlockLoggerDisp EnterBlockDisp(this Log log, LogSeverity logSeverity, string blockName, Action<BlockLoggerParams> fillParams = null)
        {
            return new BlockLoggerDisp(log, logSeverity, blockName, fillParams);
        }
    }
}
