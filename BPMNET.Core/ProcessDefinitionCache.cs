using System;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public class ProcessDefinitionCache<TKey, TProcessDefinition>
        where TKey : IEquatable<TKey>
        where TProcessDefinition : class, IProcessDefinition<TKey>
    {
        private MemoryCache cache;
        private readonly string prefix = "ProcDef";
        private readonly string prefixName = "ProcDefName";
        private static CacheItemPolicy policy = new CacheItemPolicy();
        private static ProcessDefinitionCache<TKey, TProcessDefinition> instance = null;
        private static readonly object padlock = new object();

        #region Constructor ...
        public static ProcessDefinitionCache<TKey, TProcessDefinition> Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new ProcessDefinitionCache<TKey, TProcessDefinition>();
                        }
                    }
                }
                return instance;
            }
        }

        private ProcessDefinitionCache()
        {
            cache = MemoryCache.Default;
        }
        #endregion

        #region Sub Routine ...
        private string getId(TKey id)
        {
            return prefix + id.ToString();
        }
        private string getName(string name)
        {
            return prefixName + name;
        }
        public virtual TProcessDefinition GetById(TKey id)
        {
            TProcessDefinition result = cache.Get(getId(id)) as TProcessDefinition;
            return result;
        }

        public virtual TProcessDefinition GetByName(string name)
        {
            string key = cache.Get(getName(name)) as string;
            if (key != null) return cache.Get(key) as TProcessDefinition;
            return null;
        }

        public virtual void Add(TProcessDefinition item)
        {
            Check.ThrowIfNull(item);
            Check.ThrowIfNull(item.DefinitionId);
            string key = getId(item.DefinitionId);
            cache.Add(key, item, policy);
            if (!string.IsNullOrWhiteSpace(item.Name)) cache.Add(getName(item.Name), key, policy);
        }

        public virtual void Set(TProcessDefinition item)
        {
            Check.ThrowIfNull(item);
            string key = getId(item.DefinitionId);
            cache.Set(key, item, policy);
            if (!string.IsNullOrWhiteSpace(item.Name)) cache.Set(getName(item.Name), key, policy);
        }

        public virtual void Remove(TProcessDefinition item)
        {
            Check.ThrowIfNull(item);
            string key = getId(item.DefinitionId);
            cache.Remove(key);
            if (!string.IsNullOrWhiteSpace(item.Name)) cache.Remove(getName(item.Name));
        }
        #endregion
    }
}
