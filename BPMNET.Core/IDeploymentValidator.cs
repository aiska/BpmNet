using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IDeploymentValidator<TKey, TDeployment, TProcessDefinition, TProcessItemDefinition>
    {
        Task<BpmResult> ValidateDeploymentAsync(TDeployment item);
        Task<BpmResult> ValidateDefinitionAsync(TProcessItemDefinition item);
        Task<BpmResult> ValidateDefinitionItemAsync(TProcessItemDefinition item);
        //Task<BpmResult> ValidateDefinitionVariableAsync(TDefinitionVariable item);
    }
}
