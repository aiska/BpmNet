using System;

namespace BPMNET.EntityCore
{
    public class BpmnSequenceFlow : IBaseElement
    {
        public BpmnSequenceFlow()
        {
            Key = Guid.NewGuid();
        }
        public Guid Key { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public Guid ItemSourceRef { get; set; }
        public Guid ItemSourceTarget { get; set; }
        public string ConditionExpression { get; internal set; }
    }
}
