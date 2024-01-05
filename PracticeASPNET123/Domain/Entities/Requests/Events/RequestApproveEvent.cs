namespace PracticeASPNET.Domain.Entities.Requests.Events;

public class RequestApproveEvent : Event
{
    public RequestApproveEvent(Guid id, Guid requestId, string data)
        : base(id, requestId, data)
    {
    }

    public static RequestApproveEvent Create(Guid requestId, string data)
    {
        return new RequestApproveEvent(Guid.NewGuid(), requestId, data);
    }
}