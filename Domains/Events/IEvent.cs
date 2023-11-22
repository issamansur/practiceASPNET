using practiceASPNET.Utils;

namespace practiceASPNET.Domains;

// Use abstract class instead of interface
// because we create a base class for all events

public abstract class IEvent
{
    public Guid Id { get; init; }

    public Guid RequestId { get; set; }
    public string Data { get; set; }

    public IEvent(Guid id, string data, Guid requestId)
    {
        Validator.IsValidGuid(id);
        Validator.IsValidGuid(requestId, "RequestId");

        Id = id;
        Data = data;
        RequestId = requestId;
    }
}