using System;
namespace BPMNET.Core
{
    public interface IComment<TKey>
    {
        TKey CommentId { get; set; }
        TKey ProcessInstanceId { get; set; }
        DateTime UtcCreateDate { get; set; }
        string CommentText { get; set; }
        string User { get; set; }
    }
}
