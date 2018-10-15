using BpmNet.Model;
using BpmNet.Stores;
using Microsoft.EntityFrameworkCore;
using System;

namespace BpmNet.EntityFrameworkCore.Stores
{
    public class BpmNetHistoryStore<TContext, THistory> : BaseStore<TContext, Guid, THistory>, IBpmNetHistoryStore<THistory>
        where TContext : DbContext
        where THistory : class, IBpmNetHistory
    {
        public BpmNetHistoryStore(TContext context) : base(context)
        {
        }
    }
}
