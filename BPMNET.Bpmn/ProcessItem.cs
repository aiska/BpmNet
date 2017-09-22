using System;

namespace BPMNET.Bpmn
{
    public class ProcessItem
    {

        public static bool IsFlowNode(tFlowElement item)
        {
            return (item is tFlowNode);
        }

        public static bool IsActivity(tFlowElement item)
        {
            return (item is tActivity);
        }

        public static bool IsSubProcess(tFlowElement item)
        {
            return (item is tSubProcess);
        }

        public static bool IsAdHocSubProcess(tFlowElement item)
        {
            return (item is tAdHocSubProcess);
        }

        public static bool IsTransaction(tFlowElement item)
        {
            return (item is tTransaction);
        }

        public static bool IsTask(tFlowElement item)
        {
            return (item is tTask);
        }

        public static bool IsUserTask(tFlowElement item)
        {
            return (item is tUserTask);
        }

        public static bool IsBusinessRuleTask(tFlowElement item)
        {
            return (item is tBusinessRuleTask);
        }

        public static bool IsManualTask(tFlowElement item)
        {
            return (item is tManualTask);
        }

        public static bool IsReceiveTask(tFlowElement item)
        {
            return (item is tReceiveTask);
        }

        public static bool IsScriptTask(tFlowElement item)
        {
            return (item is tScriptTask);
        }

        public static bool IsSendTask(tFlowElement item)
        {
            return (item is tSendTask);
        }

        public static bool IsServiceTask(tFlowElement item)
        {
            return (item is tServiceTask);
        }

        public static bool IsCallActivity(tFlowElement item)
        {
            return (item is tCallActivity);
        }

        public static bool IsEvent(tFlowElement item)
        {
            return (item is tEvent);
        }

        public static bool IsCatchEvent(tFlowElement item)
        {
            return (item is tCatchEvent);
        }

        public static bool IsBoundaryEvent(tFlowElement item)
        {
            return (item is tBoundaryEvent);
        }

        public static bool IsIntermediateCatchEvent(tFlowElement item)
        {
            return (item is tIntermediateCatchEvent);
        }

        public static bool IsStartEvent(tFlowElement item)
        {
            return (item is tStartEvent);
        }

        public static bool IsEndEvent(tFlowElement item)
        {
            return (item is tEndEvent);
        }

        public static bool IsThrowEvent(tFlowElement item)
        {
            return (item is tThrowEvent);
        }

        public static bool IsImplicitThrowEvent(tFlowElement item)
        {
            return (item is tImplicitThrowEvent);
        }

        public static bool IsIntermediateThrowEvent(tFlowElement item)
        {
            return (item is tIntermediateThrowEvent);
        }

        public static bool IsChoreographyActivity(tFlowElement item)
        {
            return (item is tChoreographyActivity);
        }

        public static bool IsCallChoreography(tFlowElement item)
        {
            return (item is tCallChoreography);
        }

        public static bool IsChoreographyTask(tFlowElement item)
        {
            return (item is tChoreographyTask);
        }

        public static bool IsSubChoreography(tFlowElement item)
        {
            return (item is tSubChoreography);
        }

        public static bool IsGateway(tFlowElement item)
        {
            return (item is tGateway);
        }

        public static bool IsComplexGateway(tFlowElement item)
        {
            return (item is tComplexGateway);
        }

        public static bool IsEventBasedGateway(tFlowElement item)
        {
            return (item is tEventBasedGateway);
        }

        public static bool IsExclusiveGateway(tFlowElement item)
        {
            return (item is tExclusiveGateway);
        }

        public static bool IsInclusiveGateway(tFlowElement item)
        {
            return (item is tInclusiveGateway);
        }

        public static bool IsParallelGateway(tFlowElement item)
        {
            return (item is tParallelGateway);
        }

        public static bool IsDataObject(tFlowElement item)
        {
            return (item is tDataObject);
        }

        public static bool IsDataObjectReference(tFlowElement item)
        {
            return (item is tDataObjectReference);
        }

        public static bool IsDataStoreReference(tFlowElement item)
        {
            return (item is tDataStoreReference);
        }

        public static bool IsSequenceFlow(tFlowElement item)
        {
            return (item is tSequenceFlow);
        }

        public static ProcessItemType GetProcessType(tFlowElement item)
        {
            if (IsFlowNode(item))
            {
                if (IsActivity(item))
                {
                    if (IsSubProcess(item))
                    {
                        if (IsAdHocSubProcess(item))
                        {
                            return ProcessItemType.AdHocSubProcess;
                        }
                        else if (IsTransaction(item))
                        {
                            return ProcessItemType.Transaction;
                        }
                        else
                        {
                            return ProcessItemType.SubProcess;
                        }
                    }
                    else if (IsTask(item))
                    {
                        if (IsUserTask(item))
                        {
                            return ProcessItemType.UserTask;
                        }
                        else if (IsBusinessRuleTask(item))
                        {
                            return ProcessItemType.BusinessRuleTask;
                        }
                        else if (IsManualTask(item))
                        {
                            return ProcessItemType.ManualTask;
                        }
                        else if (IsReceiveTask(item))
                        {
                            return ProcessItemType.ReceiveTask;
                        }
                        else if (IsScriptTask(item))
                        {
                            return ProcessItemType.ScriptTask;
                        }
                        else if (IsSendTask(item))
                        {
                            return ProcessItemType.SendTask;
                        }
                        else if (IsServiceTask(item))
                        {
                            return ProcessItemType.ServiceTask;
                        }
                        else
                        {
                            return ProcessItemType.Task;
                        }
                    }
                    else if (IsCallActivity(item))
                    {
                        return ProcessItemType.CallActivity;
                    }
                }
                else if (IsEvent(item))
                {
                    if (IsCatchEvent(item))
                    {
                        if (IsBoundaryEvent(item))
                        {
                            return ProcessItemType.BoundaryEvent;
                        }
                        else if (IsIntermediateCatchEvent(item))
                        {
                            return ProcessItemType.IntermediateCatchEvent;
                        }
                        else if (IsStartEvent(item))
                        {
                            return ProcessItemType.StartEvent;
                        }
                    }
                    if (IsThrowEvent(item))
                    {
                        if (IsEndEvent(item))
                        {
                            return ProcessItemType.EndEvent;
                        }
                        else if (IsImplicitThrowEvent(item))
                        {
                            return ProcessItemType.ImplicitThrowEvent;
                        }
                        else if (IsIntermediateThrowEvent(item))
                        {
                            return ProcessItemType.IntermediateThrowEvent;
                        }
                    }
                }
                else if (IsChoreographyActivity(item))
                {
                    if (IsCallChoreography(item))
                    {
                        return ProcessItemType.CallChoreography;
                    }
                    else if (IsChoreographyTask(item))
                    {
                        return ProcessItemType.ChoreographyTask;
                    }
                    else if (IsSubChoreography(item))
                    {
                        return ProcessItemType.SubChoreography;
                    }
                }
                else if (IsGateway(item))
                {
                    if (IsComplexGateway(item))
                    {
                        return ProcessItemType.ComplexGateway;
                    }
                    else if (IsEventBasedGateway(item))
                    {
                        return ProcessItemType.EventBasedGateway;
                    }
                    else if (IsExclusiveGateway(item))
                    {
                        return ProcessItemType.ExclusiveGateway;
                    }
                    else if (IsInclusiveGateway(item))
                    {
                        return ProcessItemType.InclusiveGateway;
                    }
                    else if (IsParallelGateway(item))
                    {
                        return ProcessItemType.ParallelGateway;
                    }
                }
            }
            else if (IsDataObject(item))
            {
                return ProcessItemType.DataObject;
            }
            else if (IsDataObjectReference(item))
            {
                return ProcessItemType.DataObjectReference;
            }
            else if (IsDataStoreReference(item))
            {
                return ProcessItemType.DataStoreReference;
            }
            else if (IsSequenceFlow(item))
            {
                return ProcessItemType.SequenceFlow;
            }
            throw new ArgumentException("Unknown ProcessItemType of " + item.GetType().Name);
        }
    }
}
