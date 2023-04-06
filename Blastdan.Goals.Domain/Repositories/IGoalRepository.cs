using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.Goals.Domain.Models;

namespace Blastdan.Goals.Domain.Repositories
{
    public interface IGoalRepository
    {
        Task<IEnumerable<Goal>> GetAllAggregateGoalInfo(long employeeId = 0);
        Task<GoalSummaries> GetGoalSummaries(long employeeId = 0);
        Task<Goal> Create(Goal goal);
    }
}
