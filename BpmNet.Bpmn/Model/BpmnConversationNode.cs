using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnSubConversation))]
    [XmlInclude(typeof(BpmnConversation))]
    [XmlInclude(typeof(BpmnCallConversation))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("conversationNode", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class BpmnConversationNode : BpmnBaseElement
    {
        [XmlElement("participantRef")]
        public XmlQualifiedName[] ParticipantRef { get; set; }

        [XmlElement("messageFlowRef")]
        public XmlQualifiedName[] MessageFlowRef { get; set; }

        [XmlElement("correlationKey")]
        public BpmnCorrelationKey[] CorrelationKey { get; set; }

        [XmlAttribute()]
        public string Name { get; set; }
    }
}
