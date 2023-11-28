using practiceASPNET.Utils;

namespace practiceASPNET.Domain.Requests.Events;

// Use abstract class instead of interface
// because we create a base class for all events

public abstract class IEvent
{
    public Guid Id { get; init; }
    public Guid RequestId { get; set; }
    public string Data { get; set; }

    public IEvent(Guid id, Guid requestId, string data)
    {
        Validator.IsValidGuid(id);
        Validator.IsValidGuid(requestId, "RequestId");

        Id = id;
        RequestId = requestId;
        Data = data;
    }
}