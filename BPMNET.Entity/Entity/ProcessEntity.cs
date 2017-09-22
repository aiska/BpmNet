
using BPMNET.Core;
using System;

namespace BPMNET.Entity
{
    public class ProcessDefinitionEntity : IProcessDefinition<int>, IAuditTrail
    {
        public ProcessDefinitionEntity()
        {
            Version = 1;
        }
        public int Id { get; set; }
        public int DeploymentId { get; set; }
        public int FlowNodeId { get; set; }
        public string DefinitionId { get; set; }
        public string DefinitionName { get; set; }
        public string Description { get; set; }
        public bool HasStartFormKey { get; set; }
        public bool IsSuspended { get; set; }
        public string VersionTag { get; set; }
        public string TenantId { get; set; }
        public string ProcessId { get; set; }
        public string ProcessName { get; set; }
        public bool IsExecutable { get; set; }
        public bool IsClosed { get; set; }
        public int Version { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime? UtcModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
