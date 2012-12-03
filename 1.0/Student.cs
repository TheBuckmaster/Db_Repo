using System;
using System.Text;
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
    public List<courserecord> Current = new List<courserecord>();
    public List<courserecord> History = new List<courserecord>();
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

    public double EnrolledCredits()
    {
        double credits = 0.00;

        foreach (courserecord course in Next)
            credits += course.Credit;

        return credits;
    }

    public double EarnedCredits()
    {
        double credits = 0.00;

        foreach (courserecord course in History)
        {
            if(course.Earned)
                credits += course.Credit;
        }

        return credits;
    }

    public double GPA()
    {
        double total = 0.000;
        double creds = 0.000;

        foreach (courserecord course in History)
        {
            // if a gpa factor
            if (course.GPAble)
            {
                // check if later retaken
                bool retaken = false;
                foreach (courserecord course2 in History)
                {
                    if ( course.Equals(course2) && course2.Grade.Contains("R") )
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

    public string UserDatabaseString()
    {
        Stringbuilder udbstring = new Stringbuilder(UserName);
        udbstring.Insert(12, Password);
        udbstring.Insert(22, FirstName);
        udbstring.Insert(34, MiddleName);
        udbstring.Insert(56, LastName);
        udbstring.Insert(68, Status);
        udbstring.Append('\n');

        return udbstring.ToString();
    }

    public string HistoryDatabaseString()
    {
        Stringbuilder hdbstring = new Stringbuilder(Username);
        hdbstring.Insert(10, Next.Count);

        foreach (courserecord course in Next)
            hdbstring.Append('\n' + course.HistoryDatabaseString());

        return hdbstring.ToString();
    }
}
