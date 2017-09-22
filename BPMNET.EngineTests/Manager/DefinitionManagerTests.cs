using BPMNET.Entity;
using BPMNET.Entity.Store;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BPMNET.Engine.Manager.Tests
{
    [TestClass()]
    public class DefinitionManagerTests : IDisposable
    {
        DefinitionManager<int, ProcessDefinitionStore, DeploymentEntity> manager;

        public DefinitionManagerTests()
        {
            using (BpmDbContext context = new BpmDbContext())
            {
                context.Database.CreateIfNotExists();
                context.Database.Initialize(true);
            }
            ProcessDefinitionStore store = new ProcessDefinitionStore();
            manager = new DefinitionManager<int, ProcessDefinitionStore, DeploymentEntity>(store);
        }

        [TestMethod()]
        public async Task DeployBpmnAsyncTest()
        {
            DeploymentEntity result;
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
            FileInfo item;
            item = path.GetFiles("LosFlow4.bpmn").FirstOrDefault();
            result = await manager.DeployBpmnAsync(item.FullName, "deploy1", null);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeployBpmnTest()
        {
            DeploymentEntity result;
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
            FileInfo item;
            item = path.GetFiles("subProcess.bpmn2").FirstOrDefault();
            result = manager.DeployBpmn(item.FullName, "deploy2", null);
        }

        [TestMethod()]
        public void Dispose()
        {
            manager.Dispose();
        }
    }
}