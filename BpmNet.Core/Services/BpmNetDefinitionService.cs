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

        protected ILogger Logger { get; }

        public BpmNetDefinitionService(
            IBpmNetStoreResolver storeResolver,
            ILogger<BpmNetDefinitionService<TDefinition>> logger)
        {
            _definitionStore = storeResolver.GetDefinitionStore<TDefinition>();
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

            using (MemoryStream ms = new MemoryStream())
            using (StreamReader sr = new StreamReader(stream))
            {
                stream.CopyTo(ms);
                stream.Position = 0;
                ms.Position = 0;
                var bpmnTask = SerializerService.DeserializeAsync(ms, cancellationToken);
                var content = sr.ReadToEndAsync();
                var bpmn = await bpmnTask;
                await _definitionStore.SaveDefinitionAsync(bpmn, await content, replace, cancellationToken);
                return bpmn;
            }
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