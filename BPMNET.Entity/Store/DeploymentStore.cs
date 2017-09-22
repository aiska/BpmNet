using BPMNET.Core;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BPMNET.Entity.Store
{
    public class DeploymentStore : BaseStore<int, DeploymentEntity>, IDeploymentStore<int, DeploymentEntity>
    {
        public DeploymentStore() : this(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public DeploymentStore(BpmDbContext context) : base(context) { }

        public virtual async Task<DeploymentEntity> FindLatestByNameCategoryTenantAsync(string name, string category, string tenantId)
        {
            this.ThrowIfDisposed(_disposed);
            name.ThrowIfNull();
            category.ThrowIfNull();
            tenantId.ThrowIfNull();
            DeploymentEntity result;
            result = await Entities.OrderByDescending(t=>t.Version).FirstOrDefaultAsync(t => t.Name.Equals(name) && t.Category.Equals(category) && t.TenantId.Equals(tenantId));
            return result;
        }
    }
}
