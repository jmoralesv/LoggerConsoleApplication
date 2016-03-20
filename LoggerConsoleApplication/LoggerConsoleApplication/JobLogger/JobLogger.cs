using System;
using LoggerConsoleApplication.Enums;
using LoggerConsoleApplication.Logger;

namespace LoggerConsoleApplication.JobLogger
{
    public class JobLogger : IJobLogger
    {
        private readonly IConsoleLogger _consoleLogger;
        private readonly IFileLogger _fileLogger;
        private readonly IDatabaseLogger _databaseLogger;

        public JobLogger(IConsoleLogger consoleLogger, IFileLogger fileLogger, IDatabaseLogger databaseLogger)
        {
            _consoleLogger = consoleLogger;
            _fileLogger = fileLogger;
            _databaseLogger = databaseLogger;
        }

        public bool LogMessage(string message, LogDestination logDestination, LogType logType)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message), "Message can't be null.");

            ILogger logger;

            switch (logDestination)
            {
                case LogDestination.LogToDatabase:
                    logger = _databaseLogger;
                    break;
                case LogDestination.LogToFile:
                    logger = _fileLogger;
                    break;
                case LogDestination.LogToConsole:
                    logger = _consoleLogger;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logDestination), logDestination,
                        "Invalid configuration");
            }
            logger.LogMessage(message, logType);
            return true;
        }
    }
}
