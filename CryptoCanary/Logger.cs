using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCanary
{
    public enum LogLevels
    {
        Debug,
        Normal,
        HighPriority
    }

    public class Logger
    {
        private static Logger instance = null;
        public EventHandler<LoggerMessageArgs> LoggedMessage;

        private Logger()
        {
        }

        public static Logger Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }

        private static void LogMessage(string message, LogLevels level)
        {
            Instance.LoggedMessage?.Invoke(Instance, new LoggerMessageArgs(message, level));
        }

        public static void LogException(Exception e)
        {
            LogMessage("Exception: " + e.Message + "\nStack Trace: " + e.StackTrace, LogLevels.HighPriority);
        }

        public static void LogDebug(string message)
        {
            Logger.LogMessage(message, LogLevels.Debug);
        }

        public static void LogNormal(string message)
        {
            Logger.LogMessage(message, LogLevels.Normal);
        }
    }
}
