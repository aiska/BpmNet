using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IDeploymentProvider<TProcessDefinition, TProcessItemDefinition>
        where TProcessDefinition : IProcessDefinition<TProcessItemDefinition>
        where TProcessItemDefinition : IProcessItemDefinition<TKey>
    {
        Task AddProcessDefinitionAsync(string bpmnFile, string category, string tenantId);
        Task AddProcessDefinitionAsync(string bpmnFile, string category, string tenantId, bool force);
        void AddProcessDefinition(string bpmnFile, string category, string tenantId);
        void AddProcessDefinition(string bpmnFile, string category, string tenantId, bool force);
        Task RemoveProcessDefinitionByIdAsync(long processDefinitionId);
        Task RemoveProcessDefinitionByKeyAndTenantAsync(string processDefinitionKey, string tenantId);
        Task<TProcessDefinition> FindDeployedProcessDefinitionByIdAsync(long processDefinitionById);
        Task<TProcessDefinition> FindDeployedLatestProcessDefinitionByKeyAsync(string processDefinitionKey);
        Task<TProcessDefinition> FindDeployedLatestProcessDefinitionByKeyAndTenantIdAsync(string processDefinitionKey, string tenantId);
        Task<TProcessDefinition> GetProcessDefinitionAsync(long processDefinitionId, string processDefinitionKey, string tenantId);
        IEnumerable<TProcessItemDefinition> GetOutgoingItemAsync(ICollection<TProcessItemDefinition> items, string key);
        IEnumerable<TProcessItemDefinition> GetIncomingItemAsync(ICollection<TProcessItemDefinition> items, string key);
        IEnumerable<TProcessItemDefinition> GetStartEventProcess(ICollection<TProcessItemDefinition> items);
    }
}
