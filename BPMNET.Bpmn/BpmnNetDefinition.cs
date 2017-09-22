using BPMNET.Bpmn.Exception;
using BPMNET.Exception;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace BPMNET.Bpmn
{
    public class BpmnNetDefinition
    {
        private const string ID = "id";
        private const string NAME = "name";
        private const string NOT_IMPLEMENT = "Unknown Item Definition of ";

        public tDefinitions Definition { get; private set; }
        protected XmlDocument Doc { get; private set; }

        public bool IsModified { get; private set; }


        private string _id;
        /// <summary>
        /// Get Set Id of Definition
        /// </summary>
        public string Id
        {
            get
            {
                if (_id == null)
                {
                    var val = Doc.DocumentElement.Attributes[ID];
                    _id = (val == null) ? string.Empty : val.ToString();
                }
                return _id;
            }
            set
            {
                value.ThrowIfNull();
                var root = Doc.DocumentElement;
                var current = Doc.DocumentElement.Attributes[ID];
                if (current == null || !current.Value.Equals(value))
                {
                    IsModified = true;
                    root.SetAttribute(ID, value);
                    _id = value;
                }
            }
        }

        private string _name;

        /// <summary>
        /// Get Set Id of Definition
        /// </summary>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    var val = Doc.DocumentElement.Attributes[NAME];
                    _name = (val == null) ? "" : val.ToString();
                }
                return _name;
            }
            set
            {
                value.ThrowIfNull();
                var root = Doc.DocumentElement;
                var current = Doc.DocumentElement.Attributes[NAME];
                if (current == null || !current.Value.Equals(value))
                {
                    IsModified = true;
                    root.SetAttribute(NAME, value);
                    _name = value;
                }
            }
        }

        #region Constructor ...
        public BpmnNetDefinition(string fileName)
        {
            Doc = new XmlDocument();
            using (var xmlStream = new StreamReader(fileName))
            {
                try
                {
                    var serializer = new XmlSerializer(typeof(tDefinitions));
                    Definition = (tDefinitions)serializer.Deserialize(xmlStream);
                    xmlStream.BaseStream.Position = 0;
                    Doc.Load(xmlStream);
                }
                catch (System.Exception ex)
                {
                    throw new CouldNotLoadBpmnFileException(fileName, ex);
                }
            }
        }
        #endregion

        public string GetXml()
        {
            return Doc.InnerXml;
        }

        public tRootElement GetRootElement(string id)
        {
            id.ThrowIfNull();
            return Definition.Items.Single(t => t.id.Equals(id));
        }

        public bool TryGetRootElement(string id, out tRootElement element)
        {
            element = null;
            if (id == null) return false;
            element = Definition.Items.FirstOrDefault(t => t.id.Equals(id));
            return (element != null);
        }

        public ItemDefinitionType GetItemDefinitionType(string elementId)
        {
            tRootElement element = GetRootElement(elementId);
            if (BpmnRootElement.IsCategory(element)) return ItemDefinitionType.Category;
            else if (BpmnRootElement.IsCollaboration(element)) return ItemDefinitionType.Collaboration;
            else if (BpmnRootElement.IsCorrelationProperty(element)) return ItemDefinitionType.CorrelationProperty;
            else if (BpmnRootElement.IsDataStore(element)) return ItemDefinitionType.DataStore;
            else if (BpmnRootElement.IsEndPoint(element)) return ItemDefinitionType.EndPoint;
            else if (BpmnRootElement.IsError(element)) return ItemDefinitionType.Error;
            else if (BpmnRootElement.IsEscalation(element)) return ItemDefinitionType.Escalation;
            else if (BpmnRootElement.IsEventDefinition(element)) return ItemDefinitionType.EventDefinition;
            else if (BpmnRootElement.IsGlobalBusinessRuleTask(element)) return ItemDefinitionType.GlobalBusinessRuleTask;
            else if (BpmnRootElement.IsGlobalManualTask(element)) return ItemDefinitionType.GlobalManualTask;
            else if (BpmnRootElement.IsGlobalScriptTask(element)) return ItemDefinitionType.GlobalScriptTask;
            else if (BpmnRootElement.IsGlobalTask(element)) return ItemDefinitionType.GlobalTask;
            else if (BpmnRootElement.IsGlobalUserTask(element)) return ItemDefinitionType.GlobalUserTask;
            else if (BpmnRootElement.IsInterface(element)) return ItemDefinitionType.Interface;
            else if (BpmnRootElement.IsItemDefinition(element)) return ItemDefinitionType.ItemDefinition;
            else if (BpmnRootElement.IsMessage(element)) return ItemDefinitionType.Message;
            else if (BpmnRootElement.IsPartnerEntity(element)) return ItemDefinitionType.PartnerEntity;
            else if (BpmnRootElement.IsPartnerRole(element)) return ItemDefinitionType.PartnerRole;
            else if (BpmnRootElement.IsProcess(element)) return ItemDefinitionType.Process;
            else if (BpmnRootElement.IsResource(element)) return ItemDefinitionType.Resource;
            else if (BpmnRootElement.IsRootElement(element)) return ItemDefinitionType.RootElement;
            else if (BpmnRootElement.IsSignal(element)) return ItemDefinitionType.Signal;
            else throw new System.NotImplementedException(NOT_IMPLEMENT + element.GetType().Name);
        }

        public IEnumerable<tProcess> GetAllProcess()
        {
            return Definition.Items.OfType<tProcess>();
        }

        public tProcess GetProcess(string id)
        {
            id.ThrowIfNull();
            return Definition.Items.OfType<tProcess>().Single(t => t.id.Equals(id));
        }

        public bool TryGetProcess(string id, out tProcess process)
        {
            process = null;
            if (id == null) return false;
            process = Definition.Items.OfType<tProcess>().FirstOrDefault(t => t.id.Equals(id));
            return (process != null);
        }

        public tFlowElement GetFlowElement(tProcess process, string id)
        {
            id.ThrowIfNull();
            return process.Items.Single(t => t.id.Equals(id));
        }

        public bool TryGetFlowElement(tProcess process, string id, out tFlowElement elm)
        {
            elm = null;
            if (id == null) return false;
            elm = process.Items.FirstOrDefault(t => t.id.Equals(id));
            return (elm != null);
        }

        public tSequenceFlow GetSequenceFlow(tProcess process, string id)
        {
            id.ThrowIfNull();
            return process.Items.OfType<tSequenceFlow>().Single(t => t.id.Equals(id));
        }

        public bool TryGetSequenceFlow(tProcess process, string id, out tSequenceFlow elm)
        {
            elm = null;
            if (id == null) return false;
            elm = process.Items.OfType<tSequenceFlow>().FirstOrDefault(t => t.id.Equals(id));
            return (elm != null);
        }

        public IEnumerable<tFlowNode> getFlowNode(tProcess process)
        {
            process.ThrowIfNull();
            return process.Items.OfType<tFlowNode>();
        }

        /// <summary>
        /// Get Next sequence for process
        /// </summary>
        /// <param name="process">Current Process to find next sequence</param>
        /// <param name="flowId">id of current flow element</param>
        /// <returns></returns>
        public IEnumerable<tFlowElement> GetNextSequence(tProcess process, string flowId)
        {
            //Check From Incoming
            var tFlowElement = getFlowNode(process).FirstOrDefault(t => t.id.Equals(flowId));
            if (tFlowElement != null && tFlowElement.incoming != null && tFlowElement.incoming.Length > 0)
            {
                foreach (var item in tFlowElement.incoming)
                {
                    if (item.Name != null)
                    {
                        tSequenceFlow sequenceFlow;
                        if (TryGetSequenceFlow(process, item.Name, out sequenceFlow))
                        {
                            yield return GetFlowElement(process, sequenceFlow.targetRef); ;
                        }
                    }
                }
            }
            else // Incoming not found in node, so looking in sequence flow
            {
                var sequenceFlows = process.Items.OfType<tSequenceFlow>().Where(t => t.sourceRef.Equals(flowId));
                // TODO add filter For a Process: Of the types of FlowNode, only Activities, Gateways, and Events
                // can be the source. However, Activities that are Event Sub - Processes are not
                // allowed to be a source.
                // For a Choreography: Of the types of FlowNode, only Choreography Activities,
                // Gateways, and Events can be the source.

                foreach (var item in sequenceFlows)
                {
                    //TODO Get condition and isImmediate.
                    yield return GetFlowElement(process, item.targetRef);

                    // TODO add filter For a Process: Of the types of FlowNode, only Activities, Gateways, and Events
                    // can be the target. However, Activities that are Event Sub - Processes are not allowed to be a target.
                    // For a Choreography: Of the types of FlowNode, only Choreography Activities,
                    // Gateways, and Events can be the target.
                }
            }

        }

        public IEnumerable<tStartEvent> GetStartItem(tProcess process)
        {
            return process.Items.OfType<tStartEvent>();
        }

        public IEnumerable<tItemDefinition> GetAllItemDefinition()
        {
            try
            {
                return Definition.Items.OfType<tItemDefinition>();
            }
            catch (System.Exception)
            {
                throw new ItemDefinitionNotFoundException("Item Definition Not Found in Definition");
            }
        }

        public tItemDefinition GetItemDefinition(tDefinitions definition, string id)
        {
            return definition.Items.OfType<tItemDefinition>().FirstOrDefault(t => t.id.Equals(id));
        }

        public bool TryGetItemDefinition(tDefinitions definition, string itemSubjectRef, out tItemDefinition item)
        {
            item = definition.Items.OfType<tItemDefinition>().FirstOrDefault(t => t.id.Equals(itemSubjectRef));
            return (item != null);
        }
    }
}
