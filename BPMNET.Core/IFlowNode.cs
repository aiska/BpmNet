using BPMNET.Bpmn;

namespace BPMNET.Core
{
    public interface IFlowNode<TKey>
    {
        TKey Id { get; set; }
        //TKey ProcessId { get; set; }
        string FlowNodeId { get; set; }
        string Name { get; set; }
        ProcessItemType ItemType { get; set; }
        //bool IsForCompensation { get; set; }
        //int StartQuantity { get; set; }
        //int CompletionQuantity { get; set; }
    }
}
