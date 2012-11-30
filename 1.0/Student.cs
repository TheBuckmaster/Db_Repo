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
        float total = 0.0;
        float creds = 0.0;

        foreach (pastcourse course in History)
        {
            // if a gpa factor
            if (course.GPAble)
            {
                // check if later retaken
                bool retaken = false;
                foreach (pastcourse course2 in History)
                {
                    if ( course.Coursename == course2.Coursename && course2.Grade.Contains("R") )
                    {
                        if ( (course.Year == course2.Year && course.Term != 'F')
                            || (course.Year < course2.Year))
                            retaken = true;
                    }
                }

                // skip retaken classes
                if (!retaken)
                {
                    total += course.GPoints;
                    creds += course.Credit;
                }
            }
        }

        return total / creds;
    }
}
