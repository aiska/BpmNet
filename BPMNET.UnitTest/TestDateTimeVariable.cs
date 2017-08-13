using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Core.Variable;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class TestDateTimeVariable
    {
        [TestMethod]
        public void TestDateTimeValue()
        {
            DateTimeVariable var = new DateTimeVariable();
            DateTime actual = new DateTime();
            var.CheckForStore(actual);
            Assert.AreEqual(actual, var.Value);
        }
        [TestMethod]
        public void TestDateTimeStringValue()
        {
            DateTimeVariable var = new DateTimeVariable();
            Assert.IsTrue(var.CheckForStore("2016-01-01"));
        }
        [TestMethod]
        public void TestNotDateTimeStringValue()
        {
            DateTimeVariable var = new DateTimeVariable();
            Assert.IsFalse(var.CheckForStore("not date time string"));
        }
        [TestMethod]
        public void TestDateTimeVariableNullValue()
        {
            DateTimeVariable var = new DateTimeVariable();
            bool actual = var.CheckForStore(null);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void TestGetDateTimeType()
        {
            DateTimeVariable var = new DateTimeVariable();
            Assert.AreEqual("datetime", var.StoreType);
        }
    }
}
