using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tGlobalChoreographyTask))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("choreography", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tChoreography : tCollaboration
    {

        private tFlowElement[] items2Field;

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
        public tFlowElement[] Items2
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
    }
}
