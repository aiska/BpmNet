using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("conversationAssociation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnConversationAssociation : BpmnBaseElement
    {
        [XmlAttribute("innerConversationNodeRef")]
        public XmlQualifiedName InnerConversationNodeRef { get; set; }

        [XmlAttribute("outerConversationNodeRef")]
        public XmlQualifiedName OuterConversationNodeRef { get; set; }
    }
}
