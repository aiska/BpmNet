using BPMNET.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BPMNET.EntityCore
{
    public class ProcessHistoryStore : IDisposable
    {
        public DbSet<ProcessHistory> Entities { get; private set; }
        protected bool DisposeContext { private get; set; }
        protected DbContext Context { get; private set; }

        public ProcessHistoryStore(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context;
            Entities = Context.Set<ProcessHistory>();
        }

        public ProcessHistoryStore()
        {
            Context = new BpmDbContext();
            DisposeContext = true;
            Entities = Context.Set<ProcessHistory>();
        }

        public ProcessHistory FindById(Guid Key)
        {
            this.ThrowIfDisposed(_disposed);
            Key.ThrowIfNull();
            return Entities.AsNoTracking().FirstOrDefault(t => t.ProcessHistoryId.Equals(Key));
        }

        public void Create(ProcessHistory item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Add(item);
            SaveChanges();
        }

        public void Update(ProcessHistory item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Update(item);
            SaveChanges();
        }

        public void Delete(ProcessHistory item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Remove(item);
            SaveChanges();
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
                    if (entry.Entity is ProcessHistory)
                    {
                        // Using a NoTracking query means we get the entity but it is not tracked by the context
                        // and will not be merged with existing entities in the context.
                        var databaseEntity = Entities.AsNoTracking().Single(p => p.ProcessHistoryId == ((ProcessHistory)entry.Entity).ProcessHistoryId);
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
