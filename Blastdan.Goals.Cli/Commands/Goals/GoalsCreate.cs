using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.Goals.Domain.Commands;
using MediatR;
using Spectre.Console.Cli;
using Blastdan.Goals.Cli.Commands.Goals;
using Blastdan.Goals.Cli.Views;
using Spectre.Console;

namespace Blastdan.Goals.Cli.Commands.Goals
{
    public class GoalsCreate : AsyncCommand<GoalsCreateSettings>
    {
        private readonly IAnsiConsole console;
        private readonly IMediator mediator;

        public GoalsCreate(IAnsiConsole console, IMediator mediator)
        {
            this.console = console;
            this.mediator = mediator;
        }

        public override async Task<int> ExecuteAsync(CommandContext context, GoalsCreateSettings settings)
        {
            var view = new GoalCreateView(console);
            var goal = view.GenerateRequest(settings);

            await console.Status()
            .StartAsync("Creating your goal...", async ctx =>
            {
                var command = new CreateGoalCommand(goal);
                var newGoal = await mediator.Send(command);
                var viewResponse = view.Generate(newGoal);
                console.Write(viewResponse);
            });

            return (int)GoalsExitCode.SUCCESS;
        }
    }
}
