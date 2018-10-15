using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{

    [Serializable()]
    [DebuggerStepThrough()]
    
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    [XmlRoot("signal", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnSignal : BpmnRootElement
    {

        private string nameField;

        private XmlQualifiedName structureRefField;

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
    }
}
