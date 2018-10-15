using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("correlationProperty", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnCorrelationProperty : BpmnRootElement
    {
        [XmlElement("correlationPropertyRetrievalExpression")]
        public BpmnCorrelationPropertyRetrievalExpression[] CorrelationPropertyRetrievalExpression { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public XmlQualifiedName Type { get; set; }
    }
}
