using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(Plane))]
    [XmlInclude(typeof(BPMNPlane))]
    [XmlInclude(typeof(Label))]
    [XmlInclude(typeof(BPMNLabel))]
    [XmlInclude(typeof(Shape))]
    [XmlInclude(typeof(LabeledShape))]
    [XmlInclude(typeof(BPMNShape))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/DD/20100524/DI")]
    [XmlRoot(Namespace = "http://www.omg.org/spec/DD/20100524/DI", IsNullable = false)]
    public abstract partial class Node : DiagramElement
    {
    }
}
