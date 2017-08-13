using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPMNET.Core
{
    public interface IProcessTaskManager<TKey, TProcessTask, TProcessInstance, TIdentityLink, TProcessItemDefinition>
    {
        Task CreateStartTaskAsync(TProcessInstance processInstance, TProcessItemDefinition startFlow);
        void CreateStartTask(TProcessInstance processInstance, TProcessItemDefinition startFlow);
        Task<List<TProcessInstance>> GetAssignedTask(TProcessInstance processInstance, string user);
        Task<List<TProcessInstance>> GetUnassignedTask(TProcessInstance processInstance);
        Task<List<TProcessInstance>> GetCandidateTask(TProcessInstance processInstance, string user);
        Task<List<TProcessInstance>> GetCandidateAndAssignedTask(TProcessInstance processInstance, string user);
        Task<List<TProcessInstance>> GetActiveTask(TProcessInstance processInstance);
        Task<List<TProcessInstance>> GetAllTask(TProcessInstance processInstance);
        Task<List<TProcessInstance>> GetSuspendedTask(TProcessInstance processInstance);
        void AssignTask(TProcessInstance processInstance, string AssignToUser, string user);
        void ClaimTask(TProcessInstance processInstance, string user);
        void UnclaimTask(TProcessInstance processInstance, string user);
        void ProceedTask(TProcessInstance processInstance, string user);
        void SendTask(TProcessInstance processInstance, TProcessItemDefinition ProcessItemDefinition);
        void SuspendTask(TProcessInstance processInstance, string user);
        void ReleaseTask(TProcessInstance processInstance, string user);
    }
}
