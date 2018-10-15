using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnGlobalConversation))]
    [XmlInclude(typeof(BpmnChoreography))]
    [XmlInclude(typeof(BpmnGlobalChoreographyTask))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("collaboration", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnCollaboration : BpmnRootElement
    {
        public BpmnCollaboration()
        {
            IsClosed = false;
        }

        [XmlElement("participant")]
        public BpmnParticipant[] Participant { get; set; }

        [XmlElement("messageFlow")]
        public BpmnMessageFlow[] MessageFlow { get; set; }

        [XmlElement("artifact", typeof(BpmnArtifact))]
        [XmlElement("association", typeof(BpmnAssociation))]
        [XmlElement("group", typeof(BpmnGroup))]
        [XmlElement("textAnnotation", typeof(BpmnTextAnnotation))]
        public BpmnArtifact[] Items { get; set; }

        [XmlElement("callConversation", typeof(BpmnCallConversation))]
        [XmlElement("conversation", typeof(BpmnConversation))]
        [XmlElement("conversationNode", typeof(BpmnConversationNode))]
        [XmlElement("subConversation", typeof(BpmnSubConversation))]
        public BpmnConversationNode[] Items1 { get; set; }

        [XmlElement("conversationAssociation")]
        public BpmnConversationAssociation[] ConversationAssociation { get; set; }

        [XmlElement("participantAssociation")]
        public BpmnParticipantAssociation[] ParticipantAssociation { get; set; }

        [XmlElement("messageFlowAssociation")]
        public BpmnMessageFlowAssociation[] MessageFlowAssociation { get; set; }

        [XmlElement("correlationKey")]
        public BpmnCorrelationKey[] CorrelationKey { get; set; }

        [XmlElement("choreographyRef")]
        public XmlQualifiedName[] ChoreographyRef { get; set; }

        [XmlElement("conversationLink")]
        public BpmnConversationLink[] ConversationLink { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("isClosed")]
        [DefaultValue(false)]
        public bool IsClosed { get; set; }
    }
}
