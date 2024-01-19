using LoggerConsoleApplication.Enums;

namespace LoggerConsoleApplication.Logger;

public class ConsoleLogger : IConsoleLogger
{
    public void LogMessage(string message, LogType logType)
    {
        Console.ForegroundColor = logType switch
        {
            LogType.Message => ConsoleColor.White,
            LogType.Warning => ConsoleColor.Yellow,
            LogType.Error => ConsoleColor.Red,
            _ => throw new ArgumentOutOfRangeException(nameof(logType), logType, "Error or Warning or Message must be specified"),
        };
        Console.WriteLine($"{DateTime.Now.ToShortDateString()} {message} {(int)logType}");
    }
}
