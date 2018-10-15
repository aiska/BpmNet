using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnTransaction))]
    [XmlInclude(typeof(BpmnAdHocSubProcess))]
    
    [Serializable()]
    [DebuggerStepThrough()]
    
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("subProcess", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnSubProcess : BpmnActivity
    {

        private BpmnLaneSet[] laneSetField;

        private BpmnFlowElement[] items1Field;

        private BpmnArtifact[] items2Field;

        private bool triggeredByEventField;

        public BpmnSubProcess()
        {
            triggeredByEventField = false;
        }

        [XmlElement("laneSet")]
        public BpmnLaneSet[] laneSet
        {
            get
            {
                return laneSetField;
            }
            set
            {
                laneSetField = value;
            }
        }

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
        public BpmnFlowElement[] Items1
        {
            get
            {
                return items1Field;
            }
            set
            {
                items1Field = value;
            }
        }

        [XmlElement("artifact", typeof(BpmnArtifact))]
        [XmlElement("association", typeof(BpmnAssociation))]
        [XmlElement("group", typeof(BpmnGroup))]
        [XmlElement("textAnnotation", typeof(BpmnTextAnnotation))]
        public BpmnArtifact[] Items2
        {
            get
            {
                return items2Field;
            }
            set
            {
                items2Field = value;
            }
        }

        [XmlAttribute()]
        [DefaultValue(false)]
        public bool triggeredByEvent
        {
            get
            {
                return triggeredByEventField;
            }
            set
            {
                triggeredByEventField = value;
            }
        }
    }
}
