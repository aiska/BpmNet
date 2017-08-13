using BPMNET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity
{
    public class Deployment : Deployment<string>
    { }

    public class Deployment<TKey> : IDeployment<TKey>, IEquatable<Deployment<TKey>>
        where TKey : IEquatable<TKey>
    {
        public TKey DeploymentId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string TenantId { get; set; }
        public string Version { get; set; }
        public DateTime CreateDate { get; set; }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = DeploymentId.GetHashCode();
                // Suitable nullity checks etc, of course :)
                hash = hash * 17 + Name.GetHashCode();
                hash = hash * 17 + Category.GetHashCode();
                hash = hash * 17 + TenantId.GetHashCode();
                hash = hash * 17 + Version.GetHashCode();
                hash = hash * 17 + CreateDate.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Deployment<TKey>);
        }
        public bool Equals(Deployment<TKey> other)
        {
            // Check for null
            if (ReferenceEquals(other, null))
                return false;

            // Check for same reference
            if (ReferenceEquals(this, other))
                return true;

            // Check for same value
            return DeploymentId.Equals(other.DeploymentId) &&
                Name.Equals(other.Name) &&
                Category.Equals(other.Category) &&
                TenantId.Equals(other.TenantId) &&
                Version.Equals(other.Version) &&
                CreateDate == other.CreateDate;
        }
    }
}
