using System;
using System.Text;
using Registration;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Admin
{
    public string UserName;
    public string Password;
    public string FirstName { get; }
    public string MiddleName { get; }
    public string LastName { get; }
    public string Status;

    public Admin(string uname, string pswrd, string fname, string mname, string lname, string stat)
    {
        UserName = uname;
        Password = pswrd;
        FirstName = fname;
        MiddleName = mname;
        LastName = lname;
        Status = stat;
    }

    public string UserDatabaseString()
    {
        StringBuilder udbstring = new StringBuilder(UserName);
        udbstring.Insert(12, Password);
        udbstring.Insert(22, FirstName);
        udbstring.Insert(34, MiddleName);
        udbstring.Insert(56, LastName);
        udbstring.Insert(68, Status);
        udbstring.Append('\n');

        return udbstring.ToString();
    }
}
