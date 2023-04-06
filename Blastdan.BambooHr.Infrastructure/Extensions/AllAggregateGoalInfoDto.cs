using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.BambooHr.Infrastructure.Dto;
using Blastdan.Goals.Domain.Models;

namespace Blastdan.BambooHr.Infrastructure.Extensions
{
    public static class AllAggregateGoalInfoDtoExtensions
    {
        public static IEnumerable<Goal> ToGoalList(this AllAggregateGoalInfoDto dto)
        {
            return dto.Goals.Select(ToGoal);
        }

        public static Goal ToGoal(this GoalDto dto)
        {
            var percentageComplete = dto.PercentComplete / 100d;
            return new Goal(dto.Id, dto.Title, dto.Description, dto.DueDate, percentageComplete);
        }
    }
}
