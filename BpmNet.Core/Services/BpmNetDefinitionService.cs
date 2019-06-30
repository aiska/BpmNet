using BpmNet.Bpmn;
using BpmNet.Model;
using BpmNet.Resolvers;
using BpmNet.Serializer;
using BpmNet.Stores;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Core.Services
{
    public class BpmNetDefinitionService<TDefinition, TProcess> : IBpmNetDefinitionService
        where TDefinition : class, IBpmNetDefinition, new()
        where TProcess : class, IBpmNetProcess
    {

        private readonly IBpmNetDefinitionStore<TDefinition> _definitionStore;
        private readonly IBpmNetProcessStore<TProcess> _processStore;
        private readonly IBpmNetSerializer _serializer;

        protected ILogger Logger { get; }

        public BpmNetDefinitionService(
            IBpmNetStoreResolver storeResolver,
            IBpmNetSerializer serializer,
            ILogger<BpmNetDefinitionService<TDefinition, TProcess>> logger)
        {
            _definitionStore = storeResolver.GetDefinitionStore<TDefinition>();
            _processStore = storeResolver.GetProcessStore<TProcess>();
            _serializer = serializer;
            Logger = logger;
        }

        public Task<BpmnDefinitions> DeployAsync(string filePath, CancellationToken cancellationToken) => DeployAsync(filePath, false, cancellationToken);

        public Task<BpmnDefinitions> DeployAsync(Stream stream, CancellationToken cancellationToken) {
            return DeployAsync(stream, false, cancellationToken);
        } 

        public Task<BpmnDefinitions> DeployAsync(Stream stream, bool replace, CancellationToken cancellationToken)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            // Deserialize to BpmnDefinitions
            var bpmnTask = _serializer.DeserializeBpmnStreamAsync(stream, cancellationToken);
            var contentTask = _serializer.DeserializeStreamAsync(stream, cancellationToken);

            Task.WaitAll(bpmnTask, contentTask);

            var definitionTask = _definitionStore.SaveDefinitionAsync(bpmnTask.Result, contentTask.Result, replace, cancellationToken);

            // Save Process.
            var process = _processStore.SaveProcessAsync(bpmnTask.Result, replace, cancellationToken);

            // Wait Task
            Task.WaitAll(definitionTask, process);

            return bpmnTask;

        }

        public async Task<BpmnDefinitions> DeployAsync(string filePath, bool replace, CancellationToken cancellationToken)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            using (var stream = File.OpenRead(filePath))
            {
                return await DeployAsync(stream, replace, cancellationToken);
            }
        }

        public Task<bool> IsExistsAsync(string id, CancellationToken cancellationToken)
        {
            return _definitionStore.IsExistsAsync(t => t.Id == id, cancellationToken);
        }

        public Task<BpmnDefinitions> GetDefinitionAsync(string definitionId, CancellationToken cancellationToken)
        {
            return _definitionStore.GetDefinitionAsync(definitionId, cancellationToken);
        }

    }
}