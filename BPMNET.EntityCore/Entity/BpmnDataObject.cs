using System;

namespace BPMNET.EntityCore
{
    public class BpmnDataObject : IBaseElement
    {
        public Guid Key { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string ItemSubjectRef { get; set; }
        public bool IsCollection { get; set; }
    }
}
