using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
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
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("eventDefinition", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class BpmnEventDefinition : BpmnRootElement
    {
    }

}
