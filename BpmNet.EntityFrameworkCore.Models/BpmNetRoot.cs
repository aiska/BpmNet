namespace BpmNet.EntityFrameworkCore.Models
{
    public abstract class BpmNetRoot
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string ReffId { get; set; }
    }
}
