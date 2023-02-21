using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.Goals.Domain.Models;

namespace Blastdan.BambooHr.Infrastructure.Models
{
    public class GoalsCache
    {
        public GoalsCache()
        {
            this.CurrentUserEmployeeId = 0;
        }

        public GoalsCache(Employee employee)
        {
            this.CurrentUserEmployeeId = employee.EmployeeId;
        }

        public int CurrentUserEmployeeId { get; set; }
    }
}
