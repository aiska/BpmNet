using BPMNET.Bpmn;
using BPMNET.Condition.PublicTypes;
using BPMNET.Core;
using BPMNET.Exception;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity.Store
{

    public class ProcessInstanceStore : IProcessInstanceStore<int, ProcessInstanceEntity, FlowNodeEntity>
    {
        #region Protected Properties
        protected DbContext Context { get; private set; }
        protected bool DisposeContext { get; set; }
        protected string TenantId { get; set; }
        protected IUser User { get; set; }
        protected EntityStore<ProcessInstanceEntity> processInstanceStore { get; private set; }
        protected EntityStore<ProcessFlowEntity> processFlowStore { get; private set; }
        protected EntityStore<ProcessTaskEntity> processTaskStore { get; private set; }
        protected DbSet<ProcessDefinitionEntity> processEntity { get; private set; }
        protected DbSet<FlowNodeEntity> flowNodeEntity { get; private set; }
        protected DbSet<SequenceFlowEntity> sequenceEntity { get; private set; }
        protected DbSet<ProcessVariableEntity> processVariableEntity { get; private set; }
        #endregion

        #region Constructor
        public ProcessInstanceStore() : this(new BpmDbContext(), null, null)
        {
            DisposeContext = true;
        }

        public ProcessInstanceStore(BpmDbContext context, IUser user, ITenant tenant)
        {
            Context = context;
            TenantId = tenant == null ? null : tenant.TenantId;
            User = user;
            processInstanceStore = new EntityStore<ProcessInstanceEntity>(context);
            processFlowStore = new EntityStore<ProcessFlowEntity>(context);
            processTaskStore = new EntityStore<ProcessTaskEntity>(context);
            processEntity = context.Set<ProcessDefinitionEntity>();
            flowNodeEntity = context.Set<FlowNodeEntity>();
            sequenceEntity = context.Set<SequenceFlowEntity>();
            processVariableEntity = context.Set<ProcessVariableEntity>();
        }
        #endregion

        #region Dispose
        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (DisposeContext && disposing && !_disposed)
            {
                Context.Dispose();
            }
            _disposed = true;
        }
        #endregion

        #region Save Changes
        protected virtual async Task SaveChangesAsync()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.Single().Reload();
                }
                catch (DbEntityValidationException vex)
                {
                    StringBuilder sb = new StringBuilder();
                    // Retrieve the error messages as a list of strings.
                    sb.AppendLine(vex.Message);
                    var errorMessages = vex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    sb.AppendLine("The validation errors are:");
                    foreach (var item in vex.EntityValidationErrors)
                    {
                        sb.AppendLine("entities : " + item.Entry.Entity.GetType().FullName);
                        foreach (var error in item.ValidationErrors)
                        {
                            sb.AppendLine(error.PropertyName + " : " + error.ErrorMessage);
                        }
                    }


                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(sb.ToString());

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, vex.EntityValidationErrors);
                }

            } while (saveFailed);
        }
        #endregion

        #region Sub Routine

        protected async Task<ProcessInstanceEntity> StartProcessInstanceAsync(int processId, string businessKey, int? parentId)
        {
            // Get Process
            ProcessDefinitionEntity procDef = await processEntity.FindAsync(processId);
            if (procDef == null)
                throw new ArgumentException("Process definition with id " + processId.ToString() + " not found");
            return await StartProcessInstanceAsync(procDef, businessKey, parentId);
        }

        protected async Task<ProcessInstanceEntity> StartProcessInstanceAsync(string process, string businessKey, int? parentId)
        {
            // Get Process
            var procDef = processEntity.FirstOrDefault(t => t.ProcessId.Equals(process) && t.TenantId.Equals(TenantId));
            if (procDef == null)
                throw new ArgumentException("Process " + process + " not found");
            return await StartProcessInstanceAsync(procDef, businessKey, parentId);
        }

        private async Task<ProcessInstanceEntity> StartProcessInstanceAsync(ProcessDefinitionEntity definition, string businessKey, int? parentId)
        {
            var entity = await CreateProcessInstanceAsync(definition, businessKey, parentId);
            var startFlows = await GetStartEventAsync(definition.FlowNodeId);

            // Process from Started flow
            await ProcessFromStartedFlowAsync(entity, startFlows);
            return entity;
        }

        public async Task ProcessFromStartedFlowAsync(ProcessInstanceEntity entity, params FlowNodeEntity[] startFlows)
        {
            foreach (var startFlow in startFlows)
            {
                await ProcessToNextFlowAsync(entity, startFlow);
            }
        }

        private async Task<ProcessInstanceEntity> CreateProcessInstanceAsync(ProcessDefinitionEntity processDefinition, string businessKey, int? parentId)
        {
            ProcessInstanceEntity entity = new ProcessInstanceEntity()
            {
                BusinessKey = businessKey,
                ProcessDefinitionId = processDefinition.Id,
                ProcessId = processDefinition.ProcessId,
                TenantId = TenantId,
                ParentInstanceId = parentId,
            };
            processInstanceStore.Create(entity);
            await SaveChangesAsync();
            return entity;
        }


        protected async Task<bool> ProcessFlowAsync(ProcessInstanceEntity processInstance, FlowNodeEntity flowNode)
        {
            bool result = false;
            if (ProcessItemCheck.IsSubProcess(flowNode.ItemType))
            {
                await StartProcessInstanceAsync(flowNode.FlowNodeId, processInstance.BusinessKey, processInstance.Id);
            }
            else if (ProcessItemCheck.IsTask(flowNode.ItemType))
            {
                await CreateTaskAsync(processInstance, flowNode);
                return true;
            }
            else if (ProcessItemCheck.IsGateway(flowNode.ItemType))
            {
                if (ProcessItemCheck.IsExclusiveGateway(flowNode.ItemType))
                {
                    FlowNodeEntity nextNode = null;
                    ExpressionContext context = new ExpressionContext();
                    AddVariableCondition(context, await GetAllVariableAsync(processInstance.Id));

                    // Exclusive gateway is a diversion point of a business process flow.
                    // For a given instance of the process, there is only one of the paths can be taken.
                    // If two possible paths will only execute one but not both.
                    foreach (var sequence in await GetNextSequenceFlowAsync(flowNode.Id))
                    {
                        // Set default node
                        nextNode = await GetFlowAsync(sequence.SourceId);
                        if (!string.IsNullOrWhiteSpace(sequence.ConditionExpression) && EvaluateCondition(context, sequence.ConditionExpression))                // parse condition expression
                        {
                            break;
                        }
                    }
                    if (nextNode == null) throw new ArgumentException("Next flow from flowNodeId: {0} is not found");
                    //Save Process Flow
                    await SaveProcessFlowAsync(processInstance.Id, flowNode.Id, nextNode.Id);

                    //Flow next process
                    await ProcessFlowAsync(processInstance, nextNode);
                }
                else if (ProcessItemCheck.IsInclusiveGateway(flowNode.ItemType))
                {
                    FlowNodeEntity nextNode = null;
                    ExpressionContext context = new ExpressionContext();
                    AddVariableCondition(context, await GetAllVariableAsync(processInstance.Id));

                    // Inclusive gateway is also a division point of the business process. 
                    // Unlike the exclusive gateway, inclusive gateway may trigger more than 1 out-going paths. 
                    // Since inclusive gateway may trigger more than 1 out-going paths, the condition checking process will have a little bit different then the exclusive gateway. 
                    foreach (var sequence in await GetNextSequenceFlowAsync(flowNode.Id))
                    {
                        if (string.IsNullOrWhiteSpace(sequence.ConditionExpression) || EvaluateCondition(context, sequence.ConditionExpression))
                        {
                            //Get Node
                            nextNode = await GetFlowAsync(sequence.SourceId);

                            //Save Process Flow
                            await SaveProcessFlowAsync(processInstance.Id, flowNode.Id, nextNode.Id);

                            //Flow next process
                            await ProcessFlowAsync(processInstance, nextNode);
                        }
                    }
                }
                else
                {
                    // Process To Next Flow
                    foreach (var nextFlow in await GetNextFlowAsync(flowNode.Id))
                    {
                        await ProcessFlowAsync(processInstance, nextFlow);
                    }
                    return true;
                }

                // process only if previous node is done
                if (await IsPrevNodeDoneAsync(flowNode, processInstance.Id))
                {
                    // Process To Next Flow
                    await ProcessToNextFlowAsync(processInstance, flowNode);
                    return true;
                }
            }
            else if (ProcessItemCheck.IsEndEvent(flowNode.ItemType))
            {
                //await CancelAllPendingTaskAsync(processInstanceId);
                //await CancelAllSubProcessAsync(processInstanceId);
                //ProcessInstance update = await ProcessInstanceStore.FindByIdAsync(processInstanceId);
                //if (update.ParentProcessInstanceId.HasValue)
                //{
                //    update.Status = ProcessInstanceStatus.Completed;
                //    await ProcessInstanceStore.UpdateAsync(update);
                //    var proc = await ProcessStore.FindByIdAsync(update.ProcessId);
                //    var parent = await ProcessInstanceStore.FindByIdAsync(update.ParentProcessInstanceId.Value);
                //    // Process To Next Parent Flow
                //    await ProcessToNextFlow(parent.ProcessInstanceId, proc.FlowNodeId, ProcessItemType.SubProcess);
                //}
            }
            else
            {
                throw new NotSupportedException(string.Format("node '{0}' is not support yet", flowNode.ItemType.ToString()));
            }
            return result;
        }

        protected async Task ProcessToNextFlowAsync(ProcessInstanceEntity processInstance, FlowNodeEntity flowNode)
        {
            foreach (var next in await GetNextFlowAsync(flowNode.Id))
            {
                //Save current process flow
                await SaveProcessFlowAsync(processInstance.Id, flowNode.Id, next.Id);

                //Check all process flow has been done
                if (await IsPrevNodeDoneAsync(next, processInstance.Id))
                {
                    //Process Next flow
                    await ProcessFlowAsync(processInstance, next);
                }
            }
        }

        protected async Task<ProcessTaskEntity> CreateTaskAsync(ProcessInstanceEntity processInstance, FlowNodeEntity node)
        {
            if (!ProcessItemCheck.IsTask(node.ItemType))
                throw new FlowNodeException(node.FlowNodeId, "Task");

            //Create New Task
            ProcessTaskEntity task = new ProcessTaskEntity()
            {
                ProcessInstanceId = processInstance.Id,
                FlowNodeId = node.Id,
                TaskId = node.FlowNodeId,
                TaskType = node.ItemType,
                Assignee = null,                    //TODO Set to default Assignee
                CreatedBy = GetUserId(),
                TenantId = TenantId
            };
            processTaskStore.Create(task);
            await SaveChangesAsync();
            return task;

            //TODO Add to history
            //AddHistory(proc.Name, pi.ProcessInstanceName, t.ProcessTaskName, string.Format("User: {0} Created Task '{1}'", user, proc.Name), user);
        }


        protected async Task<bool> IsPrevNodeDoneAsync(FlowNodeEntity item, int processInstanceId)
        {
            foreach (var prevFlow in await GetPreviousFlowAsync(item.Id))
            {
                if (!await processFlowStore.EntitySet.AnyAsync(t => t.FlowFrom.Equals(prevFlow.Id) && t.ProcessInstanceId.Equals(processInstanceId)))
                {
                    return false;
                }
            }
            return true;
        }

        protected string GetUserId()
        {
            if (User == null) return null;
            return User.UserId;
        }

        protected async Task SaveProcessFlowAsync(int processInstanceId, int flowFrom, int flowTo)
        {
            ProcessFlowEntity flow = new ProcessFlowEntity()
            {
                ProcessInstanceId = processInstanceId,
                FlowFrom = flowFrom,
                FlowTo = flowTo
            };
            processFlowStore.Create(flow);
            await SaveChangesAsync();
        }

        public async Task<ProcessVariableEntity[]> GetAllVariableAsync(int processInstanceId)
        {
            return await processVariableEntity.Where(t => t.ProcessInstanceId.Equals(processInstanceId)).ToArrayAsync();
        }

        protected void AddVariableCondition(ExpressionContext context, params ProcessVariableEntity[] variables)
        {

            // Register Variable Type
            foreach (var type in variables.Select(t => t.StructureRef).Distinct())
            {
                context.Imports.AddType(Type.GetType(type));
            }

            for (int i = 0; i < variables.Length; i++)
            {
                Type type = Type.GetType(variables[i].StructureRef);                      //target type
                object obj = Activator.CreateInstance(type);                                // an instance of target type
                context.Variables.Add(variables[i].Name, obj);
            }
        }

        protected bool EvaluateCondition(ExpressionContext context, string condition)
        {
            try
            {
                condition = condition.TrimStart("${".ToCharArray());
                condition = condition.TrimEnd('}');

                IGenericExpression<bool> e = context.CompileGeneric<bool>(condition);
                return e.Evaluate();
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        protected async Task<SequenceFlowEntity[]> GetNextSequenceFlowAsync(int flowId)
        {
            return await sequenceEntity.Where(t => t.SourceRef.Equals(flowId)).ToArrayAsync();
        }

        protected async Task<FlowNodeEntity> GetFlowAsync(int flowId)
        {
            return await flowNodeEntity.FindAsync(flowId);
        }

        protected async Task<FlowNodeEntity[]> GetStartEventAsync(int id)
        {
            return await flowNodeEntity.Where(t => t.ParentId.Value.Equals(id) && t.ItemType == ProcessItemType.StartEvent).ToArrayAsync();
        }

        protected async Task<FlowNodeEntity[]> GetPreviousFlowAsync(int id)
        {
            IQueryable<FlowNodeEntity> queryable =
                from fn in flowNodeEntity
                join sf in sequenceEntity on fn.Id equals sf.SourceId
                where sf.TargetId.Equals(id)
                select fn;
            return await queryable.ToArrayAsync();
        }

        protected async Task<FlowNodeEntity[]> GetNextFlowAsync(int id)
        {
            IQueryable<FlowNodeEntity> queryable =
                from fn in flowNodeEntity
                join sf in sequenceEntity on fn.Id equals sf.TargetId
                where sf.SourceId.Equals(id)
                select fn;
            return await queryable.ToArrayAsync();
        }

        protected async Task<ProcessTaskEntity[]> GetAllProcessTaskAsync(int processInstanceId)
        {
            return await processTaskStore.DbEntitySet.Where(t => t.ProcessInstanceId.Equals(processInstanceId)).ToArrayAsync();
        }

        protected async Task CancelAllTaskAsync(ProcessInstanceEntity processInstance)
        {
            //get alltask
            foreach (var task in await GetAllProcessTaskAsync(processInstance.Id))
            {
                task.PreviousStatus = task.CurrentStatus;
                task.CurrentStatus = Core.TaskStatus.Canceled;
                task.Assignee = null;
                task.Workgroup = null;
            }
            await SaveChangesAsync();
        }

        protected async Task CancelAllSubProcessAsync(ProcessInstanceEntity processInstance)
        {
            //get subprocess
            foreach (var subProcess in await GetAllSubProcessAsync(processInstance.Id))
            {
                subProcess.IsEnded = true;
                subProcess.Status = ProcessInstanceStatus.Canceled;
                await CancelAllTaskAsync(subProcess);
                await CancelAllSubProcessAsync(subProcess);
            }
            await SaveChangesAsync();
        }


        #endregion

        #region Implement Sub Routine
        public async Task<ProcessInstanceEntity> StartProcessInstanceAsync(int processId, string businessKey)
        {
            ProcessInstanceEntity result;
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    result = await StartProcessInstanceAsync(processId, businessKey, null);
                    transaction.Commit();
                }
                catch (System.Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        public async Task<ProcessInstanceEntity> StartProcessInstanceAsync(string process, string businessKey)
        {
            ProcessInstanceEntity result;
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    result = await StartProcessInstanceAsync(process, businessKey, null);
                    transaction.Commit();
                }
                catch (System.Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        public async Task<ProcessInstanceEntity[]> GetActiveProcessInstanceAsync()
        {
            return await processInstanceStore.EntitySet.Where(t => !t.IsEnded && !t.IsSuspended && t.TenantId.Equals(TenantId)).ToArrayAsync();
        }

        public async Task<ProcessInstanceEntity> GetProcessInstanceAsync(int processInstanceId)
        {
            return await processInstanceStore.DbEntitySet.FindAsync(processInstanceId);
        }

        public async Task<ProcessInstanceEntity[]> GetAllSubProcessAsync(int processInstanceId)
        {
            return await processInstanceStore.EntitySet.Where(t => t.ParentInstanceId.Value.Equals(processInstanceId)).ToArrayAsync();
        }

        public async Task<ProcessInstanceEntity[]> GetProcessInstanceByProcessNameAsync(string processName)
        {
            return await processInstanceStore.EntitySet.Where(t => t.ProcessId.Equals(processName) && !t.ParentInstanceId.HasValue).ToArrayAsync();
        }

        public async Task<ProcessTaskEntity> GetProcessTaskAsync(int processInstanceId, string taskId)
        {
            return await processTaskStore.DbEntitySet.FirstOrDefaultAsync(t => t.ProcessInstanceId.Equals(processInstanceId) && t.TaskId.Equals(taskId));
        }
        public async Task<ProcessTaskEntity> GetProcessTaskAsync(int processInstanceId, int flowNodeId)
        {
            return await processTaskStore.DbEntitySet.FirstOrDefaultAsync(t => t.ProcessInstanceId.Equals(processInstanceId) && t.FlowNodeId.Equals(flowNodeId));
        }

        public Task UpdateVariable(string processInstanceId, Dictionary<string, object> variables)
        {
            throw new NotImplementedException();
        }

        public Task CompleteTaskAsync(string processId, string taskName)
        {
            throw new NotImplementedException();
        }

        public async Task CancelAsync(int processInstanceId, string reason)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    var processInstance = await GetProcessInstanceAsync(processInstanceId);
                    processInstance.IsEnded = true;
                    processInstance.Status = ProcessInstanceStatus.Canceled;
                    await CancelAllTaskAsync(processInstance);
                    await CancelAllSubProcessAsync(processInstance);
                    transaction.Commit();
                }
                catch (System.Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<ProcessInstanceEntity> SuspendInstanceAsync(int processInstanceId)
        {
            var processInstance = await GetProcessInstanceAsync(processInstanceId);
            processInstance.IsSuspended = true;
            processInstanceStore.Update(processInstance);
            await SaveChangesAsync();
            return processInstance;
        }

        public async Task<ProcessInstanceEntity> ActivateInstanceAsync(int processInstanceId)
        {

            var processInstance = await GetProcessInstanceAsync(processInstanceId);
            processInstance.IsSuspended = false;
            processInstanceStore.Update(processInstance);
            await SaveChangesAsync();
            return processInstance;
        }

        #endregion
    }
}
