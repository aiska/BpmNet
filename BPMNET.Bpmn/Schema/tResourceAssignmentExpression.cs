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
    [XmlRoot("resourceAssignmentExpression", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tResourceAssignmentExpression : tBaseElement
    {

        private tExpression itemField;

            [XmlElement("expression", typeof(tExpression))]
        [XmlElement("formalExpression", typeof(tFormalExpression))]
        public tExpression Item
        {
            get
            {
                return itemField;
            }
            set
            {
                itemField = value;
            }
        }
    }

}
