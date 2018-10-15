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
    public partial class BPMNEdge : LabeledEdge
    {
        public BPMNLabel BPMNLabel { get; set; }

        [XmlAttribute("bpmnElement")]
        public XmlQualifiedName BpmnElement { get; set; }

        [XmlAttribute("sourceElement")]
        public XmlQualifiedName SourceElement { get; set; }

        [XmlAttribute("targetElement")]
        public XmlQualifiedName TargetElement { get; set; }

        [XmlAttribute("messageVisibleKind")]
        public MessageVisibleKind MessageVisibleKind { get; set; }

        [XmlIgnore()]
        public bool MessageVisibleKindSpecified { get; set; }
    }

}
