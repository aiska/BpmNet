using System;

namespace BPMNET.EntityCore
{
    public class ProcessInstance : IAuditTrail
    {
        public ProcessInstance()
        {
            ProcessInstanceId = Guid.NewGuid();
            SuspensionState = ESuspensionState.ACTIVE;
        }
        public Guid ProcessInstanceId { get; set; }
        public Guid ProcessKey { get; set; }
        public string ProcessInstanceName { get; set; }
        public string BusinessKey { get; set; }
        public ESuspensionState SuspensionState { get; set; }
        public string UserCandidates { get; set; }
        public string Owner { get; set; }
        public DateTime Inserted { get; set; }
        public DateTime LastUpdated { get; set; }
        public byte[] Timestamp { get; set; }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = ProcessInstanceId.GetHashCode();
                // Suitable nullity checks etc, of course :)
                if (ProcessKey != null) hash = hash * 17 + ProcessKey.GetHashCode();
                if (ProcessInstanceName != null) hash = hash * 17 + ProcessInstanceName.GetHashCode();
                if (BusinessKey != null) hash = hash * 17 + BusinessKey.GetHashCode();
                hash = hash * 17 + SuspensionState.GetHashCode();
                if (UserCandidates != null) hash = hash * 17 + UserCandidates.GetHashCode();
                if (Owner != null) hash = hash * 17 + Owner.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ProcessInstance);
        }

        public bool Equals(ProcessInstance other)
        {
            // Check for null
            if (ReferenceEquals(other, null))
                return false;

            // Check for same reference
            if (ReferenceEquals(this, other))
                return true;

            // Not Check ProcessInstanceId, because generated Guid

            // Check for same value
            return ((ProcessKey == null && other.ProcessKey == null) || (ProcessKey != null && other.ProcessKey != null && ProcessKey.Equals(other.ProcessKey))) &&
                ((ProcessInstanceName == null && other.ProcessInstanceName == null) || (ProcessInstanceName != null && other.ProcessInstanceName != null && ProcessInstanceName.Equals(other.ProcessInstanceName))) &&
                ((BusinessKey == null && other.BusinessKey == null) || (BusinessKey != null && other.BusinessKey != null && BusinessKey.Equals(other.BusinessKey))) &&
                SuspensionState.Equals(other.SuspensionState) &&
                ((UserCandidates == null && other.UserCandidates == null) || (UserCandidates != null && other.UserCandidates != null && UserCandidates.Equals(other.UserCandidates))) &&
                ((Owner == null && other.Owner == null) || (Owner != null && other.Owner != null && Owner.Equals(other.Owner)));
        }
    }
}
