namespace practiceASPNET.Domain.Requests.Events;

public class RequestCreateEvent : IEvent
{
    public RequestCreateEvent(Guid id, Guid requestId, string data)
        : base(id, requestId, data)
    {
    }

    static public RequestCreateEvent Create(Guid requestId, string data)
    {
        return new RequestCreateEvent(Guid.NewGuid(), requestId, data);
    }
}