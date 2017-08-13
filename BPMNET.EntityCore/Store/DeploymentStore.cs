using BPMNET.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BPMNET.EntityCore
{
    public class DeploymentStore : IDisposable
    {
        public DbSet<Deployment> Entities { get; private set; }
        protected bool DisposeContext { private get; set; }
        protected DbContext Context { get; private set; }

        public DeploymentStore(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context;
            Entities = Context.Set<Deployment>();
        }

        public DeploymentStore()
        {
            Context = new BpmDbContext();
            DisposeContext = true;
            Entities = Context.Set<Deployment>();
        }

        public Deployment FindById(Guid DeploymentId)
        {
            this.ThrowIfDisposed(_disposed);
            DeploymentId.ThrowIfNull();
            Deployment result;
            //get from cache
            result = Cache.Get(DeploymentId.ToString()) as Deployment;
            if (result == null)
            {
                //get from db
                return Entities.AsNoTracking().FirstOrDefault(t => t.DeploymentId.Equals(DeploymentId));
            }
            return result;
        }


        public void Create(Deployment item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Add(item);
            SaveChanges();
            Cache.Add(item.DeploymentId.ToString(), item);
        }

        public void Update(Deployment item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Update(item);
            SaveChanges();
            Cache.Set(item.DeploymentId.ToString(), item);
        }

        public void Delete(Deployment item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Remove(item);
            SaveChanges();
            Cache.Remove(item.DeploymentId.ToString());
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
                    if (entry.Entity is Deployment)
                    {
                        // Using a NoTracking query means we get the entity but it is not tracked by the context
                        // and will not be merged with existing entities in the context.
                        var databaseEntity = Entities.AsNoTracking().Single(p => p.DeploymentId == ((Deployment)entry.Entity).DeploymentId);
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
