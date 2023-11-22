namespace practiceASPNET.Domains;

public class RequestApprovedEvent : IEvent
{
    public RequestApprovedEvent(Guid id, string data, Guid requestId)
        : base(id, data, requestId)
    {
        Id = id;
        Data = data;
        RequestId = requestId;
    }

    public static RequestApprovedEvent Create(string data, Guid requestId)
    {
        return new RequestApprovedEvent(Guid.NewGuid(), data, requestId);
    }
}