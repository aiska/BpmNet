using BPMNET.Bpmn;
using System;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IProcessDefinitionStore<TKey, TDeployment> : IDisposable
        where TKey : IEquatable<TKey>
        where TDeployment : class, IDeployment<TKey>
    {
        Task<TDeployment> CreateDeploymentAsync(string deploymentId, string tenantId, string bpmnFile);
    }
}
