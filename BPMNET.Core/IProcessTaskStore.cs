using BPMNET.Bpmn;
using System;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IProcessTaskStore<TKey, TProcessTask> : IDisposable
        where TKey : IEquatable<TKey>
        where TProcessTask : IProcessTask<TKey>
    {
        Task<TProcessTask[]> GetProcessTaskByFlowNodeIdAsync(string name);
        Task<TProcessTask> CreateTaskAsync(TKey processInstanceId, TKey nodeId, string nodeName, ProcessItemType ItemType);
    }
}
