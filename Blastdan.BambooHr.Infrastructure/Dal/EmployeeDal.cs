using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blastdan.BambooHr.Infrastructure.Dal
{
    public record EmployeeDal(int EmployeeId, string FirstName, string LastName)
    {
        public EmployeeDal() : this(0, "Not Defined", "Not Defined")
        { }
    }
}
