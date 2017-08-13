using System;

namespace BPMNET.EntityCore
{
    public class Deployment : IAuditTrail
    {
        public Deployment()
        {
            DeploymentId = Guid.NewGuid();
        }
        public Guid DeploymentId { get; set; }
        public string DeploymentName { get; set; }
        public string DeploymentCategory { get; set; }
        public string DeploymentTenantId { get; set; }
        public string DeploymentVersion { get; set; }
        public DateTime Inserted { get; set; }
        public DateTime LastUpdated { get; set; }
        public byte[] Timestamp { get; set; }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = DeploymentId.GetHashCode();
                // Suitable nullity checks etc, of course :)
                if (DeploymentName != null) hash = hash * 17 + DeploymentName.GetHashCode();
                if (DeploymentCategory != null) hash = hash * 17 + DeploymentCategory.GetHashCode();
                if (DeploymentTenantId != null) hash = hash * 17 + DeploymentTenantId.GetHashCode();
                if (DeploymentVersion != null) hash = hash * 17 + DeploymentVersion.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Deployment);
        }
        public bool Equals(Deployment other)
        {
            // Check for null
            if (ReferenceEquals(other, null))
                return false;

            // Check for same reference
            if (ReferenceEquals(this, other))
                return true;

            // Not Check DeploymentId, because generated Guid

            // Check for same value
            return ((DeploymentName == null && other.DeploymentName == null) || (DeploymentName != null && other.DeploymentName != null && DeploymentName.Equals(other.DeploymentName))) &&
                ((DeploymentCategory == null && other.DeploymentCategory == null) || (DeploymentCategory != null && other.DeploymentCategory != null && DeploymentCategory.Equals(other.DeploymentCategory))) &&
                ((DeploymentTenantId == null && other.DeploymentTenantId == null) || (DeploymentTenantId != null && other.DeploymentTenantId != null && DeploymentTenantId.Equals(other.DeploymentTenantId))) &&
                ((DeploymentVersion == null && other.DeploymentVersion == null) || (DeploymentVersion != null && other.DeploymentVersion != null && DeploymentVersion.Equals(other.DeploymentVersion)));
        }
    }
}
