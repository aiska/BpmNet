using BPMNET.Bpmn;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IDeploymentManager<TKey>
    {
        Task InsertItemDefinitionAsync();
        void InsertItemDefinition();
        Task DefineProcessAsync(tProcess process, TKey definitionKey);
        void DefineProcess(tProcess process, TKey definitionKey);
        Task DefineItemDefinitionAsync(tItemDefinition item, TKey definitionKey);
        void DefineItemDefinition(tItemDefinition item, TKey definitionKey);
        Task DeployBpmnAsync(string bpmnFile);
        void DeployBpmn(string bpmnFile);
    }
}
