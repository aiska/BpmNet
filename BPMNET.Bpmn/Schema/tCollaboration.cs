using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tGlobalConversation))]
    [XmlInclude(typeof(tChoreography))]
    [XmlInclude(typeof(tGlobalChoreographyTask))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("collaboration", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tCollaboration : tRootElement
    {

        private tParticipant[] participantField;

        private tMessageFlow[] messageFlowField;

        private tArtifact[] itemsField;

        private tConversationNode[] items1Field;

        private tConversationAssociation[] conversationAssociationField;

        private tParticipantAssociation[] participantAssociationField;

        private tMessageFlowAssociation[] messageFlowAssociationField;

        private tCorrelationKey[] correlationKeyField;

        private XmlQualifiedName[] choreographyRefField;

        private tConversationLink[] conversationLinkField;

        private string nameField;

        private bool isClosedField;

        public tCollaboration()
        {
            isClosedField = false;
        }

            [XmlElement("participant")]
        public tParticipant[] participant
        {
            get
            {
                return participantField;
            }
            set
            {
                participantField = value;
            }
        }

            [XmlElement("messageFlow")]
        public tMessageFlow[] messageFlow
        {
            get
            {
                return messageFlowField;
            }
            set
            {
                messageFlowField = value;
            }
        }

            [XmlElement("artifact", typeof(tArtifact))]
        [XmlElement("association", typeof(tAssociation))]
        [XmlElement("group", typeof(tGroup))]
        [XmlElement("textAnnotation", typeof(tTextAnnotation))]
        public tArtifact[] Items
        {
            get
            {
                return itemsField;
            }
            set
            {
                itemsField = value;
            }
        }

            [XmlElement("callConversation", typeof(tCallConversation))]
        [XmlElement("conversation", typeof(tConversation))]
        [XmlElement("conversationNode", typeof(tConversationNode))]
        [XmlElement("subConversation", typeof(tSubConversation))]
        public tConversationNode[] Items1
        {
            get
            {
                return items1Field;
            }
            set
            {
                items1Field = value;
            }
        }

            [XmlElement("conversationAssociation")]
        public tConversationAssociation[] conversationAssociation
        {
            get
            {
                return conversationAssociationField;
            }
            set
            {
                conversationAssociationField = value;
            }
        }

            [XmlElement("participantAssociation")]
        public tParticipantAssociation[] participantAssociation
        {
            get
            {
                return participantAssociationField;
            }
            set
            {
                participantAssociationField = value;
            }
        }

            [XmlElement("messageFlowAssociation")]
        public tMessageFlowAssociation[] messageFlowAssociation
        {
            get
            {
                return messageFlowAssociationField;
            }
            set
            {
                messageFlowAssociationField = value;
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

            [XmlElement("choreographyRef")]
        public XmlQualifiedName[] choreographyRef
        {
            get
            {
                return choreographyRefField;
            }
            set
            {
                choreographyRefField = value;
            }
        }

            [XmlElement("conversationLink")]
        public tConversationLink[] conversationLink
        {
            get
            {
                return conversationLinkField;
            }
            set
            {
                conversationLinkField = value;
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
        [DefaultValue(false)]
        public bool isClosed
        {
            get
            {
                return isClosedField;
            }
            set
            {
                isClosedField = value;
            }
        }
    }
}
