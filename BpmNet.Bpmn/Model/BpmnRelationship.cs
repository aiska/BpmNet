using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("relationship", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnRelationship : BpmnBaseElement
    {
        [XmlElement("source")]
        public XmlQualifiedName[] Source { get; set; }

        [XmlElement("target")]
        public XmlQualifiedName[] Target { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("direction")]
        public BpmnRelationshipDirection Direction { get; set; }

        [XmlIgnore()]
        public bool DirectionSpecified { get; set; }
    }
}
