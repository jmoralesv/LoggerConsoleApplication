namespace LoggerConsoleApplication.Enums
{
    /// <summary>
    /// Types of destination where messages will be logged.
    /// </summary>
    public enum LogDestination
    {
        /// <summary>
        /// Save the message in a file.
        /// </summary>
        LogToFile = 1,
        /// <summary>
        /// Send the message to a console.
        /// </summary>
        LogToConsole,
        /// <summary>
        /// Save the message in a database.
        /// </summary>
        LogToDatabase
    }

    /// <summary>
    /// Kinds of messages to log.
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// The message is informative.
        /// </summary>
        Message = 1,
        /// <summary>
        /// The message is a warning.
        /// </summary>
        Warning,
        /// <summary>
        /// The message is an error.
        /// </summary>
        Error
    }
}
