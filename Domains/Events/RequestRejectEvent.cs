namespace practiceASPNET.Domains;

public class RequestRejectEvent : IEvent
{
    public RequestRejectEvent(Guid id, string data, Guid requestId)
        : base(id, data, requestId)
    {
        Id = id;
        Data = data;
        RequestId = requestId;
    }
    
    public static RequestRejectEvent Create(string data, Guid requestId)
    {
        return new RequestRejectEvent(Guid.NewGuid(), data, requestId);
    }
}