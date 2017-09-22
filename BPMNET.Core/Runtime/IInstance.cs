using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IInstance<TKey, TSubProcess, TInstanceTask>
        where TKey : IEquatable<TKey>
        where TSubProcess : IInstance<TKey, TSubProcess, TInstanceTask>
        where TInstanceTask : IInstanceTask<TKey>
    {
        Task ActivateAsync();
        Task SuspendInstanceAsync(string reason);
        Task CancelInstanceAsync(string reason);
        Task<TSubProcess[]> GetAllSubProcess();
        Task<TInstanceTask> GetCurrentTask();
        Task<IDictionary<string, object>> GetVariables();
    }
}