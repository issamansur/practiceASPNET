namespace PracticeASPNET.Domain.Requests.Events;

public class RequestRejectEvent : IEvent
{
    public RequestRejectEvent(Guid id, Guid requestId, string data)
        : base(id, requestId, data)
    {
    }

    static public RequestRejectEvent Create(Guid requestId, string data)
    {
        return new RequestRejectEvent(Guid.NewGuid(), requestId, data);
    }
}