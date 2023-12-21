using System.Text.RegularExpressions;

namespace PracticeASPNET.Utils;

static public class Validator
{
    static string EmailPattern => @"^[a-zA-Z0-9._+-]+@[a-zA-Z]+\.[a-zA-Z]{2,}$";
    static string NamePattern => @"^[a-zA-Z]{2,20}$";

    static Regex EmailRegex => new Regex(EmailPattern);
    static Regex NameRegex => new Regex(NamePattern);

    static public void IsValidEmail(string email, string fieldName = "Email")
    {
        if (string.IsNullOrEmpty(email))
            throw new ArgumentException($"Field '{fieldName}' can't be empty!");
        if (!EmailRegex.IsMatch(email))
            throw new ArgumentException($"Field '{fieldName}' has invalid format!");
    }

    static public void IsValidName(string name, string fieldName = "Name")
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException($"Field '{fieldName}' can't be empty!");
        if (!NameRegex.IsMatch(name))
            throw new ArgumentException($"Field '{fieldName}' has invalid format!");
    }

    static public void IsValidGuid(Guid id, string fieldName="Id")
    {
        if (id == Guid.Empty)
            throw new ArgumentException($"Field '{fieldName}' can't be 'Guid.Empty'!");
    }
}