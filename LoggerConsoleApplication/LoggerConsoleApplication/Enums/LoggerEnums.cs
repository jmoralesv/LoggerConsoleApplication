namespace LoggerConsoleApplication.Enums
{
    public enum LogDestination
    {
        LogToFile = 1,
        LogToConsole,
        LogToDatabase
    }

    public enum LogType
    {
        Message = 1,
        Warning,
        Error
    }
}
