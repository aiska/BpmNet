using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IStore<in T>
    {
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}
