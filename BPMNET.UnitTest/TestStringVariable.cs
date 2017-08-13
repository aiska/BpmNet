using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Core.Variable;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class TestStringVariable
    {
        [TestMethod]
        public void TestStringValue()
        {
            StringVariable var = new StringVariable();
            var.CheckForStore("string");
            Assert.AreEqual("string", var.Value);
        }
        [TestMethod]
        public void TestStringVariableNullValue()
        {
            StringVariable var = new StringVariable();
            bool actual = var.CheckForStore(null);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void TestGetStringType()
        {
            StringVariable var = new StringVariable();
            Assert.AreEqual("string", var.StoreType);
        }
        [TestMethod]
        public void TestCacheable()
        {
            StringVariable var = new StringVariable();
            Assert.AreEqual(true, var.Cachable);
        }
        [TestMethod]
        public void TestVariableName()
        {
            StringVariable var = new StringVariable();
            string varName = "string";
            var.Name = varName;
            Assert.AreEqual(varName, var.Name);
        }
    }
}
