using BPMNET.Bpmn;

namespace BPMNET.Core
{
    public interface IActivity<TKey>
    {
        TKey ActivityId { get; set; }
        TKey ProcessInstanceId { get; set; }
        string Id { get; set; }
        ProcessItemType ActivityType { get; set; }
        int FlowId { get; set; }
    }
}
