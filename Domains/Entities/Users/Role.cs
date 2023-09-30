namespace practiceASPNET.Domains.Entities.Users;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public Role(string name)
    {
        Name = name;
    }

    static public Role Create(string name) {
        return new Role(name);
    }
}
