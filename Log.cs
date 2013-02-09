using log4net;
using log4net.Core;

namespace LogLibrary
{
    public class Log
    {
        private readonly ILog _log;

        public Log(ILog log)
        {
            _log = log;
        }

        public void Fatal(string message)
        {
            if (IsFatalEnabled)
                _log.Fatal(message);
        }

        public void Error(string message)
        {
            if (IsErrorEnabled)
                _log.Error(message);
        }

        public void Warn(string message)
        {
            if (IsWarnEnabled)
                _log.Warn(message);
        }

        public void Info(string message)
        {
            if (IsInfoEnabled)
                _log.Info(message);
        }

        public void Debug(string message)
        {
            if (IsDebugEnabled)
                _log.Debug(message);
        }

        public bool IsDebugEnabled
        {
            get { return _log.IsDebugEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return _log.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return _log.IsErrorEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return _log.IsInfoEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return _log.IsWarnEnabled; }
        }

        public ILogger Logger
        {
            get { return _log.Logger; }
        }
    }
}
