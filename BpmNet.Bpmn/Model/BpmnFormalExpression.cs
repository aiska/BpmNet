using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("formalExpression", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnFormalExpression : BpmnExpression
    {
        [XmlAttribute("language", DataType = "anyURI")]
        public string Language { get; set; }

        [XmlAttribute("evaluatesToTypeRef")]
        public XmlQualifiedName EvaluatesToTypeRef { get; set; }
    }

}
