using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IDeploymentValidator<TKey, TDeployment, TProcessDefinition, TProcessItemDefinition>
    {
        Task<BpmResult> ValidateDeploymentAsync(TDeployment item);
        Task<BpmResult> ValidateProcessDefinitionAsync(TProcessItemDefinition item);
        Task<BpmResult> ValidateProcessItemDefinitionAsync(TProcessItemDefinition item);
    }
}
