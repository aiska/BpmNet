using BPMNET.Core;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace BPMNET.Entity
{
    public class ProcessInstanceStore : ProcessInstanceStore<string, ProcessInstance>
    {
        public ProcessInstanceStore() : base(new BpmDbContext())
        {
            DisposeContext = true;
        }

        public ProcessInstanceStore(BpmDbContext context) : base(context) { }
    }
    public class ProcessInstanceStore<TKey, TProcessInstance> :
        IProcessInstanceStore<TKey, TProcessInstance>
        where TKey : IEquatable<TKey>
        where TProcessInstance : class, IProcessInstance<TKey>
    {
        private bool _disposed;
        private EntityStore<TProcessInstance> _processInstanceStore;
        private ProcessInstanceCache<TKey, TProcessInstance> cache;

        public ProcessInstanceStore(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context;
            _processInstanceStore = new EntityStore<TProcessInstance>(context);
            cache = ProcessInstanceCache<TKey, TProcessInstance>.Instance;
        }

        public DbContext Context { get; private set; }

        protected bool DisposeContext { private get; set; }
        public IQueryable<TProcessInstance> Entities
        {
            get { return _processInstanceStore.EntitySet; }
        }

        public Task<TProcessInstance> FindByIdAsync(TKey id)
        {
            this.ThrowIfDisposed(_disposed);
            if (id == null)
                throw new ArgumentNullException("id");
            return _processInstanceStore.GetByIdAsync(id);
        }

        public TProcessInstance FindById(TKey ProcessInstanceId)
        {
            this.ThrowIfDisposed(_disposed);
            if (ProcessInstanceId == null)
                throw new ArgumentNullException("ProcessInstanceId");
            return _processInstanceStore.GetById(ProcessInstanceId);
        }

        public Task<TProcessInstance> FindByProcessInstanceNameAsync(string ProcessInstanceName)
        {
            this.ThrowIfDisposed(_disposed);
            return _processInstanceStore.EntitySet.FirstOrDefaultAsync((TProcessInstance t) => t.Name == ProcessInstanceName);
        }

        public TProcessInstance FindByProcessInstanceName(string ProcessInstanceName)
        {
            this.ThrowIfDisposed(_disposed);
            return _processInstanceStore.EntitySet.FirstOrDefault((TProcessInstance t) => t.Name == ProcessInstanceName);
        }

        public virtual async Task CreateAsync(TProcessInstance item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
                throw new ArgumentNullException("item");
            _processInstanceStore.Create(item);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task UpdateAsync(TProcessInstance item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _processInstanceStore.Update(item);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public void Update(TProcessInstance item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _processInstanceStore.Update(item);
            SaveChanges();
        }

        public virtual async Task DeleteAsync(TProcessInstance item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _processInstanceStore.Delete(item);
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public void Delete(TProcessInstance item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _processInstanceStore.Delete(item);
            SaveChanges();
        }

        public void Create(TProcessInstance item)
        {
            this.ThrowIfDisposed(_disposed);
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _processInstanceStore.Create(item);
            SaveChanges();
        }

        private void SaveChanges() {
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
        protected virtual void Dispose(bool disposing)
        {
            if (DisposeContext && disposing && Context != null)
            {
                Context.Dispose();
            }
            _disposed = true;
            Context = null;
            _processInstanceStore = null;
        }
    }
}
