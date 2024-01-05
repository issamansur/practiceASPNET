using PracticeASPNET.Domain.Entities.Requests;
using PracticeASPNET.Domain.Entities.Users;
using PracticeASPNET.Utils;

namespace PracticeASPNET.Domain.Entities.Templates;

public class WorkflowTemplate
{
    public Guid Id { get; private init; }
    public string Title { get; set; }
    public List<WorkflowStepTemplate> Steps { get; private init; }

    public WorkflowTemplate(Guid id, string title, List<WorkflowStepTemplate> steps)
    {
        Validator.IsValidGuid(id);
        Validator.IsValidName(title);
        Validator.IsValidCollection(steps, 3);

        Id = id;
        Title = title;
        Steps = steps;
    }

    public static WorkflowTemplate Create(string title, List<WorkflowStepTemplate> steps)
    {
        return new WorkflowTemplate(Guid.NewGuid(), title, steps);
    }

    public Request Create(User user, Document document)
    {
        Workflow workflow = Workflow.Create(Title, this);
        Request request = Request.Create(user, document, workflow);
        return request;
    }
}