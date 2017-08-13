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
    [XmlRoot("callChoreography", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tCallChoreography : tChoreographyActivity
    {

        private tParticipantAssociation[] participantAssociationField;

        private XmlQualifiedName calledChoreographyRefField;

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

            [XmlAttribute()]
        public XmlQualifiedName calledChoreographyRef
        {
            get
            {
                return calledChoreographyRefField;
            }
            set
            {
                calledChoreographyRefField = value;
            }
        }
    }
}
