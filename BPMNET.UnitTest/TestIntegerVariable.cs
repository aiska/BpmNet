using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Core.Variable;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class TestIntegerVariable
    {
        [TestMethod]
        public void TestIntegerValue()
        {
            IntegerVariable var = new IntegerVariable();
            var.CheckForStore(1);
            Assert.AreEqual(1, var.Value);
        }
        [TestMethod]
        public void TestIntegerVariableNullValue()
        {
            IntegerVariable var = new IntegerVariable();
            bool actual = var.CheckForStore(null);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void TestOverflowIntegerValue()
        {
            IntegerVariable var = new IntegerVariable();
            Assert.IsFalse(var.CheckForStore(9999999999999999));
        }
        [TestMethod]
        public void TestNotIntegerValue()
        {
            IntegerVariable var = new IntegerVariable();
            Assert.IsFalse(var.CheckForStore("not int"));
        }
        [TestMethod]
        public void TestStringIntegerValue()
        {
            IntegerVariable var = new IntegerVariable();
            Assert.IsTrue(var.CheckForStore("123"));
        }
        [TestMethod]
        public void TestGetIntType()
        {
            IntegerVariable var = new IntegerVariable();
            Assert.AreEqual("int", var.StoreType);
        }
    }
}
