using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.Goals.Domain.Commands;
using Blastdan.Goals.Domain.Models;
using Blastdan.Goals.Domain.Repositories;
using MediatR;

namespace Blastdan.BambooHr.Infrastructure.Handlers
{
    public class CreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, Goal>
    {
        private readonly IGoalRepository goalRepository;

        public CreateGoalCommandHandler(IGoalRepository goalRepository)
        {
            this.goalRepository = goalRepository;
        }

        public async Task<Goal> Handle(CreateGoalCommand request, CancellationToken cancellationToken)
        {
            return await this.goalRepository.Create(request.GoalToCreate);
        }
    }
}
