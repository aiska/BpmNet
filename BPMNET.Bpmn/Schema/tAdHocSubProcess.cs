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
    [XmlRoot("adHocSubProcess", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tAdHocSubProcess : tSubProcess
    {

        private tExpression completionConditionField;

        private bool cancelRemainingInstancesField;

        private tAdHocOrdering orderingField;

        private bool orderingFieldSpecified;

        public tAdHocSubProcess()
        {
            cancelRemainingInstancesField = true;
        }

        public tExpression completionCondition
        {
            get
            {
                return completionConditionField;
            }
            set
            {
                completionConditionField = value;
            }
        }

        [XmlAttribute()]
        [DefaultValue(true)]
        public bool cancelRemainingInstances
        {
            get
            {
                return cancelRemainingInstancesField;
            }
            set
            {
                cancelRemainingInstancesField = value;
            }
        }

        [XmlAttribute()]
        public tAdHocOrdering ordering
        {
            get
            {
                return orderingField;
            }
            set
            {
                orderingField = value;
            }
        }

        [XmlIgnore()]
        public bool orderingSpecified
        {
            get
            {
                return orderingFieldSpecified;
            }
            set
            {
                orderingFieldSpecified = value;
            }
        }
    }

}
