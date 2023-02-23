using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.BambooHr.Infrastructure.Respositories;
using Spectre.Console.Cli;

namespace Blastdan.Goals.Cli.Commands.Goals
{
    public class Goals : AsyncCommand
    {
        private readonly IGoalRepository goalRepository;
        public Goals(IGoalRepository goalRepository)
        {
            this.goalRepository = goalRepository;

        }

        public override async Task<int> ExecuteAsync(CommandContext context)
        {
            await goalRepository.GetAllAggregateGoalInfo();
            return (int)GoalsExitCode.SUCCESS;
        }
    }
}
