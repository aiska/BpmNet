using BPMNET.Core;
using BPMNET.Engine.Helper;
using System;

namespace BPMNET.Engine.Manager
{
    public static class ProcessInstanceManagerExtension
    {
        public static TProcessInstance[] GetActiveProcessInstance<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode> manager)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            return AsyncHelper.RunSync(() => manager.GetActiveByProcessNameAsync());
        }

        public static TProcessInstance[] GetProcessInstanceByProcessName<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode> manager, string processName)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            return AsyncHelper.RunSync(() => manager.GetProcessInstanceByProcessNameAsync(processName));
        }

        public static TProcessInstance[] GetAllSubProcess<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode> manager, TKey processInstanceId)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            return AsyncHelper.RunSync(() => manager.GetAllSubProcessAsync(processInstanceId));
        }

        public static TProcessInstance GetProcessInstance<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode> manager, TKey processInstanceId)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            return AsyncHelper.RunSync(() => manager.GetProcessInstanceAsync(processInstanceId));
        }

        public static TProcessInstance StartProcessInstance<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode> manager, string process, string businessKey)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            return AsyncHelper.RunSync(() => manager.StartProcessInstanceAsync(process, businessKey));
        }

        public static TProcessInstance StartProcessInstance<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode> manager, TKey processDefinitionId, string businessKey)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            return AsyncHelper.RunSync(() => manager.StartProcessInstanceAsync(processDefinitionId, businessKey));
        }

        public static TProcessInstance ActivateInstance<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode> manager, TKey processInstanceId)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            return AsyncHelper.RunSync(() => manager.ActivateInstanceAsync(processInstanceId));
        }

        public static TProcessInstance SuspendInstance<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode> manager, TKey processInstanceId)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            return AsyncHelper.RunSync(() => manager.SuspendInstanceAsync(processInstanceId));
        }

        public static void CancelInstance<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode> manager, TKey processInstanceId, string reason)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            AsyncHelper.RunSync(() => manager.CancelInstanceAsync( processInstanceId,  reason));
        }
    }
}
