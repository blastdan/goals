using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.BambooHr.Infrastructure.Dal;
using Blastdan.Goals.Domain.Models;

namespace Blastdan.BambooHr.Infrastructure.Extensions
{
    public static class EmployeeExtensions
    {
        public static Employee ToEmployee(this EmployeeDal dal)
        {
            return new Employee(dal.EmployeeId, dal.FirstName, dal.LastName);
        }
    }
}
