using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

namespace Blastdan.BambooHr.Infrastructure.Dto
{
    public partial class AllAggregateGoalInfoDto
    {
        public AllAggregateGoalInfoDto()
        {
            this.Filters = new List<Filter>();
            SelectedFilter = string.Empty;
            this.Goals = new List<Goal>();
            this.Persons = new List<Person>();
            this.Comments = new List<Comment>();
        }

        [JsonPropertyName("canAlign")]
        public bool CanAlign { get; set; }

        [JsonPropertyName("canCreateGoals")]
        public bool CanCreateGoals { get; set; }

        [JsonPropertyName("filters")]
        public List<Filter> Filters { get; set; }

        [JsonPropertyName("selectedFilter")]
        public string SelectedFilter { get; set; }

        [JsonPropertyName("goals")]
        public List<Goal> Goals { get; set; }

        [JsonPropertyName("persons")]
        public List<Person> Persons { get; set; }

        [JsonPropertyName("comments")]
        public List<Comment> Comments { get; set; }
    }

    public partial class Comment
    {
        public Comment()
        {
        }

        [JsonPropertyName("goalId")]
        public long GoalId { get; set; }

        [JsonPropertyName("commentCount")]
        public long CommentCount { get; set; }
    }

    public partial class Filter
    {
        public Filter()
        {
            this.Id = string.Empty;
            this.Name = string.Empty;
        }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("count")]
        public long Count { get; set; }
    }

    public partial class Goal
    {
        public Goal()
        {
            Title = string.Empty;
            Description = string.Empty;
            SharedWithEmployeeIds = new List<long>();
            Status = string.Empty;
        }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("percentComplete")]
        public long PercentComplete { get; set; }

        [JsonPropertyName("alignsWithOptionId")]
        public long? AlignsWithOptionId { get; set; }

        [JsonPropertyName("sharedWithEmployeeIds")]
        public List<long> SharedWithEmployeeIds { get; set; }

        [JsonPropertyName("dueDate")]
        public DateTimeOffset DueDate { get; set; }

        [JsonPropertyName("completionDate")]
        public DateTimeOffset CompletionDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    public partial class Person
    {

        public Person()
        {
            DisplayFirstName = "Unset";
            LastName = "Unset";
            PhotoUrl = new Uri("https://png.pngtree.com/png-clipart/20191120/original/pngtree-outline-user-icon-png-image_5045523.jpg");
        }

        [JsonPropertyName("employeeId")]
        public long EmployeeId { get; set; }

        [JsonPropertyName("userId")]
        public long UserId { get; set; }

        [JsonPropertyName("displayFirstName")]
        public string DisplayFirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("photoUrl")]
        public Uri PhotoUrl { get; set; }
    }
}
