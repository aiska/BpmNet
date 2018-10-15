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
    [XmlRoot("transaction", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnTransaction : BpmnSubProcess
    {

        private string methodField;

        public BpmnTransaction()
        {
            methodField = "##Compensate";
        }

            [XmlAttribute()]
        [DefaultValue("##Compensate")]
        public string method
        {
            get
            {
                return methodField;
            }
            set
            {
                methodField = value;
            }
        }
    }
}
