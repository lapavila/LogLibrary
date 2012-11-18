using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Configuration;
using log4net.Core;
using log4net.Config;
using System.IO;

namespace LogLibrary
{
    public class Logger
    {
        public enum LogType
        {
            None = 0,
            File = 1,
            Email = 2,
            ClientLog = 3,
            Sql = 4
        }
        public enum LogLevel
        {
            Debug = 1,
            Error = 2,
            Fatal = 3,
            Info = 4,
            Warn = 5
        }
        private readonly ILog log;
        private LogType logtype;

        public Logger(Type type)
        {
            logtype = LogType.None;

            var log4NetConfigDirectory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
            var log4NetConfigFilePath = Path.Combine(log4NetConfigDirectory, "Assets\\log4net.config");
            
            XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetConfigFilePath));

            log = LogManager.GetLogger(type);
        }

        public Logger(Type type, LogType logtype) : this(type)
        {
            this.logtype = logtype;
        }

        public void Log(LogLevel level, object message, Exception exception, LogType logtype)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    this.Debug(message, exception, logtype);
                    break;
                case LogLevel.Error:
                    this.Error(message, exception, logtype);
                    break;
                case LogLevel.Fatal:
                    this.Fatal(message, exception, logtype);
                    break;
                case LogLevel.Info:
                    this.Info(message, exception, logtype);
                    break;
                case LogLevel.Warn:
                    this.Warn(message, exception, logtype);
                    break;
            }
        }
        public void Log(LogLevel level, object message)
        {
            this.Log(level, message, null, this.logtype);
        }
        public void Log(LogLevel level, object message, Exception exception)
        {
            this.Log(level, message, exception, this.logtype);
        }
        public void Log(LogLevel level, object message, LogType logtype)
        {
            this.Log(level, message, null, logtype);
        }

        private void Debug(object message, Exception exception)
        {
            log.Debug(message, exception);
        }

        private void Debug(object message, Exception exception, LogType logtype)
        {
            logtype = this.logtype == LogType.None ? logtype : this.logtype;
            log4net.ThreadContext.Properties["LogType"] = logtype.ToString().ToLowerInvariant();
            log.Debug(message, exception);
        }

        private void Error(object message, Exception exception)
        {
            log.Error(message, exception);
        }

        private void Error(object message, Exception exception, LogType logtype)
        {
            logtype = this.logtype == LogType.None ? logtype : this.logtype;
            log4net.ThreadContext.Properties["LogType"] = logtype.ToString().ToLowerInvariant();
            log.Error(message, exception);
        }


        private void Fatal(object message, Exception exception)
        {
            log.Fatal(message, exception);
        }
        private void Fatal(object message, Exception exception, LogType logtype)
        {
            logtype = this.logtype == LogType.None ? logtype : this.logtype;
            log4net.ThreadContext.Properties["LogType"] = logtype.ToString().ToLowerInvariant();
            log.Fatal(message, exception);
        }

        private void Info(object message, Exception exception)
        {
            log.Info(message, exception);
        }
        private void Info(object message, Exception exception, LogType logtype)
        {
            logtype = this.logtype == LogType.None ? logtype : this.logtype;
            log4net.ThreadContext.Properties["LogType"] = logtype.ToString().ToLowerInvariant();
            log.Info(message, exception);
        }

        private void Warn(object message, Exception exception)
        {
            log.Warn(message, exception);
        }

        private void Warn(object message, Exception exception, LogType logtype)
        {
            logtype = this.logtype == LogType.None ? logtype : this.logtype;
            log4net.ThreadContext.Properties["LogType"] = logtype.ToString().ToLowerInvariant();
            log.Warn(message, exception);
        }
    }
}
