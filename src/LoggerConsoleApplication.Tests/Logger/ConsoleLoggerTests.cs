using LoggerConsoleApplication.Enums;
using LoggerConsoleApplication.Logger;
using LoggerConsoleApplication.Tests.Attributes;
using Xunit;

namespace LoggerConsoleApplication.Tests.Logger
{
    public class ConsoleLoggerTests
    {
        [Theory, AutoMoqData]
        public void LogMessage_MessageType_Successfully(ConsoleLogger consoleLogger, string message)
        {
            consoleLogger.LogMessage(message, LogType.Message);
        }

        [Theory, AutoMoqData]
        public void LogMessage_WarningType_Successfully(ConsoleLogger consoleLogger, string message)
        {
            consoleLogger.LogMessage(message, LogType.Warning);
        }

        [Theory, AutoMoqData]
        public void LogMessage_ErrorType_Successfully(ConsoleLogger consoleLogger, string message)
        {
            consoleLogger.LogMessage(message, LogType.Error);
        }

        [Theory, AutoMoqData]
        public void LogMessage_UnknownType_ThrowsError(ConsoleLogger consoleLogger, string message)
        {
            const int wrongLogType = 5;

            Assert.Throws<ArgumentOutOfRangeException>(() => consoleLogger.LogMessage(message, (LogType)wrongLogType));
        }
    }
}
