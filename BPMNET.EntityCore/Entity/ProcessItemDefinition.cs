using BPMNET.Bpmn;
using System;

namespace BPMNET.EntityCore
{
    public class ProcessItemDefinition
    {
        public ProcessItemDefinition()
        {
            Key = Guid.NewGuid();
        }

        public Guid Key { get; set; }
        public Guid ProcessKey { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public ProcessItemType ItemType { get; set; }
        public Guid ItemSourceRef { get; set; }
        public Guid ItemSourceTarget { get; set; }
        public string ConditionExpression { get; internal set; }
        public string itemSubjectRef { get; set; }
    }
}
