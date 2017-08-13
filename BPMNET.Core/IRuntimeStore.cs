using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IRuntimeStore<TKey, TProcessInstance, TIdentityLink, TProcessTask> : IDisposable
        where TProcessInstance : IProcessInstance<TKey>
        where TIdentityLink : IIdentityLink<TKey>
        where TProcessTask : IProcessTask<TKey>

    {
        Task CreateProcessInstanceAsync(TProcessInstance processInstance);
        Task UpdateProcessInstanceAsync(TProcessInstance processInstance);
        Task DeleteProcessInstanceAsync(TProcessInstance processInstance);
        Task<TProcessInstance> FindProcessInstanceByIdAsync(long processInstanceId);
        Task CreateProcessTaskAsync(TProcessTask task);
        Task UpdateProcessTaskAsync(TProcessTask task);
        Task DeleteProcessTaskAsync(TProcessTask task);
        Task<TProcessTask> FindProcessTaskByIdAsync(long taskId);
        Task<TProcessTask> FindProcessTaskByKeyAsync(long processInstanceId, string businesskey);
        Task<ICollection<TProcessTask>> GetProcessTasks(long processInstanceId);
        Task CreateIdentityLinkAsync(TIdentityLink identity);
        Task UpdateIdentityLinkAsync(TIdentityLink identity);
        Task DeleteIdentityLinkAsync(TIdentityLink identity);
        Task<TIdentityLink> FindIdentityLinkByGroupAsync(long taskId, EIdentityLinkType type, string group);
        Task<TIdentityLink> FindIdentityLinkByUsernameAsync(long taskId, EIdentityLinkType type, string username);
        Task<List<TProcessInstance>> FindProcessInstanceByDefinitionId(long processDefinitionId);
        Task<List<TProcessInstance>> FindProcessInstanceByDefinitionKey(string processDefinitionKey, string tenantId);
    }
}
