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
    [XmlRoot("participant", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tParticipant : tBaseElement
    {

        private XmlQualifiedName[] interfaceRefField;

        private XmlQualifiedName[] endPointRefField;

        private tParticipantMultiplicity participantMultiplicityField;

        private string nameField;

        private XmlQualifiedName processRefField;

            [XmlElement("interfaceRef")]
        public XmlQualifiedName[] interfaceRef
        {
            get
            {
                return interfaceRefField;
            }
            set
            {
                interfaceRefField = value;
            }
        }

            [XmlElement("endPointRef")]
        public XmlQualifiedName[] endPointRef
        {
            get
            {
                return endPointRefField;
            }
            set
            {
                endPointRefField = value;
            }
        }

            public tParticipantMultiplicity participantMultiplicity
        {
            get
            {
                return participantMultiplicityField;
            }
            set
            {
                participantMultiplicityField = value;
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
        public XmlQualifiedName processRef
        {
            get
            {
                return processRefField;
            }
            set
            {
                processRefField = value;
            }
        }
    }
}
