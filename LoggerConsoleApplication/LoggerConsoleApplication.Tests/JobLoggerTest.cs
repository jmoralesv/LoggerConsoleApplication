using System;
using Castle.Windsor;
using LoggerConsoleApplication.Enums;
using LoggerConsoleApplication.IoC;
using LoggerConsoleApplication.JobLogger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleUnitTests
{
    [TestClass]
    public class JobLoggerTest
    {
        private const string Message = "Hello world";
        private readonly IWindsorContainer _container;

        public JobLoggerTest()
        {
            _container = CastleWindsorBootstrapper.GetWindsorContainer();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LogMessage_ReturnException_WhenMessageIsNull()
        {
            var emptyMessage = string.Empty;
            var jobLogger = _container.Resolve<IJobLogger>();
            jobLogger.LogMessage(emptyMessage, LogDestination.LogToConsole, LogType.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LogMessage_ReturnException_WithWrongLogDestination()
        {
            const int wrongLogDestionation = 5;
            var jobLogger = _container.Resolve<IJobLogger>();
            jobLogger.LogMessage(Message, (LogDestination)wrongLogDestionation, LogType.Message);
        }

        [TestMethod]
        public void LogMessage_ToConsole_Successfully()
        {
            var jobLogger = _container.Resolve<IJobLogger>();
            var result = jobLogger.LogMessage(Message, LogDestination.LogToConsole, LogType.Message);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LogMessage_ToConsole_WithWrongLogType()
        {
            const int wrongLogType = 5;
            var jobLogger = _container.Resolve<IJobLogger>();
            jobLogger.LogMessage(Message, LogDestination.LogToConsole, (LogType)wrongLogType);
        }

        [TestMethod]
        public void LogMessage_ToFile_Successfully()
        {
            var jobLogger = _container.Resolve<IJobLogger>();
            var result = jobLogger.LogMessage(Message, LogDestination.LogToFile, LogType.Message);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))] //This is added just because we don't have a database yet.
        public void LogMessage_ToDatabase_Successfully()
        {
            var jobLogger = _container.Resolve<IJobLogger>();
            var result = jobLogger.LogMessage(Message, LogDestination.LogToDatabase, LogType.Message);
            Assert.IsTrue(result);
        }
    }
}
