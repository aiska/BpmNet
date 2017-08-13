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
    [XmlRoot("correlationSubscription", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tCorrelationSubscription : tBaseElement
    {

        private tCorrelationPropertyBinding[] correlationPropertyBindingField;

        private XmlQualifiedName correlationKeyRefField;

            [XmlElement("correlationPropertyBinding")]
        public tCorrelationPropertyBinding[] correlationPropertyBinding
        {
            get
            {
                return correlationPropertyBindingField;
            }
            set
            {
                correlationPropertyBindingField = value;
            }
        }

            [XmlAttribute()]
        public XmlQualifiedName correlationKeyRef
        {
            get
            {
                return correlationKeyRefField;
            }
            set
            {
                correlationKeyRefField = value;
            }
        }
    }
}
