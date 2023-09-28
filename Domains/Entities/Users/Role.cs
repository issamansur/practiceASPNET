public class Role
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    
    public Role(string name)
    {
        Name = name;
    }

    static public Role Create(string name) {
        return Role(name);
    }
}