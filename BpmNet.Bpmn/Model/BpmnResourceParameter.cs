using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("resourceParameter", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnResourceParameter : BpmnBaseElement
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public XmlQualifiedName Type { get; set; }

        [XmlAttribute("isRequired")]
        public bool IsRequired { get; set; }

        [XmlIgnore()]
        public bool IsRequiredSpecified { get; set; }
    }
}
