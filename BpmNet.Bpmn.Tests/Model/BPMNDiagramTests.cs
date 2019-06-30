using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace BpmNet.Bpmn.Tests.Model
{
    [ExcludeFromCodeCoverage]
    public class BPMNDiagramTests
    {
        [Fact]
        public void BPMNDiagram_Populate()
        {
            BpmnDiagram diagram = new BpmnDiagram {
                BPMNPlane = new BpmnPlane (),
                BPMNLabelStyle = new BpmnLabelStyle[0] { }
            };
            Assert.NotNull(diagram.BPMNPlane);
            Assert.NotNull(diagram.BPMNLabelStyle);
        }
    }
}
