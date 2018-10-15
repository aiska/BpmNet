using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("correlationPropertyBinding", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnCorrelationPropertyBinding : BpmnBaseElement
    {
        [XmlElement("dataPath")]
        public BpmnFormalExpression DataPath { get; set; }

        [XmlAttribute("correlationPropertyRef")]
        public XmlQualifiedName CorrelationPropertyRef { get; set; }
    }
}
