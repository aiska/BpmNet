using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{

    [Serializable()]
    [DebuggerStepThrough()]
    
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("timerEventDefinition", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnTimerEventDefinition : BpmnEventDefinition
    {

        private BpmnExpression itemField;

        private ItemChoiceType itemElementNameField;

        [XmlElement("timeCycle", typeof(BpmnExpression))]
        [XmlElement("timeDate", typeof(BpmnExpression))]
        [XmlElement("timeDuration", typeof(BpmnExpression))]
        [XmlChoiceIdentifier("ItemElementName")]
        public BpmnExpression Item
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

        [XmlIgnore()]
        public ItemChoiceType ItemElementName
        {
            get
            {
                return itemElementNameField;
            }
            set
            {
                itemElementNameField = value;
            }
        }
    }

}
