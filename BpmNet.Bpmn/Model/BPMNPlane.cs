using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/DI")]
    [XmlRoot(Namespace = "http://www.omg.org/spec/BPMN/20100524/DI", IsNullable = false)]
    public partial class BpmnPlane : Plane
    {

        [XmlAttribute("bpmnElement")]
        public XmlQualifiedName BpmnElement { get; set; }

        [XmlElement(typeof(BpmnShape))]
        [XmlElement(typeof(BpmnEdge))]
        public DiagramElement[] DiagramElements { get; set; }
    }

}
