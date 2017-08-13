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
    [XmlRoot("multiInstanceLoopCharacteristics", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tMultiInstanceLoopCharacteristics : tLoopCharacteristics
    {

        private tExpression loopCardinalityField;

        private XmlQualifiedName loopDataInputRefField;

        private XmlQualifiedName loopDataOutputRefField;

        private tDataInput inputDataItemField;

        private tDataOutput outputDataItemField;

        private tComplexBehaviorDefinition[] complexBehaviorDefinitionField;

        private tExpression completionConditionField;

        private bool isSequentialField;

        private tMultiInstanceFlowCondition behaviorField;

        private XmlQualifiedName oneBehaviorEventRefField;

        private XmlQualifiedName noneBehaviorEventRefField;

        public tMultiInstanceLoopCharacteristics()
        {
            isSequentialField = false;
            behaviorField = tMultiInstanceFlowCondition.All;
        }

        public tExpression loopCardinality
        {
            get
            {
                return loopCardinalityField;
            }
            set
            {
                loopCardinalityField = value;
            }
        }

        public XmlQualifiedName loopDataInputRef
        {
            get
            {
                return loopDataInputRefField;
            }
            set
            {
                loopDataInputRefField = value;
            }
        }

        public XmlQualifiedName loopDataOutputRef
        {
            get
            {
                return loopDataOutputRefField;
            }
            set
            {
                loopDataOutputRefField = value;
            }
        }

        public tDataInput inputDataItem
        {
            get
            {
                return inputDataItemField;
            }
            set
            {
                inputDataItemField = value;
            }
        }

        public tDataOutput outputDataItem
        {
            get
            {
                return outputDataItemField;
            }
            set
            {
                outputDataItemField = value;
            }
        }

        [XmlElement("complexBehaviorDefinition")]
        public tComplexBehaviorDefinition[] complexBehaviorDefinition
        {
            get
            {
                return complexBehaviorDefinitionField;
            }
            set
            {
                complexBehaviorDefinitionField = value;
            }
        }

        public tExpression completionCondition
        {
            get
            {
                return completionConditionField;
            }
            set
            {
                completionConditionField = value;
            }
        }

        [XmlAttribute()]
        [DefaultValue(false)]
        public bool isSequential
        {
            get
            {
                return isSequentialField;
            }
            set
            {
                isSequentialField = value;
            }
        }

        [XmlAttribute()]
        [DefaultValue(tMultiInstanceFlowCondition.All)]
        public tMultiInstanceFlowCondition behavior
        {
            get
            {
                return behaviorField;
            }
            set
            {
                behaviorField = value;
            }
        }

        [XmlAttribute()]
        public XmlQualifiedName oneBehaviorEventRef
        {
            get
            {
                return oneBehaviorEventRefField;
            }
            set
            {
                oneBehaviorEventRefField = value;
            }
        }

        [XmlAttribute()]
        public XmlQualifiedName noneBehaviorEventRef
        {
            get
            {
                return noneBehaviorEventRefField;
            }
            set
            {
                noneBehaviorEventRefField = value;
            }
        }
    }

}
