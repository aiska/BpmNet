using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tStandardLoopCharacteristics))]
    [XmlInclude(typeof(tMultiInstanceLoopCharacteristics))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("loopCharacteristics", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public abstract partial class tLoopCharacteristics : tBaseElement
    {
    }

}
