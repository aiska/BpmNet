using BPMNET.Bpmn;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;

namespace BPMNET.EntityCore.Manager.Tests
{
    [TestClass()]
    public class DeploymentManagerTests
    {
        [TestMethod()]
        public void DeployBpmnTest()
        {
            using (BpmDbContext db = new BpmDbContext())
            {
                DeploymentManager manager = new DeploymentManager(db);
                string bpmnFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\LosFlow.bpmn";
                manager.DeployBpmn(bpmnFile);
            }
        }

        [TestMethod()]
        public void printTest()
        {
            string[] enums = Enum.GetNames(typeof(ItemElementType));
            foreach (var item in enums)
            {
                Debug.Print("public bool Is" + item + "(tRootElement element) { return element is t" + item + "; }");
            }
        }

        [TestMethod()]
        public void printTest2()
        {
            string[] enums = Enum.GetNames(typeof(ItemElementType));
            foreach (var item in enums)
            {
                Debug.Print("else if (Is" + item + "(element))");
                Debug.Print("{");
                Debug.Print("return ItemElementType." + item + ";");
                Debug.Print("}");
            }
        }
    }
}