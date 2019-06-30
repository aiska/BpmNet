using BpmNet.Serializer;
using BpmNet.Bpmn;
using BpmNet.Model;
using BpmNet.Resolvers;
using BpmNet.Stores;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Core.Services
{
    public class BpmNetDefinitionService<TDefinition> : IBpmNetDefinitionService
        where TDefinition : class, IBpmNetDefinition, new()
    {

        private readonly IBpmNetDefinitionStore<TDefinition> _definitionStore;
        private readonly IBpmNetSerializer _serializer;

        protected ILogger Logger { get; }

        public BpmNetDefinitionService(
            IBpmNetStoreResolver storeResolver,
            IBpmNetSerializer serializer,
            ILogger<BpmNetDefinitionService<TDefinition>> logger)
        {
            _definitionStore = storeResolver.GetDefinitionStore<TDefinition>();
            _serializer = serializer;
            Logger = logger;
        }

        public Task<BpmnDefinitions> DeployAsync(string filePath, CancellationToken cancellationToken) => DeployAsync(filePath, false, cancellationToken);
        public Task<BpmnDefinitions> DeployAsync(Stream stream, CancellationToken cancellationToken) => DeployAsync(stream, false, cancellationToken);

        public async Task<BpmnDefinitions> DeployAsync(Stream stream, bool replace, CancellationToken cancellationToken)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            Task[] tasks = new Task[2];

            // Deserialize to BpmnDefinitions
            var bpmnTask = _serializer.DeserializeBpmnStreamAsync(stream, cancellationToken);

            // Deserialize to String
            var contentTask = _serializer.DeserializeStreamAsync(stream, cancellationToken);

            Task.WaitAll(bpmnTask, contentTask);

            await _definitionStore.SaveDefinitionAsync(bpmnTask.Result, contentTask.Result, replace, cancellationToken);

            return bpmnTask.Result;
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