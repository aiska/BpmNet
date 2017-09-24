using BPMNET.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System;
using BPMNET.Bpmn;
using BPMNET.Exception;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Text;

namespace BPMNET.Entity.Store
{
    public class ProcessTaskStore : IProcessTaskStore<int, ProcessTaskEntity>
    {
        protected DbContext Context { get; private set; }
        public bool DisposeContext { get; protected set; }

        protected string TenantId { get; set; }
        protected IUser User { get; set; }
        protected EntityStore<ProcessTaskEntity> TaskStore { get; private set; }
        protected DbSet<ProcessVariableEntity> ProcessVariableEntity { get; private set; }

        #region Constructor
        public ProcessTaskStore() : this(new BpmDbContext(), null, null)
        {
            DisposeContext = true;
        }
        public ProcessTaskStore(BpmDbContext context, IUser user, ITenant tenant)
        {
            Context = context;
            TenantId = tenant == null ? null : tenant.TenantId;
            User = user;
            TaskStore = new EntityStore<ProcessTaskEntity>(context);
            ProcessVariableEntity = context.Set<ProcessVariableEntity>();
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

        private string GetUserId() {
            if (User == null) return null;
            return User.UserId;
        }

        #region Implement Sub Routine
        public async Task<ProcessTaskEntity[]> GetProcessTaskByFlowNodeIdAsync(string name)
        {
            return await TaskStore.DbEntitySet.Where(t => t.TaskId.Equals(name)).ToArrayAsync();
        }

        public async Task<ProcessTaskEntity> CreateTaskAsync(int processInstanceId, int nodeId, string nodeName, ProcessItemType ItemType)
        {
            if (!ProcessItemCheck.IsTask(ItemType))
                throw new FlowNodeException(nodeName, "Task");
            ProcessTaskEntity task = new ProcessTaskEntity() {
                ProcessInstanceId = processInstanceId,
                FlowNodeId = nodeId,
                TaskId = nodeName,
                TaskType = ItemType,
                CreatedBy = GetUserId()
            };
            TaskStore.Create(task);
            await SaveChangesAsync();
            return task;

            //TODO Add to history
            //AddHistory(proc.Name, pi.ProcessInstanceName, t.ProcessTaskName, string.Format("User: {0} Created Task '{1}'", user, proc.Name), user);
        }

        #endregion

        //public async Task<ProcessTaskEntity> GetProcessTaskAsync(int processInstanceId, string taskName)
        //{
        //    return await Entities.FirstOrDefaultAsync(t => t.ProcessInstanceId.Equals(processInstanceId) && t.Name.Equals(taskName));
        //}

        //public ProcessTaskStore(BpmDbContext context) : base(context)
        //{
        //    _processInstanceSet = context.Set<ProcessInstanceEntity>();
        //}

        //public async Task<IEnumerable<ProcessTaskEntity>> GetActiveProcessTaskAsync(int processInstanceId)
        //{
        //    return await Store.EntitySet.Where(t => t.ProcessInstanceId.Equals(processInstanceId) && !t.IsDone).ToListAsync();
        //}

        //public async Task<ProcessTaskEntity> GetCurrentProcessTaskByName(int processInstanceId, string taskName)
        //{
        //    taskName.ThrowIfNull();
        //    return await Store.EntitySet.FirstOrDefaultAsync(t => t.ProcessInstanceId.Equals(processInstanceId) && t.Name.Equals(taskName));
        //}

        //public async Task<IEnumerable<ProcessTaskEntity>> GetAllProcessInstanceAsync(string taskName)
        //{
        //    taskName.ThrowIfNull();
        //    return await Entities.Where(t => t.Name.Equals(taskName)).ToListAsync();
        //}

        //public ProcessTaskEntity GetProcessTaskByFlowProcess(int flowNodeId, int processInstanceId)
        //{
        //    return Entities.FirstOrDefault(t => t.ProcessInstanceId.Equals(processInstanceId) && t.FlowNodeId.Equals(flowNodeId));
        //}

        //public async Task<bool> IsTaskDoneAsync(int flowNodeId, int processInstanceId)
        //{
        //    return await Entities.Where(t => t.ProcessInstanceId.Equals(processInstanceId) && t.FlowNodeId.Equals(flowNodeId)).Select(t => t.IsDone).SingleAsync();
        //}

    }
}
