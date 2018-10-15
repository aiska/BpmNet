using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnGateway))]
    [XmlInclude(typeof(BpmnParallelGateway))]
    [XmlInclude(typeof(BpmnInclusiveGateway))]
    [XmlInclude(typeof(BpmnExclusiveGateway))]
    [XmlInclude(typeof(BpmnEventBasedGateway))]
    [XmlInclude(typeof(BpmnComplexGateway))]
    [XmlInclude(typeof(BpmnChoreographyActivity))]
    [XmlInclude(typeof(BpmnSubChoreography))]
    [XmlInclude(typeof(BpmnChoreographyTask))]
    [XmlInclude(typeof(BpmnCallChoreography))]
    [XmlInclude(typeof(BpmnEvent))]
    [XmlInclude(typeof(BpmnThrowEvent))]
    [XmlInclude(typeof(BpmnIntermediateThrowEvent))]
    [XmlInclude(typeof(BpmnImplicitThrowEvent))]
    [XmlInclude(typeof(BpmnEndEvent))]
    [XmlInclude(typeof(BpmnCatchEvent))]
    [XmlInclude(typeof(BpmnStartEvent))]
    [XmlInclude(typeof(BpmnIntermediateCatchEvent))]
    [XmlInclude(typeof(BpmnBoundaryEvent))]
    [XmlInclude(typeof(BpmnActivity))]
    [XmlInclude(typeof(BpmnTask))]
    [XmlInclude(typeof(BpmnUserTask))]
    [XmlInclude(typeof(BpmnServiceTask))]
    [XmlInclude(typeof(BpmnSendTask))]
    [XmlInclude(typeof(BpmnScriptTask))]
    [XmlInclude(typeof(BpmnReceiveTask))]
    [XmlInclude(typeof(BpmnManualTask))]
    [XmlInclude(typeof(BpmnBusinessRuleTask))]
    [XmlInclude(typeof(BpmnSubProcess))]
    [XmlInclude(typeof(BpmnTransaction))]
    [XmlInclude(typeof(BpmnAdHocSubProcess))]
    [XmlInclude(typeof(BpmnCallActivity))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("flowNode", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class BpmnFlowNode : BpmnFlowElement
    {
        [XmlElement("incoming")]
        public XmlQualifiedName[] Incoming { get; set; }

        [XmlElement("outgoing")]
        public XmlQualifiedName[] Outgoing { get; set; }
    }

}
