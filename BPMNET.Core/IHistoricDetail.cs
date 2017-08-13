using System;
namespace BPMNET.Core
{
    public interface IHistoricDetail
    {
        string BpmInstanceId { get; set; }
        DateTime CreateDate { get; set; }
        string ExecutionId { get; set; }
        string Id { get; set; }
        string ProcessInstanceId { get; set; }
        string TaskId { get; set; }
    }
}
