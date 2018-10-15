using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("correlationKey", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnCorrelationKey : BpmnBaseElement
    {
        [XmlElement("correlationPropertyRef")]
        public XmlQualifiedName[] CorrelationPropertyRef { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
