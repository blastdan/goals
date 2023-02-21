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
    public class SetCurrentUserCommandHandler : IRequestHandler<SetCurrentUserCommand>
    {
        private readonly IFileCacheRepository fileCacheRepository;

        public SetCurrentUserCommandHandler(IFileCacheRepository fileCacheRepository)
        {
            this.fileCacheRepository = fileCacheRepository;
        }

        public async Task Handle(SetCurrentUserCommand request, CancellationToken cancellationToken)
        {
            return;
        }
    }
}
