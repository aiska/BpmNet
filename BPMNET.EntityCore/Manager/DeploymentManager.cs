using BPMNET.Bpmn;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BPMNET.EntityCore.Manager
{
    public class DeploymentManager
    {
        BpmnProcessStore processStore;
        ProcessItemDefinitionStore itemDefStore;
        BpmnItemDefinitionStore bpmnItemDefinitionStore;
        BpmnSequenceFlowStore sequenceFlowStore;
        BpmnFlowNodeStore flowNodeStore;
        ProcessItemVariableStore processItemVariableStore;

        public DbContext Context { get; set; }

        public DeploymentManager(BpmDbContext context)
        {
            Context = context;
            processStore = new BpmnProcessStore(context);
            itemDefStore = new ProcessItemDefinitionStore(context);
            processItemVariableStore = new ProcessItemVariableStore(context);
            sequenceFlowStore = new BpmnSequenceFlowStore(context);
            flowNodeStore = new BpmnFlowNodeStore(context);
            bpmnItemDefinitionStore = new BpmnItemDefinitionStore(context);
        }

        public void InsertItemDefinition(tRootElement[] items)
        {

        }

        public void DefineProcess(tProcess process, Guid definitionKey)
        {
            BpmnProcess procDef = new BpmnProcess();
            procDef.DefinitionKey = definitionKey;
            procDef.Id = process.id;
            procDef.Name = process.name;
            procDef.IsExecutable = process.isExecutable;
            procDef.IsClosed = process.isClosed;
            processStore.Create(procDef);
            //SetProperty(process.property);

            Dictionary<string, Guid> ItemsKeys = new Dictionary<string, Guid>();
            //Dictionary<Guid, ProcessItemDefinition> itemProcs = new Dictionary<Guid, ProcessItemDefinition>();

            foreach (var item in process.Items.OfType<tFlowNode>())
            {
                BpmnFlowNode node = new BpmnFlowNode();
                node.Id = item.id;
                node.Name = item.name;
                node.ItemType = ProcessItem.GetProcessType(item);

                ItemsKeys.Add(item.id, node.Key);
                flowNodeStore.Create(node);
            }

            foreach (var flow in process.Items.OfType<tSequenceFlow>())
            {
                BpmnSequenceFlow seqFlow = new BpmnSequenceFlow();
                seqFlow.Id = flow.id;
                seqFlow.Name = flow.name;

                Guid ItemSourceRef;
                if (ItemsKeys.TryGetValue(flow.sourceRef, out ItemSourceRef))
                {
                    seqFlow.ItemSourceRef = ItemSourceRef;
                }

                Guid ItemTargetRef;
                if (ItemsKeys.TryGetValue(flow.targetRef, out ItemTargetRef))
                {
                    seqFlow.ItemSourceTarget = ItemTargetRef;
                }

                if (flow.conditionExpression != null)
                {
                    seqFlow.ConditionExpression = string.Join(" ", flow.conditionExpression.Text);
                }
                sequenceFlowStore.Create(seqFlow);
            }
        }

        public void DefineItemDefinition(tItemDefinition item, Guid definitionKey)
        {
            BpmnItemDefinition itemDef = new BpmnItemDefinition();
            itemDef.Id = item.id;
            itemDef.IsCollection = item.isCollection;
            itemDef.StructureRef = item.structureRef.Name;
            itemDef.DefinitionKey = definitionKey;
            bpmnItemDefinitionStore.Create(itemDef);
        }


        public void DeployBpmn(string bpmnFile)
        {
            // Deserialized bpmn file
            var definition = new BpmnNetDefinition(bpmnFile);


            List<ProcessItemDefinition> itemDefs = new List<ProcessItemDefinition>();
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    BpmnDefinition dataDef = new BpmnDefinition();
                    dataDef.Id = definition.Id;
                    //BpmnNetDefinition.DefineDefinitions(def, bpmnFile);
                    
                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                }
            }

        }

        private void SetProperty(tProperty[] properties)
        {
            if (properties != null)
            {
                foreach (var property in properties)
                {
                    ProcessItemVariable procVar = new ProcessItemVariable();
                    procVar.VariableName = property.name;
                    procVar.DataType = property.itemSubjectRef.ToString();
                    processItemVariableStore.Create(procVar);
                }
            }
        }
    }
}
