using PracticeASPNET.Domain;
using PracticeASPNET.Domain.Entities.Requests;
using PracticeASPNET.Domain.Enums;
using PracticeASPNET.Utils;

namespace PracticeASPNET.Domain.Entities.Requests;

public class Request
{
    public Guid Id { get; init; }
    public User User { get; private set; }
    public Document Document { get; private set; }
    public Workflow Workflow { get; private set; }

    public Status Status { get; private set; }
    public int CurrentStep { get; private set; }

    private List<IEvent> _events = new List<IEvent>();

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

    static public Request Create(User user, Document document, Workflow workflow)
    {
        Request request = new Request(Guid.NewGuid(), user, document, workflow, Status.Pending, 0);
        IEvent @eventOnCreate = RequestCreateEvent.Create(request.Id, $"New request created. Coordinator: {user.Name}. Requester: {document.Email}");
        request.AddEvent(@eventOnCreate);

        return request;
    }

    public void AddEvent(IEvent @event)
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