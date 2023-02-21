using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Blastdan.Goals.Cli.Bootstrap
{
    public static class GoalsConfigurationBuilder
    {
        public static void Build(HostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.AddEnvironmentVariables()
            .AddJsonFile("BambooHrSettings.json", optional: false)
            .AddUserSecrets(Assembly.GetExecutingAssembly(), true);
        }
    }
}
