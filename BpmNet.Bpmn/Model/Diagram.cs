using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnDiagram))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/DD/20100524/DI")]
    [XmlRoot(Namespace = "http://www.omg.org/spec/DD/20100524/DI", IsNullable = false)]
    public abstract partial class Diagram
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("documentation")]
        public string Documentation { get; set; }

        [XmlAttribute("resolution")]
        public double Resolution { get; set; }

        [XmlIgnore()]
        public bool ResolutionSpecified { get; set; }

        [XmlAttribute("id", DataType = "ID")]
        public string Id { get; set; }
    }
}
