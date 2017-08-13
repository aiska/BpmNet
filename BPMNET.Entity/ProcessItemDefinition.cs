using BPMNET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Entity
{
    public class ProcessItemDefinition<TKey> : IProcessItemDefinition<TKey>
    {
        public TKey Id { get; set; }
        public TKey ProcessDefinitionId { get; set; }
        public string Name { get; set; }
        public string Incoming { get; set; }
        public string Outgoing { get; set; }
        public string SourceRef { get; set; }
        public string TargetRef { get; set; }
        public string CompletionQuantity { get; set; }
        public bool IsForCompensation { get; set; }
        public string StartQuantity { get; set; }
        public EProcessItemType Type { get; set; }
        public ICollection<string> UserCandidates { get; set; }
        public ICollection<string> RoleCandidates { get; set; }
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
        public DateTime? DueDate { get; set; }
    }
}
