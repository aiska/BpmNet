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
    [XmlRoot("operation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tOperation : tBaseElement
    {

        private XmlQualifiedName inMessageRefField;

        private XmlQualifiedName outMessageRefField;

        private XmlQualifiedName[] errorRefField;

        private string nameField;

        private XmlQualifiedName implementationRefField;

            public XmlQualifiedName inMessageRef
        {
            get
            {
                return inMessageRefField;
            }
            set
            {
                inMessageRefField = value;
            }
        }

            public XmlQualifiedName outMessageRef
        {
            get
            {
                return outMessageRefField;
            }
            set
            {
                outMessageRefField = value;
            }
        }

            [XmlElement("errorRef")]
        public XmlQualifiedName[] errorRef
        {
            get
            {
                return errorRefField;
            }
            set
            {
                errorRefField = value;
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

            [XmlAttribute()]
        public XmlQualifiedName implementationRef
        {
            get
            {
                return implementationRefField;
            }
            set
            {
                implementationRefField = value;
            }
        }
    }
}
