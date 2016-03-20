using System;
using System.Configuration;
using System.IO;
using LoggerConsoleApplication.Enums;

namespace LoggerConsoleApplication.Logger
{
    public class FileLogger : IFileLogger
    {
        private readonly string _fileDirectory = ConfigurationManager.AppSettings["LogFileDirectory"];
        private readonly string _fileNamePrefix = "LogFile";

        public void LogMessage(string message, LogType logType)
        {
            var fileName = string.Concat(_fileDirectory, _fileNamePrefix, DateTime.Now.ToString("yyyy-MM-dd"), ".txt");

            using (StreamWriter writer = File.AppendText(fileName))
            {
                writer.WriteLine("{0} {1} {2}", DateTime.Now.ToShortDateString(), message, (int)logType);
            }
        }
    }
}
