using LoggerConsoleApplication.Enums;
using LoggerConsoleApplication.Logger;

namespace LoggerConsoleApplication.JobLogger;

public class JobLogger(IConsoleLogger consoleLogger, IFileLogger fileLogger, IDatabaseLogger databaseLogger) : IJobLogger
{
    public bool LogMessage(string message, LogDestination logDestination, LogType logType)
    {
        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException(nameof(message), "Message can't be null.");

        ILogger logger = logDestination switch
        {
            LogDestination.LogToDatabase => databaseLogger,
            LogDestination.LogToFile => fileLogger,
            LogDestination.LogToConsole => consoleLogger,
            _ => throw new ArgumentOutOfRangeException(nameof(logDestination), logDestination, "Invalid configuration"),
        };

        logger.LogMessage(message, logType);
        return true;
    }
}
