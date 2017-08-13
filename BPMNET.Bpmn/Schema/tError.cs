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
    [XmlRoot("error", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tError : tRootElement
    {

        private string nameField;

        private string errorCodeField;

        private XmlQualifiedName structureRefField;

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
        public string errorCode
        {
            get
            {
                return errorCodeField;
            }
            set
            {
                errorCodeField = value;
            }
        }

            [XmlAttribute()]
        public XmlQualifiedName structureRef
        {
            get
            {
                return structureRefField;
            }
            set
            {
                structureRefField = value;
            }
        }
    }
}
