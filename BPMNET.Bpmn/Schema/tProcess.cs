using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("process", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tProcess : tCallableElement
    {

        private tAuditing auditingField;

        private tMonitoring monitoringField;

        private tProperty[] propertyField;

        private tLaneSet[] laneSetField;

        private tFlowElement[] itemsField;

        private tArtifact[] items1Field;

        private tResourceRole[] items2Field;

        private tCorrelationSubscription[] correlationSubscriptionField;

        private XmlQualifiedName[] supportsField;

        private tProcessType processTypeField;

        private bool isClosedField;

        private bool isExecutableField;

        private bool isExecutableFieldSpecified;

        private XmlQualifiedName definitionalCollaborationRefField;

        public tProcess()
        {
            processTypeField = tProcessType.None;
            isClosedField = false;
        }

        public tAuditing auditing
        {
            get
            {
                return auditingField;
            }
            set
            {
                auditingField = value;
            }
        }

        public tMonitoring monitoring
        {
            get
            {
                return monitoringField;
            }
            set
            {
                monitoringField = value;
            }
        }

        [XmlElement("property")]
        public tProperty[] property
        {
            get
            {
                return propertyField;
            }
            set
            {
                propertyField = value;
            }
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
        public tFlowElement[] Items
        {
            get
            {
                return itemsField;
            }
            set
            {
                itemsField = value;
            }
        }

        [XmlElement("artifact", typeof(tArtifact))]
        [XmlElement("association", typeof(tAssociation))]
        [XmlElement("group", typeof(tGroup))]
        [XmlElement("textAnnotation", typeof(tTextAnnotation))]
        public tArtifact[] Items1
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

        [XmlElement("performer", typeof(tPerformer))]
        [XmlElement("resourceRole", typeof(tResourceRole))]
        public tResourceRole[] Items2
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

        [XmlElement("correlationSubscription")]
        public tCorrelationSubscription[] correlationSubscription
        {
            get
            {
                return correlationSubscriptionField;
            }
            set
            {
                correlationSubscriptionField = value;
            }
        }

        [XmlElement("supports")]
        public XmlQualifiedName[] supports
        {
            get
            {
                return supportsField;
            }
            set
            {
                supportsField = value;
            }
        }

        [XmlAttribute()]
        [DefaultValue(tProcessType.None)]
        public tProcessType processType
        {
            get
            {
                return processTypeField;
            }
            set
            {
                processTypeField = value;
            }
        }

        [XmlAttribute()]
        [DefaultValue(false)]
        public bool isClosed
        {
            get
            {
                return isClosedField;
            }
            set
            {
                isClosedField = value;
            }
        }

        [XmlAttribute()]
        public bool isExecutable
        {
            get
            {
                return isExecutableField;
            }
            set
            {
                isExecutableField = value;
            }
        }

        [XmlIgnore()]
        public bool isExecutableSpecified
        {
            get
            {
                return isExecutableFieldSpecified;
            }
            set
            {
                isExecutableFieldSpecified = value;
            }
        }

        [XmlAttribute()]
        public XmlQualifiedName definitionalCollaborationRef
        {
            get
            {
                return definitionalCollaborationRefField;
            }
            set
            {
                definitionalCollaborationRefField = value;
            }
        }
    }
}
