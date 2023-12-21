namespace PracticeASPNET.Domain.Requests.Events;

public class RequestApproveEvent : IEvent
{
    public RequestApproveEvent(Guid id, Guid requestId, string data)
        : base(id, requestId, data)
    {
    }

    static public RequestApproveEvent Create(Guid requestId, string data)
    {
        return new RequestApproveEvent(Guid.NewGuid(), requestId, data);
    }
}