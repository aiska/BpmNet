using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Core.Variable;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class TestBooleanVariable
    {
        [TestMethod]
        public void TestGetNotBoolValue()
        {
            BooleanVariable var = new BooleanVariable();
            bool actual = var.CheckForStore(var.CheckForStore(4));
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void TestGetNotBoolValue2()
        {
            BooleanVariable var = new BooleanVariable();
            bool actual = var.CheckForStore(var.CheckForStore(4));
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void TestTrueStringValue()
        {
            BooleanVariable var = new BooleanVariable();
            var.CheckForStore("true");
            Assert.IsTrue((bool)var.Value);
        }
        [TestMethod]
        public void TestFalseStringValue()
        {
            BooleanVariable var = new BooleanVariable();
            var.CheckForStore("false");
            Assert.IsFalse((bool)var.Value);
        }
        [TestMethod]
        public void TestBoolValue()
        {
            BooleanVariable var = new BooleanVariable();
            var.CheckForStore(true);
            Assert.IsTrue((bool)var.Value);
        }
        [TestMethod]
        public void TestGetNullValue()
        {
            BooleanVariable var = new BooleanVariable();
            bool actual = var.CheckForStore(null);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void TestGetBoolType()
        {
            BooleanVariable var = new BooleanVariable();
            Assert.AreEqual("bool", var.StoreType);
        }
    }
}
