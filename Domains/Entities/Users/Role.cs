using System.Data;
using practiceASPNET.Utils;

namespace practiceASPNET.Domains;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Role(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new NoNullAllowedException("Field 'Name' can't be empty!");
        if (!Validator.IsValidName(name))
            throw new ArgumentException("Field 'Name' has invalid format!");
        Name = name;
    }

    static public Role Create(string name)
    {
        return new Role(name);
    }
}
