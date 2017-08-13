using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Caching;
using System.Diagnostics;
using BPMNET.Entity;

namespace BPMNET.UnitTest
{
    [TestClass]
    public class MemoryCacheTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Stopwatch w = new Stopwatch();
            int count = 30;
            w.Start();
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.SlidingExpiration = new TimeSpan(1, 0, 0);
            MemoryCache cache = new MemoryCache("test");
            string[] keys = new string[count];
            for (int i = 0; i < count; i++)
            {
                keys[i] = Guid.NewGuid().ToString();
            }
            w.Stop();
            Debug.WriteLine("Create Instance : " + w.ElapsedMilliseconds + "ms");
            w.Restart();
            for (int i = 0; i < count; i++)
            {
                var t = new ProcessDefinition();
                t.ProcessDefinitionId = keys[i];
                cache.Add(keys[i], t, policy);
            }
            w.Stop();
            Debug.WriteLine("Add " + count + " Test : " + w.ElapsedMilliseconds + "ms");
            w.Restart();
            for (int i = 0; i < count; i++)
            {
                var val = cache.Get(keys[i]);
            }
            w.Stop();
            Debug.WriteLine("Get " + count + " Test : " + w.ElapsedMilliseconds + "ms");
            w.Restart();
            foreach (var item in cache)
            {
                var val = item.Value as ProcessDefinition;
                val.UpdateDate = DateTime.Now;
                val.Name = "update";
                cache.Set(item.Key, val, policy);
            }
            w.Stop();
            Debug.WriteLine("Update " + count + " Test : " + w.ElapsedMilliseconds + "ms");
            w.Restart();
            for (int i = 0; i < count; i++)
            {
                cache.Remove(keys[i]);
            }
            w.Stop();
            Debug.WriteLine("Remove " + count + " Test : " + w.ElapsedMilliseconds + "ms");

        }
    }
}
