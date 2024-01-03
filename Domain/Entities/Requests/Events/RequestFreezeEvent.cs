namespace PracticeASPNET.Domain.Requests.Events;

public class RequestFreezeEvent : Event
{
    public RequestFreezeEvent(Guid id, Guid requestId, string data)
        : base(id, requestId, data)
    {
    }

    public static RequestFreezeEvent Create(Guid requestId, string data)
    {
        return new RequestFreezeEvent(Guid.NewGuid(), requestId, data);
    }
}