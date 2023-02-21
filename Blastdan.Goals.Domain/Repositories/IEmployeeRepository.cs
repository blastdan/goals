using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.Goals.Domain.Models;

namespace Blastdan.Goals.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetApiKeyUser();
    }
}
