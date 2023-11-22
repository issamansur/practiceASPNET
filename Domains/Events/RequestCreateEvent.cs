namespace practiceASPNET.Domains;

public class RequestCreateEvent : IEvent
{
    public RequestCreateEvent(Guid id, string data, Guid requestId)
        : base(id, data, requestId)
    {
        Id = id;
        Data = data;
        RequestId = requestId;
    }

    public static RequestCreateEvent Create(string data, Guid requestId)
    {
        return new RequestCreateEvent(Guid.NewGuid(), data, requestId);
    }
}