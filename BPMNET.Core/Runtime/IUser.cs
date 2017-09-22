namespace BPMNET.Core
{
    public interface IUser
    {
        string UserId { get; set; }
    }

    public interface IUser<TGroup, TRole> : IUser
        where TGroup : IGroup
        where TRole : IRole
    {
        TGroup[] Workgroups { get; set; }
        TRole[] Roles { get; set; }
    }
}
