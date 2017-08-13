using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IFindById<TKey, T>
    {
        Task<T> FindByIdAsync(TKey id);
        T FindById(TKey id);
    }
}
