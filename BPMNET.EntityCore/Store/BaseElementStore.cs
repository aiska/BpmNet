using BPMNET.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BPMNET.EntityCore
{
    public abstract class BaseElementStore<TEntity> : BaseStore<TEntity>
        where TEntity : class, IBaseElement, new()
    {
        #region Constructor ...
        public BaseElementStore(DbContext context) : base(context) { }

        public BaseElementStore() : base() { }
        #endregion


        public override TEntity FindById(Guid Key)
        {
            this.ThrowIfDisposed(_disposed);
            Key.ThrowIfNull();
            TEntity result;
            //get from cache
            result = Cache.Get(Key.ToString()) as TEntity;
            if (result == null)
            {
                //get from db
                return Entities.AsNoTracking().FirstOrDefault(t => t.Key.Equals(Key));
            }
            return result;
        }

        public override async Task<TEntity> FindByIdAsync(Guid Key)
        {
            this.ThrowIfDisposed(_disposed);
            Key.ThrowIfNull();
            TEntity result;
            //get from cache
            result = Cache.Get(Key.ToString()) as TEntity;
            if (result == null)
            {
                //get from db
                return await Entities.AsNoTracking().FirstOrDefaultAsync(t => t.Key.Equals(Key)).ConfigureAwait(false);
            }
            return result;
        }

        public override void Create(TEntity item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Add(item);
            SaveChanges();
            Cache.Add(item.Key.ToString(), item);
        }
        public override async Task CreateAsync(TEntity item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Add(item);
            await SaveChangesAsync();
            Cache.Add(item.Key.ToString(), item);
        }

        public override void Update(TEntity item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Update(item);
            SaveChanges();
            Cache.Set(item.Key.ToString(), item);
        }

        public override async Task UpdateAsync(TEntity item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Update(item);
            await SaveChangesAsync();
            Cache.Set(item.Key.ToString(), item);
        }

        public override void Delete(TEntity item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Remove(item);
            SaveChanges();
            Cache.Remove(item.Key.ToString());
        }

        public override async Task DeleteAsync(TEntity item)
        {
            this.ThrowIfDisposed(_disposed);
            item.ThrowIfNull();
            Entities.Remove(item);
            await SaveChangesAsync();
            Cache.Remove(item.Key.ToString());
        }

        protected void SaveChanges()
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
                    if (entry.Entity is TEntity)
                    {
                        // Using a NoTracking query means we get the entity but it is not tracked by the context
                        // and will not be merged with existing entities in the context.
                        var databaseEntity = Entities.AsNoTracking().Single(p => p.Key == ((TEntity)entry.Entity).Key);
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

        protected async Task SaveChangesAsync()
        {
            try
            {
                // Attempt to save changes to the database
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is TEntity)
                    {
                        // Using a NoTracking query means we get the entity but it is not tracked by the context
                        // and will not be merged with existing entities in the context.
                        var databaseEntity = Entities.AsNoTracking().Single(p => p.Key == ((TEntity)entry.Entity).Key);
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
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
