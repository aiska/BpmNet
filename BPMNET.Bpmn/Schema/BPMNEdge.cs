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
    public partial class BPMNEdge : LabeledEdge
    {

        private BPMNLabel bPMNLabelField;

        private XmlQualifiedName bpmnElementField;

        private XmlQualifiedName sourceElementField;

        private XmlQualifiedName targetElementField;

        private MessageVisibleKind messageVisibleKindField;

        private bool messageVisibleKindFieldSpecified;

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
        public XmlQualifiedName sourceElement
        {
            get
            {
                return sourceElementField;
            }
            set
            {
                sourceElementField = value;
            }
        }

            [XmlAttribute()]
        public XmlQualifiedName targetElement
        {
            get
            {
                return targetElementField;
            }
            set
            {
                targetElementField = value;
            }
        }

            [XmlAttribute()]
        public MessageVisibleKind messageVisibleKind
        {
            get
            {
                return messageVisibleKindField;
            }
            set
            {
                messageVisibleKindField = value;
            }
        }

            [XmlIgnore()]
        public bool messageVisibleKindSpecified
        {
            get
            {
                return messageVisibleKindFieldSpecified;
            }
            set
            {
                messageVisibleKindFieldSpecified = value;
            }
        }
    }

}
