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
            CreateIfNotExists(dotInfo);
            CreateIfNotExists(goalsCacheInfo, writer);
        }

        public async Task<GoalsCache> Read()
        {
            var json = await writer.ReadFile(goalsCacheInfo.FullName);
            var cache = JsonSerializer.Deserialize<GoalsCache>(json) ?? new GoalsCache();
            return cache;
        }

        public async Task Write(GoalsCache contents)
        {
            var json = JsonSerializer.Serialize(contents);
            await writer.UpdateFileAsync(json, goalsCacheInfo.FullName);
        }

        /// <summary>
        /// Creates the .director if it doesn't already exist
        /// </summary>
        /// <param name="directory"></param>
        private static void CreateIfNotExists(DirectoryInfo directory)
        {
            if (!Directory.Exists(directory.FullName))
            {
                Directory.CreateDirectory(directory.FullName);
            }
        }

        /// <summary>
        /// Writes a default cache contents into the file with the given file writer
        /// </summary>
        /// <param name="writer">A thead safe file writer is expected</param>
        /// <param name="file">Any file path</param>
        private static void CreateIfNotExists(FileInfo file, IFileWriter writer)
        {
            if (!File.Exists(file.FullName))
            {
                var cache = new GoalsCache();
                var contents = JsonSerializer.Serialize(cache);
                writer.WriteFile(contents, file.FullName);
            }
        }
    }
}
