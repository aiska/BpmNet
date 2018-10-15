using System;
using System.Xml.Serialization;

namespace BpmNet.Bpmn
{
    [Serializable()]
    [XmlType(Namespace = "http://www.omg.org/spec/BPMN/20100524/DI")]
    public enum ParticipantBandKind
    {
        top_initiating,
        middle_initiating,
        bottom_initiating,
        top_non_initiating,
        middle_non_initiating,
        bottom_non_initiating,
    }
}
