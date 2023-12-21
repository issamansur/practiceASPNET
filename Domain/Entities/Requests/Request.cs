using PracticeASPNET.Domain.Enums;
using PracticeASPNET.Domain.Requests.Events;
using PracticeASPNET.Utils;

namespace PracticeASPNET.Domain.Entities.Requests;

public class Request
{
    public Guid Id { get; private init; }
    public User User { get; private set; }
    public Document Document { get; private set; }
    public Workflow Workflow { get; private set; }

    public Status Status { get; private set; }
    public int CurrentStep { get; private set; }

    private List<Event> _events = new List<Event>();

    public bool IsApproved => Status == Status.Approved;
    public bool IsRejected => Status == Status.Rejected;

    public Request(Guid id, User user, Document document, Workflow workflow, Status status, int currentStep)
    {
        Validator.IsValidGuid(id);
        ArgumentNullException.ThrowIfNull(user, "User");
        ArgumentNullException.ThrowIfNull(document, "Document");
        ArgumentNullException.ThrowIfNull(workflow, "Workflow");

        Id = id;
        User = user;
        Document = document;
        Workflow = workflow;

        Status = status;
        CurrentStep = currentStep;
    }

    public static Request Create(User user, Document document, Workflow workflow)
    {
        Request request = new Request(Guid.NewGuid(), user, document, workflow, Status.Pending, 0);
        Event @eventOnCreate = RequestCreateEvent.Create(request.Id, $"New request created. Coordinator: {user.Name}. Requester: {document.Email}");
        request.AddEvent(@eventOnCreate);

        return request;
    }

    public void AddEvent(Event @event)
    {
        _events.Add(@event);
    }

    public void Approve(User user)
    {
        // TODO
    }

    public void Reject(User user)
    {
        // TODO
    }

    public void Restart()
    {
        // TODO
    }
}