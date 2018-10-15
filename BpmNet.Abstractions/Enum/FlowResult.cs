namespace BpmNet
{
    public enum FlowResult
    {
        NotStarted = 0,
        InProcess = 1,
        Claimed = 2,
        Escalate = 3,
        NotProcessing = 6,
        WaitingOtherProcess = 7,
        Cancelled = 8,
        Completed = 9
    }
}
