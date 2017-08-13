using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tIntermediateThrowEvent))]
    [XmlInclude(typeof(tImplicitThrowEvent))]
    [XmlInclude(typeof(tEndEvent))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("throwEvent", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class tThrowEvent : tEvent
    {

        private tDataInput[] dataInputField;

        private tDataInputAssociation[] dataInputAssociationField;

        private tInputSet inputSetField;

        private tEventDefinition[] itemsField;

        private XmlQualifiedName[] eventDefinitionRefField;

        [XmlElement("dataInput")]
        public tDataInput[] dataInput
        {
            get
            {
                return dataInputField;
            }
            set
            {
                dataInputField = value;
            }
        }

        [XmlElement("dataInputAssociation")]
        public tDataInputAssociation[] dataInputAssociation
        {
            get
            {
                return dataInputAssociationField;
            }
            set
            {
                dataInputAssociationField = value;
            }
        }

        public tInputSet inputSet
        {
            get
            {
                return inputSetField;
            }
            set
            {
                inputSetField = value;
            }
        }

        [XmlElement("cancelEventDefinition", typeof(tCancelEventDefinition))]
        [XmlElement("compensateEventDefinition", typeof(tCompensateEventDefinition))]
        [XmlElement("conditionalEventDefinition", typeof(tConditionalEventDefinition))]
        [XmlElement("errorEventDefinition", typeof(tErrorEventDefinition))]
        [XmlElement("escalationEventDefinition", typeof(tEscalationEventDefinition))]
        [XmlElement("eventDefinition", typeof(tEventDefinition))]
        [XmlElement("linkEventDefinition", typeof(tLinkEventDefinition))]
        [XmlElement("messageEventDefinition", typeof(tMessageEventDefinition))]
        [XmlElement("signalEventDefinition", typeof(tSignalEventDefinition))]
        [XmlElement("terminateEventDefinition", typeof(tTerminateEventDefinition))]
        [XmlElement("timerEventDefinition", typeof(tTimerEventDefinition))]
        public tEventDefinition[] Items
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

        [XmlElement("eventDefinitionRef")]
        public XmlQualifiedName[] eventDefinitionRef
        {
            get
            {
                return eventDefinitionRefField;
            }
            set
            {
                eventDefinitionRefField = value;
            }
        }
    }

}
