using BPMNET.Core;
using BPMNET.Core.Variable;

namespace BPMNET.Entity
{
    public class DefinitionVariable : IDefinitionVariable<int>
    {
        public int DefinitionVariableId { get; set; }
        public int DefinitionId { get; set; }
        public string VariableName { get; set; }
        public EStoreType StoreType { get; set; }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = DefinitionVariableId.GetHashCode();
                // Suitable nullity checks etc, of course :)
                hash = hash * 17 + DefinitionId.GetHashCode();
                hash = (VariableName != null) ? hash * 17 + VariableName.GetHashCode() : hash;
                hash = hash * 17 + StoreType.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as DefinitionVariable);
        }
        public bool Equals(DefinitionVariable other)
        {
            // Check for null
            if (ReferenceEquals(other, null))
                return false;

            // Check for same reference
            if (ReferenceEquals(this, other))
                return true;

            // Check for same value
            return DefinitionId.Equals(other.DefinitionId) &&
                ((VariableName == null && other.VariableName == null) || (VariableName != null && other.VariableName != null && VariableName.Equals(other.VariableName))) &&
                StoreType.Equals(other.StoreType);
        }
    }
}
