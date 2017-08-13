
namespace BPMNET.Core
{
    public enum EProcessItemType
    {
        AdHocSubProcess,
        BoundaryEvent,
        BusinessRuleTask,
        CallActivity,
        CallChoreography,
        ChoreographyTask,
        ComplexGateway,
        DataObject,
        DataObjectReference,
        DataStoreReference,
        EndEvent,
        EventBasedGateway,
        ExclusiveGateway,
        ImplicitThrowEvent,
        InclusiveGateway,
        IntermediateCatchEvent,
        IntermediateThrowEvent,
        ManualTask,
        ParallelGateway,
        ReceiveTask,
        ScriptTask,
        SendTask,
        SequenceFlow,
        ServiceTask,
        StartEvent,
        SubChoreography,
        SubProcess,
        Task,
        Transaction,
        UserTask
    }
}
