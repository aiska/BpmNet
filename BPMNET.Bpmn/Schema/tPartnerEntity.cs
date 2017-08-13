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
    [XmlRoot("partnerEntity", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tPartnerEntity : tRootElement
    {

        private XmlQualifiedName[] participantRefField;

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
