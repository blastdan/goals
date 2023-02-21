using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.BambooHr.Infrastructure.Models;

namespace Blastdan.BambooHr.Infrastructure.Respositories
{
    public interface IFileCacheRepository
    {
        Task<GoalsCache> Read();
        Task Write(GoalsCache contents);
    }
}
