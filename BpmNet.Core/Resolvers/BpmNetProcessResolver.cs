using BpmNet.Model;
using BpmNet.Resolvers;
using BpmNet.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace BpmNet.Core.Resolvers
{
    public class BpmNetProcessResolver : IBpmNetProcessResolver
    {
        private readonly IServiceProvider _provider;

        public BpmNetProcessResolver(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IBpmNetSequenceFlowProcessService<TInstance, TSequenceFlow> GetSequenceFlowProcess<TInstance, TSequenceFlow>()
            where TInstance : IProcessInstance
            where TSequenceFlow : IBpmNetSequenceFlow
        {
            throw new NotImplementedException();
        }

        public IBpmNetStartEventProcessService<TInstance, TStartEvent> GetStartEventProcess<TInstance, TStartEvent>()
            where TInstance : IProcessInstance
            where TStartEvent : IBpmNetStartEvent
        {
            var process = _provider.GetService<IBpmNetStartEventProcessService<TInstance, TStartEvent>>();
            if (process == null)
            {
                throw new InvalidOperationException(new StringBuilder()
                    .AppendLine("No definition store has been registered in the dependency injection container.")
                    .Append("To register the Entity Framework Core stores, reference the 'BpmNet.EntityFrameworkCore' ")
                    .AppendLine("package and call 'services.AddBpmNet().AddCore().UseEntityFrameworkCore()'.")
                    .Append("To register a custom store, create an implementation of 'IBpmNetDefinitionStore' and ")
                    .Append("use 'services.AddBpmNet().AddCore().AddDefinitionStore()' to add it to the DI container.")
                    .ToString());
            }
            return process;
        }
    }
}
