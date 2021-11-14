using AutoFixture.Xunit2;
using LoggerConsoleApplication.Enums;
using LoggerConsoleApplication.Logger;
using LoggerConsoleApplication.Tests.Attributes;
using Moq;
using Xunit;

namespace LoggerConsoleApplication.Tests.JobLogger
{
    public class JobLoggerTests
    {
        [Theory, AutoMoqData]
        public void LogMessage_ReturnException_WhenMessageIsNull(LoggerConsoleApplication.JobLogger.JobLogger jobLogger)
        {
            var emptyMessage = string.Empty;
            Assert.Throws<ArgumentNullException>(() => jobLogger.LogMessage(emptyMessage, LogDestination.LogToConsole, LogType.Message));
        }

        [Theory, AutoMoqData]
        public void LogMessage_ReturnException_WithWrongLogDestination(LoggerConsoleApplication.JobLogger.JobLogger jobLogger, string message)
        {
            const int wrongLogDestionation = 5;
            Assert.Throws<ArgumentOutOfRangeException>(() => jobLogger.LogMessage(message, (LogDestination)wrongLogDestionation, LogType.Message));
        }

        [Theory, AutoMoqData]
        public void LogMessage_ToConsole_WithWrongLogType([Frozen] Mock<IConsoleLogger> consoleLogger, LoggerConsoleApplication.JobLogger.JobLogger jobLogger, string message)
        {
            const int wrongLogType = 5;
            consoleLogger.Setup(x => x.LogMessage(It.IsAny<string>(), It.IsAny<LogType>()))
                .Callback((string m, LogType type) => throw new ArgumentOutOfRangeException(nameof(type)));

            Assert.Throws<ArgumentOutOfRangeException>(() => jobLogger.LogMessage(message, LogDestination.LogToConsole, (LogType)wrongLogType));
        }

        [Theory, AutoMoqData]
        public void LogMessage_ToConsole_Successfully([Frozen] Mock<IConsoleLogger> consoleLogger, LoggerConsoleApplication.JobLogger.JobLogger jobLogger, string message)
        {
            consoleLogger.Setup(x => x.LogMessage(It.IsAny<string>(), It.IsAny<LogType>())).Verifiable();

            var result = jobLogger.LogMessage(message, LogDestination.LogToConsole, LogType.Message);
            Assert.True(result);
        }

        [Theory, AutoMoqData]
        public void LogMessage_ToFile_Successfully([Frozen] Mock<IFileLogger> fileLogger, LoggerConsoleApplication.JobLogger.JobLogger jobLogger, string message)
        {
            fileLogger.Setup(x => x.LogMessage(It.IsAny<string>(), It.IsAny<LogType>())).Verifiable();

            var result = jobLogger.LogMessage(message, LogDestination.LogToFile, LogType.Message);
            Assert.True(result);
        }

        [Theory, AutoMoqData]
        public void LogMessage_ToDatabase_Successfully([Frozen] Mock<IDatabaseLogger> databaseLogger, LoggerConsoleApplication.JobLogger.JobLogger jobLogger, string message)
        {
            databaseLogger.Setup(x => x.LogMessage(It.IsAny<string>(), It.IsAny<LogType>())).Verifiable();

            var result = jobLogger.LogMessage(message, LogDestination.LogToDatabase, LogType.Message);
            Assert.True(result);
        }

        [Theory]
        [InlineAutoMoqData(LogDestination.LogToConsole, LogType.Message)]
        [InlineAutoMoqData(LogDestination.LogToDatabase, LogType.Warning)]
        [InlineAutoMoqData(LogDestination.LogToFile, LogType.Error)]
        public void LogMessage_UsingInlineData_Successfully(LogDestination logDestination, LogType logType, LoggerConsoleApplication.JobLogger.JobLogger jobLogger, string message)
        {
            var result = jobLogger.LogMessage(message, logDestination, logType);
            Assert.True(result);
        }
    }
}
