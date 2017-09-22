using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BPMNET.Entity.Store
{
    public class CommentStore : BaseStore<int, Comment>
    {
        public CommentStore() : this(new BpmDbContext())
        {
            DisposeContext = true;
        }
        public CommentStore(BpmDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Comment>> GetPrivateCommentsAsync(int processInstanceId)
        {
            return await Entities.Where(t => t.ProcessInstanceId.Equals(processInstanceId) && t.IsPrivateComment).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync(int processInstanceId)
        {
            return await Entities.Where(t => t.ProcessInstanceId.Equals(processInstanceId)).ToListAsync();
        }
    }
}
