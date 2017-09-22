using System;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IDeploymentStore<TKey, TEntity> : 
        IStore<TEntity>, IFindById<TKey, TEntity>, IDisposable
    {
        Task<TEntity> FindLatestByNameCategoryTenantAsync(string name, string category, string tenantId);
    }
}
