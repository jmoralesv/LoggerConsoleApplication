using Castle.Windsor;

namespace LoggerConsoleApplication.IoC
{
    /// <summary>
    /// Handles the initialization of Castle Windsor stuff for this application.
    /// </summary>
    public static class CastleWindsorBootstrapper
    {
        /// <summary>
        /// Creates the container that will be used in the application to resolver types.
        /// </summary>
        /// <returns></returns>
        public static IWindsorContainer GetWindsorContainer()
        {
            return new WindsorContainer().Install(new JobLoggerInstaller());
        }
    }
}
