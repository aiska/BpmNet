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
    [XmlRoot("resourceParameter", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tResourceParameter : tBaseElement
    {

        private string nameField;

        private XmlQualifiedName typeField;

        private bool isRequiredField;

        private bool isRequiredFieldSpecified;

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

            [XmlAttribute()]
        public XmlQualifiedName type
        {
            get
            {
                return typeField;
            }
            set
            {
                typeField = value;
            }
        }

            [XmlAttribute()]
        public bool isRequired
        {
            get
            {
                return isRequiredField;
            }
            set
            {
                isRequiredField = value;
            }
        }

            [XmlIgnore()]
        public bool isRequiredSpecified
        {
            get
            {
                return isRequiredFieldSpecified;
            }
            set
            {
                isRequiredFieldSpecified = value;
            }
        }
    }
}
