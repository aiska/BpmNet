using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnIntermediateThrowEvent))]
    [XmlInclude(typeof(BpmnImplicitThrowEvent))]
    [XmlInclude(typeof(BpmnEndEvent))]
    
    [Serializable()]
    [DebuggerStepThrough()]
    
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("throwEvent", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class BpmnThrowEvent : BpmnEvent
    {
        [XmlElement("dataInput")]
        public BpmnDataInput[] DataInput { get; set; }

        [XmlElement("dataInputAssociation")]
        public BpmnDataInputAssociation[] DataInputAssociation { get; set; }

        [XmlElement("inputSet")]
        public BpmnInputSet InputSet { get; set; }

        [XmlElement("cancelEventDefinition", typeof(BpmnCancelEventDefinition))]
        [XmlElement("compensateEventDefinition", typeof(BpmnCompensateEventDefinition))]
        [XmlElement("conditionalEventDefinition", typeof(BpmnConditionalEventDefinition))]
        [XmlElement("errorEventDefinition", typeof(BpmnErrorEventDefinition))]
        [XmlElement("escalationEventDefinition", typeof(BpmnEscalationEventDefinition))]
        [XmlElement("eventDefinition", typeof(BpmnEventDefinition))]
        [XmlElement("linkEventDefinition", typeof(BpmnLinkEventDefinition))]
        [XmlElement("messageEventDefinition", typeof(BpmnMessageEventDefinition))]
        [XmlElement("signalEventDefinition", typeof(BpmnSignalEventDefinition))]
        [XmlElement("terminateEventDefinition", typeof(BpmnTerminateEventDefinition))]
        [XmlElement("timerEventDefinition", typeof(BpmnTimerEventDefinition))]
        public BpmnEventDefinition[] Items { get; set; }

        [XmlElement("eventDefinitionRef")]
        public XmlQualifiedName[] EventDefinitionRef { get; set; }
    }

}
