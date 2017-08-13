using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
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
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("activity", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class tActivity : tFlowNode
    {

        private tInputOutputSpecification ioSpecificationField;

        private tProperty[] propertyField;

        private tDataInputAssociation[] dataInputAssociationField;

        private tDataOutputAssociation[] dataOutputAssociationField;

        private tResourceRole[] itemsField;

        private tLoopCharacteristics itemField;

        private bool isForCompensationField;

        private string startQuantityField;

        private string completionQuantityField;

        private string defaultField;

        public tActivity()
        {
            isForCompensationField = false;
            startQuantityField = "1";
            completionQuantityField = "1";
        }

        public tInputOutputSpecification ioSpecification
        {
            get
            {
                return ioSpecificationField;
            }
            set
            {
                ioSpecificationField = value;
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

        [XmlElement("dataInputAssociation")]
        public tDataInputAssociation[] dataInputAssociation
        {
            get
            {
                return dataInputAssociationField;
            }
            set
            {
                dataInputAssociationField = value;
            }
        }

        [XmlElement("dataOutputAssociation")]
        public tDataOutputAssociation[] dataOutputAssociation
        {
            get
            {
                return dataOutputAssociationField;
            }
            set
            {
                dataOutputAssociationField = value;
            }
        }

        [XmlElement("performer", typeof(tPerformer))]
        [XmlElement("resourceRole", typeof(tResourceRole))]
        public tResourceRole[] Items
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

        [XmlElement("loopCharacteristics", typeof(tLoopCharacteristics))]
        [XmlElement("multiInstanceLoopCharacteristics", typeof(tMultiInstanceLoopCharacteristics))]
        [XmlElement("standardLoopCharacteristics", typeof(tStandardLoopCharacteristics))]
        public tLoopCharacteristics Item
        {
            get
            {
                return itemField;
            }
            set
            {
                itemField = value;
            }
        }

        [XmlAttribute()]
        [DefaultValue(false)]
        public bool isForCompensation
        {
            get
            {
                return isForCompensationField;
            }
            set
            {
                isForCompensationField = value;
            }
        }

        [XmlAttribute(DataType = "integer")]
        [DefaultValue("1")]
        public string startQuantity
        {
            get
            {
                return startQuantityField;
            }
            set
            {
                startQuantityField = value;
            }
        }

        [XmlAttribute(DataType = "integer")]
        [DefaultValue("1")]
        public string completionQuantity
        {
            get
            {
                return completionQuantityField;
            }
            set
            {
                completionQuantityField = value;
            }
        }

        [XmlAttribute(DataType = "IDREF")]
        public string @default
        {
            get
            {
                return defaultField;
            }
            set
            {
                defaultField = value;
            }
        }
    }
}
