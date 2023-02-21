using System;
using Blastdan.Goals.Cli.Bootstrap;
using Spectre.Console.Cli;

namespace Blastdan.Goals.Cli
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            var host = GoalsHostBuilder.Generate(args);
            var registrar = new TypeRegistrar(host);
            var app = new CommandApp(registrar);
            app.Configure(ConfigureCommands.Configure);

            return await app.RunAsync(args);
        }
    }
}
