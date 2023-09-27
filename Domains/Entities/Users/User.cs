public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public int RoleId { get; set; }

    public User(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    static public User Create(string name, string email) {
        return User(id, name, email);
    }
}