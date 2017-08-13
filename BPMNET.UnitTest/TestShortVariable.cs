using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Core.Variable;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class TestShortVariable
    {
        [TestMethod]
        public void TestShortValue()
        {
            ShortVariable var = new ShortVariable();
            short val = 123;
            var.CheckForStore(val);
            Assert.AreEqual(val, var.Value);
        }
        [TestMethod]
        public void TestShortVariableNullValue()
        {
            ShortVariable var = new ShortVariable();
            bool actual = var.CheckForStore(null);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void TestOverflowShortValue()
        {
            ShortVariable var = new ShortVariable();
            Assert.IsFalse(var.CheckForStore(9223372036854775808));
        }
        [TestMethod]
        public void TestNotShortValue()
        {
            ShortVariable var = new ShortVariable();
            Assert.IsFalse(var.CheckForStore("string"));
        }
        [TestMethod]
        public void TestStringShortValue()
        {
            ShortVariable var = new ShortVariable();
            Assert.IsTrue(var.CheckForStore("123"));
        }
        [TestMethod]
        public void TestGetShortType()
        {
            ShortVariable var = new ShortVariable();
            Assert.AreEqual("short", var.StoreType);
        }
    }
}
