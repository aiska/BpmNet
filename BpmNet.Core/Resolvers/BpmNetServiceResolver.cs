using BpmNet.Model;
using BpmNet.Stores;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
namespace BpmNet.Core.Resolvers
{
    public class BpmNetServiceResolver
    {
        private readonly IServiceProvider _provider;
        public BpmNetServiceResolver(IServiceProvider provider)
        {
            _provider = provider;
        }
        public IProcessFlowService<TInstance, TInstanceFlow, TFlow> GetProcessFlowService<TInstance, TInstanceFlow, TFlow>()
            where TInstance : class, IProcessInstance<TInstanceFlow>
            where TInstanceFlow : class, IBpmNetInstanceFlow
            where TFlow : class, IBpmNetFlow
        {
            var service = _provider.GetService<IProcessFlowService<TInstance, TInstanceFlow, TFlow>>();
            if (service != null)
            {
                return service;
            }
        }

    }
}
