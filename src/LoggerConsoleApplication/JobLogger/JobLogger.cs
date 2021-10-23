using LoggerConsoleApplication.Enums;
using LoggerConsoleApplication.Logger;
using System;

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

            ILogger logger = logDestination switch
            {
                LogDestination.LogToDatabase => _databaseLogger,
                LogDestination.LogToFile => _fileLogger,
                LogDestination.LogToConsole => _consoleLogger,
                _ => throw new ArgumentOutOfRangeException(nameof(logDestination), logDestination, "Invalid configuration"),
            };

            logger.LogMessage(message, logType);
            return true;
        }
    }
}
