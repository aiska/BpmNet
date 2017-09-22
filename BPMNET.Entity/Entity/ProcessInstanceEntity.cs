using BPMNET.Core;
using System;

namespace BPMNET.Entity
{
    public class ProcessInstanceEntity : IProcessInstance<int>, IAuditTrail
    {
        public int Id { get; set; }
        public int ProcessDefinitionId { get; set; }
        public string TenantId { get; set; }
        public string BusinessKey { get; set; }
        public string ProcessId { get; set; }
        public int? ParentInstanceId { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsEnded { get; set; }
        public ProcessInstanceStatus Status { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime? UtcModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
