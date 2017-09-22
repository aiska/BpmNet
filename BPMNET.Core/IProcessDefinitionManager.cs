using System;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IProcessDefinitionManager<TKey, TProcessDefinition, TDeployment>
        where TKey : IEquatable<TKey>
        where TProcessDefinition : class, IProcessDefinitionStore<TKey, TDeployment>
        where TDeployment : class, IDeployment<TKey>
    {
        IProcessDefinitionValidator<TProcessDefinition> ProcessDefinitionValidator { get; set; }
        IProcessDefinitionStore<TKey, TProcessDefinition> Store { get; set; }

        BpmResult ActivateProcessDefinitionById(TKey processDefinitionId);
        Task<BpmResult> ActivateProcessDefinitionByIdAsync(TKey processDefinitionId);
        BpmResult CreateProcessDefinition(TProcessDefinition processDefinition);
        Task<BpmResult> CreateProcessDefinitionAsync(TProcessDefinition processDefinition);
        BpmResult DeleteProcessDefinition(TProcessDefinition processDefinition);
        Task<BpmResult> DeleteProcessDefinitionAsync(TProcessDefinition processDefinition);
        void Dispose();
        TProcessDefinition FindProcessDefinitionById(TKey id);
        Task<TProcessDefinition> FindProcessDefinitionByIdAsync(TKey id);
        BpmResult UpdateProcessDefinition(TProcessDefinition processDefinition);
        Task<BpmResult> UpdateProcessDefinitionAsync(TProcessDefinition processDefinition);
    }
}