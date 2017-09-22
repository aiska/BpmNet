using System;
using System.Runtime.Caching;

namespace BPMNET.Core
{
    public class ProcessInstanceCache<TKey, TProcessInstance>
        where TKey : IEquatable<TKey>
        where TProcessInstance : class, IProcessInstance<TKey>
    {
        private MemoryCache cache;
        //private CacheItemPolicy _policy;
        private readonly string prefix = "ProcIns";
        private static CacheItemPolicy policy = new CacheItemPolicy();
        private static ProcessInstanceCache<TKey, TProcessInstance> instance = null;
        private static readonly object padlock = new object();

        #region Constructor ...
        public static ProcessInstanceCache<TKey, TProcessInstance> Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new ProcessInstanceCache<TKey, TProcessInstance>();
                        }
                    }
                }
                return instance;
            }
        }

        private ProcessInstanceCache()
        {
            cache = MemoryCache.Default;
        }
        #endregion

        #region Sub Routine ...
        private string getId(TKey id)
        {
            return prefix + id.ToString();
        }
        public virtual TProcessInstance GetById(TKey id)
        {
            TProcessInstance result = cache.Get(getId(id)) as TProcessInstance;
            return result;
        }

        public virtual void Add(TProcessInstance item)
        {
            Check.ThrowIfNull(item);
            Check.ThrowIfNull(item.ProcessInstanceId);
            string key = getId(item.ProcessInstanceId);
            cache.Add(key, item, policy);
        }

        public virtual void Set(TProcessInstance item)
        {
            Check.ThrowIfNull(item);
            string key = getId(item.ProcessInstanceId);
            cache.Set(key, item, policy);
        }

        public virtual void Remove(TProcessInstance item)
        {
            Check.ThrowIfNull(item);
            string key = getId(item.ProcessInstanceId);
            cache.Remove(key);
        }
        #endregion
    }
}
