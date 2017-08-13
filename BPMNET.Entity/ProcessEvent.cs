using BPMNET.Core;
using System;
using System.Collections.Generic;

namespace BPMNET.Entity
{
    public class ProcessEvent : IProcessEvent
    {
        //private string ACTION_ADD_USER_LINK = "AddUserLink";
        //private string ACTION_DELETE_USER_LINK = "DeleteUserLink";
        //private string ACTION_ADD_GROUP_LINK = "AddGroupLink";
        //private string ACTION_DELETE_GROUP_LINK = "DeleteGroupLink";
        //private string ACTION_ADD_COMMENT = "AddComment";
        //private string ACTION_ADD_ATTACHMENT = "AddAttachment";
        //private string ACTION_DELETE_ATTACHMENT = "DeleteAttachment";

        public string Id { get; set; }

        public string Action { get; set; }

        public ICollection<string> MessageParts { get; set; }

        public string Message { get; set; }

        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }

        public string TaskId { get; set; }
        public string ProcessInstanceId { get; set; }
    }
}
