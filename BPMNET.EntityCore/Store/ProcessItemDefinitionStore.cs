using BPMNET.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BPMNET.EntityCore
{
    public class ProcessItemDefinitionStore : IDisposable
    {
        public DbSet<ProcessItemDefinition> Entities { get; private set; }
        protected bool DisposeContext { private get; set; }
        protected DbContext Context { get; private set; }

        public ProcessItemDefinitionStore(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context;
            Entities = Context.Set<ProcessItemDefinition>();
        }

        public ProcessItemDefinitionStore()
        {
            Context = new BpmDbContext();
            DisposeContext = true;
            Entities = Context.Set<ProcessItemDefinition>();
        }

        public ProcessItemDefinition FindById(Guid Key)
        {
            this.ThrowIfDisposed(_disposed);
            Key.ThrowIfNull();
            ProcessItemDefinition result;
            //get from cache
            result = Cache.Get(Key.ToString()) as ProcessItemDefinition;
            if (result == null)
            {
                //get from db
                result = Entities.AsNoTracking().FirstOrDefault(t => t.Key.Equals(Key));
                Cache.Add(Key.ToString(), result);
            }
            return result;
        }

        public Guid[] GetSequenceFlow(Guid sourceRef)
        {
            this.ThrowIfDisposed(_disposed);
            sourceRef.ThrowIfNull();
            //get from cache
            Guid[] result;
            result = Cache.Get("Seq" + sourceRef.ToString()) as Guid[];
            if (result == null)
            {
                //get from db
                result = Entities.Where(t => t.ItemType.Equals(Bpmn.ProcessItemType.SequenceFlow) && t.ItemSourceRef.Equals(sourceRef)).AsEnumerable().Select(t => t.ItemSourceTarget).ToArray();
                Cache.Add("Seq" + sourceRef.ToString(), result);
            }
            return result;
        }

        public IQueryable<ProcessItemDefinition> GetStartEvent(Guid processKey)
        {
            return Entities.Where(t => t.ItemType.Equals(Bpmn.ProcessItemType.StartEvent) && t.ProcessKey.Equals(processKey));
        }

        public void Create(ProcessItemDefinition item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Add(item);
            SaveChanges();
            Cache.Add(item.Key.ToString(), item);
        }

        public void Update(ProcessItemDefinition item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Update(item);
            SaveChanges();
            Cache.Set(item.Key.ToString(), item);
        }

        public void Delete(ProcessItemDefinition item)
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
                    if (entry.Entity is ProcessItemDefinition)
                    {
                        // Using a NoTracking query means we get the entity but it is not tracked by the context
                        // and will not be merged with existing entities in the context.
                        var databaseEntity = Entities.AsNoTracking().Single(p => p.Key == ((ProcessItemDefinition)entry.Entity).Key);
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
