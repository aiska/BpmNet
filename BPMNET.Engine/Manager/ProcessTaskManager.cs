using BPMNET.Core;
using BPMNET.Entity;
using BPMNET.Entity.Store;
using BPMNET.Exception;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPMNET.Engine.Manager
{
    public class ProcessTaskManager
    {
        protected BpmDbContext Context { get; private set; }
        public bool DisposeContext { get; set; }
        public ProcessTaskStore ProcessTaskStore { get; set; }
        public ProcessInstance ProcessInstance { get; protected set; }
        protected FlowNodeStore FlowNodeStore { get; private set; }
        //private IUser User;

        #region Constructor
        public ProcessTaskManager(ProcessInstance processInstance) : this(new BpmDbContext(), processInstance)
        {
            DisposeContext = true;
        }
        public ProcessTaskManager(BpmDbContext context, ProcessInstance processInstance)
        {
            context.ThrowIfNull();
            ProcessInstance = processInstance;
            ProcessTaskStore = new ProcessTaskStore(context);
            FlowNodeStore = new FlowNodeStore(context);
        }
        #endregion

        #region SubRoutine

        public async Task<ProcessTask> CreateTaskAsync(FlowNode node, IUser user)
        {
            if (!ProcessItemCheck.IsTask(node.ItemType))
                throw new FlowNodeException(node.Id, "Task");
            ProcessTask task = new ProcessTask();
            task.ProcessInstanceId = ProcessInstance.ProcessInstanceId;
            task.FlowNodeId = node.FlowNodeId;
            task.TaskType = node.ItemType;
            if (ProcessItemCheck.IsUserTask(node.ItemType))
            {
                //TODO Set to default Assignee
                task.Assignee = "";
            }
            task.CreatedBy = user.UserId;
            await ProcessTaskStore.CreateAsync(task);
            return task;

            //TODO Add to history
            //AddHistory(proc.Name, pi.ProcessInstanceName, t.ProcessTaskName, string.Format("User: {0} Created Task '{1}'", user, proc.Name), user);
        }

        //private async Task<ProcessTask> CreateTaskFromSubProcessAsync(FlowNode item, IUser user)
        //{
        //}

        public async Task<ProcessTask> CreateTaskFromGatewayAsync(FlowNode item, IUser user)
        {
            foreach (var gItem in await FlowNodeStore.GetNextFlowAsync(item.FlowNodeId))
            {
                if (ProcessItemCheck.IsTask(gItem.ItemType))
                {
                    return await CreateTaskAsync(gItem, user);
                }
                else if (ProcessItemCheck.IsGateway(gItem.ItemType))
                {
                    return await CreateTaskFromGatewayAsync(gItem, user);
                }
            }
            return null;
        }

        public async Task<IEnumerable<ProcessTask>> GetAllProcessInstanceAsync(string flowNodeName) {
            return await ProcessTaskStore.GetAllProcessInstanceAsync(flowNodeName);
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
                if (DisposeContext && Context != null)
                {
                    Context.Dispose();
                    Context = null;
                }
                ProcessTaskStore.Dispose();
            }
            _disposed = true;
        }
        #endregion

    }
}
