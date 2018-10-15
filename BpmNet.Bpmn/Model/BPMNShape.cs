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
    public partial class BPMNShape : LabeledShape
    {
        public BPMNLabel BPMNLabel { get; set; }

        [XmlAttribute("bpmnElement")]
        public XmlQualifiedName BpmnElement { get; set; }

        [XmlAttribute("isHorizontal")]
        public bool IsHorizontal { get; set; }

        [XmlIgnore()]
        public bool IsHorizontalSpecified { get; set; }

        [XmlAttribute("isExpanded")]
        public bool IsExpanded { get; set; }

        [XmlIgnore()]
        public bool IsExpandedSpecified { get; set; }

        [XmlAttribute("isMarkerVisible")]
        public bool IsMarkerVisible { get; set; }

        [XmlIgnore()]
        public bool IsMarkerVisibleSpecified { get; set; }

        [XmlAttribute("isMessageVisible")]
        public bool IsMessageVisible { get; set; }

        [XmlIgnore()]
        public bool IsMessageVisibleSpecified { get; set; }

        [XmlAttribute("participantBandKind")]
        public ParticipantBandKind ParticipantBandKind { get; set; }

        [XmlIgnore()]
        public bool ParticipantBandKindSpecified { get; set; }

        [XmlAttribute("choreographyActivityShape")]
        public XmlQualifiedName ChoreographyActivityShape { get; set; }
    }

}
