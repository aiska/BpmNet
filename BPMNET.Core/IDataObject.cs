namespace BPMNET.Core
{
    public interface IDataObject<TKey>
    {
        TKey DataObjectId { get; set; }
        string Id { get; set; }
        string Name { get; set; }
        TKey ItemSubjectRef { get; set; }
        bool IsCollection { get; set; }
    }
}
