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
    [XmlRoot("conversationLink", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tConversationLink : tBaseElement
    {

        private string nameField;

        private XmlQualifiedName sourceRefField;

        private XmlQualifiedName targetRefField;

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
        public XmlQualifiedName sourceRef
        {
            get
            {
                return sourceRefField;
            }
            set
            {
                sourceRefField = value;
            }
        }

            [XmlAttribute()]
        public XmlQualifiedName targetRef
        {
            get
            {
                return targetRefField;
            }
            set
            {
                targetRefField = value;
            }
        }
    }
}
