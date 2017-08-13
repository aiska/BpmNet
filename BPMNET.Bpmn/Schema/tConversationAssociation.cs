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
    [XmlRoot("conversationAssociation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tConversationAssociation : tBaseElement
    {

        private XmlQualifiedName innerConversationNodeRefField;

        private XmlQualifiedName outerConversationNodeRefField;

            [XmlAttribute()]
        public XmlQualifiedName innerConversationNodeRef
        {
            get
            {
                return innerConversationNodeRefField;
            }
            set
            {
                innerConversationNodeRefField = value;
            }
        }

            [XmlAttribute()]
        public XmlQualifiedName outerConversationNodeRef
        {
            get
            {
                return outerConversationNodeRefField;
            }
            set
            {
                outerConversationNodeRefField = value;
            }
        }
    }
}
