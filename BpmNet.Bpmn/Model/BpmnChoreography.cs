using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnGlobalChoreographyTask))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("choreography", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnChoreography : BpmnCollaboration
    {

        [XmlElement("adHocSubProcess", typeof(BpmnAdHocSubProcess))]
        [XmlElement("boundaryEvent", typeof(BpmnBoundaryEvent))]
        [XmlElement("businessRuleTask", typeof(BpmnBusinessRuleTask))]
        [XmlElement("callActivity", typeof(BpmnCallActivity))]
        [XmlElement("callChoreography", typeof(BpmnCallChoreography))]
        [XmlElement("choreographyTask", typeof(BpmnChoreographyTask))]
        [XmlElement("complexGateway", typeof(BpmnComplexGateway))]
        [XmlElement("dataObject", typeof(BpmnDataObject))]
        [XmlElement("dataObjectReference", typeof(BpmnDataObjectReference))]
        [XmlElement("dataStoreReference", typeof(BpmnDataStoreReference))]
        [XmlElement("endEvent", typeof(BpmnEndEvent))]
        [XmlElement("event", typeof(BpmnEvent))]
        [XmlElement("eventBasedGateway", typeof(BpmnEventBasedGateway))]
        [XmlElement("exclusiveGateway", typeof(BpmnExclusiveGateway))]
        [XmlElement("flowElement", typeof(BpmnFlowElement))]
        [XmlElement("implicitThrowEvent", typeof(BpmnImplicitThrowEvent))]
        [XmlElement("inclusiveGateway", typeof(BpmnInclusiveGateway))]
        [XmlElement("intermediateCatchEvent", typeof(BpmnIntermediateCatchEvent))]
        [XmlElement("intermediateThrowEvent", typeof(BpmnIntermediateThrowEvent))]
        [XmlElement("manualTask", typeof(BpmnManualTask))]
        [XmlElement("parallelGateway", typeof(BpmnParallelGateway))]
        [XmlElement("receiveTask", typeof(BpmnReceiveTask))]
        [XmlElement("scriptTask", typeof(BpmnScriptTask))]
        [XmlElement("sendTask", typeof(BpmnSendTask))]
        [XmlElement("sequenceFlow", typeof(BpmnSequenceFlow))]
        [XmlElement("serviceTask", typeof(BpmnServiceTask))]
        [XmlElement("startEvent", typeof(BpmnStartEvent))]
        [XmlElement("subChoreography", typeof(BpmnSubChoreography))]
        [XmlElement("subProcess", typeof(BpmnSubProcess))]
        [XmlElement("task", typeof(BpmnTask))]
        [XmlElement("transaction", typeof(BpmnTransaction))]
        [XmlElement("userTask", typeof(BpmnUserTask))]
        public BpmnFlowElement[] Items2 { get; set; }
    }
}
