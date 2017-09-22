using BPMNET.Core;
using System.Threading.Tasks;

namespace BPMNET.Entity.Validator
{
    public class DeploymentValidator : IDeploymentValidator<int, Deployment, Definition, DefinitionItem>
    {
        public virtual async Task<BpmResult> ValidateDefinitionAsync(DefinitionItem item)
        {
            //TODO Create ValidateDefinitionAsync
            return await Task.FromResult(BpmResult.Success);
        }

        public virtual async Task<BpmResult> ValidateDefinitionItemAsync(DefinitionItem item)
        {
            //TODO Create ValidateDefinitionItemAsync
            return await Task.FromResult(BpmResult.Success);
        }

        public virtual async Task<BpmResult> ValidateDeploymentAsync(Deployment item)
        {
            //TODO Create ValidateDeploymentAsync
            return await Task.FromResult(BpmResult.Success);
        }
    }
}
