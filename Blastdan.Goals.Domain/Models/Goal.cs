using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blastdan.Goals.Domain.Models
{
    public class Goal
    {
        public Goal()
        {
            this.Id = 0;
            this.Title = "Goal Not Set";
            this.Description = string.Empty;
            this.PercentageComplete = 0.00;
            this.DueDate = DateTimeOffset.MinValue;
        }

        public Goal(long id, string title, string description, DateTimeOffset dueDate, double percentageComplete)
        {
            this.Id = id;
            this.Description = description;
            this.DueDate = dueDate;
            this.Title = title;
            this.PercentageComplete = percentageComplete;
        }

        public long Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public double PercentageComplete { get; private set; }
        public DateTimeOffset DueDate { get; private set; }

        public override bool Equals(object? obj) => obj is Goal goal && this.Id == goal.Id;
        public override int GetHashCode() => HashCode.Combine(this.Id);
    }
}
