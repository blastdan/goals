using System;
using Blastdan.Goals.Cli.Commands.WhoAmI;
using Spectre.Console;
using Spectre.Console.Cli;
using goalCommand = Blastdan.Goals.Cli.Commands.Goals;

namespace Blastdan.Goals.Cli.Bootstrap
{
    public static class ConfigureCommands
    {
        public static void Configure(IConfigurator config)
        {
            config.AddCommand<WhoAmI>("whoami");
            config.AddCommand<goalCommand.Goals>("goals");
        }
    }
}
