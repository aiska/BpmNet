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
    [XmlRoot("correlationPropertyRetrievalExpression", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tCorrelationPropertyRetrievalExpression : tBaseElement
    {

        private tFormalExpression messagePathField;

        private XmlQualifiedName messageRefField;

            public tFormalExpression messagePath
        {
            get
            {
                return messagePathField;
            }
            set
            {
                messagePathField = value;
            }
        }

            [XmlAttribute()]
        public XmlQualifiedName messageRef
        {
            get
            {
                return messageRefField;
            }
            set
            {
                messageRefField = value;
            }
        }
    }
}
