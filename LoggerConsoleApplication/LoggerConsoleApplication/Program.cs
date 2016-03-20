using System;
using LoggerConsoleApplication.Enums;
using LoggerConsoleApplication.IoC;
using LoggerConsoleApplication.JobLogger;

namespace LoggerConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Testing logger";

            var container = CastleWindsorBootstrapper.GetWindsorContainer();
            var jobLogger = container.Resolve<IJobLogger>();
            jobLogger.LogMessage("Hello World", LogDestination.LogToConsole, LogType.Error);
            Console.ReadKey();
        }
    }
}
