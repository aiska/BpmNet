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
    [XmlRoot("interface", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tInterface : tRootElement
    {

        private tOperation[] operationField;

        private string nameField;

        private XmlQualifiedName implementationRefField;

            [XmlElement("operation")]
        public tOperation[] operation
        {
            get
            {
                return operationField;
            }
            set
            {
                operationField = value;
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
