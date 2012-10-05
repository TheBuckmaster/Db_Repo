using System;

public class User
{
    private string userName;
    private string fstName;
    private string midName;
    private string lstName;
    private string password;
    private string status;

    public bool validLogin(string name, string word)
    {
        return ((name == userName) && (word == password));
    }
}
