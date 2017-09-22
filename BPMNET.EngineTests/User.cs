using BPMNET.Core;

namespace BPMNET.EngineTests
{
    public class User : IUser<Group, Role>
    {
        public string UserId { get; set; }
        public Role[] Roles { get; set; }
        public Group[] Workgroups { get; set; }
    }
    public class Group : IGroup
    {
        public string GroupId { get; set; }
    }

    public class Role : IRole
    {
        public string RoleId { get; set; }
    }
}
