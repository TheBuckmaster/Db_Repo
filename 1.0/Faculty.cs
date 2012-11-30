using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Faculty
{
    public string UserName;
    public string Password;
    public string FirstName;
    public string MiddleName;
    public string LastName;
    public string Status;

    public List<string> Next = new List<string>();
    public List<string> Current = new List<pastcourse>();
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
}
