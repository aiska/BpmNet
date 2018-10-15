using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(LabeledEdge))]
    [XmlInclude(typeof(BPMNEdge))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/DD/20100524/DI")]
    [XmlRoot(Namespace = "http://www.omg.org/spec/DD/20100524/DI", IsNullable = false)]
    public abstract partial class Edge : DiagramElement
    {

        [XmlElement("waypoint")]
        public Point[] Waypoint { get; set; }
    }
}
