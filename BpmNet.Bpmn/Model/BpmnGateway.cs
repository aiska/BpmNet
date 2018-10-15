using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [XmlInclude(typeof(BpmnParallelGateway))]
    [XmlInclude(typeof(BpmnInclusiveGateway))]
    [XmlInclude(typeof(BpmnExclusiveGateway))]
    [XmlInclude(typeof(BpmnEventBasedGateway))]
    [XmlInclude(typeof(BpmnComplexGateway))]
    [Serializable()]
    [DebuggerStepThrough()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    public partial class BpmnGateway : BpmnFlowNode
    {
        public BpmnGateway()
        {
            GatewayDirection = BpmnGatewayDirection.Unspecified;
        }

        [XmlAttribute("gatewayDirection")]
        [DefaultValue(BpmnGatewayDirection.Unspecified)]
        public BpmnGatewayDirection GatewayDirection { get; set; }
    }
}
