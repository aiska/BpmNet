using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tTransaction))]
    [XmlInclude(typeof(tAdHocSubProcess))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("subProcess", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tSubProcess : tActivity
    {

        private tLaneSet[] laneSetField;

        private tFlowElement[] items1Field;

        private tArtifact[] items2Field;

        private bool triggeredByEventField;

        public tSubProcess()
        {
            triggeredByEventField = false;
        }

        [XmlElement("laneSet")]
        public tLaneSet[] laneSet
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

        [XmlElement("adHocSubProcess", typeof(tAdHocSubProcess))]
        [XmlElement("boundaryEvent", typeof(tBoundaryEvent))]
        [XmlElement("businessRuleTask", typeof(tBusinessRuleTask))]
        [XmlElement("callActivity", typeof(tCallActivity))]
        [XmlElement("callChoreography", typeof(tCallChoreography))]
        [XmlElement("choreographyTask", typeof(tChoreographyTask))]
        [XmlElement("complexGateway", typeof(tComplexGateway))]
        [XmlElement("dataObject", typeof(tDataObject))]
        [XmlElement("dataObjectReference", typeof(tDataObjectReference))]
        [XmlElement("dataStoreReference", typeof(tDataStoreReference))]
        [XmlElement("endEvent", typeof(tEndEvent))]
        [XmlElement("event", typeof(tEvent))]
        [XmlElement("eventBasedGateway", typeof(tEventBasedGateway))]
        [XmlElement("exclusiveGateway", typeof(tExclusiveGateway))]
        [XmlElement("flowElement", typeof(tFlowElement))]
        [XmlElement("implicitThrowEvent", typeof(tImplicitThrowEvent))]
        [XmlElement("inclusiveGateway", typeof(tInclusiveGateway))]
        [XmlElement("intermediateCatchEvent", typeof(tIntermediateCatchEvent))]
        [XmlElement("intermediateThrowEvent", typeof(tIntermediateThrowEvent))]
        [XmlElement("manualTask", typeof(tManualTask))]
        [XmlElement("parallelGateway", typeof(tParallelGateway))]
        [XmlElement("receiveTask", typeof(tReceiveTask))]
        [XmlElement("scriptTask", typeof(tScriptTask))]
        [XmlElement("sendTask", typeof(tSendTask))]
        [XmlElement("sequenceFlow", typeof(tSequenceFlow))]
        [XmlElement("serviceTask", typeof(tServiceTask))]
        [XmlElement("startEvent", typeof(tStartEvent))]
        [XmlElement("subChoreography", typeof(tSubChoreography))]
        [XmlElement("subProcess", typeof(tSubProcess))]
        [XmlElement("task", typeof(tTask))]
        [XmlElement("transaction", typeof(tTransaction))]
        [XmlElement("userTask", typeof(tUserTask))]
        public tFlowElement[] Items1
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

        [XmlElement("artifact", typeof(tArtifact))]
        [XmlElement("association", typeof(tAssociation))]
        [XmlElement("group", typeof(tGroup))]
        [XmlElement("textAnnotation", typeof(tTextAnnotation))]
        public tArtifact[] Items2
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
