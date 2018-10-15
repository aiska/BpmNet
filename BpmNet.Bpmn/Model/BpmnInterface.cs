using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("interface", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnInterface : BpmnRootElement
    {
        [XmlElement("operation")]
        public BpmnOperation[] Operation { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("implementationRef")]
        public XmlQualifiedName ImplementationRef { get; set; }
    }
}
