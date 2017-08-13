namespace BPMNET.Bpmn
{
    public class BpmnRootElement
    {
        public static bool IsCategory(tRootElement elm) { return (elm is tCategory); }
        public static bool IsCollaboration(tRootElement elm) { return (elm is tCollaboration); }
        public static bool IsCorrelationProperty(tRootElement elm) { return (elm is tCorrelationProperty); }
        public static bool IsDataStore(tRootElement elm) { return (elm is tDataStore); }
        public static bool IsEndPoint(tRootElement elm) { return (elm is tEndPoint); }
        public static bool IsError(tRootElement elm) { return (elm is tError); }
        public static bool IsEscalation(tRootElement elm) { return (elm is tEscalation); }
        public static bool IsEventDefinition(tRootElement elm) { return (elm is tEventDefinition); }
        public static bool IsGlobalBusinessRuleTask(tRootElement elm) { return (elm is tGlobalBusinessRuleTask); }
        public static bool IsGlobalManualTask(tRootElement elm) { return (elm is tGlobalManualTask); }
        public static bool IsGlobalScriptTask(tRootElement elm) { return (elm is tGlobalScriptTask); }
        public static bool IsGlobalTask(tRootElement elm) { return (elm is tGlobalTask); }
        public static bool IsGlobalUserTask(tRootElement elm) { return (elm is tGlobalUserTask); }
        public static bool IsInterface(tRootElement elm) { return (elm is tInterface); }
        public static bool IsItemDefinition(tRootElement elm) { return (elm is tItemDefinition); }
        public static bool IsMessage(tRootElement elm) { return (elm is tMessage); }
        public static bool IsPartnerEntity(tRootElement elm) { return (elm is tPartnerEntity); }
        public static bool IsPartnerRole(tRootElement elm) { return (elm is tPartnerRole); }
        public static bool IsProcess(tRootElement elm) { return (elm is tProcess); }
        public static bool IsResource(tRootElement elm) { return (elm is tResource); }
        public static bool IsRootElement(tRootElement elm) { return (elm is tRootElement); }
        public static bool IsSignal(tRootElement elm) { return (elm is tSignal); }
    }
}
