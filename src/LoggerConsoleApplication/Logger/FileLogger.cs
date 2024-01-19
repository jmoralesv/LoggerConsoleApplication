using LoggerConsoleApplication.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LoggerConsoleApplication.Logger;

public class FileLogger(IConfiguration configuration, ILogger<FileLogger> innerLogger) : IFileLogger
{
    private const string FileNamePrefix = "LogFile";

    public void LogMessage(string message, LogType logType)
    {
        var fileDirectory = configuration["AppSettings:LogFileDirectory"];
        var fileName = string.Concat(fileDirectory, FileNamePrefix, DateTime.Now.ToString("yyyy-MM-dd"), ".txt");

        using var writer = File.AppendText(fileName);
        writer.WriteLine($"{DateTime.Now.ToShortDateString()} {message} {(int)logType}");

        innerLogger.LogInformation("Message was saved to file: {fileName}", fileName);
    }
}
