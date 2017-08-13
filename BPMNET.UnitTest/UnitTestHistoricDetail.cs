using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Entity;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class UnitTestHistoricDetail
    {
        [TestMethod]
        public void TestHistoricDetail1()
        {
            HistoricDetail data = new HistoricDetail();
            data.BpmInstanceId = Guid.NewGuid().ToString();
            data.CreateDate = new DateTime();
            data.ExecutionId = Guid.NewGuid().ToString();
            data.Id = Guid.NewGuid().ToString();
            data.ProcessInstanceId = Guid.NewGuid().ToString();
            data.TaskId = Guid.NewGuid().ToString();
            Assert.IsNotNull(data.BpmInstanceId);
            Assert.IsNotNull(data.CreateDate);
            Assert.IsNotNull(data.ExecutionId);
            Assert.IsNotNull(data.Id);
            Assert.IsNotNull(data.ProcessInstanceId);
            Assert.IsNotNull(data.TaskId);
        }
    }
}
