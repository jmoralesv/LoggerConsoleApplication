using LoggerConsoleApplication.Enums;

namespace LoggerConsoleApplication.JobLogger;

/// <summary>
/// Specifies the methods that a job logger should implement.
/// </summary>
public interface IJobLogger
{
    /// <summary>
    /// Logs the specified message based on the given destination and its log type.
    /// </summary>
    /// <param name="message">Message to log.</param>
    /// <param name="logDestination">Destination where the message will be logged.</param>
    /// <param name="logType">Type of message.</param>
    /// <returns></returns>
    bool LogMessage(string message, LogDestination logDestination, LogType logType);
}
