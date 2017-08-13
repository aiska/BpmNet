using BPMNET.Bpmn;
using System;

namespace BPMNET.EntityCore
{
    public class BpmnItemDefinition : IBaseElement
    {
        public BpmnItemDefinition()
        {
            Key = Guid.NewGuid();
        }
        public Guid Key { get; set; }
        public Guid DefinitionKey { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string StructureRef { get; set; }
        public bool IsCollection { get; set; }
        public tItemKind ItemKind { get; set; }
    }
}
