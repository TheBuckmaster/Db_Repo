using System;

public class User
{
    private string userName;
    private string password;
    private string fstName;
    private string midName;
    private string lstName;
    private string status;
    private List<courseinfo> schedule = new List<courseinfo>();
    private List<courseinfo> history = new List<courseinfo>();

    public string UserName { get { return userName; } }
    public string FstName { get { return fstName; } }
    public string MidName { get { return midName; } }
    public string LstName { get { return lstName; } }
    public string Status { get { return status; } }

    public User(string uname, string pswd, string fname, string mname, string lname, string stat)
    {
        userName = uname;
        password = pswd;
        fstName = fname;
        midName = mname;
        lstName = lname;
        status = stat;
    }

    public bool isPassword(string pswd) { return password == pswd; }

    void enrollCourse(courseinfo course)
    {
        if(status != "faculty")
            schedule.Add(course);
    }

    void unenrollCourse(courseinfo course)
    {
        if((status != "faculty") && (!schedule.Remove(course)))
            Console.WriteLine("Unenroll failed. Were you enrolled?");
    }

    public static bool operator ==(User a, User b) { return a.UserName == b.UserName; }

    public static bool operator !=(User a, User b) { return a.UserName != b.UserName; }
}
