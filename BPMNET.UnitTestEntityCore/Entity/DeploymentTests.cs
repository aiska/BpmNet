using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BPMNET.EntityCore.Tests
{
    [TestClass()]
    public class DeploymentTests
    {
        [TestMethod()]
        public void GetHashCodeTest()
        {
            Deployment deployment = new Deployment();
            Assert.IsNull(deployment.DeploymentName);
            Assert.IsNull(deployment.DeploymentCategory);
            Assert.IsNull(deployment.DeploymentTenantId);
            Assert.IsNull(deployment.DeploymentVersion);
            Assert.AreEqual(deployment.Inserted, default(DateTime));
            Assert.AreEqual(deployment.LastUpdated, default(DateTime));
            Assert.IsNotNull(deployment.GetHashCode());
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Deployment deployment = new Deployment();
            object deploymentCompare = new Deployment();
            Assert.IsTrue(deployment.Equals(deploymentCompare));
        }

        [TestMethod()]
        public void EqualsTest1()
        {
            Deployment deployment = new Deployment();
            Deployment deploymentCompare = new Deployment();
            Assert.IsTrue(deployment.Equals(deploymentCompare));
        }
    }
}