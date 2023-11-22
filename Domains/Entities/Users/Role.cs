using practiceASPNET.Domains.Errors;
using practiceASPNET.Utils;

namespace practiceASPNET.Domains;

public class Role
{
    public Guid Id { get; init; }
    public string Name { get; private set; }

    public Role(Guid id, string name)
    {
        Validator.IsValidGuid(id, "Id");
        Validator.IsValidName(name, "Name");

        Id = id;
        Name = name;
    }

    static public Role Create(string name)
    {
        return new Role(Guid.NewGuid(), name);
    }
}
