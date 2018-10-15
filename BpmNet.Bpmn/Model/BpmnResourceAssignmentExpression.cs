using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("resourceAssignmentExpression", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnResourceAssignmentExpression : BpmnBaseElement
    {

        [XmlElement("expression", typeof(BpmnExpression))]
        [XmlElement("formalExpression", typeof(BpmnFormalExpression))]
        public BpmnExpression Item { get; set; }
    }

}
