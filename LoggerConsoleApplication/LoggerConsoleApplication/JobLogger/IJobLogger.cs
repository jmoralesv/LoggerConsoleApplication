using LoggerConsoleApplication.Enums;

namespace LoggerConsoleApplication.JobLogger
{
    public interface IJobLogger
    {
        bool LogMessage(string message, LogDestination logDestination, LogType logType);
    }
}
