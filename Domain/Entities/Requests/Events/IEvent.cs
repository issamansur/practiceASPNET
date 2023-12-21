using PracticeASPNET.Utils;

namespace PracticeASPNET.Domain.Requests.Events;

// Use abstract class instead of interface
// because we create a base class for all events

public abstract class IEvent
{
    public Guid Id { get; private init; }
    public Guid RequestId { get; private set; }
    public string Data { get; private set; }

    public IEvent(Guid id, Guid requestId, string data)
    {
        Validator.IsValidGuid(id);
        Validator.IsValidGuid(requestId, "RequestId");

        Id = id;
        RequestId = requestId;
        Data = data;
    }
}