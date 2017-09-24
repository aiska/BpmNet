using BPMNET.Core;
//using BPMNET.Entity.Validator;
using System;
using System.Threading.Tasks;

namespace BPMNET.Engine.Manager
{
    public class DefinitionManager<TKey, TProcessDefinitionStore, TDeployment> : IDisposable
        where TKey : IEquatable<TKey>
        where TProcessDefinitionStore : class, IProcessDefinitionStore<TKey, TDeployment>
        where TDeployment : class, IDeployment<TKey>
    {
        protected TProcessDefinitionStore DefinitionStore { get; set; }

        #region Constructor
        public DefinitionManager(TProcessDefinitionStore definitionStore)
        {
            DefinitionStore = definitionStore;
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
                DefinitionStore.Dispose();
            }
            _disposed = true;
        }
        #endregion

        #region Sub Routine
        public async Task<TDeployment> DeployBpmnAsync(string bpmnFile, string deploymentId, string tenantId)
        {
            //Create new Deployment
            return await DefinitionStore.CreateDeploymentAsync(deploymentId, tenantId, bpmnFile);
        }

        //private async Task GetSubProcessAsync(tProcess process, IFlowNode ParentFlow, itemKeys)
        //{
        //    // Get all Sub Process
        //    foreach (var subProcess in process.Items.OfType<tSubProcess>())
        //    {
        //        IFlowNode flow = await DefinitionStore.CreateFlowNodeAsync(subProcess.id, subProcess.name, ProcessItemType.SubProcess, ParentFlow);
        //        itemKeys.Add(subProcess.id, node.FlowNodeId);

        //        Process proc = new Process();
        //        proc.DefinitionId = definitionId;
        //        proc.Id = subProcess.id;
        //        proc.FlowNodeId = node.FlowNodeId;
        //        proc.Name = subProcess.name ?? subProcess.id;
        //        proc.IsExecutable = process.isExecutable;
        //        proc.IsClosed = process.isClosed;
        //        await ProcessStore.CreateAsync(proc);

        //        // Get Sub Process Flow Node
        //        foreach (var nodeItem in subProcess.Items1.OfType<tFlowNode>())
        //        {
        //            // save Sub Process Flow Node
        //            node = await SaveFLowNodeAsync(nodeItem, proc.FlowNodeId);
        //            itemKeys.Add(nodeItem.id, node.FlowNodeId);
        //        }

        //        // Get Sub Process Sequence Flow
        //        foreach (var flow in subProcess.Items1.OfType<tSequenceFlow>())
        //        {
        //            // Save Sub Process Sequence Flow
        //            await SaveSequenceFlowAsync(flow, itemKeys);
        //        }

        //    }
        //}

        //private async Task SaveSequenceFlowAsync(tSequenceFlow flow, IDictionary<string, int> ItemsKeys)
        //{
        //    SequenceFlow seqFlow = new SequenceFlow();
        //    seqFlow.Id = flow.id;
        //    seqFlow.Name = flow.name;

        //    int ItemSourceRef;
        //    if (ItemsKeys.TryGetValue(flow.sourceRef, out ItemSourceRef))
        //    {
        //        seqFlow.ItemSourceRef = ItemSourceRef;
        //    }

        //    int ItemTargetRef;
        //    if (ItemsKeys.TryGetValue(flow.targetRef, out ItemTargetRef))
        //    {
        //        seqFlow.ItemSourceTarget = ItemTargetRef;
        //    }

        //    if (flow.conditionExpression != null)
        //    {
        //        seqFlow.ConditionExpression = string.Join(" ", flow.conditionExpression.Text);
        //    }
        //    await SequenceFlowStore.CreateAsync(seqFlow);
        //}

        //private async Task GetSequenceFlow(tProcess process, Dictionary<string, int> itemsKeys)
        //{
        //    foreach (var flow in process.Items.OfType<tSequenceFlow>())
        //    {
        //        await SaveSequenceFlowAsync(flow, itemsKeys);
        //    }
        //}

        //private async Task GetSubProcessAsync(tProcess process, int parentId, int definitionId, Dictionary<string, int> itemKeys)
        //{
        //    // Get all Sub Process
        //    foreach (var subProcess in process.Items.OfType<tSubProcess>())
        //    {

        //        FlowNode node = await SaveFLowNodeAsync(subProcess as tFlowNode, parentId);
        //        itemKeys.Add(subProcess.id, node.FlowNodeId);

        //        Process proc = new Process();
        //        proc.DefinitionId = definitionId;
        //        proc.Id = subProcess.id;
        //        proc.FlowNodeId = node.FlowNodeId;
        //        proc.Name = subProcess.name ?? subProcess.id;
        //        proc.IsExecutable = process.isExecutable;
        //        proc.IsClosed = process.isClosed;
        //        await ProcessStore.CreateAsync(proc);

        //        // Get Sub Process Flow Node
        //        foreach (var nodeItem in subProcess.Items1.OfType<tFlowNode>())
        //        {
        //            // save Sub Process Flow Node
        //            node = await SaveFLowNodeAsync(nodeItem, proc.FlowNodeId);
        //            itemKeys.Add(nodeItem.id, node.FlowNodeId);
        //        }

        //        // Get Sub Process Sequence Flow
        //        foreach (var flow in subProcess.Items1.OfType<tSequenceFlow>())
        //        {
        //            // Save Sub Process Sequence Flow
        //            await SaveSequenceFlowAsync(flow, itemKeys);
        //        }

        //    }
        //}

        //private async Task GetProcessFlowNode(tProcess process, int parentId, Dictionary<string, int> itemKeys)
        //{

        //    // Get all tFlowNode
        //    foreach (var item in process.Items.OfType<tFlowNode>())
        //    {
        //        if (!ProcessItem.IsSubProcess(item))
        //        {
        //            FlowNode node = await SaveFLowNodeAsync(item as tFlowNode, parentId);
        //            itemKeys.Add(item.id, node.FlowNodeId);
        //        }
        //    }
        //}
        //private async Task<FlowNode> SaveFLowNodeAsync(tFlowNode item, int parentId)
        //{
        //    FlowNode node = new FlowNode();
        //    node.ParentId = parentId;
        //    node.Id = item.id;
        //    node.Name = item.name ?? item.id;
        //    node.ItemType = ProcessItem.GetProcessType(item);
        //    await FlowNodeStore.CreateAsync(node);
        //    return node;
        //}

        //private async Task<IFlowNode> SaveFlowNodeAsync(tProcess process)
        //{
        //    return await DefinitionStore.CreateFlowNodeAsync(process.id, process.name, ProcessItemType.Process);
        //}

        //private async Task<Process> SaveProcessAsync(tProcess process, int definitionId, int flowNodeId)
        //{
        //    Process proc = new Process();
        //    proc.DefinitionId = definitionId;
        //    proc.Id = process.id;
        //    proc.FlowNodeId = flowNodeId;
        //    proc.Name = process.name;
        //    proc.IsExecutable = process.isExecutable;
        //    proc.IsClosed = process.isClosed;
        //    await ProcessStore.CreateAsync(proc);
        //    return proc;
        //}

        //private async Task<DefinitionItem> SaveDefinitionItem(tItemDefinition item, int definitionId)
        //{
        //    DefinitionItem itemDef = new DefinitionItem();
        //    itemDef.Id = item.id;
        //    itemDef.IsCollection = item.isCollection;
        //    itemDef.StructureRef = item.structureRef.Name;
        //    itemDef.DefinitionId = definitionId;
        //    //itemDef.StoreType = ParseStoreType(itemDef.StructureRef);
        //    await DefinitionItemStore.CreateAsync(itemDef);
        //    return itemDef;
        //}

        #endregion

    }
}
