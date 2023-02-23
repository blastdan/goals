using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.BambooHr.Infrastructure.Dto;
using Blastdan.Goals.Domain.Models;

namespace Blastdan.BambooHr.Infrastructure.Extensions
{
    public static class EmployeeExtensions
    {
        public static Employee ToEmployee(this EmployeeDto dal)
        {
            return new Employee(dal.Id, dal.FirstName, dal.LastName);
        }
    }
}
