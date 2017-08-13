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
    [XmlRoot("dataObjectReference", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tDataObjectReference : tFlowElement
    {

        private tDataState dataStateField;

        private XmlQualifiedName itemSubjectRefField;

        private string dataObjectRefField;

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

        [XmlAttribute(DataType = "IDREF")]
        public string dataObjectRef
        {
            get
            {
                return dataObjectRefField;
            }
            set
            {
                dataObjectRefField = value;
            }
        }
    }
}
