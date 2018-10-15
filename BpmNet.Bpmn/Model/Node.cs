using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(Plane))]
    [XmlInclude(typeof(BPMNPlane))]
    [XmlInclude(typeof(Label))]
    [XmlInclude(typeof(BPMNLabel))]
    [XmlInclude(typeof(Shape))]
    [XmlInclude(typeof(LabeledShape))]
    [XmlInclude(typeof(BPMNShape))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/DD/20100524/DI")]
    [XmlRoot(Namespace = "http://www.omg.org/spec/DD/20100524/DI", IsNullable = false)]
    public abstract partial class Node : DiagramElement
    {
    }
}
