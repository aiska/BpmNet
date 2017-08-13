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
    [XmlRoot("itemDefinition", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tItemDefinition : tRootElement
    {

        private XmlQualifiedName structureRefField;

        private bool isCollectionField;

        private tItemKind itemKindField;

        public tItemDefinition()
        {
            isCollectionField = false;
            itemKindField = tItemKind.Information;
        }

        [XmlAttribute()]
        public XmlQualifiedName structureRef
        {
            get
            {
                return structureRefField;
            }
            set
            {
                structureRefField = value;
            }
        }

        [XmlAttribute()]
        [DefaultValue(false)]
        public bool isCollection
        {
            get
            {
                return isCollectionField;
            }
            set
            {
                isCollectionField = value;
            }
        }

        [XmlAttribute()]
        [DefaultValue(tItemKind.Information)]
        public tItemKind itemKind
        {
            get
            {
                return itemKindField;
            }
            set
            {
                itemKindField = value;
            }
        }
    }
}
