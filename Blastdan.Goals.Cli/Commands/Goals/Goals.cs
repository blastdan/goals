using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.BambooHr.Infrastructure.Respositories;
using Blastdan.Goals.Cli.Views;
using Blastdan.Goals.Domain.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Blastdan.Goals.Cli.Commands.Goals
{
    public class Goals : AsyncCommand
    {
        private readonly IAnsiConsole console;
        private readonly IGoalRepository goalRepository;
        public Goals(IAnsiConsole console, IGoalRepository goalRepository)
        {
            this.console = console;
            this.goalRepository = goalRepository;

        }

        public override async Task<int> ExecuteAsync(CommandContext context)
        {
            var goals = await goalRepository.GetAllAggregateGoalInfo();
            var view = GoalListView.Generate(goals);
            console.Write(view);
            return (int)GoalsExitCode.SUCCESS;
        }
    }
}
