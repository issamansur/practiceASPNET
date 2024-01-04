namespace PracticeASPNET.Domain.Entities.Requests.Events;

public class RequestRejectEvent : Event
{
    public RequestRejectEvent(Guid id, Guid requestId, string data)
        : base(id, requestId, data)
    {
    }

    public static RequestRejectEvent Create(Guid requestId, string data)
    {
        return new RequestRejectEvent(Guid.NewGuid(), requestId, data);
    }
}