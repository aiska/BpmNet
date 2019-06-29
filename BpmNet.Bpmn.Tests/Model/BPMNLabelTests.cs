using System.Diagnostics.CodeAnalysis;
using System.Xml;
using Xunit;

namespace BpmNet.Bpmn.Tests.Model
{
    [ExcludeFromCodeCoverage]
    public class BPMNLabelTests
    {
        [Fact]
        public void BPMNLabel_Populate()
        {
            BPMNLabel label = new BPMNLabel
            {
                LabelStyle = XmlQualifiedName.Empty,
            };
            Assert.NotNull(label.LabelStyle);
        }
    }
}
