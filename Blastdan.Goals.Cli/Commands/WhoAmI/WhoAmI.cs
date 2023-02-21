using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.Goals.Cli.Views;
using Blastdan.Goals.Domain.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Blastdan.Goals.Cli.Commands.WhoAmI
{
    public class WhoAmI : AsyncCommand
    {
        private readonly IAnsiConsole console;
        private readonly IEmployeeRepository repository;
        public WhoAmI(IAnsiConsole console, IEmployeeRepository repository)
        {
            this.console = console;
            this.repository = repository;
        }

        public override async Task<int> ExecuteAsync(CommandContext context)
        {
            var employee = await this.repository.GetApiKeyUser();
            var view = WhoAmIView.Generate(employee);
            console.Write(view);

            return (int)GoalsExitCode.SUCCESS;
        }
    }
}
