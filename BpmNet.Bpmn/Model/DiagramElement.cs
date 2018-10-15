using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(Edge))]
    [XmlInclude(typeof(LabeledEdge))]
    [XmlInclude(typeof(BPMNEdge))]
    [XmlInclude(typeof(Node))]
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
    public abstract partial class DiagramElement
    {
        public DiagramElementExtension extension { get; set; }

        [XmlAttribute("id", DataType = "ID")]
        public string Id { get; set; }

        [XmlAnyAttribute()]
        public XmlAttribute[] AnyAttr { get; set; }
    }

}
