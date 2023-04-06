using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.Goals.Cli.Commands.Goals;
using Blastdan.Goals.Domain.Models;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Blastdan.Goals.Cli.Views
{
    public class GoalCreateView
    {
        private readonly IAnsiConsole console;

        public GoalCreateView(IAnsiConsole console)
        {
            this.console = console;
        }

        public Goal GenerateRequest(GoalsCreateSettings settings)
        {
            if (string.IsNullOrWhiteSpace(settings.Title))
            {
                var title = console.Ask<string>("What is the title of your goal?");
                settings.Title = title;
            }

            if (string.IsNullOrWhiteSpace(settings.Description))
            {
                var description = console.Ask<string>("What is your goals description");
                settings.Description = description;
            }

            if (settings.DueDate == default(DateTime))
            {
                var dueDate = console.Ask<DateTime>("When is your goal due by yyyy-mm-dd?");
                settings.DueDate = dueDate;
            }

            if (settings.PercentageComplete == default(double))
            {
                var percentComplete = console.Ask<double>("What percentage of your goal have you completed (0-100)?");
                settings.PercentageComplete = percentComplete;
            }

            return settings.ToGoal();
        }

        public IRenderable Generate(Goal goal)
        {
            return new Markup($"Your new goal id is {goal.Id}");
        }
    }
}
