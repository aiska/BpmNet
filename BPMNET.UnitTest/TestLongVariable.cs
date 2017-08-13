using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Core.Variable;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class TestLongVariable
    {
        [TestMethod]
        public void TestLongValue()
        {
            LongVariable var = new LongVariable();
            var.CheckForStore(1L);
            Assert.AreEqual(1L, var.Value);
        }
        [TestMethod]
        public void TestLongVariableNullValue()
        {
            LongVariable var = new LongVariable();
            bool actual = var.CheckForStore(null);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void TestOverflowLongValue()
        {
            LongVariable var = new LongVariable();
            Assert.IsFalse(var.CheckForStore(9223372036854775808));
        }
        [TestMethod]
        public void TestNotLongValue()
        {
            LongVariable var = new LongVariable();
            Assert.IsFalse(var.CheckForStore("string"));
        }
        [TestMethod]
        public void TestStringLongValue()
        {
            LongVariable var = new LongVariable();
            Assert.IsTrue(var.CheckForStore("123"));
        }
        [TestMethod]
        public void TestGetLongType()
        {
            LongVariable var = new LongVariable();
            Assert.AreEqual("long", var.StoreType);
        }
    }
}
