using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LoggerConsoleApplication.JobLogger;
using LoggerConsoleApplication.Logger;

namespace LoggerConsoleApplication.IoC
{
    public class JobLoggerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IJobLogger>().ImplementedBy<JobLogger.JobLogger>(),
                Component.For<IConsoleLogger>().ImplementedBy<ConsoleLogger>(),
                Component.For<IFileLogger>().ImplementedBy<FileLogger>(),
                Component.For<IDatabaseLogger>().ImplementedBy<DatabaseLogger>());
        }
    }
}
