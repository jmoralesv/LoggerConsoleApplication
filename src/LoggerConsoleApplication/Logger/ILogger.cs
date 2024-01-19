using LoggerConsoleApplication.Enums;

namespace LoggerConsoleApplication.Logger;

/// <summary>
/// Defines a common logger signature for logging messages to different kind of destinations.
/// </summary>
public interface ILogger
{
    /// <summary>
    /// Logs the specified message.
    /// </summary>
    /// <param name="message">A message to log.</param>
    /// <param name="logType">The kind of message to log.</param>
    void LogMessage(string message, LogType logType);
}
