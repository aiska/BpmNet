using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BPMNET.EntityCore.Store.Tests
{
    [TestClass()]
    public class DeploymentStoreTests
    {
        [TestMethod()]
        public void DeploymentStoreTest()
        {
            DeploymentStore store = new DeploymentStore();
            Assert.IsNotNull(store);
        }

        [TestMethod()]
        public void DeploymentStoreTest1()
        {
            using (BpmDbContext db = new BpmDbContext())
            {
                DeploymentStore store = new DeploymentStore(db);
                Assert.IsNotNull(store);
            }
        }

        [TestMethod()]
        public void FindByIdTest()
        {
            DeploymentStore store = new DeploymentStore();
            Deployment pi = store.FindById(Guid.NewGuid());
            Assert.IsNull(pi);
            store.Dispose();
        }

        [TestMethod()]
        public void CRUDTest()
        {
            DeploymentStore store = new DeploymentStore();
            Deployment pi = new Deployment()
            {
                DeploymentCategory = "DeploymentCategory",
                DeploymentTenantId = "DeploymentTenantId",
                DeploymentVersion = "1.0"
            };
            store.Create(pi);
            pi.DeploymentCategory = "DeploymentCategory2";
            store.Update(pi);
            store.Delete(pi);
            store.Dispose();
        }

        [TestMethod()]
        public void MultipleSelect()
        {
            DeploymentStore store = new DeploymentStore();
            Deployment pi = new Deployment()
            {
                DeploymentCategory = "DeploymentCategory",
                DeploymentTenantId = "DeploymentTenantId",
                DeploymentVersion = "1.0"
            };
            store.Create(pi);

            Deployment pi2 = store.FindById(pi.DeploymentId);
            Deployment pi3 = store.FindById(pi.DeploymentId);
            Deployment pi4 = store.FindById(pi.DeploymentId);
        }
    }
}