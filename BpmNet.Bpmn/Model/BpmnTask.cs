using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnUserTask))]
    [XmlInclude(typeof(BpmnServiceTask))]
    [XmlInclude(typeof(BpmnSendTask))]
    [XmlInclude(typeof(BpmnScriptTask))]
    [XmlInclude(typeof(BpmnReceiveTask))]
    [XmlInclude(typeof(BpmnManualTask))]
    [XmlInclude(typeof(BpmnBusinessRuleTask))]
    
    [Serializable()]
    [DebuggerStepThrough()]
    
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("task", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnTask : BpmnActivity
    {
    }
}
