using System;

namespace BPMNET.EntityCore
{
    public class ProcessTask :IAuditTrail
    {
        public ProcessTask()
        {
            ProcessTaskId = Guid.NewGuid();
            SuspensionState = ESuspensionState.ACTIVE;
        }
        public Guid ProcessTaskId { get; set; }
        public string ProcessTaskName { get; set; }
        public string ProcessTaskOwner { get; set; }
        public Guid ParentTaskId { get; set; }
        public int Priority { get; set; }
        public Guid ProcessKey { get; set; }
        public Guid ProcessInstanceId { get; set; }
        public Guid ProcessItemDefinitionId { get; set; }
        public ESuspensionState SuspensionState { get; set; }
        public DateTime Inserted { get; set; }
        public DateTime LastUpdated { get; set; }
        public byte[] Timestamp { get; set; }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = ProcessTaskId.GetHashCode();
                // Suitable nullity checks etc, of course :)
                if (ProcessTaskName != null) hash = hash * 17 + ProcessTaskName.GetHashCode();
                if (ProcessTaskOwner != null) hash = hash * 17 + ProcessTaskOwner.GetHashCode();
                if (ParentTaskId != null) hash = hash * 17 + ParentTaskId.GetHashCode();
                hash = hash * 17 + Priority.GetHashCode();
                if (ProcessKey != null) hash = hash * 17 + ProcessKey.GetHashCode();
                if (ProcessInstanceId != null) hash = hash * 17 + ProcessInstanceId.GetHashCode();
                if (ProcessItemDefinitionId != null) hash = hash * 17 + ProcessItemDefinitionId.GetHashCode();
                hash = hash * 17 + SuspensionState.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ProcessTask);
        }

        public bool Equals(ProcessTask other)
        {
            // Check for null
            if (ReferenceEquals(other, null))
                return false;

            // Check for same reference
            if (ReferenceEquals(this, other))
                return true;

            // Not Check ProcessTaskId, because generated Guid

            // Check for same value

            return ((ProcessTaskName == null && other.ProcessTaskName == null) || (ProcessTaskName != null && other.ProcessTaskName != null && ProcessTaskName.Equals(other.ProcessTaskName))) &&
                ((ProcessTaskOwner == null && other.ProcessTaskOwner == null) || (ProcessTaskOwner != null && other.ProcessTaskOwner != null && ProcessTaskOwner.Equals(other.ProcessTaskOwner))) &&
                ((ParentTaskId == null && other.ParentTaskId == null) || (ParentTaskId != null && other.ParentTaskId != null && ParentTaskId.Equals(other.ParentTaskId))) &&
                ((ProcessKey == null && other.ProcessKey == null) || (ProcessKey != null && other.ProcessKey != null && ProcessKey.Equals(other.ProcessKey))) &&
                ((ProcessInstanceId == null && other.ProcessInstanceId == null) || (ProcessInstanceId != null && other.ProcessInstanceId != null && ProcessInstanceId.Equals(other.ProcessInstanceId))) &&
                ((ProcessItemDefinitionId == null && other.ProcessItemDefinitionId == null) || (ProcessItemDefinitionId != null && other.ProcessItemDefinitionId != null && ProcessItemDefinitionId.Equals(other.ProcessItemDefinitionId))) &&
                SuspensionState.Equals(other.SuspensionState);
        }
    }
}
