using System;

namespace BPMNET.Core
{
    public interface IDeployment<TKey>
    {
        TKey DeploymentId { get; set; }
        string Name { get; set; }
        string Category { get; set; }
        string TenantId { get; set; }
        string Version { get; set; }
        DateTime CreateDate { get; set; }
    }
}
