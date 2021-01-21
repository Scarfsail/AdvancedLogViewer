using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Scarfsail.Logging
{
    public class Log
    {
        public static void Configure(string logFilePath, string baseLogFileName)
        {
            //_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}
            LogFilePath = logFilePath;

            var fileName = $"{Path.Combine(logFilePath, baseLogFileName)}.log";
            var outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss,fff} [{ThreadId}] {Level:u3} {ClassName} - {Message:lj}{NewLine}";

            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.WithThreadId()
                .WriteTo.Console(
                    outputTemplate: outputTemplate
                )
                .WriteTo.File(
                    fileName,
                    rollOnFileSizeLimit: true,
                    retainedFileCountLimit: 20,
                    fileSizeLimitBytes: 10/*B*/* 1024/*KB*/* 1024/*MB*/,
                    outputTemplate: outputTemplate,
                    shared: false
                )
                .CreateLogger();

        }

        readonly ILogger logger;

        public Log()
        {
            this.logger = Serilog.Log.Logger.ForContext("ClassName", GetCallerMethod()?.DeclaringType?.ToString() ?? "Caller method not found.");
        }

        public static string? LogFilePath { get; private set; }

        public void Debug(string msg)
        {
            if (this.IsDebugEnabled)
                this.logger.Debug(ComposeMessage(msg));
        }
        public void DebugFormat(string format, params object?[] args)
        {
            if (this.IsDebugEnabled)
                this.logger.Debug(ComposeMessage(string.Format(format, args)));
        }

        public void Info(string msg)
        {
            if (this.IsInfoEnabled)
                this.logger.Information(ComposeMessage(msg));
        }

        public void Warn(string msg)
        {
            if (this.IsWarnEnabled)
                this.logger.Warning(ComposeMessage(msg));
        }

        public void Error(string msg)
        {
            if (this.IsErrorEnabled)
                this.logger.Error(ComposeMessage(msg));
        }

        public void Fatal(string msg)
        {
            if (this.IsFatalEnabled)
                this.logger.Fatal(ComposeMessage(msg));
        }

        public void Verbose(string msg)
        {
            if (this.IsVerboseEnabled)
                this.logger.Verbose(ComposeMessage(msg));
        }


        public bool IsDebugEnabled => this.logger.IsEnabled(LogEventLevel.Debug);

        public bool IsInfoEnabled => this.logger.IsEnabled(LogEventLevel.Information);

        public bool IsWarnEnabled => this.logger.IsEnabled(LogEventLevel.Warning);

        public bool IsErrorEnabled => this.logger.IsEnabled(LogEventLevel.Error);

        public bool IsFatalEnabled => this.logger.IsEnabled(LogEventLevel.Fatal);

        public bool IsVerboseEnabled => this.logger.IsEnabled(LogEventLevel.Verbose);



        [MethodImpl(MethodImplOptions.NoInlining)]
        private static MethodBase? GetCallerMethod()
        {
            return new StackFrame(2, false).GetMethod();
        }

        private static string ComposeMessage(string msg)
        {
            return msg;
        }
    }
}
