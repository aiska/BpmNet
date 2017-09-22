using BPMNET.Bpmn;
using BPMNET.Core;

namespace BPMNET.Entity
{
    public class FlowNodeEntity : IFlowNode<int>
    {
        public int Id { get; set; }
        public string FlowNodeId { get; set; }
        public int? ParentId { get; set; }
        public string Processid { get; set; }
        //public int ProcessId { get; set; }
        public string Name { get; set; }
        public ProcessItemType ItemType { get; set; }
        //public bool IsForCompensation { get; set; }
        //public int StartQuantity { get; set; }
        //public int CompletionQuantity { get; set; }

        public string[] UserCandidates { get; private set; }
        public string[] RoleCandidates { get; private set; }
        public string Users
        {
            get
            {
                if (UserCandidates == null) return null;
                return string.Join(",", UserCandidates);
            }
            set
            {
                if (value == null)
                    UserCandidates = null;
                else
                    UserCandidates = value.Split(',');
            }
        }
        public string Roles
        {
            get
            {
                if (RoleCandidates == null) return null;
                return string.Join(",", RoleCandidates);
            }
            set
            {
                if (value == null)
                    UserCandidates = null;
                else
                    UserCandidates = value.Split(',');
            }
        }
    }
}
