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
    [XmlRoot("itemDefinition", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnItemDefinition : BpmnRootElement
    {
        public BpmnItemDefinition()
        {
            IsCollection = false;
            ItemKind = BpmnItemKind.Information;
        }

        [XmlAttribute("structureRef")]
        public XmlQualifiedName StructureRef { get; set; }

        [XmlAttribute("isCollection")]
        [DefaultValue(false)]
        public bool IsCollection { get; set; }

        [XmlAttribute("itemKind")]
        [DefaultValue(BpmnItemKind.Information)]
        public BpmnItemKind ItemKind { get; set; }
    }
}
