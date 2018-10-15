using BpmNet.Model;
using System;

namespace BpmNet.Stores
{
    public interface IBpmNetHistoryStore<THistory> : IStore<Guid, THistory>
        where THistory : class, IBpmNetHistory
    {
    }
}
