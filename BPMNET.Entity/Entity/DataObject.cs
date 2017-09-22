using BPMNET.Core;

namespace BPMNET.Entity
{
    public class DataObject : IDataObject<int>
    {
        public int DataObjectId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int ItemSubjectRef { get; set; }
        public bool IsCollection { get; set; }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = DataObjectId.GetHashCode();
                // Suitable nullity checks etc, of course :)
                hash = (Id != null) ? hash * 17 + Id.GetHashCode() : hash;
                hash = (Name != null) ? hash * 17 + Name.GetHashCode() : hash;
                hash = hash * 17 + ItemSubjectRef.GetHashCode();
                hash = hash * 17 + IsCollection.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as DataObject);
        }
        public bool Equals(DataObject other)
        {
            // Check for null
            if (ReferenceEquals(other, null))
                return false;

            // Check for same reference
            if (ReferenceEquals(this, other))
                return true;

            // Check for same value
            return ((Id == null && other.Id == null) || (Id != null && other.Id != null && Id.Equals(other.Id))) &&
                ((Name == null && other.Name == null) || (Name != null && other.Name != null && Name.Equals(other.Name))) &&
                ItemSubjectRef.Equals(other.ItemSubjectRef) &&
                IsCollection.Equals(other.IsCollection);
        }
    }
}
