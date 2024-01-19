using Castle.Windsor;
using Castle.Windsor.Extensions.DependencyInjection;
using LoggerConsoleApplication.Enums;
using LoggerConsoleApplication.IoC;
using LoggerConsoleApplication.JobLogger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace LoggerConsoleApplication;

[ExcludeFromCodeCoverage]
public class Program
{
    public static void Main(string[] args)
    {
        Console.Title = "Testing logger";

        // DI in .NET Core in console app needs to handle its own scopes
        var builder = CreateHostBuilder(args);
        using var host = builder.Build();
        using var scope = host.Services.CreateScope();

        var jobLogger = scope.ServiceProvider.GetService<IJobLogger>();
        jobLogger.LogMessage("Hello World", LogDestination.LogToFile, LogType.Error);

        Console.ReadKey();
    }

    /// <summary>
    /// This method has to have this signature for EF Core migrations to work.
    /// </summary>
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new WindsorServiceProviderFactory())
            .ConfigureContainer<WindsorContainer>((hostBuilderContext, windsorContainer) =>
            {
                windsorContainer.Install(new JobLoggerInstaller());
            })
            .ConfigureLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddSimpleConsole(options =>
                {
                    options.IncludeScopes = true;
                    options.SingleLine = true;
                    options.TimestampFormat = "hh:mm:ss ";
                });
            })
            .UseConsoleLifetime();
}
