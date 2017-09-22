using BPMNET.Core;
using System;

namespace BPMNET.Entity
{
    public class DeploymentEntity : IDeployment<int>, IAuditTrail
    {
        public int Id { get; set; }
        public string DeploymentId { get; set; }
        public string DeploymentName { get; set; }
        public DateTime UtcDeploymentTime { get; set; }
        public string Source { get; set; }
        public string TenantId { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime? UtcModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
