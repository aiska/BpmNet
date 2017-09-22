using System;

namespace BPMNET.Bpmn
{
    public enum ProcessItemType
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
        Process,
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
