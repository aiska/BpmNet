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
    [XmlRoot("correlationKey", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tCorrelationKey : tBaseElement
    {

        private XmlQualifiedName[] correlationPropertyRefField;

        private string nameField;

            [XmlElement("correlationPropertyRef")]
        public XmlQualifiedName[] correlationPropertyRef
        {
            get
            {
                return correlationPropertyRefField;
            }
            set
            {
                correlationPropertyRefField = value;
            }
        }

            [XmlAttribute()]
        public string name
        {
            get
            {
                return nameField;
            }
            set
            {
                nameField = value;
            }
        }
    }
}
