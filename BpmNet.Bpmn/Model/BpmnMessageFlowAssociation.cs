using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("messageFlowAssociation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnMessageFlowAssociation : BpmnBaseElement
    {
        [XmlAttribute("innerMessageFlowRef")]
        public XmlQualifiedName InnerMessageFlowRef { get; set; }

        [XmlAttribute("outerMessageFlowRef")]
        public XmlQualifiedName OuterMessageFlowRef { get; set; }
    }
}
