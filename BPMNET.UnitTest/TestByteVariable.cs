using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Core.Variable;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class TestByteVariable
    {
        [TestMethod]
        public void TestByteValue()
        {
            ByteVariable var = new ByteVariable();
            byte actualVal = 1;
            var.CheckForStore(actualVal);
            Assert.AreEqual(1, var.Value);
        }
        [TestMethod]
        public void TestFalseStringValue()
        {
            ByteVariable var = new ByteVariable();
            var.CheckForStore("false");
            Assert.IsFalse(var.CheckForStore("false"));
        }
        [TestMethod]
        public void TestByteVariableNullValue()
        {
            ByteVariable var = new ByteVariable();
            bool actual = var.CheckForStore(null);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void TestGetByteType()
        {
            ByteVariable var = new ByteVariable();
            Assert.AreEqual("byte", var.StoreType);
        }
    }
}
