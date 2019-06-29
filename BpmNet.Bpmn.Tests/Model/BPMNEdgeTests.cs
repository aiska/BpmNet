using System.Xml;
using Xunit;

namespace BpmNet.Bpmn.Tests.Model
{
    public class BPMNEdgeTests
    {
        [Fact]
        public void BPMNEdge_Populate()
        {
            BPMNEdge edge = new BPMNEdge
            {
                BPMNLabel = new BPMNLabel(),
                BpmnElement = XmlQualifiedName.Empty,
                SourceElement = XmlQualifiedName.Empty,
                TargetElement = XmlQualifiedName.Empty,
                MessageVisibleKind = MessageVisibleKind.initiating,
                MessageVisibleKindSpecified = false
            };
            Assert.NotNull(edge.BPMNLabel);
            Assert.NotNull(edge.BpmnElement);
            Assert.NotNull(edge.SourceElement);
            Assert.NotNull(edge.TargetElement);
            Assert.Equal(MessageVisibleKind.initiating, edge.MessageVisibleKind);
            Assert.False(edge.MessageVisibleKindSpecified);
        }
    }
}
