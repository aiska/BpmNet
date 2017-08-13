using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    [XmlInclude(typeof(tPerformer))]
    [XmlInclude(typeof(tHumanPerformer))]
    [XmlInclude(typeof(tPotentialOwner))]
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("resourceRole", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tResourceRole : tBaseElement
    {

        private object[] itemsField;

        private string nameField;

            [XmlElement("resourceAssignmentExpression", typeof(tResourceAssignmentExpression))]
        [XmlElement("resourceParameterBinding", typeof(tResourceParameterBinding))]
        [XmlElement("resourceRef", typeof(XmlQualifiedName))]
        public object[] Items
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

            [XmlAttribute()]
        public string name
        {
            get
            {
                return nameField;
            }
            set
            {
                nameField = value;
            }
        }
    }

}
