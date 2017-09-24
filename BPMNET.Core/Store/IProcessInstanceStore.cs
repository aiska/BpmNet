using System;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IProcessInstanceStore<TKey, TProcessInstance, TFlowNode> : IDisposable
        where TKey : IEquatable<TKey>
        where TProcessInstance : IProcessInstance<TKey>
        where TFlowNode : IFlowNode<TKey>
    {
        Task<TProcessInstance[]> GetActiveProcessInstanceAsync();
        Task<TProcessInstance> GetProcessInstanceAsync(TKey processInstanceId);
        Task<TProcessInstance[]> GetAllSubProcessAsync(TKey processInstanceId);
        Task<TProcessInstance[]> GetProcessInstanceByProcessNameAsync(string processName);
        Task<TProcessInstance> StartProcessInstanceAsync(TKey processId, string businessKey);
        Task<TProcessInstance> StartProcessInstanceAsync(string process, string businessKey);
        Task CancelAsync(TKey processInstanceId, string reason);
        Task<TProcessInstance> SuspendInstanceAsync(TKey processInstanceId);
        Task<TProcessInstance> ActivateInstanceAsync(TKey processInstanceId);
    }
}
