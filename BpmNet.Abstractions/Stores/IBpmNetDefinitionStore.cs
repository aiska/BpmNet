using BpmNet.Bpmn;
using BpmNet.Model;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Stores
{
    /// <summary>
    /// Provides methods allowing to manage the applications stored in a database.
    /// </summary>
    /// <typeparam name="TDefinition">The type of the Application entity.</typeparam>
    public interface IBpmNetDefinitionStore<TDefinition>
        where TDefinition : class, IBpmNetDefinition
    {
        Task<long> CountAsync(CancellationToken cancellationToken);
        Task<long> CountAsync<TResult>(Func<IQueryable<TDefinition>, IQueryable<TResult>> query, CancellationToken cancellationToken);
        Task CreateAsync(TDefinition definition, CancellationToken cancellationToken);
        Task UpdateAsync(TDefinition definition, CancellationToken cancellationToken);
        Task DeleteAsync(TDefinition definition, CancellationToken cancellationToken);
        Task<TDefinition> FindByIdAsync(string id, CancellationToken cancellationToken);
        Task<bool> IsExistsAsync(Expression<Func<TDefinition, bool>> predicate, CancellationToken cancellationToken);
        Task<TDefinition[]> GetLatestDefinitionAsync(DateTime lastCheck, CancellationToken cancellationToken);
        Task<string[]> GetXmlLatestAsync(DateTime lastCheck, CancellationToken cancellationToken);
        //Task<BpmnProcess> GetProcessAsync(string processId, CancellationToken cancellationToken);
        Task<BpmnDefinitions> GetDefinitionAsync(string definitionId, CancellationToken cancellationToken);
        Task SaveDefinitionAsync(BpmnDefinitions bpmn, string content, bool replace, CancellationToken cancellationToken);
    }
}
