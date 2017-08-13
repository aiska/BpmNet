using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tSubConversation))]
    [XmlInclude(typeof(tConversation))]
    [XmlInclude(typeof(tCallConversation))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("conversationNode", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class tConversationNode : tBaseElement
    {

        private XmlQualifiedName[] participantRefField;

        private XmlQualifiedName[] messageFlowRefField;

        private tCorrelationKey[] correlationKeyField;

        private string nameField;

            [XmlElement("participantRef")]
        public XmlQualifiedName[] participantRef
        {
            get
            {
                return participantRefField;
            }
            set
            {
                participantRefField = value;
            }
        }

            [XmlElement("messageFlowRef")]
        public XmlQualifiedName[] messageFlowRef
        {
            get
            {
                return messageFlowRefField;
            }
            set
            {
                messageFlowRefField = value;
            }
        }

            [XmlElement("correlationKey")]
        public tCorrelationKey[] correlationKey
        {
            get
            {
                return correlationKeyField;
            }
            set
            {
                correlationKeyField = value;
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
