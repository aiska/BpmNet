using System.Diagnostics.CodeAnalysis;
using System.Xml;
using Xunit;

namespace BpmNet.Bpmn.Tests.Model
{
    [ExcludeFromCodeCoverage]
    public class BPMNPlaneTests
    {
        [Fact]
        public void BPMNPlane_Populate()
        {
            BPMNPlane plane = new BPMNPlane
            {
                BpmnElement = XmlQualifiedName.Empty,
                DiagramElements = new BPMNEdge[0] { }
            };
            Assert.NotNull(plane.BpmnElement);
            Assert.NotNull(plane.DiagramElements);
        }
    }
}
