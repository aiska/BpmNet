using BPMNET.Bpmn;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace BPMNET.Bpmn.Tests
{
    [TestClass()]
    public class BpmnNetDefinitionTests
    {
        BpmnNetDefinition def;
        public BpmnNetDefinitionTests()
        {
            //string bpmnFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\LosFlow.bpmn";
            string bpmnFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\LosFlow4.bpmn";
            def = new BpmnNetDefinition(bpmnFile);
        }

        [TestMethod()]
        public void BpmnNetDefinitionTest()
        {
            string bpmnFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\LosFlow.bpmn";
            def = new BpmnNetDefinition(bpmnFile);
        }

        [TestMethod()]
        public void GetId()
        {
            string id = def.Id;
        }

        [TestMethod()]
        public void SetId()
        {
            def.Id = "test";
        }

        [TestMethod()]
        public void SetName()
        {
            def.Name = "test";
        }

        [TestMethod()]
        public void GetXmlTest()
        {
            Assert.IsNotNull(def.GetXml());
        }

        [TestMethod()]
        public void GetItemDefinitionTypeTest()
        {
            Assert.AreEqual(ItemDefinitionType.ItemDefinition, def.GetItemDefinitionType("FistName"));
        }

        [TestMethod()]
        public void GetAllProcessTest()
        {
            Assert.IsNotNull(def.GetAllProcess());
        }

        [TestMethod()]
        public void GetProcessTest()
        {
            var t = def.GetProcess("losFlow");
            Assert.IsNotNull(t);
        }

        [TestMethod()]
        public void TryGetProcessTest()
        {
            tProcess p = null;
            def.TryGetProcess("losFlow", out p);
            Assert.IsNotNull(p);
        }

        [TestMethod()]
        public void GetFlowElementTest()
        {
            var t = def.GetProcess("losFlow");
            Assert.IsNotNull(def.GetFlowElement(t, "startevent1"));
        }

        [TestMethod()]
        public void TryGetFlowElementTest()
        {
            var t = def.GetProcess("losFlow");
            tFlowElement el = null;
            Assert.IsTrue(def.TryGetFlowElement(t, "startevent1", out el));
            Assert.IsNotNull(el);
        }

        [TestMethod()]
        public void GetSequenceFlowTest()
        {
            var t = def.GetProcess("losFlow");
            Assert.IsNotNull(def.GetSequenceFlow(t, "flow1"));
        }

        [TestMethod()]
        public void TryGetSequenceFlowTest()
        {
            var t = def.GetProcess("losFlow");
            tSequenceFlow seq = null;
            Assert.IsTrue(def.TryGetSequenceFlow(t, "flow1", out seq));
            Assert.IsNotNull(seq);
        }

        [TestMethod()]
        public void GetNextSequenceTest()
        {
            var t = def.GetProcess("losFlow");
            var s = def.GetNextSequence(t, "IDE");
            foreach (var item in s)
            {
                Assert.IsNotNull(item);
            }
        }

        [TestMethod()]
        public void GetStartItemTest()
        {

        }

        [TestMethod()]
        public void GetItemDefinitionTest()
        {

        }

        [TestMethod()]
        public void TryGetItemDefinitionTest()
        {

        }

        [TestMethod()]
        public void getFlowNodeTest()
        {
            var t = def.GetProcess("losFlow");
            Assert.IsNotNull(def.GetFlowElement(t, "flow1"));
        }
    }
}