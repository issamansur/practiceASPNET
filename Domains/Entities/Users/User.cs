namespace practiceASPNET.Domains.Entities.Users;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }

    // public virtual Role Role { get; set; }

    public User(string name, string email, int roleId)
    {
        Name = name;
        Email = email;

        RoleId = roleId;
    }

    static public User Create(string name, string email, int roleId) {
        return new User(name, email, roleId);
    }
}

