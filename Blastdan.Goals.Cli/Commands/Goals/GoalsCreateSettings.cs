using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.Goals.Domain.Models;
using Spectre.Console.Cli;

namespace Blastdan.Goals.Cli.Commands.Goals
{
    public class GoalsCreateSettings : CommandSettings
    {
        [CommandOption("-t|--title")]
        [Description("The goal title.")]
        public string Title { get; set; }

        [CommandOption("-d|--description")]
        [Description("The goal description.")]
        public string Description { get; set; }

        [CommandOption("-u|--duedate")]
        [Description("The goal due date in YYYY-mm-dd format.")]
        public DateTime DueDate { get; set; }

        [CommandOption("-p|--percent")]
        [Description("The goal completion percentage (0 - 100).")]
        public double PercentageComplete { get; set; }
    }

    public static class GoalsCreateSettingsExtensions
    {
        public static Goal ToGoal(this GoalsCreateSettings settings)
        {
            var goal = new Goal(default(long),
                                settings.Title,
                                settings.Description,
                                settings.DueDate,
                                settings.PercentageComplete);
            return goal;
        }
    }
}
