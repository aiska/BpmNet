using System;

namespace BPMNET.Core.Variable
{
    public abstract class AbstractVariable<T> : IVariable<T>
    {
        public T Value { get; protected set; }
        public string Name { get; set; }

        public abstract EStoreType StoreType { get; }

        public virtual bool Cachable
        {
            get { return true; }
        }
        public virtual bool CheckForStore(object value)
        {
            if (value == null) return false;
            if (typeof(T).IsAssignableFrom(value.GetType()))
            {
                Value = (T)value;
            }
            return true;
        }
    }
}
