using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(LabeledEdge))]
    [XmlInclude(typeof(BPMNEdge))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/DD/20100524/DI")]
    [XmlRoot(Namespace = "http://www.omg.org/spec/DD/20100524/DI", IsNullable = false)]
    public abstract partial class Edge : DiagramElement
    {

        private Point[] waypointField;

            [XmlElement("waypoint")]
        public Point[] waypoint
        {
            get
            {
                return waypointField;
            }
            set
            {
                waypointField = value;
            }
        }
    }
}
