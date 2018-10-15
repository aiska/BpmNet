using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnThrowEvent))]
    [XmlInclude(typeof(BpmnIntermediateThrowEvent))]
    [XmlInclude(typeof(BpmnImplicitThrowEvent))]
    [XmlInclude(typeof(BpmnEndEvent))]
    [XmlInclude(typeof(BpmnCatchEvent))]
    [XmlInclude(typeof(BpmnStartEvent))]
    [XmlInclude(typeof(BpmnIntermediateCatchEvent))]
    [XmlInclude(typeof(BpmnBoundaryEvent))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("event", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class BpmnEvent : BpmnFlowNode
    {

        [XmlElement("property")]
        public BpmnProperty[] Property { get; set; }
    }

}
