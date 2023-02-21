using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blastdan.BambooHr.Infrastructure
{
    public interface IFileWriter
    {
        Task<string> ReadFile(string filePathAndName);
        void WriteFile(string fileContents, string filePathAndName);
        Task WriteFileAsync(string fileContents, string filePathAndName);
        Task UpdateFileAsync(string fileContents, string filePathAndName);
    }

    public class ThreadSafeFileWriter : IFileWriter
    {
        public async Task<string> ReadFile(string filePathAndName)
        {
            // This block will be protected area
            using (var mutex = new Mutex(false, filePathAndName.Replace("\\", "")))
            {
                var hasHandle = false;
                try
                {
                    // Wait for the muted to be available
                    hasHandle = mutex.WaitOne(Timeout.Infinite, false);
                    // Do the file read
                    if (!File.Exists(filePathAndName))
                        return string.Empty;
                    return await File.ReadAllTextAsync(filePathAndName);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    // Very important! Release the mutex
                    // Or the code will be locked forever
                    if (hasHandle)
                        mutex.ReleaseMutex();
                }
            }
        }

        public async Task UpdateFileAsync(string fileContents, string filePathAndName)
        {
            using (var mutex = new Mutex(false, filePathAndName.Replace("\\", "")))
            {
                var hasHandle = false;
                try
                {
                    hasHandle = mutex.WaitOne(Timeout.Infinite, false);
                    if (!File.Exists(filePathAndName))
                    {
                        return;
                    }
                    await File.WriteAllTextAsync(filePathAndName, fileContents);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    // Very important! Release the mutex
                    // Or the code will be locked forever
                    if (hasHandle)
                        mutex.ReleaseMutex();
                }
            }
        }

        public void WriteFile(string fileContents, string filePathAndName)
        {
            using (var mutex = new Mutex(false, filePathAndName.Replace("\\", "")))
            {
                var hasHandle = false;
                try
                {
                    hasHandle = mutex.WaitOne(Timeout.Infinite, false);
                    if (File.Exists(filePathAndName))
                    {
                        return;
                    }
                    File.WriteAllText(filePathAndName, fileContents);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (hasHandle)
                        mutex.ReleaseMutex();
                }
            }
        }

        public async Task WriteFileAsync(string fileContents, string filePathAndName)
        {
            using (var mutex = new Mutex(false, filePathAndName.Replace("\\", "")))
            {
                var hasHandle = false;
                try
                {
                    hasHandle = mutex.WaitOne(Timeout.Infinite, false);
                    if (File.Exists(filePathAndName))
                    {
                        return;
                    }
                    await File.WriteAllTextAsync(filePathAndName, fileContents);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (hasHandle)
                        mutex.ReleaseMutex();
                }
            }
        }
    }
}
