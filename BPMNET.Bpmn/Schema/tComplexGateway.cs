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
    [XmlRoot("complexGateway", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tComplexGateway : tGateway
    {

        private tExpression activationConditionField;

        private string defaultField;

            public tExpression activationCondition
        {
            get
            {
                return activationConditionField;
            }
            set
            {
                activationConditionField = value;
            }
        }

            [XmlAttribute(DataType = "IDREF")]
        public string @default
        {
            get
            {
                return defaultField;
            }
            set
            {
                defaultField = value;
            }
        }
    }
}
