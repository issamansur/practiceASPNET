public class RequestCreateEvent : IEvent
{
    public int RequestId { get; set; }
    public Request Request { get; set; }
}