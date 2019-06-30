using BpmNet.Bpmn;
using BpmNet.Model;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Stores
{
    public interface IBpmNetProcessStore<TProcess>
        where TProcess : class, IBpmNetProcess
    {
        Task<long> CountAsync(CancellationToken cancellationToken);
        Task<long> CountAsync<TResult>(Func<IQueryable<TProcess>, IQueryable<TResult>> query, CancellationToken cancellationToken);
        Task<TProcess> FindByIdAsync(string id, CancellationToken cancellationToken);
        Task CreateAsync(TProcess process, CancellationToken cancellationToken);
        Task UpdateAsync(TProcess process, CancellationToken cancellationToken);
        Task DeleteAsync(TProcess process, CancellationToken cancellationToken);
        Task DeleteByDefinitionAsync(string definitionId, CancellationToken cancellationToken);
        Task<bool> IsExistsAsync(Expression<Func<TProcess, bool>> predicate, CancellationToken cancellationToken);
        Task<TProcess> GetProcessAsync(string processId, CancellationToken cancellationToken);
        Task SaveProcessAsync(BpmnDefinitions bpmn, bool replace, CancellationToken cancellationToken);
        Task<TProcess[]> GetLatestProcessAsync(DateTime lastCheck, CancellationToken cancellationToken);
    }
}
