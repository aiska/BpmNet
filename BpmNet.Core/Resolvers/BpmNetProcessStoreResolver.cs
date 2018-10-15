using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace BpmNet.Core
{
    public class BpmNetProcessStoreResolver : IBpmNetStoreResolver
    {
        private readonly IServiceProvider _provider;

        public BpmNetProcessStoreResolver(IServiceProvider provider)
        {
            _provider = provider;
        }
    }
}
