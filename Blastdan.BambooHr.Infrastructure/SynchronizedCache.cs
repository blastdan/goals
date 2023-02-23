using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Blastdan.BambooHr.Infrastructure.SynchronizedCache;

namespace Blastdan.BambooHr.Infrastructure
{
    public interface IFileWriter
    {
        string Read(string filePathAndName);
        void Write(string filePathAndName, string contents);
        AddOrUpdateStatus AddOrUpdate(string filePathAndName, string contents);
        void Delete(string filePathAndName);
    }

    public class SynchronizedCache : IFileWriter, IDisposable
    {
        private ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
        private bool disposedValue;

        public string Read(string filePathAndName)
        {
            cacheLock.EnterReadLock();
            try
            {
                if (!File.Exists(filePathAndName))
                {
                    return string.Empty;
                }
                return File.ReadAllText(filePathAndName);
            }
            finally
            {
                cacheLock.ExitReadLock();
            }
        }

        public void Write(string filePathAndName, string content)
        {
            cacheLock.EnterWriteLock();
            try
            {
                if (File.Exists(filePathAndName))
                {
                    return;
                }
                File.WriteAllText(filePathAndName, content);
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        public AddOrUpdateStatus AddOrUpdate(string filePathAndName, string content)
        {
            cacheLock.EnterUpgradeableReadLock();
            try
            {

                if (File.Exists(filePathAndName))
                {
                    var value = Read(filePathAndName);
                    if (value == content)
                    {
                        return AddOrUpdateStatus.Unchanged;
                    }
                    else
                    {
                        cacheLock.EnterWriteLock();
                        try
                        {
                            File.WriteAllText(filePathAndName, content);
                        }
                        finally
                        {
                            cacheLock.ExitWriteLock();
                        }
                        return AddOrUpdateStatus.Updated;
                    }
                }
                else
                {
                    cacheLock.EnterWriteLock();
                    try
                    {
                        File.WriteAllText(filePathAndName, content);
                    }
                    finally
                    {
                        cacheLock.ExitWriteLock();
                    }
                    return AddOrUpdateStatus.Added;
                }
            }
            finally
            {
                cacheLock.ExitUpgradeableReadLock();
            }
        }

        public void Delete(string filePathAndName)
        {
            cacheLock.EnterWriteLock();
            try
            {
                File.Delete(filePathAndName);
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        public enum AddOrUpdateStatus
        {
            Added,
            Updated,
            Unchanged
        };

        ~SynchronizedCache()
        {
            if (cacheLock != null)
                cacheLock.Dispose();
        }

        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.cacheLock.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
