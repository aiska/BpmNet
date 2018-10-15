using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnStartEvent))]
    [XmlInclude(typeof(BpmnIntermediateCatchEvent))]
    [XmlInclude(typeof(BpmnBoundaryEvent))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("catchEvent", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class BpmnCatchEvent : BpmnEvent
    {
        public BpmnCatchEvent()
        {
            ParallelMultiple = false;
        }

        [XmlElement("dataOutput")]
        public BpmnDataOutput[] DataOutput { get; set; }

        [XmlElement("dataOutputAssociation")]
        public BpmnDataOutputAssociation[] DataOutputAssociation { get; set; }

        [XmlElement("outputSet")]
        public BpmnOutputSet OutputSet { get; set; }

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

        [XmlAttribute("parallelMultiple")]
        [DefaultValue(false)]
        public bool ParallelMultiple { get; set; }
    }
}
