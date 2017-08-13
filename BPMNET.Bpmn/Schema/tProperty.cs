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
    [XmlRoot("property", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tProperty : tBaseElement
    {

        private tDataState dataStateField;

        private string nameField;

        private XmlQualifiedName itemSubjectRefField;

        public tDataState dataState
        {
            get
            {
                return dataStateField;
            }
            set
            {
                dataStateField = value;
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

        [XmlAttribute()]
        public XmlQualifiedName itemSubjectRef
        {
            get
            {
                return itemSubjectRefField;
            }
            set
            {
                itemSubjectRefField = value;
            }
        }
    }

}
