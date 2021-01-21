using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Scarfsail.Logging;

namespace Scarfsail.Logging
{

    /// <summary>
    /// used for logging performance.
    /// <example>
    /// 
    /// <code>
    /// using(new PerformanceLogger("test01"))
    /// {
    /// // do some time consuming
    /// }
    /// </code>
    /// after ending the 'Using' block, something like 
    /// 
    /// PerformanceLogger: test01 took 10.00sec
    /// 
    /// can be also nested:
    /// <code>
    /// using(new PerformanceLogger("test01"))
    /// {
    ///     using(new PerformanceLogger("subtest02"))
    ///     {
    ///         // something time consuming
    ///     }
    ///     using(new PerformanceLogger("subtest03"))
    ///     {
    ///         // something time consuming
    ///     }
    /// }
    /// </code>
    /// writes
    /// PerformanceLogger: test01 took 10.00sec
    /// PerformanceLogger: test01.subtest02 took 4.00sec
    /// PerformanceLogger: test01.subtest03 took 6.00sec
    /// 
    /// 
    /// you can also add some message to performance logging with PerformanceLogger.FormatMessage(), it will look like
    /// PerformanceLogger: test01.subtest03 took 6.00sec AND SOME MESSAGE FOLLOWS
    /// 
    /// </example>
    /// </summary>
    public class PerformanceLogger 
        : IDisposable
    {
        private readonly static Log _log = new Log();

        [ThreadStatic]
        private static Stack<PerformanceLogger>? _callStack;

        private static Stack<PerformanceLogger> CallStack
        {
            get
            {
                return (_callStack ?? (_callStack = new Stack<PerformanceLogger>()));
            }
        }


        private string _name;
        private LogSeverity _logSeverity;
        private Stopwatch _watch;
        private bool _disposed = false;
        private string? _message = null;

        public static void FormatMessage(string s, params object[] p)
        {
            CallStack.Peek().DoFormatMessage(s, p);
        }

        private void DoFormatMessage(string s, params object[] p)
        {
            _message = string.Format(s, p);
        }

        public PerformanceLogger(string message)
            : this(message, LogSeverity.VERBOSE)
        {
            
        }


        public PerformanceLogger(string name, LogSeverity logSeverity)
        {
            if (CallStack.Count == 0)
                _name = name;
            else
                _name = CallStack.Peek()._name + "." + name;

            _logSeverity = logSeverity;

            CallStack.Push(this);
            _watch = Stopwatch.StartNew();
        }


        public void Dispose()
        {
            if (_disposed)
                return;

            try
            {
                _watch.Stop();
                _disposed = true;
                CallStack.Pop();

                string message = string.Format("PerformanceLogger: {0} took [{1:0.000}s] {2}", _name, _watch.ElapsedMilliseconds / 1000.0, _message??"");
                switch (_logSeverity)
                {
                    case LogSeverity.VERBOSE:
                    case LogSeverity.DEBUG:
                        _log.Debug(message);
                        break;
                    case LogSeverity.ERROR:
                        _log.Error(message);
                        break;
                    case LogSeverity.FATAL:
                        _log.Fatal(message);
                        break;
                    case LogSeverity.INFO:
                        _log.Info(message);
                        break;
                    case LogSeverity.WARNING:
                        _log.Warn(message);
                        break;
                }
            }
            catch (Exception) 
            {
                /* this code should NEVER crash!!!! */
            }

        }
    }
}
