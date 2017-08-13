
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tRelationship))]
    [XmlInclude(typeof(tResourceParameter))]
    [XmlInclude(typeof(tOperation))]
    [XmlInclude(typeof(tCorrelationPropertyRetrievalExpression))]
    [XmlInclude(typeof(tConversationLink))]
    [XmlInclude(typeof(tMessageFlowAssociation))]
    [XmlInclude(typeof(tConversationAssociation))]
    [XmlInclude(typeof(tConversationNode))]
    [XmlInclude(typeof(tSubConversation))]
    [XmlInclude(typeof(tConversation))]
    [XmlInclude(typeof(tCallConversation))]
    [XmlInclude(typeof(tMessageFlow))]
    [XmlInclude(typeof(tParticipantMultiplicity))]
    [XmlInclude(typeof(tParticipant))]
    [XmlInclude(typeof(tCorrelationPropertyBinding))]
    [XmlInclude(typeof(tCorrelationSubscription))]
    [XmlInclude(typeof(tParticipantAssociation))]
    [XmlInclude(typeof(tCorrelationKey))]
    [XmlInclude(typeof(tRendering))]
    [XmlInclude(typeof(tInputOutputBinding))]
    [XmlInclude(typeof(tRootElement))]
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
    [XmlInclude(typeof(tLane))]
    [XmlInclude(typeof(tLaneSet))]
    [XmlInclude(typeof(tLoopCharacteristics))]
    [XmlInclude(typeof(tStandardLoopCharacteristics))]
    [XmlInclude(typeof(tMultiInstanceLoopCharacteristics))]
    [XmlInclude(typeof(tResourceAssignmentExpression))]
    [XmlInclude(typeof(tResourceParameterBinding))]
    [XmlInclude(typeof(tResourceRole))]
    [XmlInclude(typeof(tPerformer))]
    [XmlInclude(typeof(tHumanPerformer))]
    [XmlInclude(typeof(tPotentialOwner))]
    [XmlInclude(typeof(tDataAssociation))]
    [XmlInclude(typeof(tDataOutputAssociation))]
    [XmlInclude(typeof(tDataInputAssociation))]
    [XmlInclude(typeof(tProperty))]
    [XmlInclude(typeof(tOutputSet))]
    [XmlInclude(typeof(tInputSet))]
    [XmlInclude(typeof(tDataOutput))]
    [XmlInclude(typeof(tDataInput))]
    [XmlInclude(typeof(tInputOutputSpecification))]
    [XmlInclude(typeof(tDataState))]
    [XmlInclude(typeof(tMonitoring))]
    [XmlInclude(typeof(tFlowElement))]
    [XmlInclude(typeof(tSequenceFlow))]
    [XmlInclude(typeof(tFlowNode))]
    [XmlInclude(typeof(tGateway))]
    [XmlInclude(typeof(tParallelGateway))]
    [XmlInclude(typeof(tInclusiveGateway))]
    [XmlInclude(typeof(tExclusiveGateway))]
    [XmlInclude(typeof(tEventBasedGateway))]
    [XmlInclude(typeof(tComplexGateway))]
    [XmlInclude(typeof(tChoreographyActivity))]
    [XmlInclude(typeof(tSubChoreography))]
    [XmlInclude(typeof(tChoreographyTask))]
    [XmlInclude(typeof(tCallChoreography))]
    [XmlInclude(typeof(tEvent))]
    [XmlInclude(typeof(tThrowEvent))]
    [XmlInclude(typeof(tIntermediateThrowEvent))]
    [XmlInclude(typeof(tImplicitThrowEvent))]
    [XmlInclude(typeof(tEndEvent))]
    [XmlInclude(typeof(tCatchEvent))]
    [XmlInclude(typeof(tStartEvent))]
    [XmlInclude(typeof(tIntermediateCatchEvent))]
    [XmlInclude(typeof(tBoundaryEvent))]
    [XmlInclude(typeof(tActivity))]
    [XmlInclude(typeof(tTask))]
    [XmlInclude(typeof(tUserTask))]
    [XmlInclude(typeof(tServiceTask))]
    [XmlInclude(typeof(tSendTask))]
    [XmlInclude(typeof(tScriptTask))]
    [XmlInclude(typeof(tReceiveTask))]
    [XmlInclude(typeof(tManualTask))]
    [XmlInclude(typeof(tBusinessRuleTask))]
    [XmlInclude(typeof(tSubProcess))]
    [XmlInclude(typeof(tTransaction))]
    [XmlInclude(typeof(tAdHocSubProcess))]
    [XmlInclude(typeof(tCallActivity))]
    [XmlInclude(typeof(tDataStoreReference))]
    [XmlInclude(typeof(tDataObjectReference))]
    [XmlInclude(typeof(tDataObject))]
    [XmlInclude(typeof(tComplexBehaviorDefinition))]
    [XmlInclude(typeof(tCategoryValue))]
    [XmlInclude(typeof(tAuditing))]
    [XmlInclude(typeof(tAssignment))]
    [XmlInclude(typeof(tArtifact))]
    [XmlInclude(typeof(tTextAnnotation))]
    [XmlInclude(typeof(tGroup))]
    [XmlInclude(typeof(tAssociation))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("baseElement", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class tBaseElement
    {

        private tDocumentation[] documentationField;

        private tExtensionElements extensionElementsField;

        private string idField;

        private XmlAttribute[] anyAttrField;

        [XmlElement("documentation")]
        public tDocumentation[] documentation
        {
            get
            {
                return documentationField;
            }
            set
            {
                documentationField = value;
            }
        }

        public tExtensionElements extensionElements
        {
            get
            {
                return extensionElementsField;
            }
            set
            {
                extensionElementsField = value;
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }

        [XmlAnyAttribute()]
        public XmlAttribute[] AnyAttr
        {
            get
            {
                return anyAttrField;
            }
            set
            {
                anyAttrField = value;
            }
        }
    }
}
