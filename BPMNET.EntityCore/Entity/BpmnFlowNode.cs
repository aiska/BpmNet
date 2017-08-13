using BPMNET.Bpmn;
using System;


namespace BPMNET.EntityCore
{
    public class BpmnFlowNode : IBaseElement
    {
        public BpmnFlowNode()
        {
            Key = Guid.NewGuid();
            StartQuantity = 1;
            CompletionQuantity = 1;
        }
        public Guid Key { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public ProcessItemType ItemType { get; set; }
        public bool IsForCompensation { get; set; }
        public int StartQuantity { get; set; }
        public int CompletionQuantity { get; set; }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (Key != null) ? Key.GetHashCode() : 0;
                // Suitable nullity checks etc, of course :)
                hash = (Id != null) ? hash * 17 + Id.GetHashCode() : hash;
                hash = (Name != null) ? hash * 17 + Name.GetHashCode() : hash;
                hash = hash * 17 + ItemType.GetHashCode();
                hash = hash * 17 + IsForCompensation.GetHashCode();
                hash = hash * 17 + StartQuantity.GetHashCode();
                hash = hash * 17 + CompletionQuantity.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as BpmnFlowNode);
        }
        public bool Equals(BpmnFlowNode other)
        {
            // Check for null
            if (ReferenceEquals(other, null))
                return false;

            // Check for same reference
            if (ReferenceEquals(this, other))
                return true;

            // Not Check Key, because generated Guid

            // Check for same value
            return ((Id == null && other.Id == null) || (Id != null && other.Id != null && Id.Equals(other.Id))) &&
                ((Name == null && other.Name == null) || (Name != null && other.Name != null && Name.Equals(other.Name))) &&
                (IsForCompensation.Equals(other.IsForCompensation)) &&
                (ItemType.Equals(other.ItemType)) &&
                (StartQuantity.Equals(other.StartQuantity)) &&
                (CompletionQuantity.Equals(other.CompletionQuantity));
        }
    }
}
