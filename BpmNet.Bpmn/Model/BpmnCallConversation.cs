using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("callConversation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnCallConversation : BpmnConversationNode
    {
        [XmlElement("participantAssociation")]
        public BpmnParticipantAssociation[] ParticipantAssociation { get; set; }

        [XmlAttribute("calledCollaborationRef")]
        public XmlQualifiedName CalledCollaborationRef { get; set; }
    }
}
