namespace BPMNET.EntityCore
{
    public abstract class ProcessVariableBase
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string DataType { get; set; }
    }
}
