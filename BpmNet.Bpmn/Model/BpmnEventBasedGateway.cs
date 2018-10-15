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
    [XmlRoot("eventBasedGateway", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = false)]
    public partial class BpmnEventBasedGateway : BpmnGateway
    {
        public BpmnEventBasedGateway()
        {
            Instantiate = false;
            EventGatewayType = BpmnEventBasedGatewayType.Exclusive;
        }

        [XmlAttribute("instantiate")]
        [DefaultValue(false)]
        public bool Instantiate { get; set; }

        [XmlAttribute("eventGatewayType")]
        [DefaultValue(BpmnEventBasedGatewayType.Exclusive)]
        public BpmnEventBasedGatewayType EventGatewayType { get; set; }
    }
}
