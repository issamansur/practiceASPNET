using System.Data;
using practiceASPNET.Domains.Errors;
using practiceASPNET.Utils;

namespace practiceASPNET.Domains;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Guid RoleId { get; set; }

    public User(Guid id, string name, string email, Guid roleId)
    {
        Validator.IsValidGuid(id);
        Validator.IsValidName(name);
        Validator.IsValidEmail(email);
        Validator.IsValidGuid(roleId, "RoleId");

        Id = id;
        Name = name;
        Email = email;
        RoleId = roleId;
    }

    static public User Create(string name, string email, Guid roleId)
    {
        return new User(Guid.NewGuid(), name, email, roleId);
    }

    static public User Create(string name, string email, Role role)
    {
        return new User(Guid.NewGuid(), name, email, role.Id);
    }
}

