using System;
using Blastdan.Goals.Cli.Commands.WhoAmI;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Blastdan.Goals.Cli.Bootstrap
{
    public static class ConfigureCommands
    {
        public static void Configure(IConfigurator config)
        {
            config.AddCommand<WhoAmI>("whoami");
        }
    }
}
