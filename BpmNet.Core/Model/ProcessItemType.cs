using BpmNet.Bpmn;

namespace BpmNet.Core.Model
{
    public static class ProcessItemType
    {
        public static FlowElementType GetItemType(BpmnFlowElement flowElement)
        {
            if (flowElement is BpmnSequenceFlow)
            {
                return FlowElementType.SequenceFlow;
            }
            if (flowElement is BpmnGateway)
            {
                if (flowElement is BpmnParallelGateway)
                {
                    return FlowElementType.ParallelGateway;
                }
                if (flowElement is BpmnExclusiveGateway)
                {
                    return FlowElementType.ExclusiveGateway;
                }
                if (flowElement is BpmnInclusiveGateway)
                {
                    return FlowElementType.InclusiveGateway;
                }
                if (flowElement is BpmnComplexGateway)
                {
                    return FlowElementType.ComplexGateway;
                }
                if (flowElement is BpmnEventBasedGateway)
                {
                    return FlowElementType.EventBasedGateway;
                }
            }
            if (flowElement is BpmnTask)
            {
                if (flowElement is BpmnUserTask)
                {
                    return FlowElementType.UserTask;
                }
                if (flowElement is BpmnServiceTask)
                {
                    return FlowElementType.ServiceTask;
                }
                if (flowElement is BpmnBusinessRuleTask)
                {
                    return FlowElementType.BusinessRuleTask;
                }
                if (flowElement is BpmnManualTask)
                {
                    return FlowElementType.ManualTask;
                }
                if (flowElement is BpmnReceiveTask)
                {
                    return FlowElementType.ReceiveTask;
                }
                if (flowElement is BpmnScriptTask)
                {
                    return FlowElementType.ScriptTask;
                }
                if (flowElement is BpmnSendTask)
                {
                    return FlowElementType.SendTask;
                }
                return FlowElementType.Task;
            }
            if (flowElement is BpmnEvent)
            {
                if (flowElement is BpmnStartEvent)
                {
                    return FlowElementType.StartEvent;
                }
                if (flowElement is BpmnEndEvent)
                {
                    return FlowElementType.EndEvent;
                }
                if (flowElement is BpmnIntermediateCatchEvent)
                {
                    return FlowElementType.IntermediateCatchEvent;
                }
                if (flowElement is BpmnImplicitThrowEvent)
                {
                    return FlowElementType.ImplicitThrowEvent;
                }
                if (flowElement is BpmnBoundaryEvent)
                {
                    return FlowElementType.BoundaryEvent;
                }
                if (flowElement is BpmnIntermediateThrowEvent)
                {
                    return FlowElementType.IntermediateThrowEvent;
                }
                return FlowElementType.Event;
            }
            if (flowElement is BpmnSubProcess)
            {
                if (flowElement is BpmnAdHocSubProcess)
                {
                    return FlowElementType.AdHocSubProcess;
                }
                if (flowElement is BpmnTransaction)
                {
                    return FlowElementType.Transaction;
                }
                return FlowElementType.SubProcess;
            }
            if (flowElement is BpmnCallActivity)
            {
                return FlowElementType.CallActivity;
            }
            if (flowElement is BpmnCallChoreography)
            {
                return FlowElementType.CallChoreography;
            }
            if (flowElement is BpmnChoreographyTask)
            {
                return FlowElementType.ChoreographyTask;
            }
            if (flowElement is BpmnSubChoreography)
            {
                return FlowElementType.SubChoreography;
            }
            if (flowElement is BpmnDataObject)
            {
                return FlowElementType.DataObject;
            }
            if (flowElement is BpmnDataObjectReference)
            {
                return FlowElementType.DataObjectReference;
            }
            if (flowElement is BpmnDataStoreReference)
            {
                return FlowElementType.DataStoreReference;
            }
            return FlowElementType.Flow;
        }
    }
}
