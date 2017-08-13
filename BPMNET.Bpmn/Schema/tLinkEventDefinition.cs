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
    [XmlRoot("linkEventDefinition", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tLinkEventDefinition : tEventDefinition
    {

        private XmlQualifiedName[] sourceField;

        private XmlQualifiedName targetField;

        private string nameField;

            [XmlElement("source")]
        public XmlQualifiedName[] source
        {
            get
            {
                return sourceField;
            }
            set
            {
                sourceField = value;
            }
        }

            public XmlQualifiedName target
        {
            get
            {
                return targetField;
            }
            set
            {
                targetField = value;
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
