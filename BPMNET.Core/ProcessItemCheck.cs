using BPMNET.Bpmn;

namespace BPMNET.Core
{
    public class ProcessItemCheck
    {
        public static bool IsFlowNode(ProcessItemType type)
        {
            return
                IsActivity(type) ||
                IsEvent(type) ||
                IsChoreographyActivity(type) ||
                IsGateway(type);
        }
        public static bool IsChoreographyActivity(ProcessItemType type)
        {
            return
                IsCallChoreography(type) ||
                IsChoreographyTask(type) ||
                IsSubChoreography(type);
        }
        public static bool IsGateway(ProcessItemType type)
        {
            return
                IsComplexGateway(type) ||
                IsEventBasedGateway(type) ||
                IsExclusiveGateway(type) ||
                IsInclusiveGateway(type) ||
                IsParallelGateway(type);
        }
        public static bool IsActivity(ProcessItemType type)
        {
            return
                IsSubProcess(type) ||
                IsTask(type) ||
                IsCallActivity(type);
        }
        public static bool IsEvent(ProcessItemType type)
        {
            return
                IsCatchEvent(type) ||
                IsThrowEvent(type);
        }
        public static bool IsCatchEvent(ProcessItemType type)
        {
            return
                IsBoundaryEvent(type) ||
                IsIntermediateCatchEvent(type) ||
                IsStartEvent(type);
        }
        public static bool IsThrowEvent(ProcessItemType type)
        {
            return
                IsEndEvent(type) ||
                IsImplicitThrowEvent(type) ||
                IsIntermediateThrowEvent(type);
        }
        public static bool IsSubProcess(ProcessItemType type)
        {
            return
                IsAdHocSubProcess(type) ||
                IsTransaction(type) ||
                type.Equals(ProcessItemType.SubProcess);
        }
        public static bool IsTask(ProcessItemType type)
        {
            return
                IsUserTask(type) ||
                IsBusinessRuleTask(type) ||
                IsManualTask(type) ||
                IsReceiveTask(type) ||
                IsScriptTask(type) ||
                IsSendTask(type) ||
                IsServiceTask(type) ||
                type.Equals(ProcessItemType.Task);
        }
        public static bool IsAdHocSubProcess(ProcessItemType type)
        {
            return type == ProcessItemType.AdHocSubProcess;
        }
        public static bool IsTransaction(ProcessItemType type)
        {
            return type == ProcessItemType.Transaction;
        }
        private static bool IsServiceTask(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.ServiceTask);
        }
        private static bool IsSendTask(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.SendTask);
        }
        private static bool IsScriptTask(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.ScriptTask);
        }
        private static bool IsReceiveTask(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.ReceiveTask);
        }
        private static bool IsManualTask(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.ManualTask);
        }
        private static bool IsBusinessRuleTask(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.BusinessRuleTask);
        }
        public static bool IsUserTask(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.UserTask);
        }
        public static bool IsCallActivity(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.CallActivity);
        }
        public static bool IsBoundaryEvent(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.BoundaryEvent);
        }
        public static bool IsIntermediateCatchEvent(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.IntermediateCatchEvent);
        }
        public static bool IsStartEvent(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.StartEvent);
        }
        public static bool IsEndEvent(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.EndEvent);
        }
        public static bool IsImplicitThrowEvent(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.ImplicitThrowEvent);
        }
        public static bool IsIntermediateThrowEvent(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.IntermediateThrowEvent);
        }
        public static bool IsCallChoreography(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.CallChoreography);
        }
        public static bool IsChoreographyTask(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.ChoreographyTask);
        }
        public static bool IsSubChoreography(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.SubChoreography);
        }
        public static bool IsComplexGateway(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.ComplexGateway);
        }
        public static bool IsEventBasedGateway(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.EventBasedGateway);
        }
        public static bool IsExclusiveGateway(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.ExclusiveGateway);
        }
        public static bool IsInclusiveGateway(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.InclusiveGateway);
        }
        public static bool IsParallelGateway(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.ParallelGateway);
        }
        public static bool IsDataObject(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.DataObject);
        }
        public static bool IsDataObjectReference(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.DataObjectReference);
        }
        public static bool IsDataStoreReference(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.DataStoreReference);
        }
        public static bool IsSequenceFlow(ProcessItemType type)
        {
            return type.Equals(ProcessItemType.SequenceFlow);
        }
    }
}
