using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("conversationLink", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnConversationLink : BpmnBaseElement
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("sourceRef")]
        public XmlQualifiedName SourceRef { get; set; }

        [XmlAttribute("targetRef")]
        public XmlQualifiedName TargetRef { get; set; }
    }
}
