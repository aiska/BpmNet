using BPMNET.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BPMNET.EntityCore
{
    public class ProcessTaskStore : IDisposable
    {
        public DbSet<ProcessTask> Entities { get; private set; }
        protected bool DisposeContext { private get; set; }
        protected DbContext Context { get; private set; }

        public ProcessTaskStore(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context;
            Entities = Context.Set<ProcessTask>();
        }

        public ProcessTaskStore()
        {
            Context = new BpmDbContext();
            DisposeContext = true;
            Entities = Context.Set<ProcessTask>();
        }

        public ProcessTask FindById(Guid ProcessTaskId)
        {
            this.ThrowIfDisposed(_disposed);
            ProcessTaskId.ThrowIfNull();
            ProcessTask result;
            //get from cache
            result = Cache.Get(ProcessTaskId.ToString()) as ProcessTask;
            if (result == null)
            {
                //get from db
                return Entities.AsNoTracking().FirstOrDefault(t => t.ProcessTaskId.Equals(ProcessTaskId));
            }
            return result;
        }


        public void Create(ProcessTask item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Add(item);
            SaveChanges();
            Cache.Add(item.ProcessTaskId.ToString(), item);
        }

        public void Update(ProcessTask item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Update(item);
            SaveChanges();
            Cache.Set(item.ProcessTaskId.ToString(), item);
        }

        public void Delete(ProcessTask item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Remove(item);
            SaveChanges();
            Cache.Remove(item.ProcessTaskId.ToString());
        }

        private void SaveChanges()
        {
            try
            {
                // Attempt to save changes to the database
                Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is ProcessTask)
                    {
                        // Using a NoTracking query means we get the entity but it is not tracked by the context
                        // and will not be merged with existing entities in the context.
                        var databaseEntity = Entities.AsNoTracking().Single(p => p.ProcessTaskId == ((ProcessTask)entry.Entity).ProcessTaskId);
                        var databaseEntry = Context.Entry(databaseEntity);

                        foreach (var property in entry.Metadata.GetProperties())
                        {
                            // Update original values to 
                            entry.Property(property.Name).OriginalValue = databaseEntry.Property(property.Name).CurrentValue;
                        }
                    }
                    else
                    {
                        throw new NotSupportedException("concurrency conflicts for " + entry.Metadata.Name);
                    }
                }
                // Retry the save operation
                Context.SaveChanges();
            }
        }

        #region Dispose ...
        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (DisposeContext && disposing && Context != null)
            {
                Context.Dispose();
            }
            _disposed = true;
            Context = null;
            Entities = null;
        }
        #endregion
    }
}
