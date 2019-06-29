using System.Xml;
using Xunit;

namespace BpmNet.Bpmn.Tests.Model
{
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
