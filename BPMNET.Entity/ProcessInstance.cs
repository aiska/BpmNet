using BPMNET.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace BPMNET.Entity
{
    public class ProcessInstance : ProcessInstance<string>
    {

    }
    public class ProcessInstance<TKey> : IProcessInstance<TKey>, IEquatable<ProcessInstance<TKey>>
        where TKey : IEquatable<TKey>
    {
        public ProcessInstance()
        {
            SuspensionState = ESuspensionState.ACTIVE;
        }
        [Key]
        public TKey ProcessInstanceId { get; set; }

        public TKey ProcessDefinitionId { get; set; }

        public string ProcessDefinitionName { get; set; }

        public string Name { get; set; }

        public string BusinessKey { get; set; }

        public string TenantId { get; set; }

        public ESuspensionState SuspensionState { get; set; }

        public string UserCandidates { get; set; }
        public string Owner { get; set; }
        //public ICollection<TIdentityLink> IdentityLinks { get; set; }

        //public Dictionary<string, object> ProcessVariables { get; set; }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = ProcessInstanceId.GetHashCode();
                // Suitable nullity checks etc, of course :)
                hash = hash * 17 + ProcessDefinitionId.GetHashCode();
                hash = hash * 17 + ProcessDefinitionName.GetHashCode();
                hash = hash * 17 + Name.GetHashCode();
                hash = hash * 17 + BusinessKey.GetHashCode();
                hash = hash * 17 + TenantId.GetHashCode();
                hash = hash * 17 + SuspensionState.GetHashCode();
                hash = hash * 17 + UserCandidates.GetHashCode();
                hash = hash * 17 + Owner.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as ProcessInstance<TKey>);
        }
        public bool Equals(ProcessInstance<TKey> other)
        {
            // Check for null
            if (ReferenceEquals(other, null))
                return false;

            // Check for same reference
            if (ReferenceEquals(this, other))
                return true;

            // Check for same value
            return ProcessDefinitionId.Equals(other.ProcessDefinitionId) &&
                ProcessDefinitionName.Equals(other.ProcessDefinitionName) &&
                ProcessDefinitionName.Equals(other.ProcessDefinitionName) &&
                Name.Equals(other.Name) &&
                BusinessKey.Equals(other.BusinessKey) &&
                TenantId.Equals(other.TenantId) &&
                SuspensionState.Equals(other.SuspensionState) &&
                UserCandidates.Equals(other.UserCandidates) &&
                Owner.Equals(other.Owner);
        }
    }
}
