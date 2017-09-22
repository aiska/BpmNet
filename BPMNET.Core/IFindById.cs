using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IFindById<TKey, TEntity>
    {
        Task<TEntity> FindByIdAsync(TKey id);
    }
}
