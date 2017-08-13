using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IRuntimeProvider<TKey, TProcessInstance, TIdentityLink>
        where TProcessInstance : IProcessInstance<TKey>
        where TIdentityLink : IIdentityLink<TKey>
    {
        #region Start Process Instance ...
        #region Start Process Async
        Task<TProcessInstance> StartProcessInstanceByIdAsync(long processDefinitionId);
        Task<TProcessInstance> StartProcessInstanceByIdAsync(long processDefinitionId, string businessKey);
        Task<TProcessInstance> StartProcessInstanceByIdAsync(long processDefinitionId, Dictionary<string, object> variables);
        Task<TProcessInstance> StartProcessInstanceByIdAsync(long processDefinitionId, string businessKey, Dictionary<string, object> variables);
        Task<TProcessInstance> StartProcessInstanceByKeyAsync(string processDefinitionKey);
        Task<TProcessInstance> StartProcessInstanceByKeyAsync(string processDefinitionKey, string businessKey);
        Task<TProcessInstance> StartProcessInstanceByKeyAsync(string processDefinitionKey, Dictionary<string, object> variables);
        Task<TProcessInstance> StartProcessInstanceByKeyAsync(string processDefinitionKey, string businessKey, Dictionary<string, object> variables);
        Task<TProcessInstance> StartProcessInstanceByKeyAndTenantAsync(string processDefinitionKey, string tenantId);
        Task<TProcessInstance> StartProcessInstanceByKeyAndTenantAsync(string processDefinitionKey, string tenantId, string businessKey);
        Task<TProcessInstance> StartProcessInstanceByKeyAndTenantAsync(string processDefinitionKey, string tenantId, Dictionary<string, object> variables);
        Task<TProcessInstance> StartProcessInstanceByKeyAndTenantAsync(string processDefinitionKey, string tenantId, string businessKey, Dictionary<string, object> variables);
        #endregion

        #region Start Process Sync
        TProcessInstance StartProcessInstanceById(long processDefinitionId);
        TProcessInstance StartProcessInstanceById(long processDefinitionId, string businessKey);
        TProcessInstance StartProcessInstanceById(long processDefinitionId, Dictionary<string, object> variables);
        TProcessInstance StartProcessInstanceById(long processDefinitionId, string businessKey, Dictionary<string, object> variables);
        TProcessInstance StartProcessInstanceByKey(string processDefinitionKey);
        TProcessInstance StartProcessInstanceByKey(string processDefinitionKey, string businessKey);
        TProcessInstance StartProcessInstanceByKey(string processDefinitionKey, Dictionary<string, object> variables);
        TProcessInstance StartProcessInstanceByKey(string processDefinitionKey, string businessKey, Dictionary<string, object> variables);
        TProcessInstance StartProcessInstanceByKeyAndTenant(string processDefinitionKey, string tenantId);
        TProcessInstance StartProcessInstanceByKeyAndTenant(string processDefinitionKey, string tenantId, string businessKey);
        TProcessInstance StartProcessInstanceByKeyAndTenant(string processDefinitionKey, string tenantId, Dictionary<string, object> variables);
        TProcessInstance StartProcessInstanceByKeyAndTenant(string processDefinitionKey, string tenantId, string businessKey, Dictionary<string, object> variables);
        #endregion
        #endregion

        #region Activate Process Instance ...
        Task ActivateProcessInstanceByIdAsync(long processInstanceId);
        void ActivateProcessInstanceById(long processInstanceId);
        Task ActivateProcessInstanceByKeyAsync(string processDefinitionKey);
        void ActivateProcessInstanceByKey(string processDefinitionKey);
        Task ActivateProcessInstanceByKeyAndTenantAsync(string processDefinitionKey, string tenant);
        void ActivateProcessInstanceByKeyAndTenant(string processDefinitionKey, string tenant);
        #endregion

        Task AddGroupIdentityLinkAsync(long processInstanceId, string group, TIdentityLink identityLinkType);
        void AddGroupIdentityLink(long processInstanceId, string group, TIdentityLink identityLinkType);
        Task AddParticipantUserAsync(long processInstanceId, string username);
        void AddParticipantUser(long processInstanceId, string username);

        ///// <summary>
        ///// Starts a new process instance in the latest Version of the process definition with the given Key.
        ///// </summary>
        ///// <param name="processDefinitionKey">
        ///// Key of process definition, cannot be null.
        ///// </param>
        ///// <returns></returns>
        //Task<TProcessInstance> StartProcessInstanceByKeyAsync(string processDefinitionKey);
        ///// <summary>
        ///// Starts a new process instance in the latest Version of the process definition with the given Key.
        ///// 
        ///// A business Key can be provided to associate the process instance with a
        ///// certain identifier that has a clear business meaning. For example in an
        ///// order process, the business Key could be an order Id. This business Key can
        ///// hen be used to easily look up that process instance.
        ///// 
        ///// Providing such a business Key is definitely a best practice.
        ///// </summary>
        ///// <param name="processDefinitionKey">
        ///// Key of process definition, cannot be null.
        ///// </param>
        ///// <param name="businessKey">
        ///// a Key that uniquely identifies the process instance in the context
        ///// or the given process definition.
        ///// </param>
        ///// <returns></returns>
        //Task<TProcessInstance> StartProcessInstanceByKeyAsync(string processDefinitionKey, string businessKey);
        ///// <summary>
        ///// Starts a new process instance in the latest Version of the process definition with the given Key.
        ///// </summary>
        ///// <param name="processDefinitionKey">
        ///// Key of process definition, cannot be null.
        ///// </param>
        ///// <param name="variables">
        ///// the variables to pass, can be null.
        ///// </param>
        ///// <returns></returns>
        //Task<TProcessInstance> StartProcessInstanceByKeyAsync(string processDefinitionKey, Dictionary<string, object> variables);
        ///// <summary>
        ///// Starts a new process instance in the latest Version of the process definition with the given Key.
        ///// </summary>
        ///// <param name="processDefinitionKey">
        ///// Key of process definition, cannot be null.
        ///// </param>
        ///// <param name="businessKey">
        ///// a Key that uniquely identifies the process instance in the context
        ///// or the given process definition.
        ///// </param>
        ///// <param name="variables">the variables to pass, can be null.</param>
        ///// <returns></returns>
        //Task<TProcessInstance> StartProcessInstanceByKeyAsync(string processDefinitionKey, string businessKey, Dictionary<string, object> variables);
        //Task<TProcessInstance> StartProcessInstanceByKeyAndTenantIdAsync(string processDefinitionKey, string tenantId);
        //Task<TProcessInstance> StartProcessInstanceByKeyAndTenantIdAsync(string processDefinitionKey, string businessKey, string tenantId);
        //Task<TProcessInstance> StartProcessInstanceByKeyAndTenantIdAsync(string processDefinitionKey, Dictionary<string, object> variables, string tenantId);
        //Task<TProcessInstance> StartProcessInstanceByKeyAndTenantIdAsync(string processDefinitionKey, string businessKey, Dictionary<string, object> variables, string tenantId);
        //Task<TProcessInstance> StartProcessInstanceByIdAsync(long processDefinitionId);
        //Task<TProcessInstance> StartProcessInstanceByIdAsync(long processDefinitionId, string businessKey);
        //Task<TProcessInstance> StartProcessInstanceByIdAsync(long processDefinitionId, Dictionary<string, object> variables);
        //Task<TProcessInstance> StartProcessInstanceByIdAsync(long processDefinitionId, string businessKey, Dictionary<string, object> variables);
        //Task<TProcessInstance> StartProcessInstanceByMessageAsync(string messageName);
        //Task<TProcessInstance> StartProcessInstanceByMessageAndTenantIdAsync(string messageName, string tenantId);
        //Task<TProcessInstance> StartProcessInstanceByMessageAsync(string messageName, string businessKey);
        //Task<TProcessInstance> StartProcessInstanceByMessageAndTenantIdAsync(string messageName, string businessKey, string tenantId);
        //Task<TProcessInstance> StartProcessInstanceByMessageAsync(string messageName, Dictionary<string, object> processVariables);
        //Task<TProcessInstance> StartProcessInstanceByMessageAndTenantIdAsync(string messageName, Dictionary<string, object> processVariables, string tenantId);
        //Task<TProcessInstance> StartProcessInstanceByMessageAsync(string messageName, string businessKey, Dictionary<string, object> processVariables);
        //Task<TProcessInstance> StartProcessInstanceByMessageAndTenantIdAsync(string messageName, string businessKey, Dictionary<string, object> processVariables, string tenantId);
        //Task deleteProcessInstanceAsync(string processInstanceId, string deleteReason);
        //Task<List<string>> getActivePwsIdsAsync(string executionId);
        //void signal(string executionId);
        //void signal(string executionId, Dictionary<string, object> processVariables);
        //void updateBusinessKey(string processInstanceId, string businessKey);
        //void addUserIdentityLink(string processInstanceId, string userId, string identityLinkType);
        //void AddGroupIdentityLinkAsync(string processInstanceId, string groupId, string identityLinkType);
        //void AddParticipantUser(string processInstanceId, string userId);
        //void addParticipantGroup(string processInstanceId, string groupId);
        //void deleteParticipantUser(string processInstanceId, string userId);
        //void deleteParticipantGroup(string processInstanceId, string groupId);
        //void deleteUserIdentityLink(string processInstanceId, string userId, string identityLinkType);
        //void deleteGroupIdentityLink(string processInstanceId, string groupId, string identityLinkType);
        ////List<IdentityLink> getIdentityLinksForProcessInstance(string instanceId);
        //Dictionary<string, object> getVariables(string executionId);
        //Dictionary<string, object> getVariablesLocal(string executionId);
        //Dictionary<string, object> getVariables(string executionId, string[] variableNames);
        //Dictionary<string, object> getVariablesLocal(string executionId, string[] variableNames);
        //object getVariable(string executionId, string variableName);
        //bool hasVariable(string executionId, string variableName);
        //object getVariableLocal(string executionId, string variableName);
        //bool hasVariableLocal(string executionId, string variableName);
        //void setVariable(string executionId, string variableName, object value);
        //void setVariableLocal(string executionId, string variableName, object value);
        //void setVariables(string executionId, Dictionary<string, object> variables);
        //void setVariablesLocal(string executionId, Dictionary<string, object> variables);
        //void removeVariable(string executionId, string variableName);
        //void removeVariableLocal(string executionId, string variableName);
        //void removeVariables(string executionId, string[] variableNames);
        //void removeVariablesLocal(string executionId, string[] variableNames);
        //ExecutionQuery createExecutionQuery();
        //NativeExecutionQuery createNativeExecutionQuery();
        //ProcessInstanceQuery createProcessInstanceQuery();
        //void suspendProcessInstanceById(string processInstanceId);
        //void ActivateProcessInstanceById(string processInstanceId);
        //void signalEventReceived(string signalName);
        //void signalEventReceivedWithTenantId(string signalName, string tenantId);
        //void signalEventReceivedAsync(string signalName);
        //void signalEventReceivedAsyncWithTenantId(string signalName, string tenantId);
        //void signalEventReceived(string signalName, Dictionary<string, object> processVariables);
        //void signalEventReceivedWithTenantId(string signalName, Dictionary<string, object> processVariables, string tenantId);
        //void signalEventReceived(string signalName, string executionId);
        //void signalEventReceived(string signalName, string executionId, Dictionary<string, object> processVariables);
        //void signalEventReceivedAsync(string signalName, string executionId);
        //void messageEventReceived(string messageName, string executionId);
        //void messageEventReceived(string messageName, string executionId, Dictionary<string, object> processVariables);
        //void messageEventReceivedAsync(string messageName, string executionId);
        //void addEventListener(ActivitiEventListener listenerToAdd);
        //void addEventListener(ActivitiEventListener listenerToAdd, ActivitiEventType... types);
        //void removeEventListener(ActivitiEventListener listenerToRemove);
        //void dispatchEvent(ActivitiEvent event);
        //void setProcessInstanceName(string processInstanceId, string name);
        //List<Event> getProcessInstanceEvents(string processInstanceId);
        //TProcessInstanceBuilder createProcessInstanceBuilder();
    }
}
