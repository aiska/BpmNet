using BPMNET.Core;
using System;
using System.Threading.Tasks;

namespace BPMNET.Engine.Manager
{
    public abstract class ProcessInstanceManager<TKey, TProcessInstanceStore, TProcessInstance, TFlowNode> : IDisposable
        where TKey : IEquatable<TKey>
        where TProcessInstanceStore : class, IProcessInstanceStore<TKey, TProcessInstance, TFlowNode>
        where TProcessInstance : class, IProcessInstance<TKey>
        where TFlowNode : class, IFlowNode<TKey>
    {
        #region Properties
        private const string PROCESS_NOT_FOUND = "Bpmn ProcessId: '{0}' not found.";
        private const string PROCESS_STARTED = "User: {0} Started Process Process Instance'{1}'";

        protected TProcessInstanceStore Store { get; private set; }

        #endregion

        #region Constructor
        public ProcessInstanceManager(TProcessInstanceStore store)
        {
            Store = store;
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
            if (disposing && !_disposed)
            {
                Store.Dispose();
            }
            _disposed = true;
        }
        #endregion

        #region Public Sub Routine

        public async Task<TProcessInstance[]> GetActiveByProcessNameAsync()
        {
            return await Store.GetActiveProcessInstanceAsync();
        }

        public async Task<TProcessInstance[]> GetAllSubProcessAsync(TKey processInstanceId)
        {
            return await Store.GetAllSubProcessAsync(processInstanceId);
        }

        public async Task<TProcessInstance[]> GetProcessInstanceByProcessNameAsync(string processName)
        {
            return await Store.GetProcessInstanceByProcessNameAsync(processName);
        }

        public async Task<TProcessInstance> GetProcessInstanceAsync(TKey processInstanceId)
        {
            return await Store.GetProcessInstanceAsync(processInstanceId);
        }

        public async Task<TProcessInstance> StartProcessInstanceAsync(string process, string businessKey)
        {
            return await Store.StartProcessInstanceAsync(process, businessKey);
        }

        public async Task<TProcessInstance> StartProcessInstanceAsync(TKey processDefinitionId, string businessKey)
        {
            return await Store.StartProcessInstanceAsync(processDefinitionId, businessKey);
        }

        public async Task<TProcessInstance> SuspendInstanceAsync(TKey processInstanceId)
        {
            return await SuspendInstanceAsync(processInstanceId);
        }

        public async Task<TProcessInstance> ActivateInstanceAsync(TKey processInstanceId)
        {
            return await ActivateInstanceAsync(processInstanceId);
        }

        public async Task CancelInstanceAsync(TKey processInstanceId, string reason)
        {
            await Store.CancelAsync(processInstanceId, reason);
        }

        #endregion

        //public async Task<ProcessTask> GetProcessTaskAsync(int processInstanceId, string taskName)
        //{
        //    return await ProcessTaskStore.GetProcessTaskAsync(processInstanceId, taskName);
        //}

        //private object GetValue(EStoreType type, string value)
        //{
        //    switch (type)
        //    {
        //        case EStoreType.BitValue: return Convert.ToBoolean(value);
        //        case EStoreType.ShortValue: return Convert.ToInt16(value);
        //        case EStoreType.IntValue: return Convert.ToInt32(value);
        //        case EStoreType.LongValue: return Convert.ToInt64(value);
        //        case EStoreType.DecimalValue: return Convert.ToDecimal(value);
        //        case EStoreType.DoubleValue: return Convert.ToDouble(value);
        //        case EStoreType.DateTimeValue: return Convert.ToDateTime(value); ;
        //        default: return value;
        //    }
        //}

        //private EStoreType GetEStoreType(object value)
        //{
        //    if (value is bool)
        //        return EStoreType.BitValue;
        //    if (value is string)
        //        return EStoreType.StringValue;
        //    else if (value is short)
        //        return EStoreType.ShortValue;
        //    else if (value is int)
        //        return EStoreType.IntValue;
        //    else if (value is long)
        //        return EStoreType.LongValue;
        //    else if (value is decimal)
        //        return EStoreType.DecimalValue;
        //    else if (value is double)
        //        return EStoreType.DoubleValue;
        //    else if (value is DateTime)
        //        return EStoreType.DateTimeValue;
        //    else
        //        throw new NotSupportedException("Type Value not support");
        //}

        //public async Task<Dictionary<string, object>> GetAllVariablesAsync(int processInstanceId)
        //{
        //    Dictionary<string, object> dict = new Dictionary<string, object>();
        //    foreach (var variable in await ProcessVariablesStore.GetAllVariableAsync(processInstanceId))
        //    {
        //        dict[variable.Name] = GetValue(variable.StoreType, variable.Value);
        //    }
        //    return dict;
        //}

        //public async Task<ProcessVariables> GetVariable(int processInstanceId, string name)
        //{
        //    name.ThrowIfNull();
        //    return await ProcessVariablesStore.GetVariableByNameAsync(processInstanceId, name);
        //}

        //public async Task SaveVariable(int processInstanceId, IDictionary<string, object> variables)
        //{
        //    foreach (var item in variables)
        //    {
        //        var variable = await GetVariable(processInstanceId, item.Key);
        //        if (variable == null)
        //        {
        //            variable = new ProcessVariables();
        //            variable.ProcessInstanceId = processInstanceId;
        //            variable.Name = item.Key;
        //            variable.StoreType = GetEStoreType(item.Value);
        //            variable.Value = item.Value.ToString();
        //            await ProcessVariablesStore.CreateAsync(variable);
        //        }
        //        else
        //        {
        //            variable.Value = item.Value.ToString();
        //            await ProcessVariablesStore.UpdateAsync(variable);
        //        }
        //    }
        //}

        //public async Task<ProcessInstance> GetSubProcessInstanceAsync(int processInstanceId, string name)
        //{
        //    return await ProcessInstanceStore.GetSubProcessInstanceAsync(processInstanceId, name);
        //}

        //public async Task<IEnumerable<ProcessInstance>> GetProcessInstanceActiveByNameAsync(string processName)
        //{
        //    return await ProcessInstanceStore.GetProcessInstanceActiveByNameAsync(processName);
        //}

        //public async Task ProcessToNextFlow(int processInstanceId, int flowNodeId, ProcessItemType type)
        //{
        //    if (ProcessItemCheck.IsExclusiveGateway(type))
        //    {
        //        // Exclusive gateway is a diversion point of a business process flow.
        //        // For a given instance of the process, there is only one of the paths can be taken.
        //        // If two possible paths will only execute one but not both.

        //        FlowNode nextNode = null;

        //        ExpressionContext context = new ExpressionContext();
        //        var variables = await ProcessVariablesStore.GetAllVariableAsync(processInstanceId);
        //        AddVariableCondition(context, variables);

        //        // GetSequence
        //        foreach (var sequence in await SequenceFlowStore.GetNextSequenceFlowAsync(flowNodeId))
        //        {
        //            if (string.IsNullOrWhiteSpace(sequence.ConditionExpression))
        //                // Set default node
        //                nextNode = await FlowNodeStore.FindByIdAsync(sequence.ItemSourceTarget);
        //            else if (EvaluateCondition(context, sequence.ConditionExpression))                // parse condition expression
        //            {
        //                nextNode = await FlowNodeStore.FindByIdAsync(sequence.ItemSourceTarget);
        //                // Exclusive Gateway is only one node to process, stop looking another sequence
        //                break;
        //            }
        //        }
        //        if (nextNode == null) throw new ArgumentException("Next flow from flowNodeId: {0} is not found");

        //        //Save Process Flow
        //        await SaveProcessFlowAsync(processInstanceId, flowNodeId, nextNode.FlowNodeId);
        //        await FlowProcessAsync(processInstanceId, nextNode);
        //    }
        //    else if (ProcessItemCheck.IsInclusiveGateway(type))
        //    {
        //        // Inclusive gateway is also a division point of the business process. 
        //        // Unlike the exclusive gateway, inclusive gateway may trigger more than 1 out-going paths. 
        //        // Since inclusive gateway may trigger more than 1 out-going paths, the condition checking process will have a little bit different then the exclusive gateway. 

        //        ExpressionContext context = new ExpressionContext();
        //        var variables = await ProcessVariablesStore.GetAllVariableAsync(processInstanceId);
        //        AddVariableCondition(context, variables);

        //        foreach (var sequence in await SequenceFlowStore.GetNextSequenceFlowAsync(flowNodeId))
        //        {
        //            FlowNode nextNode = null;
        //            if (string.IsNullOrWhiteSpace(sequence.ConditionExpression))
        //                nextNode = await FlowNodeStore.FindByIdAsync(sequence.ItemSourceTarget);
        //            else if (EvaluateCondition(context, sequence.ConditionExpression))                // parse condition expression
        //            {
        //                nextNode = await FlowNodeStore.FindByIdAsync(sequence.ItemSourceTarget);
        //            }

        //            if (nextNode != null)
        //            {
        //                //Save Process Flow
        //                await SaveProcessFlowAsync(processInstanceId, flowNodeId, nextNode.FlowNodeId);
        //                await FlowProcessAsync(processInstanceId, nextNode);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (var item in await GetNextFlowAsync(flowNodeId))
        //        {
        //            //Save Process Flow
        //            await SaveProcessFlowAsync(processInstanceId, flowNodeId, item.FlowNodeId);
        //            await FlowProcessAsync(processInstanceId, item);
        //        }
        //    }
        //}

        //public async Task<IEnumerable<Comment>> GetPrivateCommentsAsync(int processInstanceId)
        //{
        //    return await CommentStore.GetPrivateCommentsAsync(processInstanceId);
        //}

        //public async Task<IEnumerable<Comment>> GetCommentsAsync(int processInstanceId)
        //{
        //    return await CommentStore.GetCommentsAsync(processInstanceId);
        //}

        //private async Task SaveProcessFlowAsync(int processInstanceId, int flowFrom, int flowTo)
        //{
        //    ProcessFlow flow = await ProcessFlowStore.GetProcessFlowAsync(processInstanceId, flowFrom, flowTo);
        //    if (flow == null)
        //    {
        //        flow = new ProcessFlow() { ProcessInstanceId = processInstanceId, FlowFrom = flowFrom, FlowTo = flowTo };
        //        await ProcessFlowStore.CreateAsync(flow);
        //    }
        //}

        //public async Task CompleteTaskAsync(int processInstanceId, string taskName)
        //{
        //    await CompleteTaskAsync(processInstanceId, taskName, new Dictionary<string, object>());
        //}
        //public async Task CompleteTaskAsync(int processInstanceId, string taskName, IDictionary<string, object> variables)
        //{
        //    ProcessTask task = await ProcessTaskStore.GetProcessTaskAsync(processInstanceId, taskName);

        //    if (task == null)
        //    {
        //        throw new ArgumentException(string.Format("Process Task {0} is not created yet, cannot complete task. ", taskName));
        //    }

        //    if (task.CurrentStatus == Core.TaskStatus.Canceled || task.CurrentStatus == Core.TaskStatus.Completed)
        //    {
        //        throw new ArgumentException("Task already Completed or Canceled");
        //    }

        //    task.PreviousStatus = task.CurrentStatus;
        //    task.CurrentStatus = Core.TaskStatus.Completed;
        //    task.Assignee = null;
        //    task.IsDone = true;
        //    task.ModifiedBy = User.UserId;
        //    task.Workgroup = null;

        //    // Save Variable
        //    await SaveVariable(processInstanceId, variables);

        //    // Update task to complete
        //    await ProcessTaskStore.UpdateAsync(task);

        //    // Proceed to next flow
        //    await ProcessToNextFlow(processInstanceId, task.FlowNodeId, ProcessItemType.Task);
        //}

        //protected CommentStore CommentStore { get; private set; }
        //protected IUser User { get; private set; }

        //public IQueryable<ProcessInstance> ProcessInstances
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public async Task<IEnumerable<FlowNode>> GetNextFlowAsync(int flowNodeId)
        //{
        //    return await FlowNodeStore.GetNextFlowAsync(flowNodeId);
        //}

        //public async Task<IEnumerable<ProcessInstance>> GetActiveProcessInstanceAsync()
        //{
        //    return await ProcessInstanceStore.GetActiveProcessInstanceAsync();
        //}

        //public async Task<Process> GetProcessByBpmnIdAsync(string id)
        //{
        //    return await ProcessStore.FindByBpmnIdAsync(id);
        //}

        //public async Task<Process> GetProcessByIdAsync(int processId)
        //{
        //    return await ProcessStore.FindByIdAsync(processId);
        //}

        //public async Task<Comment> AddCommentAsync(int ProcessInstanceId, string commentText, bool isPrivate = false)
        //{
        //    Comment comment = new Comment();
        //    comment.ProcessInstanceId = ProcessInstanceId;
        //    comment.CommentText = commentText;
        //    comment.IsPrivateComment = isPrivate;
        //    comment.User = User.UserId;
        //    await CommentStore.CreateAsync(comment);
        //    return comment;

        //}

        //public async Task<ProcessInstance> CreateProcessInstanceAsync(int processId, string processInstanceName, string businessKey, int? parentId = null)
        //{
        //    ProcessInstance pi = new ProcessInstance();
        //    pi.ProcessId = processId;
        //    pi.ParentProcessInstanceId = parentId;
        //    pi.Name = processInstanceName;
        //    pi.BusinessKey = businessKey;
        //    pi.Owner = GetUserId();
        //    await ProcessInstanceStore.CreateAsync(pi);
        //    return pi;
        //}

        //private string GetUserId()
        //{
        //    if (User == null || User.UserId == null) return null;
        //    return User.UserId;
        //}

        //public async Task<IProcessInstance> StartProcessAsync(IProcessDefinition process, string processInstanceName, string businessKey)
        //{
        //    process.ThrowIfNull();

        //    ProcessInstance pi = await CreateProcessInstanceAsync(process.ProcessId, processInstanceName, businessKey);

        //    // Get Started flow
        //    foreach (var item in await FlowNodeStore.GetStartEvent(process.FlowNodeId))
        //    {
        //        // Process To Next Flow
        //        await ProcessToNextFlow(pi.ProcessInstanceId, item.FlowNodeId, ProcessItemType.StartEvent);
        //    }

        //    //Add to history
        //    //AddHistory(proc.Name, pi.ProcessInstanceName, "", string.Format(PROCESS_STARTED, user, proc.Name), user);

        //    return pi;
        //}

        //public void AddVariableCondition(ExpressionContext context, IEnumerable<ProcessVariables> variables)
        //{
        //    context.Imports.AddType(typeof(string));

        //    foreach (var variable in variables)
        //    {
        //        switch (variable.StoreType)
        //        {
        //            case EStoreType.BitValue:
        //                context.Variables.Add(variable.Name, bool.Parse(variable.Value));
        //                break;
        //            case EStoreType.ShortValue:
        //                context.Variables.Add(variable.Name, short.Parse(variable.Value));
        //                break;
        //            case EStoreType.IntValue:
        //                context.Variables.Add(variable.Name, int.Parse(variable.Value));
        //                break;
        //            case EStoreType.LongValue:
        //                context.Variables.Add(variable.Name, long.Parse(variable.Value));
        //                break;
        //            case EStoreType.DecimalValue:
        //                context.Variables.Add(variable.Name, decimal.Parse(variable.Value));
        //                break;
        //            case EStoreType.DoubleValue:
        //                context.Variables.Add(variable.Name, double.Parse(variable.Value));
        //                break;
        //            case EStoreType.DateTimeValue:
        //                context.Variables.Add(variable.Name, DateTime.Parse(variable.Value));
        //                break;
        //            default:
        //                context.Variables.Add(variable.Name, variable.Value);
        //                break;
        //        }
        //    }
        //}
        //public bool EvaluateCondition(ExpressionContext context, string condition)
        //{
        //    try
        //    {
        //        condition = condition.TrimStart("${".ToCharArray());
        //        condition = condition.TrimEnd('}');

        //        IGenericExpression<bool> e = context.CompileGeneric<bool>(condition);
        //        return e.Evaluate();
        //    }
        //    catch (System.Exception)
        //    {
        //        return false;
        //    }
        //}

        //public async Task<bool> IsPrevNodeDoneAsync(FlowNode item, int processInstanceId)
        //{
        //    foreach (FlowNode prevFlow in FlowNodeStore.GetPreviousFlow(item.FlowNodeId))
        //    {
        //        if (!await ProcessFlowStore.IsExistAsync(processInstanceId, prevFlow.FlowNodeId, item.FlowNodeId))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //public async Task FlowProcessAsync(int processInstanceId, FlowNode item)
        //{
        //    if (ProcessItemCheck.IsSubProcess(item.ItemType))
        //    {
        //        var processInstance = await ProcessInstanceStore.FindByIdAsync(processInstanceId);
        //        var proc = await ProcessStore.GetByFlowIdAsync(item.FlowNodeId);
        //        ProcessInstance pi = await CreateProcessInstanceAsync(proc.ProcessId, item.Id, processInstance.BusinessKey, processInstance.ProcessInstanceId);
        //        // Get Started flow
        //        foreach (var nextItem in await FlowNodeStore.GetStartEvent(item.FlowNodeId))
        //        {
        //            // Process To Next Flow
        //            await ProcessToNextFlow(pi.ProcessInstanceId, nextItem.FlowNodeId, nextItem.ItemType);
        //        }
        //    }
        //    else if (ProcessItemCheck.IsTask(item.ItemType))
        //    {
        //        await CreateOrActivateTaskAsync(item, processInstanceId, item.Id);
        //    }
        //    else if (ProcessItemCheck.IsGateway(item.ItemType))
        //    {
        //        if (await IsPrevNodeDoneAsync(item, processInstanceId))
        //        {
        //            // Process To Next Flow
        //            await ProcessToNextFlow(processInstanceId, item.FlowNodeId, item.ItemType);
        //        }
        //    }
        //    else if (ProcessItemCheck.IsEndEvent(item.ItemType))
        //    {
        //        await CancelAllPendingTaskAsync(processInstanceId);
        //        await CancelAllSubProcessAsync(processInstanceId);
        //        ProcessInstance update = await ProcessInstanceStore.FindByIdAsync(processInstanceId);
        //        if (update.ParentProcessInstanceId.HasValue)
        //        {
        //            update.Status = ProcessInstanceStatus.Completed;
        //            await ProcessInstanceStore.UpdateAsync(update);
        //            var proc = await ProcessStore.FindByIdAsync(update.ProcessId);
        //            var parent = await ProcessInstanceStore.FindByIdAsync(update.ParentProcessInstanceId.Value);
        //            // Process To Next Parent Flow
        //            await ProcessToNextFlow(parent.ProcessInstanceId, proc.FlowNodeId, ProcessItemType.SubProcess);
        //        }
        //    }
        //    else
        //    {
        //        throw new NotSupportedException(string.Format("node '{0}' is not support yet", item.ItemType.ToString()));
        //    }
        //}

        //private async Task CancelAllSubProcessAsync(int processInstanceId)
        //{
        //    foreach (var item in await ProcessInstanceStore.GetAllSubProcessIdAsync(processInstanceId))
        //    {
        //        await CancelAllPendingTaskAsync(item);
        //        await CancelAllSubProcessAsync(item);
        //    }
        //}

        //private async Task CancelAllPendingTaskAsync(int processInstanceId)
        //{
        //    //Get all active task in process
        //    foreach (var item in await ProcessTaskStore.GetActiveProcessTaskAsync(processInstanceId))
        //    {
        //        item.Assignee = null;
        //        item.PreviousStatus = item.CurrentStatus;
        //        item.CurrentStatus = Core.TaskStatus.Canceled;
        //        item.IsDone = true;
        //        item.Workgroup = null;
        //        await ProcessTaskStore.UpdateAsync(item);
        //    }
        //}

        //public async Task<bool> CreateOrActivateTaskAsync(FlowNode node, int processInstanceId, string taskName)
        //{
        //    ProcessTask task = await ProcessTaskStore.GetCurrentProcessTaskByName(processInstanceId, taskName);
        //    if (task == null)
        //    {
        //        //Create New Task
        //        task = new ProcessTask();
        //        if (!ProcessItemCheck.IsTask(node.ItemType))
        //            throw new FlowNodeException(node.Id, "Task");
        //        task.ProcessInstanceId = processInstanceId;
        //        task.FlowNodeId = node.FlowNodeId;
        //        task.Name = node.Id;
        //        task.TaskType = node.ItemType;
        //        if (ProcessItemCheck.IsUserTask(node.ItemType))
        //        {
        //            //TODO Set to default Assignee
        //            task.Assignee = null;
        //        }
        //        task.CreatedBy = GetUserId();
        //        await ProcessTaskStore.CreateAsync(task);
        //    }
        //    else
        //    {
        //        task.IsDone = false;
        //        task.PreviousStatus = task.CurrentStatus;
        //        task.CurrentStatus = Core.TaskStatus.New;
        //        await ProcessTaskStore.UpdateAsync(task);
        //    }
        //    return true;
        //    //TODO Add to history
        //    //AddHistory(proc.Name, pi.ProcessInstanceName, t.ProcessTaskName, string.Format("User: {0} Created Task '{1}'", user, proc.Name), user);
        //}

        //public BpmResult ActivateProcessInstanceById(int processInstanceId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<BpmResult> ActivateProcessInstanceByIdAsync(int processInstanceId)
        //{
        //    try
        //    {
        //        int BpmResult = ProcessInstanceStore.ActivateProcessInstanceByIdAsync();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        BpmResult.Failed(ex.Message);
        //    }
        //}

        //public BpmResult AddParticipantUser(int processInstanceId, string userId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<BpmResult> AddParticipantUserAsync(int processInstanceId, string userId)
        //{
        //    throw new NotImplementedException();
        //}

        //public BpmResult CreateProcessInstance(ProcessInstance processInstance)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<BpmResult> CreateProcessInstanceAsync(ProcessInstance processInstance)
        //{
        //    throw new NotImplementedException();
        //}

        //public BpmResult DeleteProcessInstance(ProcessInstance processInstance)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<BpmResult> DeleteProcessInstanceAsync(ProcessInstance processInstance)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<ProcessInstance> FindProcessInstanceByDefinitionId(int processDefinitionId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ProcessInstance> FindProcessInstanceByDefinitionIdAsync(int processInstanceId)
        //{
        //    throw new NotImplementedException();
        //}

        //public ProcessInstance FindProcessInstanceById(int processInstanceId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ProcessInstance> FindProcessInstanceByIdAsync(int processInstanceId)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool IsProcessDefinitionExist(int processDefinitionId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> IsProcessDefinitionExistAsync(int processDefinitionId)
        //{
        //    throw new NotImplementedException();
        //}

        //public BpmResult UpdateProcessInstance(ProcessInstance processInstance)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<BpmResult> UpdateProcessInstanceAsync(ProcessInstance processInstance)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
