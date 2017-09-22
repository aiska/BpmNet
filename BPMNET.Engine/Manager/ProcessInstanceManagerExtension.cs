using BPMNET.Core;
using BPMNET.Engine.Helper;
using System;

namespace BPMNET.Engine.Manager
{
    public static class ProcessInstanceManagerExtension
    {
        public static TProcessInstance[] GetActiveProcessInstance<TKey, TProcessInstanceStore, TInstance, TInstanceTask, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TInstance, TInstanceTask, TProcessInstance, TFlowNode> manager)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TInstance : class, IInstance<TKey, TInstance, TInstanceTask>
        where TInstanceTask : class, IInstanceTask<TKey>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            return AsyncHelper.RunSync(() => manager.GetActiveByProcessNameAsync());
        }

        public static TProcessInstance[] GetProcessInstanceByProcessName<TKey, TProcessInstanceStore, TInstance, TInstanceTask, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TInstance, TInstanceTask, TProcessInstance, TFlowNode> manager, string processName)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TInstance : class, IInstance<TKey, TInstance, TInstanceTask>
        where TInstanceTask : class, IInstanceTask<TKey>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            return AsyncHelper.RunSync(() => manager.GetProcessInstanceByProcessNameAsync(processName));
        }

        public static TProcessInstance[] GetAllSubProcess<TKey, TProcessInstanceStore, TInstance, TInstanceTask, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TInstance, TInstanceTask, TProcessInstance, TFlowNode> manager, TKey processInstanceId)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TInstance : class, IInstance<TKey, TInstance, TInstanceTask>
        where TInstanceTask : class, IInstanceTask<TKey>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            return AsyncHelper.RunSync(() => manager.GetAllSubProcessAsync(processInstanceId));
        }

        public static TInstance GetProcessInstance<TKey, TProcessInstanceStore, TInstance, TInstanceTask, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TInstance, TInstanceTask, TProcessInstance, TFlowNode> manager, TKey processInstanceId)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TInstance : class, IInstance<TKey, TInstance, TInstanceTask>
        where TInstanceTask : class, IInstanceTask<TKey>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            return AsyncHelper.RunSync(() => manager.GetProcessInstanceAsync(processInstanceId));
        }

        public static TInstance StartProcessInstance<TKey, TProcessInstanceStore, TInstance, TInstanceTask, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TInstance, TInstanceTask, TProcessInstance, TFlowNode> manager, string process, string businessKey)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TInstance : class, IInstance<TKey, TInstance, TInstanceTask>
        where TInstanceTask : class, IInstanceTask<TKey>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            return AsyncHelper.RunSync(() => manager.StartProcessInstanceAsync(process, businessKey));
        }

        public static TInstance StartProcessInstance<TKey, TProcessInstanceStore, TInstance, TInstanceTask, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TInstance, TInstanceTask, TProcessInstance, TFlowNode> manager, TKey processId, string businessKey)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TInstance : class, IInstance<TKey, TInstance, TInstanceTask>
        where TInstanceTask : class, IInstanceTask<TKey>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            return AsyncHelper.RunSync(() => manager.StartProcessInstanceAsync(processId, businessKey));
        }

        public static TProcessInstance Activate<TKey, TProcessInstanceStore, TInstance, TInstanceTask, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TInstance, TInstanceTask, TProcessInstance, TFlowNode> manager, TKey processInstanceId)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TInstance : class, IInstance<TKey, TInstance, TInstanceTask>
        where TInstanceTask : class, IInstanceTask<TKey>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            return AsyncHelper.RunSync(() => manager.ActivateAsync(processInstanceId));
        }

        public static void Cancel<TKey, TProcessInstanceStore, TInstance, TInstanceTask, TProcessInstance, TFlowNode>(this ProcessInstanceManager<TKey, TProcessInstanceStore, TInstance, TInstanceTask, TProcessInstance, TFlowNode> manager, TKey processInstanceId, string reason)
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TInstance : class, IInstance<TKey, TInstance, TInstanceTask>
        where TInstanceTask : class, IInstanceTask<TKey>
        where TProcessInstance : class, IProcessInstance<TKey>, new()
        where TFlowNode : class, IFlowNode<TKey>
        {
            AsyncHelper.RunSync(() => manager.CancelAsync( processInstanceId,  reason));
        }
    }
}
