using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnSignal))]
    [XmlInclude(typeof(BpmnResource))]
    [XmlInclude(typeof(BpmnPartnerRole))]
    [XmlInclude(typeof(BpmnPartnerEntity))]
    [XmlInclude(typeof(BpmnMessage))]
    [XmlInclude(typeof(BpmnItemDefinition))]
    [XmlInclude(typeof(BpmnInterface))]
    [XmlInclude(typeof(BpmnEscalation))]
    [XmlInclude(typeof(BpmnError))]
    [XmlInclude(typeof(BpmnEndPoint))]
    [XmlInclude(typeof(BpmnDataStore))]
    [XmlInclude(typeof(BpmnCorrelationProperty))]
    [XmlInclude(typeof(BpmnCollaboration))]
    [XmlInclude(typeof(BpmnGlobalConversation))]
    [XmlInclude(typeof(BpmnChoreography))]
    [XmlInclude(typeof(BpmnGlobalChoreographyTask))]
    [XmlInclude(typeof(BpmnCategory))]
    [XmlInclude(typeof(BpmnEventDefinition))]
    [XmlInclude(typeof(BpmnTimerEventDefinition))]
    [XmlInclude(typeof(BpmnTerminateEventDefinition))]
    [XmlInclude(typeof(BpmnSignalEventDefinition))]
    [XmlInclude(typeof(BpmnMessageEventDefinition))]
    [XmlInclude(typeof(BpmnLinkEventDefinition))]
    [XmlInclude(typeof(BpmnEscalationEventDefinition))]
    [XmlInclude(typeof(BpmnErrorEventDefinition))]
    [XmlInclude(typeof(BpmnConditionalEventDefinition))]
    [XmlInclude(typeof(BpmnCompensateEventDefinition))]
    [XmlInclude(typeof(BpmnCancelEventDefinition))]
    [XmlInclude(typeof(BpmnCallableElement))]
    [XmlInclude(typeof(BpmnProcess))]
    [XmlInclude(typeof(BpmnGlobalTask))]
    [XmlInclude(typeof(BpmnGlobalUserTask))]
    [XmlInclude(typeof(BpmnGlobalScriptTask))]
    [XmlInclude(typeof(BpmnGlobalManualTask))]
    [XmlInclude(typeof(BpmnGlobalBusinessRuleTask))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("rootElement", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class BpmnRootElement : BpmnBaseElement
    {
    }

}
