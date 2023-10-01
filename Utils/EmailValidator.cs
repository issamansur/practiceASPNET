using System.Text.RegularExpressions;

namespace practiceASPNET.Utils;

static public class Validator
{
    static string emailPattern = @"^[a-zA-Z0-9._+-]+@[a-zA-Z]+\.[a-zA-Z]{2,}$";
    static string namePattern = @"^[a-zA-Z]{2,20}$";

    static public bool IsValidEmail(string email)
    {
        Regex regex = new Regex(emailPattern);
        return regex.IsMatch(email);
    }

    static public bool IsValidName(string name)
    {
        Regex regex = new Regex(emailPattern);
        return regex.IsMatch(name);
    }
}