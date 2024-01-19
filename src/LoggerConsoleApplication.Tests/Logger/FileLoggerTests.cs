using AutoFixture.Xunit2;
using LoggerConsoleApplication.Enums;
using LoggerConsoleApplication.Logger;
using LoggerConsoleApplication.Tests.Attributes;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace LoggerConsoleApplication.Tests.Logger;

public class FileLoggerTests
{
    [Theory, AutoMoqData]
    public void LogMessage_MessageType_Successfully([Frozen] Mock<IConfiguration> configuration, FileLogger fileLogger, string message)
    {
        configuration.Setup(x => x[It.IsAny<string>()]).Returns(string.Empty);

        fileLogger.LogMessage(message, LogType.Message);
    }

    [Theory, AutoMoqData]
    public void LogMessage_WarningType_Successfully([Frozen] Mock<IConfiguration> configuration, FileLogger fileLogger, string message)
    {
        configuration.Setup(x => x[It.IsAny<string>()]).Returns(string.Empty);

        fileLogger.LogMessage(message, LogType.Warning);
    }

    [Theory, AutoMoqData]
    public void LogMessage_ErrorType_Successfully([Frozen] Mock<IConfiguration> configuration, FileLogger fileLogger, string message)
    {
        configuration.Setup(x => x[It.IsAny<string>()]).Returns(string.Empty);

        fileLogger.LogMessage(message, LogType.Error);
    }
}
