using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tStartEvent))]
    [XmlInclude(typeof(tIntermediateCatchEvent))]
    [XmlInclude(typeof(tBoundaryEvent))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("catchEvent", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class tCatchEvent : tEvent
    {

        private tDataOutput[] dataOutputField;

        private tDataOutputAssociation[] dataOutputAssociationField;

        private tOutputSet outputSetField;

        private tEventDefinition[] itemsField;

        private XmlQualifiedName[] eventDefinitionRefField;

        private bool parallelMultipleField;

        public tCatchEvent()
        {
            parallelMultipleField = false;
        }

            [XmlElement("dataOutput")]
        public tDataOutput[] dataOutput
        {
            get
            {
                return dataOutputField;
            }
            set
            {
                dataOutputField = value;
            }
        }

            [XmlElement("dataOutputAssociation")]
        public tDataOutputAssociation[] dataOutputAssociation
        {
            get
            {
                return dataOutputAssociationField;
            }
            set
            {
                dataOutputAssociationField = value;
            }
        }

            public tOutputSet outputSet
        {
            get
            {
                return outputSetField;
            }
            set
            {
                outputSetField = value;
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

            [XmlAttribute()]
        [DefaultValue(false)]
        public bool parallelMultiple
        {
            get
            {
                return parallelMultipleField;
            }
            set
            {
                parallelMultipleField = value;
            }
        }
    }
}
