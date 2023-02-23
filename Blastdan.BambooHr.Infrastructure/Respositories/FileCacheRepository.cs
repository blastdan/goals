using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Blastdan.BambooHr.Infrastructure.Models;

namespace Blastdan.BambooHr.Infrastructure.Respositories
{
    public class FileCacheRepository : IFileCacheRepository
    {
        private const string dotFolder = ".goals";
        private const string goalsCacheFileName = "goalsCache.json";
        private readonly DirectoryInfo dotInfo;
        private readonly FileInfo goalsCacheInfo;
        private readonly IFileWriter writer;

        public FileCacheRepository(IFileWriter writer)
        {
            this.writer = writer;
            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            dotInfo = new DirectoryInfo(Path.Combine(userProfile, dotFolder));
            goalsCacheInfo = new FileInfo(Path.Combine(dotInfo.FullName, goalsCacheFileName));
        }

        public GoalsCache Read()
        {
            var json = writer.Read(goalsCacheInfo.FullName);

            if (json == string.Empty)
            {
                return new GoalsCache();
            }

            var cache = JsonSerializer.Deserialize<GoalsCache>(json) ?? new GoalsCache();
            return cache;
        }

        public void Write(GoalsCache contents)
        {
            var json = JsonSerializer.Serialize(contents);
            writer.AddOrUpdate(goalsCacheInfo.FullName, json);
        }
    }
}
