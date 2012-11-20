using System;
using System.IO;
using log4net.Config;
using log4net;
using System.Reflection;
using System.Configuration;

namespace LogLibrary
{
    public class Logger
    {
        private static Log _log;

        public static Log GetLogger(Type type)
        {
            if (LogManager.GetCurrentLoggers().Length == 0)
            {
                LoadConfig();
            }
            _log = new Log(LogManager.GetLogger(type));
            return _log;
        }

        private static void LoadConfig()
        {
            var log4NetConfigFilePath = LoadCustomtConfig();
            if (log4NetConfigFilePath == null)
            {
                log4NetConfigFilePath = LoadDefaultConfig();
            }

            Configure(log4NetConfigFilePath);
        }

        private static string LoadDefaultConfig()
        {
            var log4NetConfigDirectory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
            var log4NetConfigFilePath = Path.Combine(log4NetConfigDirectory, "Assets\\log4net.config");
            return log4NetConfigFilePath;
        }

        private static string LoadCustomtConfig()
        {
            string configFilePath = ConfigurationManager.AppSettings["log.config"];
            string log4NetConfigFilePath = null;

            if (configFilePath != null)
            {
                var log4NetConfigDirectory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
                log4NetConfigFilePath = Path.Combine(log4NetConfigDirectory, configFilePath);
            }
            return log4NetConfigFilePath;
        }

        private static void Configure(string log4NetConfigFilePath)
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetConfigFilePath));
        }

    }
}
