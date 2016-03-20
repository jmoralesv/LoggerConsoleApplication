using Castle.Windsor;

namespace LoggerConsoleApplication.IoC
{
    public static class CastleWindsorBootstrapper
    {
        public static IWindsorContainer GetWindsorContainer()
        {
            return new WindsorContainer().Install(new JobLoggerInstaller());
        }
    }
}
