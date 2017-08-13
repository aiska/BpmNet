using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BPMNET.EntityCore.Tests
{
    [TestClass()]
    public class ProcessInstanceStoreTests
    {
        [TestMethod()]
        public void ProcessInstanceStoreTest()
        {
            ProcessInstanceStore store = new ProcessInstanceStore();
            Assert.IsNotNull(store);
        }

        [TestMethod()]
        public void ProcessInstanceStoreTest1()
        {
            using (BpmDbContext db = new BpmDbContext())
            {
                ProcessInstanceStore store = new ProcessInstanceStore(db);
                Assert.IsNotNull(store);
            }
        }

        [TestMethod()]
        public void FindByIdTest()
        {
            ProcessInstanceStore store = new ProcessInstanceStore();
            ProcessInstance pi = store.FindById(Guid.NewGuid());
            Assert.IsNull(pi);
            store.Dispose();
        }

        [TestMethod()]
        public void CRUDTest()
        {
            ProcessInstanceStore store = new ProcessInstanceStore();
            ProcessInstance pi = new ProcessInstance() {
                BusinessKey = "BusinessKey",
                Owner = "aiska",
                ProcessKey = Guid.NewGuid(),
                ProcessInstanceId = Guid.NewGuid(),
                ProcessInstanceName = "ProcessInstanceName",
                UserCandidates = ""
            };
            store.Create(pi);
            pi.Owner = "Aiska Hendra";
            store.Update(pi);
            store.Delete(pi);
            store.Dispose();
        }

        [TestMethod()]
        public void MultipleSelect()
        {
            ProcessInstanceStore store = new ProcessInstanceStore();
            ProcessInstance pi = new ProcessInstance()
            {
                BusinessKey = "BusinessKey",
                Owner = "aiska",
                ProcessKey = Guid.NewGuid(),
                ProcessInstanceId = Guid.NewGuid(),
                ProcessInstanceName = "ProcessInstanceName",
                UserCandidates = ""
            };
            store.Create(pi);

            ProcessInstance pi2 = store.FindById(pi.ProcessInstanceId);
            ProcessInstance pi3 = store.FindById(pi.ProcessInstanceId);
            ProcessInstance pi4 = store.FindById(pi.ProcessInstanceId);
        }
    }
}