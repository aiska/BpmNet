using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{

    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(AnonymousType = true, Namespace = "http://www.omg.org/spec/DD/20100524/DI")]
    public partial class DiagramElementExtension
    {

        [XmlAnyElement()]
        public XmlElement[] Any { get; set; }
    }
}
