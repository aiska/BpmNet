using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnStandardLoopCharacteristics))]
    [XmlInclude(typeof(BpmnMultiInstanceLoopCharacteristics))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("loopCharacteristics", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class BpmnLoopCharacteristics : BpmnBaseElement
    {
    }

}
