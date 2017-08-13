using System;

namespace BPMNET.EntityCore
{
    public class BpmnProcess : IBaseElement
    {
        public BpmnProcess()
        {
            Key = Guid.NewGuid();
        }
        public Guid Key { get; set; }
        public Guid DefinitionKey { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsExecutable { get; set; }
        public bool IsClosed { get; set; }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (Key != null) ? Key.GetHashCode() : 0;
                // Suitable nullity checks etc, of course :)
                hash = (DefinitionKey != null) ? hash * 17 + DefinitionKey.GetHashCode() : hash;
                hash = (Id != null) ? hash * 17 + Id.GetHashCode() : hash;
                hash = (Name != null) ? hash * 17 + Name.GetHashCode() : hash;
                hash = hash * 17 + IsExecutable.GetHashCode();
                hash = hash * 17 + IsClosed.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as BpmnProcess);
        }
        public bool Equals(BpmnProcess other)
        {
            // Check for null
            if (ReferenceEquals(other, null))
                return false;

            // Check for same reference
            if (ReferenceEquals(this, other))
                return true;

            // Not Check Key, because generated Guid

            // Check for same value
            return ((DefinitionKey == null && other.DefinitionKey == null) || (DefinitionKey != null && other.DefinitionKey != null && DefinitionKey.Equals(other.DefinitionKey))) &&
                ((Id == null && other.Id == null) || (Id != null && other.Id != null && Id.Equals(other.Id))) &&
                ((Name == null && other.Name == null) || (Name != null && other.Name != null && Name.Equals(other.Name))) &&
                (IsExecutable.Equals(other.IsExecutable)) &&
                (IsClosed.Equals(other.IsClosed));
        }
    }
}
