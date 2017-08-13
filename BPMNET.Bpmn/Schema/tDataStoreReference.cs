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
    [XmlRoot("dataStoreReference", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tDataStoreReference : tFlowElement
    {

        private tDataState dataStateField;

        private XmlQualifiedName itemSubjectRefField;

        private XmlQualifiedName dataStoreRefField;

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

        [XmlAttribute()]
        public XmlQualifiedName dataStoreRef
        {
            get
            {
                return dataStoreRefField;
            }
            set
            {
                dataStoreRefField = value;
            }
        }
    }
}
