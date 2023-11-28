using System.Data;
using practiceASPNET.Utils;

namespace practiceASPNET.Domain;

public class Document
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    public Document(Guid id, string name, string email)
    {
        Validator.IsValidGuid(id);
        Validator.IsValidName(name);
        Validator.IsValidEmail(email);

        Id = id;
        Name = name;
        Email = email;
    }

    static public Document Create(string name, string email)
    {
        return new Document(Guid.NewGuid(), name, email);
    }
}