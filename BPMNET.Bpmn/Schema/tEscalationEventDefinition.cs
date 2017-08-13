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
    [XmlRoot("escalationEventDefinition", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tEscalationEventDefinition : tEventDefinition
    {

        private XmlQualifiedName escalationRefField;

            [XmlAttribute()]
        public XmlQualifiedName escalationRef
        {
            get
            {
                return escalationRefField;
            }
            set
            {
                escalationRefField = value;
            }
        }
    }

}
