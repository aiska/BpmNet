using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("linkEventDefinition", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnLinkEventDefinition : BpmnEventDefinition
    {
        [XmlElement("source")]
        public XmlQualifiedName[] Source { get; set; }

        [XmlElement("target")]
        public XmlQualifiedName Target { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }

}
