using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("process", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnProcess : BpmnCallableElement
    {
        public BpmnProcess()
        {
            ProcessType = BpmnProcessType.None;
            IsClosed = false;
        }

        [XmlElement("auditing")]
        public BpmnAuditing Auditing { get; set; }

        [XmlElement("monitoring")]
        public BpmnMonitoring Monitoring { get; set; }

        [XmlElement("property")]
        public BpmnProperty[] Property { get; set; }

        [XmlElement("laneSet")]
        public BpmnLaneSet[] LaneSet { get; set; }

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
        public BpmnFlowElement[] Items { get; set; }

        [XmlElement("artifact", typeof(BpmnArtifact))]
        [XmlElement("association", typeof(BpmnAssociation))]
        [XmlElement("group", typeof(BpmnGroup))]
        [XmlElement("textAnnotation", typeof(BpmnTextAnnotation))]
        public BpmnArtifact[] Items1 { get; set; }

        [XmlElement("performer", typeof(BpmnPerformer))]
        [XmlElement("resourceRole", typeof(BpmnResourceRole))]
        public BpmnResourceRole[] Items2 { get; set; }

        [XmlElement("correlationSubscription")]
        public BpmnCorrelationSubscription[] CorrelationSubscription { get; set; }

        [XmlElement("supports")]
        public XmlQualifiedName[] Supports { get; set; }

        [XmlAttribute("processType")]
        [DefaultValue(BpmnProcessType.None)]
        public BpmnProcessType ProcessType { get; set; }

        [XmlAttribute("isClosed")]
        [DefaultValue(false)]
        public bool IsClosed { get; set; }

        [XmlAttribute("isExecutable")]
        public bool IsExecutable { get; set; }

        [XmlIgnore()]
        public bool IsExecutableSpecified { get; set; }

        [XmlAttribute("definitionalCollaborationRef")]
        public XmlQualifiedName DefinitionalCollaborationRef { get; set; }
    }
}
