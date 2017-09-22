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
    [XmlRoot("timerEventDefinition", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tTimerEventDefinition : tEventDefinition
    {

        private tExpression itemField;

        private ItemChoiceType itemElementNameField;

        [XmlElement("timeCycle", typeof(tExpression))]
        [XmlElement("timeDate", typeof(tExpression))]
        [XmlElement("timeDuration", typeof(tExpression))]
        [XmlChoiceIdentifier("ItemElementName")]
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
