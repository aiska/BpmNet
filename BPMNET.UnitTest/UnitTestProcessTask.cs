using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Entity;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class UnitTestProcessTask
    {
        [TestMethod]
        public void TestProcessTask()
        {
            ProcessTask data = new ProcessTask();
            data.Assignee = "assignee";
            data.BusinessKey = "BusinessKey";
            data.Category = "";
            data.Description = "";
            data.ExecutionId = Guid.NewGuid().ToString();
            data.getDueDate = DateTime.Now;
            data.TaskVariables = new Dictionary<string, object>();
            data.Name = "";
            data.Owner = "";
            data.ParentTaskId = Guid.NewGuid().ToString();
            data.Priority = 1;
            data.ProcessDefinitionId = Guid.NewGuid().ToString();
            data.ProcessInstanceId = Guid.NewGuid().ToString();
            data.ProcessItemDefinitionId = "";
            data.TaskDate = DateTime.Now;
            data.ProcessTaskId = Guid.NewGuid().ToString();
            data.TenantId = "";
            Assert.IsNotNull(data.Assignee);
            Assert.IsNotNull(data.BusinessKey);
            Assert.IsNotNull(data.Category);
            Assert.IsNotNull(data.Description);
            Assert.IsNotNull(data.ExecutionId);
            Assert.IsNotNull(data.getDueDate);
            Assert.IsNotNull(data.TaskVariables);
            Assert.IsNotNull(data.Name);
            Assert.IsNotNull(data.Owner);
            Assert.IsNotNull(data.ParentTaskId);
            Assert.IsNotNull(data.Priority);
            Assert.IsNotNull(data.ProcessDefinitionId);
            Assert.IsNotNull(data.ProcessItemDefinitionId);
            Assert.IsNotNull(data.ProcessTaskId);
            Assert.IsNotNull(data.TenantId);
        }
    }
}
