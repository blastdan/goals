using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blastdan.Goals.Domain.Models
{
    public class GoalSummaries
    {
        public GoalSummaries()
        {
            Goals = new List<Goal>();
            SharedWith = new List<Employee>();
        }

        public GoalSummaries(IEnumerable<Goal> goals, IEnumerable<Employee> sharedWith)
        {
            Goals = goals;
            SharedWith = sharedWith;
        }

        public IEnumerable<Goal> Goals { get; private set; }

        public IEnumerable<Employee> SharedWith { get; set; }
    }
}
