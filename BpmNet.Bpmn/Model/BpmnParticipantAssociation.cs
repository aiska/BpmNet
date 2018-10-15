using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("participantAssociation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnParticipantAssociation : BpmnBaseElement
    {
        [XmlAttribute("innerParticipantRef")]
        public XmlQualifiedName InnerParticipantRef { get; set; }

        [XmlAttribute("outerParticipantRef")]
        public XmlQualifiedName OuterParticipantRef { get; set; }
    }
}
