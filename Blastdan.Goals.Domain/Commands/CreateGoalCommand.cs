using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.Goals.Domain.Models;
using MediatR;

namespace Blastdan.Goals.Domain.Commands
{
    public class CreateGoalCommand : IRequest<Goal>
    {
        public CreateGoalCommand(Goal goalToCreate)
        {
            GoalToCreate = goalToCreate;
        }

        public Goal GoalToCreate { get; private set; }
    }
}
