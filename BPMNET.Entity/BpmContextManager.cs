using BPMNET.Configuration;
using BPMNET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity
{
    public class BpmContextManager<TKey, TProcessInstance, TProcessDefinition> : IDisposable
    {
        private const string NOT_IMPLEMENT_IQUERYABLE = "Business Process Manager does not implement IProcessInstanceManager<TProcessInstance, TKey>";
        private const string INVALID_DBCONTEXT = "Invalid DbContext, DbContext must inherit from BpmDbContext";
        private const string INVALID_KEY_TYPE = "Type Key not supported";

        protected string KeyType { get; private set; }
        public DbContext Context { get; protected set; }
        protected bool DisposeContext { private get; set; }

        public ProcessInstanceManager<TKey, TProcessInstance, TProcessDefinition> Bpm<TKey, TProcessInstance, TProcessDefinition>() 
            where TProcessInstance : class, IProcessInstance<TKey> 
            where TKey : IEquatable<TKey>
        {
            ProcessInstanceManager<TKey, TProcessInstance, TProcessDefinition> manager;
            switch (KeyType.ToLower())
            {
                case "string":
                    manager = new ProcessInstanceManager(new ProcessInstanceStore((BpmDbContext)Context)) as ProcessInstanceManager<TProcessInstance, TKey>;
                    break;
                case "int":
                    manager = new IntKey.ProcessInstanceManager(new IntKey.ProcessInstanceStore((IntKey.BpmDbContext)Context)) as ProcessInstanceManager<TProcessInstance, TKey>;
                    break;
                case "guid":
                    manager = new GuidKey.ProcessInstanceManager(new GuidKey.ProcessInstanceStore((GuidKey.BpmDbContext)Context)) as ProcessInstanceManager<TProcessInstance, TKey>;
                    break;
                default:
                    throw new NotSupportedException(INVALID_KEY_TYPE);
            }
            if (manager == null)
            {
                throw new NotSupportedException(NOT_IMPLEMENT_IQUERYABLE);
            }
            return manager;
        }

        public BpmContextManager() :
            this(Config.Instance.ConnectionName, Config.Instance.KeyType, DatabaseGeneratedOption.None)
        { }
        public BpmContextManager(string nameOrConnectionString, string keyType, DatabaseGeneratedOption option)
        {
            if (keyType == null)
                throw new ArgumentNullException("keyType");
            KeyType = keyType;
            switch (keyType.ToLower())
            {
                case "string":
                    Context = new BpmDbContext(nameOrConnectionString);
                    break;
                case "int":
                    Context = new IntKey.BpmDbContext(nameOrConnectionString);
                    break;
                case "guid":
                    Context = new GuidKey.BpmDbContext(nameOrConnectionString);
                    break;
                default:
                    throw new NotSupportedException(INVALID_KEY_TYPE);
            }
            DisposeContext = true;
        }
        public BpmContextManager(DbContext context)
        {
            IBpmDbContext c = context as IBpmDbContext;
            if (c == null)
                throw new NotSupportedException(INVALID_DBCONTEXT);
            KeyType = c.KeyType;
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
            if (DisposeContext && disposing && !_disposed)
            {
                Context.Dispose();
            }
            _disposed = true;
        }

        #endregion
    }
}
