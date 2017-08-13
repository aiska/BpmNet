using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tTimerEventDefinition))]
    [XmlInclude(typeof(tTerminateEventDefinition))]
    [XmlInclude(typeof(tSignalEventDefinition))]
    [XmlInclude(typeof(tMessageEventDefinition))]
    [XmlInclude(typeof(tLinkEventDefinition))]
    [XmlInclude(typeof(tEscalationEventDefinition))]
    [XmlInclude(typeof(tErrorEventDefinition))]
    [XmlInclude(typeof(tConditionalEventDefinition))]
    [XmlInclude(typeof(tCompensateEventDefinition))]
    [XmlInclude(typeof(tCancelEventDefinition))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("eventDefinition", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class tEventDefinition : tRootElement
    {
    }

}
