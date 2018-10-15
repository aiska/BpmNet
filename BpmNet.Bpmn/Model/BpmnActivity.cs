using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnTask))]
    [XmlInclude(typeof(BpmnUserTask))]
    [XmlInclude(typeof(BpmnServiceTask))]
    [XmlInclude(typeof(BpmnSendTask))]
    [XmlInclude(typeof(BpmnScriptTask))]
    [XmlInclude(typeof(BpmnReceiveTask))]
    [XmlInclude(typeof(BpmnManualTask))]
    [XmlInclude(typeof(BpmnBusinessRuleTask))]
    [XmlInclude(typeof(BpmnSubProcess))]
    [XmlInclude(typeof(BpmnTransaction))]
    [XmlInclude(typeof(BpmnAdHocSubProcess))]
    [XmlInclude(typeof(BpmnCallActivity))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("activity", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class BpmnActivity : BpmnFlowNode
    {
        public BpmnActivity()
        {
            IsForCompensation = false;
            StartQuantity = "1";
            CompletionQuantity = "1";
        }

        public BpmnInputOutputSpecification IoSpecification { get; set; }

        [XmlElement("property")]
        public BpmnProperty[] Property { get; set; }

        [XmlElement("dataInputAssociation")]
        public BpmnDataInputAssociation[] DataInputAssociation { get; set; }

        [XmlElement("dataOutputAssociation")]
        public BpmnDataOutputAssociation[] DataOutputAssociation { get; set; }

        [XmlElement("performer", typeof(BpmnPerformer))]
        [XmlElement("resourceRole", typeof(BpmnResourceRole))]
        public BpmnResourceRole[] Items { get; set; }

        [XmlElement("loopCharacteristics", typeof(BpmnLoopCharacteristics))]
        [XmlElement("multiInstanceLoopCharacteristics", typeof(BpmnMultiInstanceLoopCharacteristics))]
        [XmlElement("standardLoopCharacteristics", typeof(BpmnStandardLoopCharacteristics))]
        public BpmnLoopCharacteristics Item { get; set; }

        [XmlAttribute("isForCompensation")]
        [DefaultValue(false)]
        public bool IsForCompensation { get; set; }

        [XmlAttribute("startQuantity", DataType = "integer")]
        [DefaultValue("1")]
        public string StartQuantity { get; set; }

        [XmlAttribute("completionQuantity", DataType = "integer")]
        [DefaultValue("1")]
        public string CompletionQuantity { get; set; }

        [XmlAttribute("default", DataType = "IDREF")]
        public string Default { get; set; }
    }
}
