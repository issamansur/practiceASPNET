using PracticeASPNET.Domain.Entities.Workflows.Templates;
using System.Text.RegularExpressions;

namespace PracticeASPNET.Utils;

public static class Validator
{
    static string EmailPattern => @"^[a-zA-Z0-9._+-]+@[a-zA-Z]+\.[a-zA-Z]{2,}$";
    static string NamePattern => @"^[a-zA-Z]{2,20}$";

    static Regex EmailRegex => new Regex(EmailPattern);
    static Regex NameRegex => new Regex(NamePattern);

    public static void IsValidGuid(Guid id, string fieldName="Id")
    {
        if (id == Guid.Empty)
            throw new ArgumentException($"Field '{fieldName}' can't be 'Guid.Empty'!");
    }

    public static void IsValidName(string name, string fieldName = "Name")
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException($"Field '{fieldName}' can't be empty!");
        if (!NameRegex.IsMatch(name))
            throw new ArgumentException($"Field '{fieldName}' has invalid format!");
    }

    public static void IsValidEmail(string email, string fieldName = "Email")
    {
        if (string.IsNullOrEmpty(email))
            throw new ArgumentException($"Field '{fieldName}' can't be empty!");
        if (!EmailRegex.IsMatch(email))
            throw new ArgumentException($"Field '{fieldName}' has invalid format!");
    }

    public static void IsValidCollection(ICollection<WorkflowStepTemplate> collection, string fieldName = "Collection", int max = 5)
    {
        if (collection is null)
            throw new ArgumentException($"Field '{fieldName}' can't be empty!");
        if (collection.Count == 0 || collection.Count < max) 
            throw new ArgumentException($"Field '{fieldName}' must have at least {max} items!");
    }

    public static void IsValidOrder(int order, string fieldName = "Order", int max = 5)
    {
        if (order < 0)
            throw new ArgumentException($"Field '{fieldName}' must be greater than 0!");
        if (order > max)
            throw new ArgumentException($"Field '{fieldName}' must be less than {max}!");
    }   
}