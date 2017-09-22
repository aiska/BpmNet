using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IProcessInstanceManager<TKey, TProcessInstance> : IDisposable
        where TKey : IEquatable<TKey>
        where TProcessInstance : IProcessInstance<TKey>
    {
        IQueryable<TProcessInstance> ProcessInstances { get; }

        BpmResult ActivateProcessInstanceById(TKey processInstanceId);
        Task<BpmResult> ActivateProcessInstanceByIdAsync(TKey processInstanceId);
        BpmResult AddParticipantUser(TKey processInstanceId, string userId);
        Task<BpmResult> AddParticipantUserAsync(TKey processInstanceId, string userId);
        BpmResult CreateProcessInstance(TProcessInstance processInstance);
        Task<BpmResult> CreateProcessInstanceAsync(TProcessInstance processInstance);
        BpmResult DeleteProcessInstance(TProcessInstance processInstance);
        Task<BpmResult> DeleteProcessInstanceAsync(TProcessInstance processInstance);
        IEnumerable<TProcessInstance> FindProcessInstanceByDefinitionId(TKey processDefinitionId);
        Task<TProcessInstance> FindProcessInstanceByDefinitionIdAsync(TKey processInstanceId);
        TProcessInstance FindProcessInstanceById(TKey processInstanceId);
        Task<TProcessInstance> FindProcessInstanceByIdAsync(TKey processInstanceId);
        bool IsProcessDefinitionExist(TKey processDefinitionId);
        Task<bool> IsProcessDefinitionExistAsync(TKey processDefinitionId);
        BpmResult UpdateProcessInstance(TProcessInstance processInstance);
        Task<BpmResult> UpdateProcessInstanceAsync(TProcessInstance processInstance);
    }
}