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
    [XmlRoot("standardLoopCharacteristics", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tStandardLoopCharacteristics : tLoopCharacteristics
    {

        private tExpression loopConditionField;

        private bool testBeforeField;

        private string loopMaximumField;

        public tStandardLoopCharacteristics()
        {
            testBeforeField = false;
        }

            public tExpression loopCondition
        {
            get
            {
                return loopConditionField;
            }
            set
            {
                loopConditionField = value;
            }
        }

            [XmlAttribute()]
        [DefaultValue(false)]
        public bool testBefore
        {
            get
            {
                return testBeforeField;
            }
            set
            {
                testBeforeField = value;
            }
        }

            [XmlAttribute(DataType = "integer")]
        public string loopMaximum
        {
            get
            {
                return loopMaximumField;
            }
            set
            {
                loopMaximumField = value;
            }
        }
    }
}
