using BPMNET.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity
{
    public class ProcessTaskStore : ProcessTaskStore<string, ProcessTask>
    {
        public ProcessTaskStore():base(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public ProcessTaskStore(BpmDbContext context) : base(context)
        {
        }
    }
    public class ProcessTaskStore<TKey, TProcessTask> : IProcessTaskStore<TKey, TProcessTask>
    where TKey : IEquatable<TKey>
    where TProcessTask : class, IProcessTask<TKey>
    {
        private EntityStore<TProcessTask> _processTaskStore;
        public DbContext Context { get; private set; }
        protected bool DisposeContext { private get; set; }
        public ProcessTaskStore(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context;
            _processTaskStore = new EntityStore<TProcessTask>(context);
        }
        public IQueryable<TProcessTask> Entities
        {
            get { return _processTaskStore.EntitySet; }
        }


        public Task<TProcessTask> FindByIdAsync(TKey id)
        {
            this.ThrowIfDisposed(_disposed);
            if (id == null)
                throw new ArgumentNullException("id");
            return _processTaskStore.GetByIdAsync(id);
        }

        public TProcessTask FindById(TKey TaskId)
        {
            this.ThrowIfDisposed(_disposed);
            if (TaskId == null)
                throw new ArgumentNullException("TaskId");
            return _processTaskStore.GetById(TaskId);
        }

        public Task<TProcessTask> FindByProcessInstanceNameAsync(string ProcessInstanceName)
        {
            this.ThrowIfDisposed(_disposed);
            return _processTaskStore.EntitySet.FirstOrDefaultAsync((TProcessTask t) => t.Name == ProcessInstanceName);
        }

        public TProcessTask FindByProcessInstanceName(string ProcessInstanceName)
        {
            this.ThrowIfDisposed(_disposed);
            return _processTaskStore.EntitySet.FirstOrDefault((TProcessTask t) => t.Name == ProcessInstanceName);
        }

        public virtual async Task CreateAsync(TProcessTask item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
                throw new ArgumentNullException("item");
            _processTaskStore.Create(item);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task UpdateAsync(TProcessTask item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _processTaskStore.Update(item);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public void Update(TProcessTask item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _processTaskStore.Update(item);
            SaveChanges();
        }

        public virtual async Task DeleteAsync(TProcessTask item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _processTaskStore.Delete(item);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public void Delete(TProcessTask item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _processTaskStore.Delete(item);
            SaveChanges();
        }

        public void Create(TProcessTask item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _processTaskStore.Create(item);
            SaveChanges();
        }

        private void SaveChanges()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    Context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.Single().Reload();
                }

            } while (saveFailed);
        }

        private async Task SaveChangesAsync()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    await Context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.Single().Reload();
                }

            } while (saveFailed);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (DisposeContext && disposing && Context != null)
            {
                Context.Dispose();
            }
            _disposed = true;
            Context = null;
            _processTaskStore = null;
        }
    }
}
