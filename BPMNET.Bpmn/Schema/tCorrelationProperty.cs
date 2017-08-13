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
    [XmlRoot("correlationProperty", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tCorrelationProperty : tRootElement
    {

        private tCorrelationPropertyRetrievalExpression[] correlationPropertyRetrievalExpressionField;

        private string nameField;

        private XmlQualifiedName typeField;

            [XmlElement("correlationPropertyRetrievalExpression")]
        public tCorrelationPropertyRetrievalExpression[] correlationPropertyRetrievalExpression
        {
            get
            {
                return correlationPropertyRetrievalExpressionField;
            }
            set
            {
                correlationPropertyRetrievalExpressionField = value;
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
    }
}
