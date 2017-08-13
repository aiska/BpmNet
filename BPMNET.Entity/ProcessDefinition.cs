using BPMNET.Core;
using System;

namespace BPMNET.Entity
{
    public class ProcessDefinition : ProcessDefinition<string>
    { }

    public class ProcessDefinition<TKey> : IProcessDefinition<TKey>, IEquatable<ProcessDefinition<TKey>>
        where TKey : IEquatable<TKey>
    {
        public ProcessDefinition()
        {
            CreatedDate = DateTime.Now;
        }
        public TKey ProcessDefinitionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public TKey DeploymentId { get; set; }
        public string Description { get; set; }
        public string DiagramResourceName { get; set; }
        public bool HasGraphicalNotation { get; set; }
        public bool HasStartFormKey { get; set; }
        public bool IsSuspended { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Resource { get; set; }
        public string TenantId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = ProcessDefinitionId.GetHashCode();
                // Suitable nullity checks etc, of course :)
                hash = hash * 17 + CreatedDate.GetHashCode();
                hash = hash * 17 + DeploymentId.GetHashCode();
                hash = hash * 17 + Description.GetHashCode();
                hash = hash * 17 + DiagramResourceName.GetHashCode();
                hash = hash * 17 + HasGraphicalNotation.GetHashCode();
                hash = hash * 17 + HasStartFormKey.GetHashCode();
                hash = hash * 17 + IsSuspended.GetHashCode();
                hash = hash * 17 + Key.GetHashCode();
                hash = hash * 17 + Name.GetHashCode();
                hash = hash * 17 + Resource.GetHashCode();
                hash = hash * 17 + TenantId.GetHashCode();
                hash = hash * 17 + UpdateDate.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as ProcessDefinition<TKey>);
        }
        public bool Equals(ProcessDefinition<TKey> other)
        {
            // Check for null
            if (ReferenceEquals(other, null))
                return false;

            // Check for same reference
            if (ReferenceEquals(this, other))
                return true;

            // Check for same value
            return ProcessDefinitionId.Equals(other.ProcessDefinitionId) &&
                CreatedDate == other.CreatedDate &&
                DeploymentId.Equals(other.DeploymentId) &&
                Description.Equals(other.Description) &&
                DiagramResourceName.Equals(other.DiagramResourceName) &&
                HasGraphicalNotation == other.HasGraphicalNotation &&
                HasStartFormKey == other.HasStartFormKey &&
                IsSuspended == other.IsSuspended &&
                Key.Equals(other.Key) &&
                Name.Equals(other.Name) &&
                Resource.Equals(other.Resource) &&
                TenantId.Equals(other.TenantId) &&
                UpdateDate.Equals(other.UpdateDate);
        }
    }
}
