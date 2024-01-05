using PracticeASPNET.Domain.Entities.Users;
using PracticeASPNET.Domain.Enums;
using PracticeASPNET.Domain.Entities.Requests.Events;
using PracticeASPNET.Utils;

namespace PracticeASPNET.Domain.Entities.Requests;

public class Request
{
    public Guid Id { get; private init; }
    public User User { get; private set; }
    public Document Document { get; private set; }
    public Workflow Workflow { get; private init; }

    public Status Status { get; private set; }
    public int CurrentStep { get; private set; }

    private List<Event> Events { get; init; }

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

        Events = new List<Event>();
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
        Events.Add(@event);
    }

    public void SetDocument(Document document)
    {
        ArgumentNullException.ThrowIfNull(document);
        Document = document;
    }

    public void Approve(User user)
    {
        WorkflowStep currentStep = Workflow.Steps[CurrentStep];
        if (currentStep.Status != Status.Pending)
            throw new InvalidOperationException("Current step is not pending");
        if (user.RoleId != currentStep.RoleId && user.Id != currentStep.UserId)
            throw new InvalidOperationException("User is not allowed to approve this step");

        currentStep.SetStatus(user, Status.Approved);

        if (CurrentStep < Workflow.Steps.Count - 1)
        {
            CurrentStep++;
            WorkflowStep nextStep = Workflow.Steps[CurrentStep];
            nextStep.SetStatus(user, Status.Pending);
        }
        else
        {
            Status = Status.Approved;
        }

        Events.Add(RequestApproveEvent.Create(Id, $"Request approved by {user.Name}"));
    }

    public void Reject(User user)
    {
        WorkflowStep currentStep = Workflow.Steps[CurrentStep];
        if (currentStep.Status != Status.Pending)
            throw new InvalidOperationException("Current step is not pending");
        if (user.RoleId != currentStep.RoleId && user.Id != currentStep.UserId)
            throw new InvalidOperationException("User is not allowed to approve this step");

        currentStep.SetStatus(user, Status.Rejected);

        Status = Status.Rejected;

        Events.Add(RequestRejectEvent.Create(Id, $"Request rejected by {user.Name}"));
    }

    public void Restart(User user)
    {
        foreach (WorkflowStep step in Workflow.Steps)
        {
            step.SetStatus(user, Status.Frozen);
        }
        Workflow.Steps[0].SetStatus(user, Status.Pending);

        Events.Add(RequestRestartEvent.Create(Id, $"Request restarted by {user.Name}"));
    }

    public void Freeze(User user)
    {
        WorkflowStep currentStep = Workflow.Steps[CurrentStep];
        if (currentStep.Status != Status.Pending)
            throw new InvalidOperationException("Current step is not pending");
        if (user.RoleId != currentStep.RoleId && user.Id != currentStep.UserId)
            throw new InvalidOperationException("User is not allowed to approve this step");

        currentStep.SetStatus(user, Status.Frozen);

        Events.Add(RequestFreezeEvent.Create(Id, $"Request frozen by {user.Name}"));
    }   
}