using System;
using LoggerConsoleApplication.Enums;

namespace LoggerConsoleApplication.Logger
{
    public class ConsoleLogger : IConsoleLogger
    {
        public void LogMessage(string message, LogType logType)
        {
            switch (logType)
            {
                case LogType.Message:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logType), logType,
                        "Error or Warning or Message must be specified");
            }
            Console.WriteLine("{0} {1} {2}", DateTime.Now.ToShortDateString(), message, (int)logType);
        }
    }
}
