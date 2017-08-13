using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tUserTask))]
    [XmlInclude(typeof(tServiceTask))]
    [XmlInclude(typeof(tSendTask))]
    [XmlInclude(typeof(tScriptTask))]
    [XmlInclude(typeof(tReceiveTask))]
    [XmlInclude(typeof(tManualTask))]
    [XmlInclude(typeof(tBusinessRuleTask))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("task", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tTask : tActivity
    {
    }
}
