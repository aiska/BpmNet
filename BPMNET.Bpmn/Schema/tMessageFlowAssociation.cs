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
    [XmlRoot("messageFlowAssociation", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tMessageFlowAssociation : tBaseElement
    {

        private XmlQualifiedName innerMessageFlowRefField;

        private XmlQualifiedName outerMessageFlowRefField;

            [XmlAttribute()]
        public XmlQualifiedName innerMessageFlowRef
        {
            get
            {
                return innerMessageFlowRefField;
            }
            set
            {
                innerMessageFlowRefField = value;
            }
        }

            [XmlAttribute()]
        public XmlQualifiedName outerMessageFlowRef
        {
            get
            {
                return outerMessageFlowRefField;
            }
            set
            {
                outerMessageFlowRefField = value;
            }
        }
    }
}
