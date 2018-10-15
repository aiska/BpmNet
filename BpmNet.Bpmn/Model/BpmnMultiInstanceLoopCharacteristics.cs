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
    [XmlRoot("multiInstanceLoopCharacteristics", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnMultiInstanceLoopCharacteristics : BpmnLoopCharacteristics
    {
        public BpmnMultiInstanceLoopCharacteristics()
        {
            IsSequential = false;
            Behavior = BpmnMultiInstanceFlowCondition.All;
        }
        [XmlElement("loopCardinality")]
        public BpmnExpression LoopCardinality { get; set; }

        [XmlAttribute("loopDataInputRef")]
        public XmlQualifiedName LoopDataInputRef { get; set; }

        [XmlAttribute("loopDataOutputRef")]
        public XmlQualifiedName LoopDataOutputRef { get; set; }

        [XmlElement("inputDataItem")]
        public BpmnDataInput InputDataItem { get; set; }

        [XmlElement("outputDataItem")]
        public BpmnDataOutput OutputDataItem { get; set; }

        [XmlElement("complexBehaviorDefinition")]
        public BpmnComplexBehaviorDefinition[] ComplexBehaviorDefinition { get; set; }

        [XmlElement("completionCondition")]
        public BpmnExpression CompletionCondition { get; set; }

        [XmlAttribute("isSequential")]
        [DefaultValue(false)]
        public bool IsSequential { get; set; }

        [XmlAttribute("behavior")]
        [DefaultValue(BpmnMultiInstanceFlowCondition.All)]
        public BpmnMultiInstanceFlowCondition Behavior { get; set; }

        [XmlAttribute("oneBehaviorEventRef")]
        public XmlQualifiedName OneBehaviorEventRef { get; set; }

        [XmlAttribute("noneBehaviorEventRef")]
        public XmlQualifiedName NoneBehaviorEventRef { get; set; }
    }

}
