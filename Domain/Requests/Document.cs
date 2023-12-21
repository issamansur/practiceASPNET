using System.Data;
using practiceASPNET.Utils;

namespace practiceASPNET.Domain.Requests;

public class Document
{
    public string Name { get; private set; }
    public string Email { get; private set; }

    public Document(string name, string email)
    {
        Validator.IsValidName(name);
        Validator.IsValidEmail(email);

        Name = name;
        Email = email;
    }

    static public Document Create(string name, string email)
    {
        return new Document(name, email);
    }
}