using PracticeASPNET.Utils;

namespace PracticeASPNET.Domain.Entities.Requests.Events;

// Use abstract class instead of interface
// because we create a base class for all events

public abstract class Event
{
    public Guid Id { get; private init; }
    public Guid RequestId { get; private set; }
    public string Data { get; private set; }

    public Event(Guid id, Guid requestId, string data)
    {
        Validator.IsValidGuid(id);
        Validator.IsValidGuid(requestId, "RequestId");

        Id = id;
        RequestId = requestId;
        Data = data;
    }
}