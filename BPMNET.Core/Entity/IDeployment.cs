using System;

namespace BPMNET.Core
{
    public interface IDeployment<TKey>
    {
        TKey Id { get; set; }
        string DeploymentId { get; set; }
        string DeploymentName { get; set; }
        DateTime UtcDeploymentTime { get; set; }
        string Source { get; set; }
        string TenantId { get; set; }
    }
}
