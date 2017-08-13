using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMNET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNET.Entity;
using System.Diagnostics;

namespace BPMNET.Core.Tests
{

    public class ProcessDefinitionStoreD : Core.ProcessDefinitionStore<string, ProcessDefinition>
    {
        public override IQueryable<ProcessDefinition> Entities
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Task CreateAsync(ProcessDefinition item)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(ProcessDefinition item)
        {
            throw new NotImplementedException();
        }

        public override Task<ProcessDefinition> FindByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(ProcessDefinition item)
        {
            throw new NotImplementedException();
        }
    }

    [TestClass()]
    public class ProcessDefinitionStoreTests
    {
        ProcessDefinitionStoreD store;
        ProcessDefinition pd;
        public ProcessDefinitionStoreTests()
        {
            store = new ProcessDefinitionStoreD();
            pd = new ProcessDefinition();
            pd.ProcessDefinitionId = Guid.NewGuid().ToString();
            store.Create(pd);

        }

        [TestMethod()]
        public void ProcessDefinitionStoreTest()
        {
            ProcessDefinitionStoreD actual = new ProcessDefinitionStoreD();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void DisposeTest()
        {
            ProcessDefinitionStoreD actual = new ProcessDefinitionStoreD();
            actual.Dispose();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void CreateTest()
        {
            store.Create(pd);
        }

        //[TestMethod()]
        //public void Create1000Test()
        //{
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        var t = new ProcessDefinition();
        //        t.ProcessDefinitionId = Guid.NewGuid().ToString();
        //        store.Create(t);
        //    }
        //}


        [TestMethod()]
        public void CacheCreate100000TestAsync()
        {
            Stopwatch w = new Stopwatch();
            w.Start();
            var store = new ProcessDefinitionStoreD();
            Task[] task = new Task[100000];
            for (int i = 0; i < 100000; i++)
            {
                task[i] = Task.Run(() => {
                    var t = new ProcessDefinition();
                    t.ProcessDefinitionId = Guid.NewGuid().ToString();
                    store.Create(t);
                });
            }
            Task.WaitAll(task);
            w.Stop();
            Debug.WriteLine("CacheCreate100000TestAsync : " + w.ElapsedMilliseconds + "ms");
            store.Dispose();
        }

        [TestMethod()]
        public void CacheCreate100000Test()
        {
            Stopwatch w = new Stopwatch();
            w.Start();
            var store = new ProcessDefinitionStoreD();
            for (int i = 0; i < 100000; i++)
            {

                var t = new ProcessDefinition();
                t.ProcessDefinitionId = Guid.NewGuid().ToString();
                store.Create(t);
            }
            w.Stop();
            Debug.WriteLine("CacheCreate100000Test : " + w.ElapsedMilliseconds + "ms");
            store.Dispose();
        }

        [TestMethod()]
        public void CacheCreate1000000TestAsync()
        {
            Stopwatch w = new Stopwatch();
            w.Start();
            var store = new ProcessDefinitionStoreD();
            Task[] task = new Task[1000000];
            for (int i = 0; i < 1000000; i++)
            {
                task[i] = Task.Run(() => {
                    var t = new ProcessDefinition();
                    t.ProcessDefinitionId = Guid.NewGuid().ToString();
                    store.Create(t);
                });
            }
            Task.WaitAll(task);
            w.Stop();
            Debug.WriteLine("CacheCreate1000000TestAsync : " + w.ElapsedMilliseconds + "ms");
            store.Dispose();
        }

        [TestMethod()]
        public void CacheCreate1000000Test()
        {
            Stopwatch w = new Stopwatch();
            w.Start();
            var store = new ProcessDefinitionStoreD();
            w.Stop();
            Debug.WriteLine("Initialize instance : " + w.ElapsedMilliseconds + "ms");
            w.Restart();
            for (int i = 0; i < 1000000; i++)
            {

                var t = new ProcessDefinition();
                t.ProcessDefinitionId = Guid.NewGuid().ToString();
                store.Create(t);
            }
            w.Stop();
            Debug.WriteLine("Add1000000Test : " + w.ElapsedMilliseconds + "ms");
            w.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                var t = new ProcessDefinition();
                t.ProcessDefinitionId = Guid.NewGuid().ToString();
                store.Create(t);
            }
            w.Stop();
            Debug.WriteLine("Add1000000Test : " + w.ElapsedMilliseconds + "ms");
            store.Dispose();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            store.Update(pd);
        }

        //[TestMethod()]
        //public void FindByIdTest()
        //{
        //    var actual = store.FindById(pd.ProcessDefinitionId);
        //    Assert.IsNotNull(actual);
        //}

        [TestMethod()]
        public void DeleteTest()
        {
            store.Delete(pd);
        }

        [TestMethod()]
        public void CreateAsyncTest()
        {

        }

        [TestMethod()]
        public void UpdateAsyncTest()
        {

        }

        [TestMethod()]
        public void DeleteAsyncTest()
        {

        }

        [TestMethod()]
        public void FindByIdAsyncTest()
        {

        }
    }
}