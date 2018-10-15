using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("message", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnMessage : BpmnRootElement
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("itemRef")]
        public XmlQualifiedName ItemRef { get; set; }
    }
}
