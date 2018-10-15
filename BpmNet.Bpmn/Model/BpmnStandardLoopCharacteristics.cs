using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{

    [Serializable()]
    [DebuggerStepThrough()]
    
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("standardLoopCharacteristics", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnStandardLoopCharacteristics : BpmnLoopCharacteristics
    {

        private BpmnExpression loopConditionField;

        private bool testBeforeField;

        private string loopMaximumField;

        public BpmnStandardLoopCharacteristics()
        {
            testBeforeField = false;
        }

            public BpmnExpression loopCondition
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
