namespace BPMNET.Core
{
    public enum TaskStatus
    {
        New = 0,
        Assigned=1,
        Executing=2,
        Forwarded=3,
        WaitingForApproval=4,
        Canceled=9,
        Completed=10
    }
}
