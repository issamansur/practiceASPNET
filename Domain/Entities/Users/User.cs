using PracticeASPNET.Utils;

namespace PracticeASPNET.Domain;

public class User
{
    public Guid Id { get; set; }
    public Guid RoleId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public User(Guid id, Guid roleId, string name, string email)
    {
        Validator.IsValidGuid(id);
        Validator.IsValidGuid(roleId, "RoleId");
        Validator.IsValidName(name);
        Validator.IsValidEmail(email);

        Id = id;
        RoleId = roleId;
        Name = name;
        Email = email;
    }

    public static User Create(Guid roleId, string name, string email)
    {
        return new User(Guid.NewGuid(), roleId, name, email);
    }
}

