using System.Data;
using practiceASPNET.Utils;

namespace practiceASPNET.Domains;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }

    // public virtual Role Role { get; set; }

    public User(string name, string email, int roleId)
    {
        if (string.IsNullOrEmpty(name))
            throw new NoNullAllowedException("Field 'Name' can't be empty!");
        if (!Validator.IsValidName(name))
            throw new ArgumentException("Field 'Name' has invalid format!");

        if (string.IsNullOrEmpty(email))
            throw new NoNullAllowedException("Field 'Email' can't be empty!");
        if (!Validator.IsValidEmail(email))
            throw new ArgumentException("Field 'Email' has invalid format!");

        Name = name;
        Email = email;

        RoleId = roleId;
    }

    static public User Create(string name, string email, int roleId)
    {
        return new User(name, email, roleId);
    }
}

