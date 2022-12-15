using LoggerConsoleApplication.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LoggerConsoleApplication.Logger
{
    public class FileLogger : IFileLogger
    {
        private const string FileNamePrefix = "LogFile";
        private readonly IConfiguration _configuration;
        private readonly ILogger<FileLogger> _innerLogger;

        public FileLogger(IConfiguration configuration, ILogger<FileLogger> innerLogger)
        {
            _configuration = configuration;
            _innerLogger = innerLogger;
        }

        public void LogMessage(string message, LogType logType)
        {
            var fileDirectory = _configuration["AppSettings:LogFileDirectory"];
            var fileName = string.Concat(fileDirectory, FileNamePrefix, DateTime.Now.ToString("yyyy-MM-dd"), ".txt");

            using var writer = File.AppendText(fileName);
            writer.WriteLine($"{DateTime.Now.ToShortDateString()} {message} {(int)logType}");

            _innerLogger.LogInformation("Message was saved to file: {fileName}", fileName);
        }
    }
}
