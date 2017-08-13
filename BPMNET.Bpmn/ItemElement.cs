using System;

namespace BPMNET.Bpmn
{
    public enum ItemElementType
    {
        Category,
        Collaboration,
        CorrelationProperty,
        DataStore,
        EndPoint,
        Error,
        Escalation,
        EventDefinition,
        GlobalBusinessRuleTask,
        GlobalManualTask,
        GlobalScriptTask,
        GlobalTask,
        GlobalUserTask,
        Interface,
        ItemDefinition,
        Message,
        PartnerEntity,
        PartnerRole,
        Process,
        Resource,
        RootElement,
        Signal
    }

    /// <summary>
    /// 
    /// </summary>
    public class ItemElement
    {
        public static bool IsCategory(tRootElement element) { return element is tCategory; }
        public static bool IsCollaboration(tRootElement element) { return element is tCollaboration; }
        public static bool IsCorrelationProperty(tRootElement element) { return element is tCorrelationProperty; }
        public static bool IsDataStore(tRootElement element) { return element is tDataStore; }
        public static bool IsEndPoint(tRootElement element) { return element is tEndPoint; }
        public static bool IsError(tRootElement element) { return element is tError; }
        public static bool IsEscalation(tRootElement element) { return element is tEscalation; }
        public static bool IsEventDefinition(tRootElement element) { return element is tEventDefinition; }
        public static bool IsGlobalBusinessRuleTask(tRootElement element) { return element is tGlobalBusinessRuleTask; }
        public static bool IsGlobalManualTask(tRootElement element) { return element is tGlobalManualTask; }
        public static bool IsGlobalScriptTask(tRootElement element) { return element is tGlobalScriptTask; }
        public static bool IsGlobalTask(tRootElement element) { return element is tGlobalTask; }
        public static bool IsGlobalUserTask(tRootElement element) { return element is tGlobalUserTask; }
        public static bool IsInterface(tRootElement element) { return element is tInterface; }
        public static bool IsItemDefinition(tRootElement element) { return element is tItemDefinition; }
        public static bool IsMessage(tRootElement element) { return element is tMessage; }
        public static bool IsPartnerEntity(tRootElement element) { return element is tPartnerEntity; }
        public static bool IsPartnerRole(tRootElement element) { return element is tPartnerRole; }
        public static bool IsProcess(tRootElement element) { return element is tProcess; }
        public static bool IsResource(tRootElement element) { return element is tResource; }
        public static bool IsRootElement(tRootElement element) { return element is tRootElement; }
        public static bool IsSignal(tRootElement element) { return element is tSignal; }

        public static ItemElementType GetElementType(tRootElement element)
        {
            if (IsCategory(element))
            {
                return ItemElementType.Category;
            }
            else if (IsCollaboration(element))
            {
                return ItemElementType.Collaboration;
            }
            else if (IsCorrelationProperty(element))
            {
                return ItemElementType.CorrelationProperty;
            }
            else if (IsDataStore(element))
            {
                return ItemElementType.DataStore;
            }
            else if (IsEndPoint(element))
            {
                return ItemElementType.EndPoint;
            }
            else if (IsError(element))
            {
                return ItemElementType.Error;
            }
            else if (IsEscalation(element))
            {
                return ItemElementType.Escalation;
            }
            else if (IsEventDefinition(element))
            {
                return ItemElementType.EventDefinition;
            }
            else if (IsGlobalBusinessRuleTask(element))
            {
                return ItemElementType.GlobalBusinessRuleTask;
            }
            else if (IsGlobalManualTask(element))
            {
                return ItemElementType.GlobalManualTask;
            }
            else if (IsGlobalScriptTask(element))
            {
                return ItemElementType.GlobalScriptTask;
            }
            else if (IsGlobalTask(element))
            {
                return ItemElementType.GlobalTask;
            }
            else if (IsGlobalUserTask(element))
            {
                return ItemElementType.GlobalUserTask;
            }
            else if (IsInterface(element))
            {
                return ItemElementType.Interface;
            }
            else if (IsItemDefinition(element))
            {
                return ItemElementType.ItemDefinition;
            }
            else if (IsMessage(element))
            {
                return ItemElementType.Message;
            }
            else if (IsPartnerEntity(element))
            {
                return ItemElementType.PartnerEntity;
            }
            else if (IsPartnerRole(element))
            {
                return ItemElementType.PartnerRole;
            }
            else if (IsProcess(element))
            {
                return ItemElementType.Process;
            }
            else if (IsResource(element))
            {
                return ItemElementType.Resource;
            }
            else if (IsRootElement(element))
            {
                return ItemElementType.RootElement;
            }
            else if (IsSignal(element))
            {
                return ItemElementType.Signal;
            }
            else
            {
                throw new ArgumentException("Unknown Item Element Type of " + element.GetType().Name);
            }
        }
    }
}
