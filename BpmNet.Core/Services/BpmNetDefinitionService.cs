using BpmNet.Bpmn;
using BpmNet.Model;
using BpmNet.Resolvers;
using BpmNet.Serializer;
using BpmNet.Stores;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _cache;

        private readonly IBpmNetDefinitionStore<TDefinition> _definitionStore;
        private readonly IBpmNetProcessStore<TProcess> _processStore;
        private readonly IBpmNetSerializer _serializer;

        protected ILogger Logger { get; }

        public BpmNetDefinitionService(
            IMemoryCache cache,
            IBpmNetStoreResolver storeResolver,
            IBpmNetSerializer serializer,
            ILogger<BpmNetDefinitionService<TDefinition, TProcess>> logger)
        {
            _cache = cache;
            _definitionStore = storeResolver.GetDefinitionStore<TDefinition>();
            _processStore = storeResolver.GetProcessStore<TProcess>();
            _serializer = serializer;
            Logger = logger;
        }

        public Task<BpmnDefinitions> DeployAsync(string filePath, CancellationToken cancellationToken) => DeployAsync(filePath, false, cancellationToken);

        public Task<BpmnDefinitions> DeployAsync(Stream stream, CancellationToken cancellationToken) {
            return DeployAsync(stream, false, cancellationToken);
        } 

        public async Task<BpmnDefinitions> DeployAsync(Stream stream, bool replace, CancellationToken cancellationToken)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            BpmnDefinitions bpmn = null;

            // Deserialize to BpmnDefinitions
            using (MemoryStream bpmnStream = new MemoryStream())
            {
                stream.CopyTo(bpmnStream);
                bpmn = await _serializer.DeserializeBpmnStreamAsync(bpmnStream, cancellationToken);
            }

            var content = await _serializer.DeserializeStreamAsync(stream, cancellationToken);

            await _definitionStore.SaveDefinitionAsync(bpmn, content, replace, cancellationToken);

            // Save Process.
            await _processStore.SaveProcessAsync(bpmn, replace, cancellationToken);

            // Store bpmn to Memory cache
            _cache.Set(string.Concat(Cache.Prefix.BpmnDefinition, bpmn.Id), bpmn);

            return bpmn;
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
            return _cache.GetOrCreateAsync(string.Concat(Cache.Prefix.BpmnDefinition, definitionId), def =>
            {
                return _definitionStore.FindByIdAsync(definitionId, cancellationToken).ContinueWith(t =>
                {
                    return SerializerService.DeserializeFromStringAsync(t.Result.Xml, cancellationToken);
                }).Unwrap();
            });
        }
    }
}