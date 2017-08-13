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
    [XmlRoot("complexBehaviorDefinition", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tComplexBehaviorDefinition : tBaseElement
    {

        private tFormalExpression conditionField;

        private tImplicitThrowEvent eventField;

            public tFormalExpression condition
        {
            get
            {
                return conditionField;
            }
            set
            {
                conditionField = value;
            }
        }

            public tImplicitThrowEvent @event
        {
            get
            {
                return eventField;
            }
            set
            {
                eventField = value;
            }
        }
    }

}
