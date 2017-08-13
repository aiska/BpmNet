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
    [XmlRoot("compensateEventDefinition", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tCompensateEventDefinition : tEventDefinition
    {

        private bool waitForCompletionField;

        private bool waitForCompletionFieldSpecified;

        private XmlQualifiedName activityRefField;

            [XmlAttribute()]
        public bool waitForCompletion
        {
            get
            {
                return waitForCompletionField;
            }
            set
            {
                waitForCompletionField = value;
            }
        }

            [XmlIgnore()]
        public bool waitForCompletionSpecified
        {
            get
            {
                return waitForCompletionFieldSpecified;
            }
            set
            {
                waitForCompletionFieldSpecified = value;
            }
        }

            [XmlAttribute()]
        public XmlQualifiedName activityRef
        {
            get
            {
                return activityRefField;
            }
            set
            {
                activityRefField = value;
            }
        }
    }

}
