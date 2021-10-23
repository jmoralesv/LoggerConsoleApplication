using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LoggerConsoleApplication.JobLogger;
using LoggerConsoleApplication.Logger;
using System.Diagnostics.CodeAnalysis;

namespace LoggerConsoleApplication.IoC
{
    /// <summary>
    /// Handles the management of types that will be available for this application.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class JobLoggerInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Registers the types in the container that will be available for this application.
        /// </summary>
        /// <param name="container">IWindsorContainer container object.</param>
        /// <param name="store">IConfigurationStore object.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IJobLogger>().ImplementedBy<JobLogger.JobLogger>(),
                Component.For<IConsoleLogger>().ImplementedBy<ConsoleLogger>(),
                Component.For<IFileLogger>().ImplementedBy<FileLogger>(),
                Component.For<IDatabaseLogger>().ImplementedBy<DatabaseLogger>());
        }
    }
}
