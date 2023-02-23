using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.BambooHr.Infrastructure.Models;
using Blastdan.BambooHr.Infrastructure.Respositories;
using Blastdan.Goals.Domain.Commands;
using Blastdan.Goals.Domain.Repositories;
using MediatR;

namespace Blastdan.BambooHr.Infrastructure.Handlers
{
    public class SetCurrentUserCommandHandler : IRequestHandler<SetCurrentUserCommand, long>
    {
        private readonly IFileCacheRepository fileCacheRepository;
        private readonly IEmployeeRepository employeeRepository;

        public SetCurrentUserCommandHandler(IFileCacheRepository fileCacheRepository, IEmployeeRepository employeeRepository)
        {
            this.fileCacheRepository = fileCacheRepository;
            this.employeeRepository = employeeRepository;
        }

        public async Task<long> Handle(SetCurrentUserCommand request, CancellationToken cancellationToken)
        {
            var user = fileCacheRepository.Read();
            if (user.CurrentUserEmployeeId == 0)
            {
                var employee = await employeeRepository.GetApiKeyUser();
                fileCacheRepository.Write(new GoalsCache(employee));
                user.CurrentUserEmployeeId = employee.EmployeeId;
            }

            return user.CurrentUserEmployeeId;
        }
    }
}
