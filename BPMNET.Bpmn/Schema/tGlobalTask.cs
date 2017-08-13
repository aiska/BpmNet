using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tGlobalUserTask))]
    [XmlInclude(typeof(tGlobalScriptTask))]
    [XmlInclude(typeof(tGlobalManualTask))]
    [XmlInclude(typeof(tGlobalBusinessRuleTask))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("globalTask", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tGlobalTask : tCallableElement
    {

        private tResourceRole[] itemsField;

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
    }
}
