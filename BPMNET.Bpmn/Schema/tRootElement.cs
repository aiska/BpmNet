using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tSignal))]
    [XmlInclude(typeof(tResource))]
    [XmlInclude(typeof(tPartnerRole))]
    [XmlInclude(typeof(tPartnerEntity))]
    [XmlInclude(typeof(tMessage))]
    [XmlInclude(typeof(tItemDefinition))]
    [XmlInclude(typeof(tInterface))]
    [XmlInclude(typeof(tEscalation))]
    [XmlInclude(typeof(tError))]
    [XmlInclude(typeof(tEndPoint))]
    [XmlInclude(typeof(tDataStore))]
    [XmlInclude(typeof(tCorrelationProperty))]
    [XmlInclude(typeof(tCollaboration))]
    [XmlInclude(typeof(tGlobalConversation))]
    [XmlInclude(typeof(tChoreography))]
    [XmlInclude(typeof(tGlobalChoreographyTask))]
    [XmlInclude(typeof(tCategory))]
    [XmlInclude(typeof(tEventDefinition))]
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
    [XmlInclude(typeof(tCallableElement))]
    [XmlInclude(typeof(tProcess))]
    [XmlInclude(typeof(tGlobalTask))]
    [XmlInclude(typeof(tGlobalUserTask))]
    [XmlInclude(typeof(tGlobalScriptTask))]
    [XmlInclude(typeof(tGlobalManualTask))]
    [XmlInclude(typeof(tGlobalBusinessRuleTask))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("rootElement", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class tRootElement : tBaseElement
    {
    }

}
