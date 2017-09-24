using BPMNET.Engine.Manager.Int;
using BPMNET.Entity;
using BPMNET.Entity.Store;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace BPMNET.Engine.Manager.Tests
{
    [TestClass()]
    public class DefinitionManagerExtensionTests
    {
        [TestMethod()]
        public void DeployBpmnTest()
        {
            using (DefinitionManager manager = new DefinitionManager(new ProcessDefinitionStore()))
            {
                DeploymentEntity result;
                var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
                FileInfo item;
                item = path.GetFiles("subProcess.bpmn2").FirstOrDefault();
                result = manager.DeployBpmn(item.FullName, "deploy2", null);
            }
        }
    }
}