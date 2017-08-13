using BPMNET.Core;
using System;
using System.Data.Entity;

namespace BPMNET.Entity
{
    public class BpmFactory : IDisposable
    {
        //public DbContext Context { get; set; }
        //public IProcessInstanceManager ProcessInstance { get; protected set; }
        protected DbContext Context { get; private set; }

        public BpmFactory(string nameOrConnectionString, EKeyType keyType)
        {
            switch (keyType)
            {
                case EKeyType.Int:
                    Context = new IntKey.BpmDbContext(nameOrConnectionString);
                    //ProcessInstance = new IntKey.ProcessInstanceManager(new IntKey.ProcessInstanceStore((IntKey.BpmDbContext)Context));
                    break;
                case EKeyType.String:
                    Context = new BpmDbContext(nameOrConnectionString);
                    //ProcessInstance = new ProcessInstanceManager(new ProcessInstanceStore(new BpmDbContext(nameOrConnectionString)));
                    break;
                case EKeyType.Guid:
                    Context = new GuidKey.BpmDbContext(nameOrConnectionString);
                    //ProcessInstance = new GuidKey.ProcessInstanceManager(new GuidKey.ProcessInstanceStore((GuidKey.BpmDbContext)Context));
                    break;
                default:
                    Context = new BpmDbContext(nameOrConnectionString);
                    //ProcessInstance = new ProcessInstanceManager(new ProcessInstanceStore(new BpmDbContext(nameOrConnectionString)));
                    break;
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
            if (disposing && !_disposed)
            {
                Context.Dispose();
            }
            _disposed = true;
        }

        #endregion    }
    }
}
