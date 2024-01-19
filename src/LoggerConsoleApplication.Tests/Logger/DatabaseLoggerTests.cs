using AutoFixture.Xunit2;
using LoggerConsoleApplication.Enums;
using LoggerConsoleApplication.Logger;
using LoggerConsoleApplication.Tests.Attributes;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace LoggerConsoleApplication.Tests.Logger;

public class DatabaseLoggerTests
{
    private const string connectionString = "Server=Test-Server;Database=LoggerDb;Trusted_Connection=True;Connect Timeout=1;";

    [Theory, AutoMoqData]
    public void LogMessage_MessageType_Successfully([Frozen] Mock<IConfiguration> configuration, DatabaseLogger databaseLogger, string message)
    {
        configuration.Setup(x => x[It.IsAny<string>()]).Returns(connectionString);

        Assert.Throws<SqlException>(() => databaseLogger.LogMessage(message, LogType.Message));
    }

    [Theory, AutoMoqData]
    public void LogMessage_WarningType_Successfully([Frozen] Mock<IConfiguration> configuration, DatabaseLogger databaseLogger, string message)
    {
        configuration.Setup(x => x[It.IsAny<string>()]).Returns(connectionString);

        Assert.Throws<SqlException>(() => databaseLogger.LogMessage(message, LogType.Warning));
    }

    [Theory, AutoMoqData]
    public void LogMessage_ErrorType_Successfully([Frozen] Mock<IConfiguration> configuration, DatabaseLogger databaseLogger, string message)
    {
        configuration.Setup(x => x[It.IsAny<string>()]).Returns(connectionString);

        Assert.Throws<SqlException>(() => databaseLogger.LogMessage(message, LogType.Error));
    }
}
