using BpmNet.Bpmn;
using BpmNet.Model;
using BpmNet.Stores;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Cache
{
    public interface IDefinitionCache
    {
        void AddOrUpdateDefinitionCache(BpmnDefinitions bpmn);
        bool TryGetProcess(string processId, out BpmnProcess value);
        bool TryGetDefinition(string definitionId, out BpmnDefinitions value);
        Task LoadDefinitionFromStoreAsync<TDefinition>(IBpmNetDefinitionStore<TDefinition> store, CancellationToken cancellationToken)
            where TDefinition: class, IBpmNetDefinition;
    }
}
