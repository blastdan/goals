using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;
using Blastdan.Goals.Domain.Models;

namespace Blastdan.BambooHr.Infrastructure.Dto
{
    public partial class CreateGoalRequestDto
    {
        public CreateGoalRequestDto()
        {
            Description = string.Empty;
            SharedWithEmployeeIds = new List<long>();
            Title = string.Empty;
            Milestones = new List<MilestoneDto>();
        }

        public CreateGoalRequestDto(Goal goal)
        {
            Description = goal.Description;
            DueDate = goal.DueDate;
            Title = goal.Title;
            PercentageComplete = Convert.ToInt64(goal.PercentageComplete);
        }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("dueDate")]
        public DateTimeOffset DueDate { get; set; }

        [JsonPropertyName("sharedWithEmployeeIds")]
        public List<long> SharedWithEmployeeIds { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("percentComplete")]
        public long PercentageComplete { get; set; }

        [JsonPropertyName("milestones")]
        public List<MilestoneDto> Milestones { get; set; }
    }

    public static class CreateGoalRequestDtoExtensions
    {
        public static Goal ToGoal(this CreateGoalResponseDto goal)
        {
            var response = goal.Goal;
            var domainGoal = new Goal(response.Id, response.Title, response.Description, response.DueDate, response.PercentComplete);
            return domainGoal;
        }
    }
}
