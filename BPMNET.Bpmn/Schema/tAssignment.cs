using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("assignment", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tAssignment : tBaseElement
    {

        private tExpression fromField;

        private tExpression toField;

        public tExpression from
        {
            get
            {
                return fromField;
            }
            set
            {
                fromField = value;
            }
        }

        public tExpression to
        {
            get
            {
                return toField;
            }
            set
            {
                toField = value;
            }
        }
    }

}
