using PracticeASPNET.Utils;

namespace PracticeASPNET.Domain.Entities.Users;

public class Role
{
    public Guid Id { get; init; }
    public string Name { get; private set; }

    public Role(Guid id, string name)
    {
        Validator.IsValidGuid(id);
        Validator.IsValidName(name);

        Id = id;
        Name = name;
    }

    public static Role Create(string name)
    {
        return new Role(Guid.NewGuid(), name);
    }
}
