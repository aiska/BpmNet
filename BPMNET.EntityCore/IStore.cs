using System;

namespace BPMNET.EntityCore
{
    public interface IStore<T> : IDisposable
    {
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
