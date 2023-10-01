using System.Data;
using practiceASPNET.Utils;

namespace practiceASPNET.Domains;

public class Document
{
    public int Id { get; set; }
    public string Email { get; set; }

    public Document(string email)
    {
        if (string.IsNullOrEmpty(email))
            throw new NoNullAllowedException("Field 'Email' can't be empty!");
        if (!Validator.IsValidEmail(email))
            throw new ArgumentException("Field 'Email' has invalid format!");
        Email = email;
    }

    static public Document Create(string email)
    {
        return new Document(email);
    }
}