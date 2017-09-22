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
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("boundaryEvent", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tBoundaryEvent : tCatchEvent
    {

        private bool cancelActivityField;

        private XmlQualifiedName attachedToRefField;

        public tBoundaryEvent()
        {
            cancelActivityField = true;
        }

        [XmlAttribute()]
        [DefaultValue(true)]
        public bool cancelActivity
        {
            get
            {
                return cancelActivityField;
            }
            set
            {
                cancelActivityField = value;
            }
        }

        [XmlAttribute()]
        public XmlQualifiedName attachedToRef
        {
            get
            {
                return attachedToRefField;
            }
            set
            {
                attachedToRefField = value;
            }
        }
    }
}
