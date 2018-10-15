using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnSubChoreography))]
    [XmlInclude(typeof(BpmnChoreographyTask))]
    [XmlInclude(typeof(BpmnCallChoreography))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("choreographyActivity", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class BpmnChoreographyActivity : BpmnFlowNode
    {
        public BpmnChoreographyActivity()
        {
            LoopType = BpmnChoreographyLoopType.None;
        }

        [XmlElement("participantRef")]
        public XmlQualifiedName[] ParticipantRef { get; set; }

        [XmlElement("correlationKey")]
        public BpmnCorrelationKey[] CorrelationKey { get; set; }

        [XmlAttribute("initiatingParticipantRef")]
        public XmlQualifiedName InitiatingParticipantRef { get; set; }

        [XmlAttribute("loopType")]
        [DefaultValue(BpmnChoreographyLoopType.None)]
        public BpmnChoreographyLoopType LoopType { get; set; }
    }
}
