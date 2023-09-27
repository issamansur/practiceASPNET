public class RequestApprovedEvent : IEvent
{
    public int RequestId { get; set; }
    public Request Request { get; set; }
}