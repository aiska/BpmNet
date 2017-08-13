using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/DI")]
    [XmlRoot(Namespace = "http://www.omg.org/spec/BPMN/20100524/DI", IsNullable = false)]
    public partial class BPMNShape : LabeledShape
    {

        private BPMNLabel bPMNLabelField;

        private XmlQualifiedName bpmnElementField;

        private bool isHorizontalField;

        private bool isHorizontalFieldSpecified;

        private bool isExpandedField;

        private bool isExpandedFieldSpecified;

        private bool isMarkerVisibleField;

        private bool isMarkerVisibleFieldSpecified;

        private bool isMessageVisibleField;

        private bool isMessageVisibleFieldSpecified;

        private ParticipantBandKind participantBandKindField;

        private bool participantBandKindFieldSpecified;

        private XmlQualifiedName choreographyActivityShapeField;

            public BPMNLabel BPMNLabel
        {
            get
            {
                return bPMNLabelField;
            }
            set
            {
                bPMNLabelField = value;
            }
        }

            [XmlAttribute()]
        public XmlQualifiedName bpmnElement
        {
            get
            {
                return bpmnElementField;
            }
            set
            {
                bpmnElementField = value;
            }
        }

            [XmlAttribute()]
        public bool isHorizontal
        {
            get
            {
                return isHorizontalField;
            }
            set
            {
                isHorizontalField = value;
            }
        }

            [XmlIgnore()]
        public bool isHorizontalSpecified
        {
            get
            {
                return isHorizontalFieldSpecified;
            }
            set
            {
                isHorizontalFieldSpecified = value;
            }
        }

            [XmlAttribute()]
        public bool isExpanded
        {
            get
            {
                return isExpandedField;
            }
            set
            {
                isExpandedField = value;
            }
        }

            [XmlIgnore()]
        public bool isExpandedSpecified
        {
            get
            {
                return isExpandedFieldSpecified;
            }
            set
            {
                isExpandedFieldSpecified = value;
            }
        }

            [XmlAttribute()]
        public bool isMarkerVisible
        {
            get
            {
                return isMarkerVisibleField;
            }
            set
            {
                isMarkerVisibleField = value;
            }
        }

            [XmlIgnore()]
        public bool isMarkerVisibleSpecified
        {
            get
            {
                return isMarkerVisibleFieldSpecified;
            }
            set
            {
                isMarkerVisibleFieldSpecified = value;
            }
        }

            [XmlAttribute()]
        public bool isMessageVisible
        {
            get
            {
                return isMessageVisibleField;
            }
            set
            {
                isMessageVisibleField = value;
            }
        }

            [XmlIgnore()]
        public bool isMessageVisibleSpecified
        {
            get
            {
                return isMessageVisibleFieldSpecified;
            }
            set
            {
                isMessageVisibleFieldSpecified = value;
            }
        }

            [XmlAttribute()]
        public ParticipantBandKind participantBandKind
        {
            get
            {
                return participantBandKindField;
            }
            set
            {
                participantBandKindField = value;
            }
        }

            [XmlIgnore()]
        public bool participantBandKindSpecified
        {
            get
            {
                return participantBandKindFieldSpecified;
            }
            set
            {
                participantBandKindFieldSpecified = value;
            }
        }

            [XmlAttribute()]
        public XmlQualifiedName choreographyActivityShape
        {
            get
            {
                return choreographyActivityShapeField;
            }
            set
            {
                choreographyActivityShapeField = value;
            }
        }
    }

}
