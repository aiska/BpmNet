using BPMNET.Core;
using BPMNET.Core.Variable;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPMNET.Entity
{
    public class ProcessManager : ProcessManager<string, ProcessInstance, ProcessDefinition, ProcessTask>
    {

        public ProcessManager() : base(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public ProcessManager(BpmDbContext context) : base(context)
        {
        }
        public ProcessManager(IProcessDefinitionStore<string, ProcessDefinition> definitionStore,
            IProcessInstanceStore<string, ProcessInstance> instanceStore,
            IProcessTaskStore<string, ProcessTask> taskStore) :
            base(definitionStore, instanceStore, taskStore)
        {
        }
    }

    public abstract class ProcessManager<TKey, TProcessInstance, TProcessDefinition, TProcessTask> : IDisposable
        where TKey : IEquatable<TKey>
        where TProcessInstance : class, IProcessInstance<TKey>
        where TProcessDefinition : class, IProcessDefinition<TKey>
        where TProcessTask : class, IProcessTask<TKey>
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        private const string StoreNotIQueryableGroupStore = "Store does not implement IQueryableGroupStore<TGroup>";
        //private const string UNSUPPORT_MANAGER = "Unsupport ProcessInstanceManager";
        protected bool DisposeContext { private get; set; }
        private IProcessValidator<TKey, TProcessInstance, TProcessDefinition, TProcessTask> _processValidator;
        public IProcessValidator<TKey, TProcessInstance, TProcessDefinition, TProcessTask> ProcessValidator
        {
            get
            {
                return _processValidator;
            }
            set
            {
                Check.ThrowIfNull(value);
                _processValidator = value;
            }
        }
        protected IProcessDefinitionStore<TKey, TProcessDefinition> DefinitionStore { get; private set; }
        protected IProcessInstanceStore<TKey, TProcessInstance> InstanceStore { get; private set; }
        protected IProcessTaskStore<TKey, TProcessTask> TaskStore { get; private set; }
        protected ProcessVariablesStore<TKey> VariableStore { get; private set; }
        protected DefinitionVariableStore<TKey> DefinitionVariableStore { get; private set; }
        protected BpmDbContext<TKey, TProcessInstance, TProcessDefinition, TProcessTask> Context { get; private set; }

        #region Constructor ...
        public ProcessManager(BpmDbContext<TKey, TProcessInstance, TProcessDefinition, TProcessTask> context)
        {
            Context = context;
            DefinitionStore = new ProcessDefinitionStore<TKey, TProcessDefinition>(context);
            InstanceStore = new ProcessInstanceStore<TKey, TProcessInstance>(context);
            TaskStore = new ProcessTaskStore<TKey, TProcessTask>(context);
            VariableStore = new ProcessVariablesStore<TKey>(context);
            Initialize(Context);
        }

        public ProcessManager(IProcessDefinitionStore<TKey, TProcessDefinition> definitionStore,
            IProcessInstanceStore<TKey, TProcessInstance> instanceStore,
            IProcessTaskStore<TKey, TProcessTask> taskStore
            )
        {
            Check.ThrowIfNull(definitionStore);
            Check.ThrowIfNull(instanceStore);
            Check.ThrowIfNull(taskStore);
            DefinitionStore = definitionStore;
            InstanceStore = instanceStore;
            TaskStore = taskStore;
            Context = new BpmDbContext<TKey, TProcessInstance, TProcessDefinition, TProcessTask>();
            DisposeContext = true;
            Initialize(Context);
        }

        private void Initialize(BpmDbContext<TKey, TProcessInstance, TProcessDefinition, TProcessTask> context)
        {
            VariableStore = new ProcessVariablesStore<TKey>(context);
            DefinitionVariableStore = new DefinitionVariableStore<TKey>(context);
            _processValidator = new ProcessValidator<TKey, TProcessInstance, TProcessDefinition, TProcessTask>(this);

        }

        #endregion

        #region Dispose ...
        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                if (DisposeContext && Context != null)
                {
                    Context.Dispose();
                    Context = null;
                }
                DefinitionStore.Dispose();
                InstanceStore.Dispose();
            }
            _disposed = true;
        }
        #endregion

        #region Process Manager Routine

        #region Process Instance Routine ...
        public virtual IQueryable<TProcessInstance> ProcessInstances
        {
            get
            {
                IQueryableStore<TProcessInstance> processInstances = InstanceStore as IQueryableStore<TProcessInstance>;
                Check.ThrowIfNull(processInstances);
                return processInstances.Entities;
            }
        }

        public virtual IQueryable<TProcessDefinition> ProcessDefinitions
        {
            get
            {
                IQueryableStore<TProcessDefinition> processDefinition = DefinitionStore as IQueryableStore<TProcessDefinition>;
                if (processDefinition == null)
                    throw new NotSupportedException(StoreNotIQueryableGroupStore);
                return processDefinition.Entities;
            }
        }

        public virtual IQueryable<TProcessTask> ProcessTasks
        {
            get
            {
                IQueryableStore<TProcessTask> processTask = TaskStore as IQueryableStore<TProcessTask>;
                if (processTask == null)
                    throw new NotSupportedException(StoreNotIQueryableGroupStore);
                return processTask.Entities;
            }
        }

        public virtual async Task<TProcessInstance> FindProcessInstanceByIdAsync(TKey processInstanceId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processInstanceId);
            log.Trace(LogConstant.FindProcessInstanceByIdAsync, processInstanceId);
            return await InstanceStore.FindByIdAsync(processInstanceId).ConfigureAwait(false);
        }

        public TProcessInstance FindProcessInstanceById(TKey processInstanceId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processInstanceId);
            log.Trace(LogConstant.FindProcessInstanceById, processInstanceId);
            return InstanceStore.FindById(processInstanceId);
        }

        public virtual async Task<BpmResult> CreateProcessInstanceAsync(TProcessInstance processInstance)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processInstance);
            log.Trace(LogConstant.CreateProcessInstanceAsync, processInstance);
            BpmResult validateResult = await _processValidator.ValidateProcessInstanceAsync(processInstance).ConfigureAwait(false);
            if (!validateResult.Succeeded) return validateResult;
            await InstanceStore.CreateAsync(processInstance).ConfigureAwait(false);
            return BpmResult.Success;
        }

        public BpmResult CreateProcessInstance(TProcessInstance processInstance)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processInstance);
            log.Trace(LogConstant.CreateProcessInstance, processInstance);
            BpmResult validateResult = _processValidator.ValidateProcessInstance(processInstance);
            if (!validateResult.Succeeded) return validateResult;
            InstanceStore.Create(processInstance);
            return BpmResult.Success;
        }

        public virtual async Task<BpmResult> UpdateProcessInstanceAsync(TProcessInstance processInstance)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processInstance);
            log.Trace(LogConstant.UpdateProcessInstanceAsync, processInstance);
            BpmResult validateResult = await _processValidator.ValidateProcessInstanceAsync(processInstance).ConfigureAwait(false);
            if (!validateResult.Succeeded) return validateResult;
            await InstanceStore.UpdateAsync(processInstance);
            return BpmResult.Success;
        }

        public BpmResult UpdateProcessInstance(TProcessInstance processInstance)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processInstance);
            log.Trace(LogConstant.UpdateProcessInstance, processInstance);
            BpmResult validateResult = _processValidator.ValidateProcessInstance(processInstance);
            if (!validateResult.Succeeded) return validateResult;
            InstanceStore.Update(processInstance);
            return BpmResult.Success;
        }

        public virtual async Task<BpmResult> DeleteProcessInstanceAsync(TKey processInstanceId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processInstanceId);
            log.Trace(LogConstant.DeleteProcessInstanceAsync, processInstanceId);
            TProcessInstance current = await InstanceStore.FindByIdAsync(processInstanceId).ConfigureAwait(false);
            if (current == null)
                return BpmResult.Failed(EntityConstant.PROCESS_INSTANCE_NOT_FOUND);
            await InstanceStore.DeleteAsync(current);
            return BpmResult.Success;
        }

        public BpmResult DeleteProcessInstance(TKey processInstanceId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processInstanceId);
            log.Trace(LogConstant.DeleteProcessInstance, processInstanceId);
            TProcessInstance current = InstanceStore.FindById(processInstanceId);
            if (current == null)
                return BpmResult.Failed(EntityConstant.PROCESS_INSTANCE_NOT_FOUND);
            InstanceStore.Delete(current);
            return BpmResult.Success;
        }

        public virtual async Task<BpmResult> ActivateProcessInstanceByIdAsync(TKey processInstanceId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processInstanceId);
            log.Trace(LogConstant.ActivateProcessInstanceByIdAsync, processInstanceId);
            TProcessInstance current = await InstanceStore.FindByIdAsync(processInstanceId).ConfigureAwait(false);
            if (current == null)
                return BpmResult.Failed(EntityConstant.PROCESS_INSTANCE_NOT_FOUND);
            current.SuspensionState = ESuspensionState.ACTIVE;
            await InstanceStore.UpdateAsync(current).ConfigureAwait(false);
            return BpmResult.Success;
        }

        public BpmResult ActivateProcessInstanceById(TKey processInstanceId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processInstanceId);
            log.Trace(LogConstant.ActivateProcessInstanceById, processInstanceId);
            TProcessInstance current = InstanceStore.FindById(processInstanceId);
            if (current == null)
                return BpmResult.Failed(EntityConstant.PROCESS_INSTANCE_NOT_FOUND);
            current.SuspensionState = ESuspensionState.ACTIVE;
            InstanceStore.Update(current);
            return BpmResult.Success;
        }
        #endregion

        #region Process Definition Routine ...
        public virtual async Task<bool> IsProcessDefinitionExistAsync(TKey ProcessDefinitionId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(ProcessDefinitionId);
            log.Trace(LogConstant.IsProcessDefinitionExistAsync, ProcessDefinitionId);
            TProcessDefinition current = await DefinitionStore.FindByIdAsync(ProcessDefinitionId).ConfigureAwait(false);
            return current != null;
        }

        public bool IsProcessDefinitionExist(TKey ProcessDefinitionId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(ProcessDefinitionId);
            log.Trace(LogConstant.IsProcessDefinitionExist, ProcessDefinitionId);
            TProcessDefinition current = DefinitionStore.FindById(ProcessDefinitionId);
            return current != null;
        }

        public virtual async Task<TProcessDefinition> FindProcessDefinitionByIdAsync(TKey processDefinitionId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processDefinitionId);
            log.Trace(LogConstant.FindProcessDefinitionByIdAsync, processDefinitionId);
            return await DefinitionStore.FindByIdAsync(processDefinitionId).ConfigureAwait(false);
        }

        public TProcessDefinition FindProcessDefinitionById(TKey processDefinitionId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processDefinitionId);
            log.Trace(LogConstant.FindProcessDefinitionById, processDefinitionId);
            return DefinitionStore.FindById(processDefinitionId);
        }

        public virtual async Task<BpmResult> CreateProcessDefinitionAsync(TProcessDefinition processDefinition)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processDefinition);
            log.Trace(LogConstant.CreateProcessDefinitionAsync, processDefinition);
            BpmResult validateResult = await _processValidator.ValidateProcessDefinitionAsync(processDefinition).ConfigureAwait(false);
            if (!validateResult.Succeeded) return validateResult;
            await DefinitionStore.CreateAsync(processDefinition).ConfigureAwait(false);
            return BpmResult.Success;
        }

        public BpmResult CreateProcessDefinition(TProcessDefinition processDefinition)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processDefinition);
            log.Trace(LogConstant.CreateProcessDefinition, processDefinition);
            BpmResult validateResult = _processValidator.ValidateProcessDefinition(processDefinition);
            if (!validateResult.Succeeded) return validateResult;
            DefinitionStore.Create(processDefinition);
            return BpmResult.Success;
        }

        public virtual async Task<BpmResult> UpdateProcessDefinitionAsync(TProcessDefinition processDefinition)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processDefinition);
            log.Trace(LogConstant.UpdateProcessDefinitionAsync, processDefinition);
            BpmResult validateResult = await _processValidator.ValidateProcessDefinitionAsync(processDefinition).ConfigureAwait(false);
            if (!validateResult.Succeeded) return validateResult;
            await DefinitionStore.UpdateAsync(processDefinition);
            return BpmResult.Success;
        }

        public BpmResult UpdateProcessDefinition(TProcessDefinition processDefinition)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processDefinition);
            log.Trace(LogConstant.UpdateProcessDefinitionAsync, processDefinition);
            BpmResult validateResult = _processValidator.ValidateProcessDefinition(processDefinition);
            if (!validateResult.Succeeded) return validateResult;
            DefinitionStore.Update(processDefinition);
            return BpmResult.Success;
        }

        public virtual async Task<BpmResult> DeleteProcessDefinitionAsync(TKey processDefinitionId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processDefinitionId);
            log.Trace(LogConstant.DeleteProcessDefinitionAsync, processDefinitionId);
            TProcessDefinition current = await DefinitionStore.FindByIdAsync(processDefinitionId).ConfigureAwait(false);
            if (current == null)
                return BpmResult.Failed("Process Definition Not Found");
            await DefinitionStore.DeleteAsync(current);
            return BpmResult.Success;
        }

        public BpmResult DeleteProcessDefinition(TKey processDefinitionId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processDefinitionId);
            log.Trace(LogConstant.DeleteProcessDefinition, processDefinitionId);
            TProcessDefinition current = DefinitionStore.FindById(processDefinitionId);
            if (current == null)
                return BpmResult.Failed("Process Definition Not Found");
            DefinitionStore.Delete(current);
            return BpmResult.Success;
        }
        #endregion        

        #region Process Task Routine ...
        public virtual async Task<bool> IsProcessTaskExistAsync(TKey processTaskId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processTaskId);
            TProcessTask current = await TaskStore.FindByIdAsync(processTaskId).ConfigureAwait(false);
            return current != null;
        }

        public bool IsProcessTaskExist(TKey processTaskId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processTaskId);
            log.Trace(LogConstant.IsProcessTaskExist, processTaskId);
            TProcessTask current = TaskStore.FindById(processTaskId);
            return current != null;
        }

        public virtual async Task<TProcessTask> FindProcessTaskByIdAsync(TKey processTaskId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processTaskId);
            log.Trace(LogConstant.FindProcessTaskByIdAsync, processTaskId);
            return await TaskStore.FindByIdAsync(processTaskId).ConfigureAwait(false);
        }

        public TProcessTask FindProcessTaskById(TKey processTaskId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processTaskId);
            log.Trace(LogConstant.FindProcessTaskById, processTaskId);
            return TaskStore.FindById(processTaskId);
        }

        public virtual async Task<BpmResult> CreateProcessTaskAsync(TProcessTask processTask)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processTask);
            log.Trace(LogConstant.CreateProcessTaskAsync, processTask);
            BpmResult validateResult = await _processValidator.ValidateProcessTaskAsync(processTask).ConfigureAwait(false);
            if (!validateResult.Succeeded) return validateResult;
            await TaskStore.CreateAsync(processTask).ConfigureAwait(false);
            return BpmResult.Success;
        }

        public BpmResult CreateProcessTask(TProcessTask processTask)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processTask);
            log.Trace(LogConstant.CreateProcessTask, processTask);
            BpmResult validateResult = _processValidator.ValidateProcessTask(processTask);
            if (!validateResult.Succeeded) return validateResult;
            TaskStore.Create(processTask);
            return BpmResult.Success;
        }

        public virtual async Task<BpmResult> UpdateProcessTaskAsync(TProcessTask processTask)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processTask);
            log.Trace(LogConstant.UpdateProcessTaskAsync, processTask);
            BpmResult validateResult = await _processValidator.ValidateProcessTaskAsync(processTask).ConfigureAwait(false);
            if (!validateResult.Succeeded) return validateResult;
            await TaskStore.UpdateAsync(processTask);
            return BpmResult.Success;
        }

        public BpmResult UpdateProcessTask(TProcessTask processTask)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processTask);
            log.Trace(LogConstant.UpdateProcessTask, processTask);
            BpmResult validateResult = _processValidator.ValidateProcessTask(processTask);
            if (!validateResult.Succeeded) return validateResult;
            TaskStore.Update(processTask);
            return BpmResult.Success;
        }

        public virtual async Task<BpmResult> DeleteProcessTaskAsync(TKey processTaskId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processTaskId);
            log.Trace(LogConstant.DeleteProcessTaskAsync, processTaskId);
            TProcessTask current = await TaskStore.FindByIdAsync(processTaskId).ConfigureAwait(false);
            if (current == null)
                return BpmResult.Failed(EntityConstant.PROCESS_TASK_NOT_FOUND);
            await TaskStore.DeleteAsync(current);
            return BpmResult.Success;
        }

        public BpmResult DeleteProcessTask(TKey processTaskId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processTaskId);
            log.Trace(LogConstant.DeleteProcessTask, processTaskId);
            TProcessTask current = TaskStore.FindById(processTaskId);
            if (current == null)
                return BpmResult.Failed(EntityConstant.PROCESS_TASK_NOT_FOUND);
            TaskStore.Delete(current);
            return BpmResult.Success;
        }

        public virtual async Task<BpmResult> ClaimProcessTaskAsync(TKey processTaskId, string userId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processTaskId);
            log.Trace(LogConstant.ClaimProcessTaskAsync, processTaskId, userId);
            TProcessTask current = TaskStore.FindById(processTaskId);
            if (current == null)
                return BpmResult.Failed(EntityConstant.PROCESS_TASK_NOT_FOUND);
            BpmResult validateResult = await _processValidator.ValidateClaimTaskAsync(current, userId);
            if (!validateResult.Succeeded) return validateResult;
            current.Assignee = userId;
            await TaskStore.UpdateAsync(current);
            return BpmResult.Success;
        }

        public BpmResult ClaimProcessTask(TKey processTaskId, string userId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processTaskId);
            log.Trace(LogConstant.ClaimProcessTask, processTaskId, userId);
            TProcessTask current = TaskStore.FindById(processTaskId);
            if (current == null)
                return BpmResult.Failed(EntityConstant.PROCESS_TASK_NOT_FOUND);
            BpmResult validateResult = _processValidator.ValidateClaimTask(current, userId);
            if (!validateResult.Succeeded) return validateResult;
            current.Assignee = userId;
            TaskStore.Update(current);
            return BpmResult.Success;
        }

        public virtual async Task<BpmResult> UnClaimProcessTaskAsync(TKey processTaskId)
        {
            log.Trace(LogConstant.UnClaimProcessTaskAsync, processTaskId);
            return await ClaimProcessTaskAsync(processTaskId, null);
        }

        public BpmResult UnClaimProcessTask(TKey processTaskId)
        {
            log.Trace(LogConstant.UnClaimProcessTask, processTaskId);
            return ClaimProcessTask(processTaskId, null);
        }

        public BpmResult CompleteProcessTask(TKey processTaskId)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processTaskId);
            log.Trace(LogConstant.CompleteProcessTask, processTaskId);
            TProcessTask processTask = TaskStore.FindById(processTaskId);
            if (processTask == null)
                return BpmResult.Failed(EntityConstant.PROCESS_TASK_NOT_FOUND);
            TaskStore.Update(processTask);
            return BpmResult.Success;
        }

        public virtual async Task<BpmResult> CompleteProcessTaskAsync(TKey processTaskId)
        {
            return await CompleteProcessTaskAsync(processTaskId, null);
        }

        public virtual async Task<BpmResult> CompleteProcessTaskAsync(TKey processTaskId, Dictionary<string, object> variables)
        {
            this.ThrowIfDisposed(_disposed);
            Check.ThrowIfNull(processTaskId);
            log.Trace(LogConstant.CompleteProcessTaskAsync2, processTaskId);
            TProcessTask current = await TaskStore.FindByIdAsync(processTaskId).ConfigureAwait(false);
            if (current == null)
                return BpmResult.Failed(EntityConstant.PROCESS_TASK_NOT_FOUND);
            List<ProcessVariables<TKey>> taskVariables = new List<ProcessVariables<TKey>>();
            Task[] tasks = new Task[variables.Count];
            int i = 0;
            foreach (KeyValuePair<string, object> item in variables)
            {
                tasks[i] = SetVariables(current.ProcessItemDefinitionId, item, taskVariables);
                i++;
            }
            Task.WaitAll(tasks);
            await TaskStore.DeleteAsync(current).ConfigureAwait(false);
            return BpmResult.Success;
        }

        private async Task SetVariables(TKey processDefinitionId, KeyValuePair<string, object> item, List<ProcessVariables<TKey>> taskVariables)
        {
            DefinitionVariable<TKey> def = await DefinitionVariableStore.FindByProcessDefinitionIdAndNameAsync(processDefinitionId, item.Key);
            ProcessVariables<TKey> variable = new ProcessVariables<TKey>();
            bool stored = false;
            if (def != null)
            {
                stored = GetVariable(item, def, variable, stored);
            }
            if (stored)
            {
                taskVariables.Add(variable);
            }
        }

        private static bool GetVariable(KeyValuePair<string, object> item, DefinitionVariable<TKey> def, ProcessVariables<TKey> variable, bool stored)
        {
            switch (def.StoreType)
            {
                case EStoreType.BitValue:
                    variable.BitValue = VariableParser.GetBool(item.Value, out stored);
                    break;
                case EStoreType.LongValue:
                    variable.LongValue = VariableParser.GetLong(item.Value, out stored);
                    break;
                case EStoreType.DecimalValue:
                    variable.DecimalValue = VariableParser.GetDecimal(item.Value, out stored);
                    break;
                case EStoreType.FloatValue:
                    variable.FloatValue = VariableParser.GetFloat(item.Value, out stored);
                    break;
                case EStoreType.DateTimeValue:
                    variable.DateTimeValue = VariableParser.GetDateTime(item.Value, out stored);
                    break;
                case EStoreType.StringValue:
                    variable.StringValue = item.Value.ToString();
                    stored = true;
                    break;
                default:
                    break;
            }
            return stored;
        }

        #endregion

        #endregion
    }
}
