using System;
using System.IO;
using LoggerConsoleApplication.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LoggerConsoleApplication.Logger
{
    public class FileLogger : IFileLogger
    {
        private readonly string _fileNamePrefix = "LogFile";
        private readonly IConfiguration configuration;
        private readonly ILogger<FileLogger> innerLogger;

        public FileLogger(IConfiguration configuration, ILogger<FileLogger> innerLogger)
        {
            this.configuration = configuration;
            this.innerLogger = innerLogger;
        }

        public void LogMessage(string message, LogType logType)
        {
            var _fileDirectory = configuration["AppSettings:LogFileDirectory"];
            var fileName = string.Concat(_fileDirectory, _fileNamePrefix, DateTime.Now.ToString("yyyy-MM-dd"), ".txt");

            using var writer = File.AppendText(fileName);
            writer.WriteLine("{0} {1} {2}", DateTime.Now.ToShortDateString(), message, (int)logType);

            innerLogger.LogInformation($"Message was saved to file: {fileName}");
        }
    }
}
