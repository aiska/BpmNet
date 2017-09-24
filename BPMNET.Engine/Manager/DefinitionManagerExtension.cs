using BPMNET.Core;
using BPMNET.Engine.Helper;
using System;

namespace BPMNET.Engine.Manager
{
    public static class DefinitionManagerExtension
    {
        public static TDeployment DeployBpmn<TKey, TProcessDefinitionStore, TDeployment>(this DefinitionManager<TKey, TProcessDefinitionStore, TDeployment> manager, string bpmnFile, string deploymentId, string tenantId)
            where TKey : IEquatable<TKey>
            where TProcessDefinitionStore : class, IProcessDefinitionStore<TKey, TDeployment>
            where TDeployment : class, IDeployment<TKey>
        {
            return AsyncHelper.RunSync(() => manager.DeployBpmnAsync(bpmnFile, deploymentId, tenantId));
        }
    }
}
