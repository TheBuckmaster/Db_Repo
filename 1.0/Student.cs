using Registration;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Student
{ 
    public string UserName;
    public string Password;
    public string FirstName;
    public string MiddleName;
    public string LastName;
    public string Status;

    public List<string> Next = new List<string>();
    public List<pastcourse> Current = new List<pastcourse>();
    public List<pastcourse> History = new List<pastcourse>();
    public List<string> Conflicts = new List<string>();

    public Student(string uname, string pswrd, string fname, string mname, string lname, string stat)
    {
        UserName = uname;
        Password = pswrd;
        FirstName = fname;
        MiddleName = mname;
        LastName = lname;
        Status = stat;
    }

    public double enrolledCredits()
    {
        double credits = 0.00;
        foreach (courseinfo course in Next)
            credits += course.Credit;
        return credits;
    }

    public double earnedCredits()
    {
        double credits = 0.00;
        foreach (pastcourse course in History)
            credits += course.Credit;
        return credits;
    }

    public double gpa()
    {

    }
}
