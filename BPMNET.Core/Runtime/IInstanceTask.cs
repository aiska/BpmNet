using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IInstanceTask<TKey>
        where TKey : IEquatable<TKey>
    {
        Task ClaimTask(IUser user);
        Task CompleteTask(IDictionary<string, object> variables);
        Task AssignTask(IUser user);
        Task AssignTask(IUser user, IDictionary<string, object> variables);
    }
}
