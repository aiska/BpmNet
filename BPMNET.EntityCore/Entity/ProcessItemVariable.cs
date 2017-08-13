using System;

namespace BPMNET.EntityCore
{
    public class ProcessItemVariable
    {
        public ProcessItemVariable()
        {
            Key = Guid.NewGuid();
        }
        public Guid Key { get; set; }
        public string VariableName { get; set; }
        public string DataType { get; set; }
        public Guid ProcessItemKey { get; set; }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (Key != null) ? Key.GetHashCode() : 0;
                // Suitable nullity checks etc, of course :)
                hash = (VariableName != null) ? hash * 17 + VariableName.GetHashCode() : hash;
                hash = (DataType != null) ? hash * 17 + DataType.GetHashCode() : hash;
                hash = (ProcessItemKey != null) ? hash * 17 + ProcessItemKey.GetHashCode() : hash;
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Deployment);
        }
        public bool Equals(ProcessItemVariable other)
        {
            // Check for null
            if (ReferenceEquals(other, null))
                return false;

            // Check for same reference
            if (ReferenceEquals(this, other))
                return true;

            // Not Check DeploymentId, because generated Guid

            // Check for same value
            return ((VariableName == null && other.VariableName == null) || (VariableName != null && other.VariableName != null && VariableName.Equals(other.VariableName))) &&
                ((DataType == null && other.DataType == null) || (DataType != null && other.DataType != null && DataType.Equals(other.DataType))) &&
                ((ProcessItemKey == null && other.ProcessItemKey == null) || (ProcessItemKey != null && other.ProcessItemKey != null && ProcessItemKey.Equals(other.ProcessItemKey)));
        }
    }
}
