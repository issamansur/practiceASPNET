namespace PracticeASPNET.Domain.Requests.Events;

public class RequestRestartEvent : Event
{
    public RequestRestartEvent(Guid id, Guid requestId, string data)
        : base(id, requestId, data)
    {
    }

    public static RequestRestartEvent Create(Guid requestId, string data)
    {
        return new RequestRestartEvent(Guid.NewGuid(), requestId, data);
    }
}