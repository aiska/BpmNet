using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("resourceParameterBinding", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnResourceParameterBinding : BpmnBaseElement
    {
        [XmlElement("expression", typeof(BpmnExpression))]
        [XmlElement("formalExpression", typeof(BpmnFormalExpression))]
        public BpmnExpression Item { get; set; }

        [XmlAttribute("parameterRef")]
        public XmlQualifiedName ParameterRef { get; set; }
    }

}
