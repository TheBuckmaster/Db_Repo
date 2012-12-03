using System;
using System.Text;
using Registration;
using System.Collections.Generic; 

/// <summary>
/// Summary description for Class1
/// </summary>
public class Faculty
{
    public string UserName;
    public string Password;
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Status;

    public List<string> Next = new List<string>();
    public List<string> Advisees = new List<string>();

    public Faculty(string uname, string pswrd, string fname, string mname, string lname, string stat)
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
