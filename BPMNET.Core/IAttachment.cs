using System;
namespace BPMNET.Core
{
    public interface IAttachment<TKey>
    {
        TKey Id { get; set; }
        TKey ProcessInstanceId { get; set; }
        DateTime CreateDate { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        string Type { get; set; }
        string Url { get; set; }
        string UserId { get; set; }
    }
}
