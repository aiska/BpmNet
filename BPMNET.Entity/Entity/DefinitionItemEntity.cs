using BPMNET.Core;

namespace BPMNET.Entity
{
    public class DefinitionItemEntity : IDefinitionItem<int>
    {
        public int Id { get; set; }
        public int DeploymentId { get; set; }
        public string DefinitionItemId { get; set; }
        public bool IsCollection { get; set; }
        public string StructureRef { get; set; }
    }
}
