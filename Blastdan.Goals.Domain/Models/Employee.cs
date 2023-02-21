using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blastdan.Goals.Domain.Models
{
    public class Employee
    {
        public Employee()
        {
            this.EmployeeId = 0;
            this.FirstName = "Not Defined";
            this.LastName = "Not Defined";
        }

        public Employee(int employeeId, string firstName, string lastName)
        {
            this.EmployeeId = employeeId;
            this.FirstName = firstName;
            this.LastName = lastName;

        }
        public int EmployeeId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override bool Equals(object? obj) => obj is Employee employee && this.EmployeeId == employee.EmployeeId;
        public override int GetHashCode() => HashCode.Combine(this.EmployeeId);
    }
}
