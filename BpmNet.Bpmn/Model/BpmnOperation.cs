using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("operation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnOperation : BpmnBaseElement
    {
        [XmlAttribute("inMessageRef")]
        public XmlQualifiedName InMessageRef { get; set; }

        [XmlAttribute("outMessageRef")]
        public XmlQualifiedName OutMessageRef { get; set; }

        [XmlAttribute("errorRef")]
        public XmlQualifiedName[] ErrorRef { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("implementationRef")]
        public XmlQualifiedName ImplementationRef { get; set; }
    }
}
