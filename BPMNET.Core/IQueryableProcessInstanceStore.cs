using System;
using System.Linq;

namespace BPMNET.Core
{
    public interface IQueryableProcessInstanceStore<TProcessInstance, TKey>
        where TProcessInstance : class, IProcessInstance<TKey>
        where TKey : IEquatable<TKey>
    {
        IQueryable<TProcessInstance> ProcessInstances { get; }
    }
}