using BPMNET.Core;
using System;

namespace BPMNET.Entity
{
    public class Comment : IComment<int>
    {
        public Comment()
        {
            UtcCreateDate = DateTime.UtcNow;
        }
        public int CommentId { get; set; }
        public int ProcessInstanceId { get; set; }
        public string User { get; set; }
        public bool IsPrivateComment { get; set; }
        public DateTime UtcCreateDate { get; set; }
        public string CommentText { get; set; }

        //public override int GetHashCode()
        //{
        //    unchecked // Overflow is fine, just wrap
        //    {
        //        int hash = CommentId.GetHashCode();
        //        // Suitable nullity checks etc, of course :)
        //        hash = hash * 17 + ProcessInstanceId.GetHashCode();
        //        hash = (User != null) ? hash * 17 + User.GetHashCode() : hash;
        //        hash = hash * 17 + IsPrivateComment.GetHashCode();
        //        hash = hash * 17 + UtcCreateDate.GetHashCode();
        //        hash = (CommentText != null) ? hash * 17 + CommentText.GetHashCode() : hash;
        //        return hash;
        //    }
        //}
        //public override bool Equals(object obj)
        //{
        //    return Equals(obj as Comment);
        //}
        //public bool Equals(Comment other)
        //{
        //    // Check for null
        //    if (ReferenceEquals(other, null))
        //        return false;

        //    // Check for same reference
        //    if (ReferenceEquals(this, other))
        //        return true;

        //    // Check for same value
        //    return ProcessInstanceId.Equals(other.ProcessInstanceId) &&
        //        IsPrivateComment.Equals(other.IsPrivateComment) &&
        //        UtcCreateDate.Equals(other.UtcCreateDate) &&
        //        ((User == null && other.User == null) || (User != null && other.User != null && User.Equals(other.User))) &&
        //        ((CommentText == null && other.CommentText == null) || (CommentText != null && other.CommentText != null && CommentText.Equals(other.CommentText)));
        //}
    }
}
