public class Role
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    
    public Role(int id, string name)
    {
        Id = id;
        Name = name;
    }

    static public Role Create(string name) {
        return Role(id, name);
    }
}