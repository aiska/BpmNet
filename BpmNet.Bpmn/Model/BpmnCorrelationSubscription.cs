using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("correlationSubscription", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnCorrelationSubscription : BpmnBaseElement
    {
        [XmlElement("correlationPropertyBinding")]
        public BpmnCorrelationPropertyBinding[] CorrelationPropertyBinding { get; set; }

        [XmlAttribute("correlationKeyRef")]
        public XmlQualifiedName CorrelationKeyRef { get; set; }
    }
}
