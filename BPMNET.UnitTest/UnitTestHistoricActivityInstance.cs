using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Entity;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class UnitTestHistoricActivityInstance
    {
        [TestMethod]
        public void TestHistoricActivityInstance1()
        {
            HistoricActivityInstance data = new HistoricActivityInstance();
            data.Assignee = "Assigne";
            data.BpmId = Guid.NewGuid().ToString();
            data.BpmName = "BpmnName";
            data.BpmType = "Type";
            data.CalledProcessInstanceId = Guid.NewGuid().ToString();
            data.DurationInMillis = 0;
            data.EndTime = new DateTime();
            data.ExecutionId = Guid.NewGuid().ToString();
            data.Id = Guid.NewGuid().ToString();
            data.ProcessDefinitionId = Guid.NewGuid().ToString();
            data.ProcessInstanceId = Guid.NewGuid().ToString();
            data.StartTime = new DateTime();
            data.TaskId = Guid.NewGuid().ToString();
            data.TenantId = "tenant";
            Assert.IsNotNull(data.Assignee);
            Assert.IsNotNull(data.BpmId);
            Assert.IsNotNull(data.BpmName);
            Assert.IsNotNull(data.BpmType);
            Assert.IsNotNull(data.CalledProcessInstanceId);
            Assert.IsNotNull(data.DurationInMillis);
            Assert.IsNotNull(data.EndTime);
            Assert.IsNotNull(data.ExecutionId);
            Assert.IsNotNull(data.Id);
            Assert.IsNotNull(data.ProcessDefinitionId);
            Assert.IsNotNull(data.ProcessInstanceId);
            Assert.IsNotNull(data.StartTime);
            Assert.IsNotNull(data.TaskId);
            Assert.IsNotNull(data.TenantId);
        }
    }
}
