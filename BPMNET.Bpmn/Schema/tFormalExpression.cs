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
    [XmlRoot("formalExpression", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tFormalExpression : tExpression
    {

        private string languageField;

        private XmlQualifiedName evaluatesToTypeRefField;

            [XmlAttribute(DataType = "anyURI")]
        public string language
        {
            get
            {
                return languageField;
            }
            set
            {
                languageField = value;
            }
        }

            [XmlAttribute()]
        public XmlQualifiedName evaluatesToTypeRef
        {
            get
            {
                return evaluatesToTypeRefField;
            }
            set
            {
                evaluatesToTypeRefField = value;
            }
        }
    }

}
