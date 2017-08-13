using System;
namespace BPMNET.Core
{
    public interface IComment<TKey>
    {
        TKey Id { get; set; }
        TKey ProcessInstanceId { get; set; }
        TKey ProcessTaskId { get; set; }
        DateTime CreateDate { get; set; }
        string FullMessage { get; set; }
        string Type { get; set; }
        string UserId { get; set; }
    }
}
