using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BPMNET.Core
{
    public interface IDeploymentStore<TKey, TDeployment, TProcessDefinition, TProcessItemDefinition> : IDisposable
    {
        Task CreateDeploymentAsync(TDeployment deployment);
        Task UpdateDeploymentAsync(TDeployment deployment);
        Task DeleteDeploymentAsync(TDeployment deployment);
        Task<TDeployment> FindDeploymentByIdAsync(long deploymentId);
        Task<TDeployment> FindDeploymentByNameAsync(string deploymentName);
        Task<TDeployment> FindDeploymentByNameAndCategoryAndTenantAsync(string deploymentName, string deploymentCategory, string deploymentTenantId);
        Task CreateProcessDefinitionAsync(TProcessDefinition processDefinition);
        Task UpdateProcessDefinitionAsync(TProcessDefinition processDefinition);
        Task DeleteProcessDefinitionAsync(TProcessDefinition processDefinition);
        Task<TProcessDefinition> FindProcessDefinitionByIdAsync(long processDefinitionId);
        Task<TProcessDefinition> FindProcessDefinitionByLatestKeyAsync(string key);
        Task<TProcessDefinition> FindProcessDefinitionByLatestKeyAndTenantAsync(string key, string tenantId);
        Task<List<TProcessDefinition>> FindProcessDefinitionByKeyAsync(string key);
        Task<List<TProcessDefinition>> FindProcessDefinitionByKeyAndTenantAsync(string key, string tenantId);
        Task CreateProcessItemDefinitionAsync(TProcessItemDefinition item);
        Task UpdateProcessItemDefinitionAsync(TProcessItemDefinition item);
        Task DeleteProcessItemDefinitionAsync(TProcessItemDefinition item);
        Task<TProcessItemDefinition> FindProcessItemDefinitionByIdAsync(long itemId);
        bool AutoSaved { get; set; }
        Task SaveChangesAsync();
    }
}
