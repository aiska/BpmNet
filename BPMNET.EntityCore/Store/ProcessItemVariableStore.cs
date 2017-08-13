using BPMNET.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BPMNET.EntityCore
{
    public class ProcessItemVariableStore : IDisposable
    {
        public DbSet<ProcessItemVariable> Entities { get; private set; }
        protected bool DisposeContext { private get; set; }
        protected DbContext Context { get; private set; }

        public ProcessItemVariableStore(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context;
            Entities = Context.Set<ProcessItemVariable>();
        }

        public ProcessItemVariableStore()
        {
            Context = new BpmDbContext();
            DisposeContext = true;
            Entities = Context.Set<ProcessItemVariable>();
        }

        public ProcessItemVariable FindById(Guid Key)
        {
            this.ThrowIfDisposed(_disposed);
            Key.ThrowIfNull();
            ProcessItemVariable result;
            //get from cache
            result = Cache.Get(Key.ToString()) as ProcessItemVariable;
            if (result == null)
            {
                //get from db
                return Entities.AsNoTracking().FirstOrDefault(t => t.Key.Equals(Key));
            }
            return result;
        }


        public void Create(ProcessItemVariable item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Add(item);
            SaveChanges();
            Cache.Add(item.Key.ToString(), item);
        }

        public void Update(ProcessItemVariable item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Update(item);
            SaveChanges();
            Cache.Set(item.Key.ToString(), item);
        }

        public void Delete(ProcessItemVariable item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Remove(item);
            SaveChanges();
            Cache.Remove(item.Key.ToString());
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
                    if (entry.Entity is ProcessItemVariable)
                    {
                        // Using a NoTracking query means we get the entity but it is not tracked by the context
                        // and will not be merged with existing entities in the context.
                        var databaseEntity = Entities.AsNoTracking().Single(p => p.Key == ((ProcessItemVariable)entry.Entity).Key);
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
