using System;
using System.Threading.Tasks;

namespace BPMNET.EntityCore
{
    public interface IStoreAsync<T> : IDisposable
    {
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}
