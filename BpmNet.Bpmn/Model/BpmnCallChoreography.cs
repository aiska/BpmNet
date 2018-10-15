using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("callChoreography", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnCallChoreography : BpmnChoreographyActivity
    {
        [XmlElement("participantAssociation")]
        public BpmnParticipantAssociation[] ParticipantAssociation { get; set; }

        [XmlAttribute("calledChoreographyRef")]
        public XmlQualifiedName CalledChoreographyRef { get; set; }
    }
}
