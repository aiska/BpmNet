using BPMNET.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BPMNET.Bpmn;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Text;

namespace BPMNET.Entity.Store
{
    public class ProcessDefinitionStore : IProcessDefinitionStore<int, DeploymentEntity>, IDisposable
    {
        protected DbContext Context { get; private set; }
        protected bool DisposeContext { get; private set; }

        private EntityStore<DeploymentEntity> deploymentStore;
        private EntityStore<DefinitionEntity> definitionStore;
        private EntityStore<FlowNodeEntity> flowNodeStore;
        private EntityStore<SequenceFlowEntity> sequenceFlowStore;
        private EntityStore<DefinitionItemEntity> definitionItemStore;
        private EntityStore<ProcessDefinitionEntity> processStore;
        protected bool _disposed;

        #region Constructor
        public ProcessDefinitionStore() : this(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public ProcessDefinitionStore(BpmDbContext context)
        {
            Context = context;
            deploymentStore = new EntityStore<DeploymentEntity>(context);
            definitionStore = new EntityStore<DefinitionEntity>(context);
            flowNodeStore = new EntityStore<FlowNodeEntity>(context);
            sequenceFlowStore = new EntityStore<SequenceFlowEntity>(context);
            definitionItemStore = new EntityStore<DefinitionItemEntity>(context);
            processStore = new EntityStore<ProcessDefinitionEntity>(context);
        }

        #endregion

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && DisposeContext)
            {
                Context.Dispose();
            }
            _disposed = true;
        }
        #endregion

        #region Save Change
        protected async Task SaveChangesAsync()
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
        public async Task<DeploymentEntity> CreateDeploymentAsync(string deploymentId, string tenantId, string bpmnFile)
        {
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    DeploymentEntity deployment = new DeploymentEntity()
                    {
                        DeploymentId = deploymentId,
                        DeploymentName = deploymentId,
                        TenantId = tenantId,
                        Source = bpmnFile,
                        UtcDeploymentTime = DateTime.UtcNow
                    };
                    deploymentStore.Create(deployment);
                    await SaveChangesAsync();

                    BpmnNetDefinition bpmnDefinition = new BpmnNetDefinition(bpmnFile);

                    // Set Item Definitions
                    await SaveItemDefintionAsync(deployment.Id, bpmnDefinition.GetAllItemDefinition());

                    //SaveAllProcess
                    await SaveProcessAsync(deployment.Id, bpmnDefinition.GetAllProcess(), tenantId);


                    dbContextTransaction.Commit();
                    return deployment;
                }
                catch (System.Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }

        private async Task SaveItemDefintionAsync(int deploymentId, IEnumerable<tItemDefinition> itemDefinitions)
        {
            foreach (var item in itemDefinitions)
            {
                DefinitionItemEntity itemDef = new DefinitionItemEntity()
                {
                    DeploymentId = deploymentId,
                    DefinitionItemId = item.id,
                    IsCollection = item.isCollection,
                    StructureRef = item.structureRef == null ? null : item.structureRef.Name
                };
                definitionItemStore.Create(itemDef);
                await SaveChangesAsync();
            }
        }

        private async Task SaveProcessAsync(int deploymentId, IEnumerable<tProcess> processes, string tenantId)
        {
            Dictionary<string, int> itemKeys = new Dictionary<string, int>();
            foreach (var process in processes)
            {

                FlowNodeEntity ProcessNode = await CreateFlowNodeAsync(process.id, process.name, ProcessItemType.Process, process.id);

                itemKeys.Add(process.id, ProcessNode.Id);

                //SaveProcessDefinition
                await SaveProcessDefinitionAsync(deploymentId, ProcessNode.Id, process.id, process.name, process.isClosed, process.isExecutable, tenantId);

                // SaveAllFlowNodeAsync
                await SaveAllFlowNodeAsync(deploymentId, ProcessNode.Id, process, itemKeys, tenantId);

                // Get Process Sequence Flow
                foreach (var sequenceFlow in process.Items.OfType<tSequenceFlow>())
                {
                    // Save Sub Process Sequence Flow
                    await CreateSequenceFlowAsync(sequenceFlow, itemKeys);
                }
            }
        }

        private async Task SaveProcessDefinitionAsync(int deploymentId, int nodeId, string processId, string processName, bool isClosed, bool isExecutable, string tenantId)
        {
            ProcessDefinitionEntity processEntity = new ProcessDefinitionEntity()
            {
                DeploymentId = deploymentId,
                FlowNodeId = nodeId,
                ProcessId = processId,
                ProcessName = processName,
                IsClosed = isClosed,
                IsExecutable = isExecutable,
            };
            ProcessDefinitionEntity currentEntity = processStore.DbEntitySet.FirstOrDefault(t => t.ProcessId.Equals(processId) && t.TenantId.Equals(tenantId));
            if (currentEntity != null)
            {
                currentEntity.IsSuspended = true;
                processEntity.Version = currentEntity.Version + 1;
            }
            processStore.Create(processEntity);
            await SaveChangesAsync();
        }

        private async Task SaveAllFlowNodeAsync(int deploymentId, int processNodeId, tProcess process, Dictionary<string, int> itemKeys, string tenantId)
        {
            // Get all tFlowNode
            foreach (var flowNode in process.Items.OfType<tFlowNode>())
            {
                // Get All Process Flow Node
                FlowNodeEntity node = await CreateFlowNodeAsync(flowNode.id, flowNode.name, ProcessItem.GetProcessType(flowNode), process.id, processNodeId);
                itemKeys.Add(flowNode.id, node.Id);

                // Get Sub Process
                if (ProcessItem.IsSubProcess(flowNode))
                {
                    await SaveSubProcess(deploymentId, flowNode as tSubProcess, process, node, tenantId);
                }
            }
        }

        private async Task SaveSubProcess(int deploymentId, tSubProcess subProcess, tProcess process, FlowNodeEntity node, string tenantId)
        {
            Dictionary<string, int> itemKeys = new Dictionary<string, int>();
            //SaveProcessDefinition
            await SaveProcessDefinitionAsync(deploymentId, node.Id, subProcess.id, subProcess.name, process.isClosed, process.isExecutable, tenantId);

            // Get Sub Process Flow Node
            foreach (var subProcessItem in subProcess.Items1.OfType<tFlowNode>())
            {
                FlowNodeEntity subNode = await CreateFlowNodeAsync(subProcessItem.id, subProcessItem.name, ProcessItem.GetProcessType(subProcessItem), subProcess.id, node.Id);
                itemKeys.Add(subProcessItem.id, subNode.Id);
            }

            // Get Sub Process Sequence Flow
            foreach (var sequenceFlow in subProcess.Items1.OfType<tSequenceFlow>())
            {
                // Save Sub Process Sequence Flow
                await CreateSequenceFlowAsync(sequenceFlow, itemKeys);
            }
        }

        private async Task<FlowNodeEntity> CreateFlowNodeAsync(string flowNodeId, string flowNodeName, ProcessItemType processType, string ProcessId, int? parentFlowId = null)
        {
            FlowNodeEntity flowNode = new FlowNodeEntity()
            {
                FlowNodeId = flowNodeId,
                Name = flowNodeName,
                ItemType = processType,
                ParentId = parentFlowId,
                Processid = ProcessId
            };
            flowNodeStore.Create(flowNode);
            await SaveChangesAsync();
            return flowNode;
        }

        private async Task<SequenceFlowEntity> CreateSequenceFlowAsync(tSequenceFlow sequenceFlow, Dictionary<string, int> itemKeys)
        {
            string condition = sequenceFlow.conditionExpression != null ? string.Join(" ", sequenceFlow.conditionExpression.Text) : null;
            SequenceFlowEntity seq = new SequenceFlowEntity()
            {
                SequenceFlowId = sequenceFlow.id,
                SequenceFlowName = sequenceFlow.name,
                SourceId = itemKeys[sequenceFlow.sourceRef],
                TargetId = itemKeys[sequenceFlow.targetRef],
                SourceRef = sequenceFlow.sourceRef,
                TargetRef = sequenceFlow.targetRef,
                ConditionExpression = condition
            };
            sequenceFlowStore.Create(seq);
            await SaveChangesAsync();
            return seq;
        }
        #endregion
    }
}
