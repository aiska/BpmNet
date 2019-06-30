using BpmNet.Abstractions.Flow;
using BpmNet.Bpmn;
using BpmNet.Core.Model;
using BpmNet.Model;
using BpmNet.Resolvers;
using BpmNet.Services;
using BpmNet.Stores;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BpmNet.Core
{
    public class ProcessFlowService<TDefinition, TInstance, TInstanceFlow>
        : IBpmNetProcessService
        where TDefinition : class, IBpmNetDefinition
        where TInstance : class, IProcessInstance<TInstanceFlow>, new()
        where TInstanceFlow : class, IBpmNetInstanceFlow, new()
    {
        private readonly IBpmNetProcessInstanceStore<TInstance, TInstanceFlow> _instanceStore;
        private readonly IBpmNetDefinitionStore<TDefinition> _definitionStore;

        private readonly IBpmNetSequenceFlowProcessService _sequenceFlowProcessService;
        private readonly IBpmNetStartEventProcessService _startEventProcessService;
        private readonly IBpmNetUserTaskProcessService _userTaskProcessService;
        private readonly IBpmNetExclusiveGatewayProcessService _exclusiveGatewayProcessService;
        private readonly IBpmNetInclusiveGatewayProcessService _inclusiveGatewayProcessService;
        private readonly IBpmNetParallelGatewayProcessService _parallelGatewayProcessService;
        private readonly IBpmNetServiceTaskProcessService _serviceTaskProcessService;
        private readonly IBpmNetEndEventProcessService _endEventProcessService;
        private readonly IBpmNetFlowElementProcessService _flowElementProcessService;
        private readonly IBpmNetAdHocSubProcessService _adHocSubProcessProcessService;
        private readonly IBpmNetBoundaryEventProcessService _boundaryEventProcessService;
        private readonly IBpmNetBusinessRuleTaskProcessService _businessRuleTaskProcessService;
        private readonly IBpmNetCallActivityProcessService _callActivityProcessService;
        private readonly IBpmNetCallChoreographyProcessService _callChoreographyProcessService;
        private readonly IBpmNetChoreographyTaskProcessService _choreographyTaskProcessService;
        private readonly IBpmNetComplexGatewayProcessService _complexGatewayProcessService;
        private readonly IBpmNetSendTaskProcessService _sendTaskProcessService;
        private readonly IBpmNetManualTaskProcessService _manualTaskProcessService;
        private readonly IBpmNetScriptTaskProcessService _scriptTaskProcessService;
        private readonly IBpmNetSubProcessProcessService _subProcessProcessService;
        private readonly IBpmNetTaskProcessService _taskProcessService;
        private readonly IBpmNetReceiveTaskProcessService _receiveTaskProcessService;
        private readonly IBpmNetDataObjectProcessService _dataObjectProcessService;
        private readonly IBpmNetDataObjectReferenceProcessService _dataObjectReferenceProcessService;
        private readonly IBpmNetDataStoreReferenceProcessService _dataStoreReferenceProcessService;
        private readonly IBpmNetEventBasedGatewayProcessService _eventBasedGatewayProcessService;
        private readonly IBpmNetImplicitThrowEventProcessService _implicitThrowEventProcessService;
        private readonly IBpmNetIntermediateCatchEventProcessService _intermediateCatchEventProcessService;
        private readonly IBpmNetIntermediateThrowEventProcessService _intermediateThrowEventProcessService;
        private readonly IBpmNetSubChoreographyProcessService _subChoreographyProcessService;
        private readonly IBpmNetTransactionProcessService _transactionProcessService;
        private readonly IBpmNetEventProcessService _eventProcessService;

        public ProcessFlowService(
            IBpmNetSequenceFlowProcessService sequenceFlowProcessService,
            IBpmNetStartEventProcessService startEventProcessService,
            IBpmNetUserTaskProcessService userTaskProcessService,
            IBpmNetExclusiveGatewayProcessService exclusiveGatewayProcessService,
            IBpmNetInclusiveGatewayProcessService inclusiveGatewayProcessService,
            IBpmNetParallelGatewayProcessService parallelGatewayProcessService,
            IBpmNetServiceTaskProcessService serviceTaskProcessService,
            IBpmNetEndEventProcessService endEventProcessService,
            IBpmNetFlowElementProcessService flowElementProcessService,
            IBpmNetAdHocSubProcessService adHocSubProcessProcessService,
            IBpmNetBoundaryEventProcessService boundaryEventProcessService,
            IBpmNetBusinessRuleTaskProcessService businessRuleTaskProcessService,
            IBpmNetCallActivityProcessService callActivityProcessService,
            IBpmNetCallChoreographyProcessService callChoreographyProcessService,
            IBpmNetChoreographyTaskProcessService choreographyTaskProcessService,
            IBpmNetComplexGatewayProcessService complexGatewayProcessService,
            IBpmNetSendTaskProcessService sendTaskProcessService,
            IBpmNetManualTaskProcessService manualTaskProcessService,
            IBpmNetScriptTaskProcessService scriptTaskProcessService,
            IBpmNetSubProcessProcessService subProcessProcessService,
            IBpmNetTaskProcessService taskProcessService,
            IBpmNetReceiveTaskProcessService receiveTaskProcessService,
            IBpmNetDataObjectProcessService dataObjectProcessService,
            IBpmNetDataObjectReferenceProcessService dataObjectReferenceProcessService,
            IBpmNetDataStoreReferenceProcessService dataStoreReferenceProcessService,
            IBpmNetEventBasedGatewayProcessService eventBasedGatewayProcessService,
            IBpmNetImplicitThrowEventProcessService implicitThrowEventProcessService,
            IBpmNetIntermediateCatchEventProcessService intermediateCatchEventProcessService,
            IBpmNetIntermediateThrowEventProcessService intermediateThrowEventProcessService,
            IBpmNetSubChoreographyProcessService subChoreographyProcessService,
            IBpmNetEventProcessService eventProcessService,
            IBpmNetTransactionProcessService transactionProcessService,
            IBpmNetStoreResolver storeResolver)
        {
            _instanceStore = storeResolver.GetProcessInstanceStore<TInstance, TInstanceFlow>();
            _definitionStore = storeResolver.GetDefinitionStore<TDefinition>();

            _sequenceFlowProcessService = sequenceFlowProcessService;
            _startEventProcessService = startEventProcessService;
            _userTaskProcessService = userTaskProcessService;
            _exclusiveGatewayProcessService = exclusiveGatewayProcessService;
            _inclusiveGatewayProcessService = inclusiveGatewayProcessService;
            _parallelGatewayProcessService = parallelGatewayProcessService;
            _serviceTaskProcessService = serviceTaskProcessService;
            _flowElementProcessService = flowElementProcessService;
            _adHocSubProcessProcessService = adHocSubProcessProcessService;
            _boundaryEventProcessService = boundaryEventProcessService;
            _businessRuleTaskProcessService = businessRuleTaskProcessService;
            _callActivityProcessService = callActivityProcessService;
            _callChoreographyProcessService = callChoreographyProcessService;
            _choreographyTaskProcessService = choreographyTaskProcessService;
            _complexGatewayProcessService = complexGatewayProcessService;
            _sendTaskProcessService = sendTaskProcessService;
            _manualTaskProcessService = manualTaskProcessService;
            _scriptTaskProcessService = scriptTaskProcessService;
            _subProcessProcessService = subProcessProcessService;
            _taskProcessService = taskProcessService;
            _receiveTaskProcessService = receiveTaskProcessService;
            _dataObjectProcessService = dataObjectProcessService;
            _dataObjectReferenceProcessService = dataObjectReferenceProcessService;
            _dataStoreReferenceProcessService = dataStoreReferenceProcessService;
            _eventBasedGatewayProcessService = eventBasedGatewayProcessService;
            _endEventProcessService = endEventProcessService;
            _implicitThrowEventProcessService = implicitThrowEventProcessService;
            _intermediateCatchEventProcessService = intermediateCatchEventProcessService;
            _intermediateThrowEventProcessService = intermediateThrowEventProcessService;
            _subChoreographyProcessService = subChoreographyProcessService;
            _eventProcessService = eventProcessService;
            _transactionProcessService = transactionProcessService;
        }


        BpmnProcess process;
        private async Task<BpmnProcess> GetProcessAsync(string processId, CancellationToken cancellationToken)
        {
            if (process == null || process.Id != processId)
            {
                process = await _definitionStore.GetProcessAsync(processId, cancellationToken);
                if (process == null)
                {
                    throw new ArgumentException("Process not found.");
                }
            }
            return process;
        }
        private async Task<IEnumerable<BpmnSequenceFlow>> GetBySourceRefAsync(string processId, string sourceRef, CancellationToken cancellationToken)
        {
            var process = await GetProcessAsync(processId, cancellationToken);
            return process.Items.OfType<BpmnSequenceFlow>().Where(t => t.SourceRef == sourceRef);
        }

        private async Task<IEnumerable<BpmnStartEvent>> GetByStartEventAsync(string processId, CancellationToken cancellationToken)
        {
            var process = await GetProcessAsync(processId, cancellationToken);
            return process.Items.OfType<BpmnStartEvent>();
        }

        private async Task<BpmnFlowElement> GetFlowAsync(string processId, string flowId, CancellationToken cancellationToken)
        {
            var process = await GetProcessAsync(processId, cancellationToken);
            return process.Items.FirstOrDefault(t => t.Id == flowId);
        }

        private async Task ProcessFlowAsync(TInstance instance, string flowId, CancellationToken cancellationToken)
        {
            var instanceFlow = await _instanceStore.GetOrAddInstanceFlowAsync(instance, flowId);
            var flowTask = GetFlowAsync(instance.ProcessId, flowId, cancellationToken);
            if (IsCanProcess(instanceFlow.Status))
            {
                var flow = await flowTask;
                var executeTask = ExecuteFlowAsync(instance, flow, cancellationToken);
                instanceFlow.ElementType = ProcessItemType.GetItemType(flow);
                instanceFlow.Status = await executeTask;
                if (instanceFlow.Status == FlowResult.Completed)
                {
                    await ExecuteCompleteAsync(instance, flow, cancellationToken);
                    var next = ProcessNextFlow(instance, flow, cancellationToken);
                    instanceFlow.Finnish = DateTime.Now;
                    instanceFlow.Duration = (instanceFlow.Finnish.Value - instanceFlow.Start).Milliseconds;
                    await next;
                }
            }
        }

        private bool IsCanProcess(FlowResult status)
        {
            return status == FlowResult.NotStarted;
        }

        private Task ExecuteCompleteAsync(TInstance instance, BpmnFlowElement flow, CancellationToken cancellationToken)
        {
            if (flow is BpmnSequenceFlow sequenceFlow)
            {
                return _sequenceFlowProcessService.OnCompleteAsync(instance, sequenceFlow, cancellationToken);
            }
            if (flow is BpmnGateway)
            {
                if (flow is BpmnParallelGateway parallelGateway)
                {
                    return _parallelGatewayProcessService.OnCompleteAsync(instance, parallelGateway, cancellationToken);
                }
                if (flow is BpmnInclusiveGateway inclusiveGateway)
                {
                    return _inclusiveGatewayProcessService.OnCompleteAsync(instance, inclusiveGateway, cancellationToken);
                }
                if (flow is BpmnExclusiveGateway exclusiveGateway)
                {
                    return _exclusiveGatewayProcessService.OnCompleteAsync(instance, exclusiveGateway, cancellationToken);
                }
                if (flow is BpmnComplexGateway complexGateway)
                {
                    return _complexGatewayProcessService.OnCompleteAsync(instance, complexGateway, cancellationToken);
                }
                if (flow is BpmnEventBasedGateway eventBasedGateway)
                {
                    return _eventBasedGatewayProcessService.OnCompleteAsync(instance, eventBasedGateway, cancellationToken);
                }
            }
            if (flow is BpmnTask task)
            {
                if (flow is BpmnUserTask userTask)
                {
                    return _userTaskProcessService.OnCompleteAsync(instance, userTask, cancellationToken);
                }
                if (flow is BpmnServiceTask serviceTask)
                {
                    return _serviceTaskProcessService.OnCompleteAsync(instance, serviceTask, cancellationToken);
                }
                if (flow is BpmnBusinessRuleTask businessRuleTask)
                {
                    return _businessRuleTaskProcessService.OnCompleteAsync(instance, businessRuleTask, cancellationToken);
                }
                if (flow is BpmnManualTask manualTask)
                {
                    return _manualTaskProcessService.OnCompleteAsync(instance, manualTask, cancellationToken);
                }
                if (flow is BpmnReceiveTask receiveTask)
                {
                    return _receiveTaskProcessService.OnCompleteAsync(instance, receiveTask, cancellationToken);
                }
                if (flow is BpmnScriptTask scriptTask)
                {
                    return _scriptTaskProcessService.OnCompleteAsync(instance, scriptTask, cancellationToken);
                }
                if (flow is BpmnSendTask sendTask)
                {
                    return _sendTaskProcessService.OnCompleteAsync(instance, sendTask, cancellationToken);
                }
                return _taskProcessService.OnCompleteAsync(instance, task, cancellationToken);
            }
            if (flow is BpmnEvent bpmnEvent)
            {
                if (flow is BpmnStartEvent startEvent)
                {
                    return _startEventProcessService.OnCompleteAsync(instance, startEvent, cancellationToken);
                }
                if (flow is BpmnEndEvent endEvent)
                {
                    return _endEventProcessService.OnCompleteAsync(instance, endEvent, cancellationToken);
                }
                if (flow is BpmnIntermediateCatchEvent intermediateCatchEvent)
                {
                    return _intermediateCatchEventProcessService.OnCompleteAsync(instance, intermediateCatchEvent, cancellationToken);
                }
                if (flow is BpmnImplicitThrowEvent implicitThrowEvent)
                {
                    return _implicitThrowEventProcessService.OnCompleteAsync(instance, implicitThrowEvent, cancellationToken);
                }
                if (flow is BpmnBoundaryEvent boundaryEvent)
                {
                    return _boundaryEventProcessService.OnCompleteAsync(instance, boundaryEvent, cancellationToken);
                }
                if (flow is BpmnIntermediateThrowEvent intermediateThrowEvent)
                {
                    return _intermediateThrowEventProcessService.OnCompleteAsync(instance, intermediateThrowEvent, cancellationToken);
                }
                return _eventProcessService.OnCompleteAsync(instance, bpmnEvent, cancellationToken);
            }
            if (flow is BpmnSubProcess subProcess)
            {
                if (flow is BpmnAdHocSubProcess adHocSubProcess)
                {
                    return _adHocSubProcessProcessService.OnCompleteAsync(instance, adHocSubProcess, cancellationToken);
                }
                if (flow is BpmnTransaction transaction)
                {
                    return _transactionProcessService.OnCompleteAsync(instance, transaction, cancellationToken);
                }
                return _subProcessProcessService.OnCompleteAsync(instance, subProcess, cancellationToken);
            }
            if (flow is BpmnCallActivity callActivity)
            {
                return _callActivityProcessService.OnCompleteAsync(instance, callActivity, cancellationToken);
            }
            if (flow is BpmnCallChoreography callChoreography)
            {
                return _callChoreographyProcessService.OnCompleteAsync(instance, callChoreography, cancellationToken);
            }
            if (flow is BpmnChoreographyTask choreographyTask)
            {
                return _choreographyTaskProcessService.OnCompleteAsync(instance, choreographyTask, cancellationToken);
            }
            if (flow is BpmnDataObject dataObject)
            {
                return _dataObjectProcessService.OnCompleteAsync(instance, dataObject, cancellationToken);
            }
            if (flow is BpmnDataObjectReference dataObjectReference)
            {
                return _dataObjectReferenceProcessService.OnCompleteAsync(instance, dataObjectReference, cancellationToken);
            }
            if (flow is BpmnDataStoreReference dataStoreReference)
            {
                return _dataStoreReferenceProcessService.OnCompleteAsync(instance, dataStoreReference, cancellationToken);
            }
            if (flow is BpmnSubChoreography subChoreography)
            {
                return _subChoreographyProcessService.OnCompleteAsync(instance, subChoreography, cancellationToken);
            }
            return _flowElementProcessService.OnCompleteAsync(instance, flow, cancellationToken);
        }

        private Task<FlowResult> ExecuteFlowAsync(TInstance instance, BpmnFlowElement flow, CancellationToken cancellationToken)
        {
            if (flow is BpmnSequenceFlow sequenceFlow)
            {
                return _sequenceFlowProcessService.ExecuteAsync(instance, sequenceFlow, cancellationToken);
            }
            if (flow is BpmnGateway)
            {
                if (flow is BpmnParallelGateway parallelGateway)
                {
                    return _parallelGatewayProcessService.ExecuteAsync(instance, parallelGateway, cancellationToken);
                }
                if (flow is BpmnInclusiveGateway inclusiveGateway)
                {
                    return _inclusiveGatewayProcessService.ExecuteAsync(instance, inclusiveGateway, cancellationToken);
                }
                if (flow is BpmnExclusiveGateway exclusiveGateway)
                {
                    return _exclusiveGatewayProcessService.ExecuteAsync(instance, exclusiveGateway, cancellationToken);
                }
                if (flow is BpmnComplexGateway complexGateway)
                {
                    return _complexGatewayProcessService.ExecuteAsync(instance, complexGateway, cancellationToken);
                }
                if (flow is BpmnEventBasedGateway eventBasedGateway)
                {
                    return _eventBasedGatewayProcessService.ExecuteAsync(instance, eventBasedGateway, cancellationToken);
                }
            }
            if (flow is BpmnTask task)
            {
                if (flow is BpmnUserTask userTask)
                {
                    return _userTaskProcessService.ExecuteAsync(instance, userTask, cancellationToken);
                }
                if (flow is BpmnServiceTask serviceTask)
                {
                    return _serviceTaskProcessService.ExecuteAsync(instance, serviceTask, cancellationToken);
                }
                if (flow is BpmnBusinessRuleTask businessRuleTask)
                {
                    return _businessRuleTaskProcessService.ExecuteAsync(instance, businessRuleTask, cancellationToken);
                }
                if (flow is BpmnManualTask manualTask)
                {
                    return _manualTaskProcessService.ExecuteAsync(instance, manualTask, cancellationToken);
                }
                if (flow is BpmnReceiveTask receiveTask)
                {
                    return _receiveTaskProcessService.ExecuteAsync(instance, receiveTask, cancellationToken);
                }
                if (flow is BpmnScriptTask scriptTask)
                {
                    return _scriptTaskProcessService.ExecuteAsync(instance, scriptTask, cancellationToken);
                }
                if (flow is BpmnSendTask sendTask)
                {
                    return _sendTaskProcessService.ExecuteAsync(instance, sendTask, cancellationToken);
                }
                return _taskProcessService.ExecuteAsync(instance, task, cancellationToken);
            }
            if (flow is BpmnEvent bpmnEvent)
            {
                if (flow is BpmnStartEvent startEvent)
                {
                    return _startEventProcessService.ExecuteAsync(instance, startEvent, cancellationToken);
                }
                if (flow is BpmnEndEvent endEvent)
                {
                    return _endEventProcessService.ExecuteAsync(instance, endEvent, cancellationToken);
                }
                if (flow is BpmnIntermediateCatchEvent intermediateCatchEvent)
                {
                    return _intermediateCatchEventProcessService.ExecuteAsync(instance, intermediateCatchEvent, cancellationToken);
                }
                if (flow is BpmnImplicitThrowEvent implicitThrowEvent)
                {
                    return _implicitThrowEventProcessService.ExecuteAsync(instance, implicitThrowEvent, cancellationToken);
                }
                if (flow is BpmnBoundaryEvent boundaryEvent)
                {
                    return _boundaryEventProcessService.ExecuteAsync(instance, boundaryEvent, cancellationToken);
                }
                if (flow is BpmnIntermediateThrowEvent intermediateThrowEvent)
                {
                    return _intermediateThrowEventProcessService.ExecuteAsync(instance, intermediateThrowEvent, cancellationToken);
                }
                return _eventProcessService.ExecuteAsync(instance, bpmnEvent, cancellationToken);
            }
            if (flow is BpmnSubProcess subProcess)
            {
                if (flow is BpmnAdHocSubProcess adHocSubProcess)
                {
                    return _adHocSubProcessProcessService.ExecuteAsync(instance, adHocSubProcess, cancellationToken);
                }
                if (flow is BpmnTransaction transaction)
                {
                    return _transactionProcessService.ExecuteAsync(instance, transaction, cancellationToken);
                }
                return _subProcessProcessService.ExecuteAsync(instance, subProcess, cancellationToken);
            }
            if (flow is BpmnCallActivity callActivity)
            {
                return _callActivityProcessService.ExecuteAsync(instance, callActivity, cancellationToken);
            }
            if (flow is BpmnCallChoreography callChoreography)
            {
                return _callChoreographyProcessService.ExecuteAsync(instance, callChoreography, cancellationToken);
            }
            if (flow is BpmnChoreographyTask choreographyTask)
            {
                return _choreographyTaskProcessService.ExecuteAsync(instance, choreographyTask, cancellationToken);
            }
            if (flow is BpmnDataObject dataObject)
            {
                return _dataObjectProcessService.ExecuteAsync(instance, dataObject, cancellationToken);
            }
            if (flow is BpmnDataObjectReference dataObjectReference)
            {
                return _dataObjectReferenceProcessService.ExecuteAsync(instance, dataObjectReference, cancellationToken);
            }
            if (flow is BpmnDataStoreReference dataStoreReference)
            {
                return _dataStoreReferenceProcessService.ExecuteAsync(instance, dataStoreReference, cancellationToken);
            }
            if (flow is BpmnSubChoreography subChoreography)
            {
                return _subChoreographyProcessService.ExecuteAsync(instance, subChoreography, cancellationToken);
            }
            return _flowElementProcessService.ExecuteAsync(instance, flow, cancellationToken);
        }

        public async Task ProcessTargetSequenceFlowAsync(TInstance instance, string sourceId, CancellationToken cancellationToken)
        {
            var tasks = (await GetBySourceRefAsync(instance.ProcessId, sourceId, cancellationToken)).Select(async flow =>
            {
                await ProcessFlowAsync(instance, flow.TargetRef, cancellationToken);
            });
            await Task.WhenAll(tasks);
        }

        private Task ProcessNextFlow(TInstance instance, BpmnFlowElement flow, CancellationToken cancellationToken)
        {
            if (flow is BpmnFlowNode flowNode)
            {
                if (flowNode.Outgoing != null)
                {
                    var tasks = flowNode.Outgoing.Select(async outgoing =>
                    {
                        await ProcessFlowAsync(instance, outgoing.Name, cancellationToken);
                    });
                    return Task.WhenAll(tasks);
                }
            }
            if (flow is BpmnSequenceFlow sequence)
            {
                return ProcessFlowAsync(instance, sequence.TargetRef, cancellationToken);
            }
            if (flow is BpmnEndEvent endEvent)
            {
                foreach (var item in instance.Flows)
                {
                    if (item.Status != FlowResult.Completed && item.Status != FlowResult.NotProcessing && item.Status != FlowResult.Cancelled)
                    {
                        item.Status = FlowResult.Cancelled;
                    }
                }
                instance.Status = InstanceStatus.Completed;
            }
            return ProcessTargetSequenceFlowAsync(instance, flow.Id, cancellationToken);
        }

        public async Task<IProcessInstance> StartProcessAsync(Guid instanceId, CancellationToken cancellationToken)
        {
            var instance = await _instanceStore.GetInstanceAsync(instanceId);
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instanceId), "Process Instance not found.");
            }
            await StartProcessAsync(instance, cancellationToken);
            //instance.Flows = ImmutableList.CreateRange(instance.Flows);
            await _instanceStore.SaveChangesAsync();
            return instance;
        }

        private async Task StartProcessAsync(TInstance instance, CancellationToken cancellationToken)
        {
            var tasks = (await GetByStartEventAsync(instance.ProcessId, cancellationToken)).Select(async startEvent =>
            {
                await ProcessFlowAsync(instance, startEvent.Id, cancellationToken);
            });
            await Task.WhenAll(tasks);
        }

        public Task<IProcessInstance> StartProcessAsync(string processId, string bussinessKey, CancellationToken cancellationToken)
        {
            return StartProcessAsync(processId, bussinessKey, null, cancellationToken);
        }

        public async Task<IProcessInstance> StartProcessAsync(string processId, string bussinessKey, string tenantId, CancellationToken cancellationToken)
        {
            var instance = new TInstance
            {
                Id = Guid.NewGuid(),
                ProcessId = processId,
                BussinesKey = bussinessKey,
                TenantId = tenantId,
                Status = InstanceStatus.InProcess,
            };
            var addTask = _instanceStore.AddAsync(instance);
            await StartProcessAsync(instance, cancellationToken);
            instance.Flows = ImmutableList.CreateRange(instance.Flows);
            await addTask;
            await _instanceStore.SaveChangesAsync();
            return instance;
        }

        public Task<ImmutableArray<TResult>> ListProcessInstanceAsync<TResult>(Func<IQueryable<object>, IQueryable<TResult>> query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return _instanceStore.ListAsync(query, cancellationToken);
        }

        public Task<ImmutableArray<TResult>> ListProcessAsync<TResult>(Func<IQueryable<object>, IQueryable<TResult>> query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return _instanceStore.ListAsync(query, cancellationToken);
        }
    }
}
