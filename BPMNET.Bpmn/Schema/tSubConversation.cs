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
    [XmlRoot("subConversation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tSubConversation : tConversationNode
    {

        private tConversationNode[] itemsField;

            [XmlElement("callConversation", typeof(tCallConversation))]
        [XmlElement("conversation", typeof(tConversation))]
        [XmlElement("conversationNode", typeof(tConversationNode))]
        [XmlElement("subConversation", typeof(tSubConversation))]
        public tConversationNode[] Items
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
    }
}
