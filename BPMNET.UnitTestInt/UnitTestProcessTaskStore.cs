using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Entity.IntKey;

namespace BPMNET.UnitTestInt
{
    [TestClass]
    public class UnitTestProcessTaskStore
    {
        [TestMethod]
        public void TestProcessTaskStore1()
        {
            ProcessTaskStore store = new ProcessTaskStore();
        }

        [TestMethod]
        public void TestProcessTaskStore2()
        {
            using (BpmDbContext context = new BpmDbContext())
            {
                ProcessTaskStore store = new ProcessTaskStore(context);
            }
        }
    }
}
