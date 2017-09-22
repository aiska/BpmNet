using BPMNET.Core;

namespace BPMNET.Entity
{
    public class Approval : IApproval<int>
    {
        public Approval()
        {
            Level = 1;
            Level = 0;
        }
        public int ApprovalId { get; set; }
        public string Assignee { get; set; }
        public string Group { get; set; }
        public int Level { get; set; }
        public int Order { get; set; }
        public string Criteria { get; set; }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = ApprovalId.GetHashCode();
                // Suitable nullity checks etc, of course :)
                hash = hash * 17 + Level.GetHashCode();
                hash = hash * 17 + Order.GetHashCode();
                hash = (Assignee != null) ? hash * 17 + Assignee.GetHashCode() : hash;
                hash = (Group != null) ? hash * 17 + Group.GetHashCode() : hash;
                hash = (Criteria != null) ? hash * 17 + Criteria.GetHashCode() : hash;
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Approval);
        }
        public bool Equals(Approval other)
        {
            // Check for null
            if (ReferenceEquals(other, null))
                return false;

            // Check for same reference
            if (ReferenceEquals(this, other))
                return true;

            // Check for same value
            return Level.Equals(other.Level) &&
                Order.Equals(other.Order) &&
                ((Assignee == null && other.Assignee == null) || (Assignee != null && other.Assignee != null && Assignee.Equals(other.Assignee))) &&
                ((Group == null && other.Group == null) || (Group != null && other.Group != null && Group.Equals(other.Group))) &&
                ((Criteria == null && other.Criteria == null) || (Criteria != null && other.Criteria != null && Criteria.Equals(other.Criteria)));
        }
    }
}
