using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("messageFlow", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnMessageFlow : BpmnBaseElement
    {
        [XmlAttribute()]
        public string Name { get; set; }

        [XmlAttribute("sourceRef")]
        public XmlQualifiedName SourceRef { get; set; }

        [XmlAttribute("targetRef")]
        public XmlQualifiedName TargetRef { get; set; }

        [XmlAttribute("messageRef")]
        public XmlQualifiedName MessageRef { get; set; }
    }
}
