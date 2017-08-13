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
    [XmlRoot("dataStore", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class tDataStore : tRootElement
    {

        private tDataState dataStateField;

        private string nameField;

        private string capacityField;

        private bool isUnlimitedField;

        private XmlQualifiedName itemSubjectRefField;

        public tDataStore()
        {
            isUnlimitedField = true;
        }

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

        [XmlAttribute(DataType = "integer")]
        public string capacity
        {
            get
            {
                return capacityField;
            }
            set
            {
                capacityField = value;
            }
        }

        [XmlAttribute()]
        [DefaultValue(true)]
        public bool isUnlimited
        {
            get
            {
                return isUnlimitedField;
            }
            set
            {
                isUnlimitedField = value;
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
