using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{

    [Serializable()]
    [DebuggerStepThrough()]
    
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("subConversation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnSubConversation : BpmnConversationNode
    {

        private BpmnConversationNode[] itemsField;

            [XmlElement("callConversation", typeof(BpmnCallConversation))]
        [XmlElement("conversation", typeof(BpmnConversation))]
        [XmlElement("conversationNode", typeof(BpmnConversationNode))]
        [XmlElement("subConversation", typeof(BpmnSubConversation))]
        public BpmnConversationNode[] Items
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
