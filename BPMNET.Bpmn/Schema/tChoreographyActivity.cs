using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tSubChoreography))]
    [XmlInclude(typeof(tChoreographyTask))]
    [XmlInclude(typeof(tCallChoreography))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("choreographyActivity", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class tChoreographyActivity : tFlowNode
    {

        private XmlQualifiedName[] participantRefField;

        private tCorrelationKey[] correlationKeyField;

        private XmlQualifiedName initiatingParticipantRefField;

        private tChoreographyLoopType loopTypeField;

        public tChoreographyActivity()
        {
            loopTypeField = tChoreographyLoopType.None;
        }

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
        public XmlQualifiedName initiatingParticipantRef
        {
            get
            {
                return initiatingParticipantRefField;
            }
            set
            {
                initiatingParticipantRefField = value;
            }
        }

            [XmlAttribute()]
        [DefaultValue(tChoreographyLoopType.None)]
        public tChoreographyLoopType loopType
        {
            get
            {
                return loopTypeField;
            }
            set
            {
                loopTypeField = value;
            }
        }
    }
}
