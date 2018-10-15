using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{

    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/DD/20100524/DC")]
    [XmlRoot(Namespace = "http://www.omg.org/spec/DD/20100524/DC", IsNullable = false)]
    public partial class Bounds
    {

        [XmlAttribute("x")]
        public double X { get; set; }

        [XmlAttribute("y")]
        public double Y { get; set; }

        [XmlAttribute("width")]
        public double Width { get; set; }

        [XmlAttribute("height")]
        public double Height { get; set; }
    }
}
