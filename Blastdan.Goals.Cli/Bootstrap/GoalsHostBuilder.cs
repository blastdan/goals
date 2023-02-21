using Microsoft.Extensions.Hosting;

namespace Blastdan.Goals.Cli.Bootstrap
{
    public static class GoalsHostBuilder
    {
        public static IHostBuilder Generate(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                       .ConfigureAppConfiguration(GoalsConfigurationBuilder.Build)
                       .ConfigureServices(GoalsServiceConfiguration.Configure)
                       .UseConsoleLifetime();
        }
    }
}
