using System;
using System.Collections.Generic;
using System.Text;
using Registration;

public class courseinfo : ICourse<courseinfo>
{
    public string Coursename;
    public string Coursetitle;
    public string Instructor;
    public double Credit;
    public int Seats;
    public int Enrolled = 0;
    public List<coursetime> Times = new List<coursetime>();
    public List<string> Prereqs = new List<string>();



    public courseinfo(string name, string title, string prof, double cred, int seats,
        List<coursetime> timeslist)
    {
        Coursename = name;
        Coursetitle = title;
        Instructor = prof;
        Credit = cred;
        Seats = seats;
        Times = timeslist;
    }

    public bool isFull()
    {
        return Seats <= Enrolled;
    }

    public bool isConflict(courseinfo course)
    {
        bool conflict = false;

        foreach (coursetime time in Times)   //Each time the course is offered
        {
            foreach (coursetime time2 in course.Times)     //And each time of that class. 
            {
                if (((time.start <= time2.start) && (time2.start <= time.end)) || ((time2.start <= time.start) && (time.start <= time2.end)))
                {   //Does this time overlap?
                    foreach (char day in time.days)
                    {   //Is it on the same day? 
                        if (time2.days.Contains(day))
                        {   
                            conflict = true;
                            break;
                        }
                    }
                }
                if (conflict)
                    break;
            }
            if (conflict)
                break;
        }

        return conflict;
    }

    public string CourseDatabaseString()
    {
        Stringbuilder cdbstring = new Stringbuilder(Term);
        cdbstring.Insert(5, Coursename);
        cdbstring.Insert(17, Coursetitle);
        cdbstring.Insert(34, Instructor);
        cdbstring.Insert(46, Credit.ToString());
        cdbstring.Insert(52, Seats.ToString());
        cdbstring.Insert(57, Times.Count);
        foreach (coursetime time in Times)
            cdbstring.Append(time.ToString() + "  ");

        return cdbstring.ToString();
    }

    public bool Equals(courseinfo course)
    {
        return this.Coursename.Substring(0, Coursename.Length - 3) == course.Coursename.Substring(0, course.Coursename.Length - 3);
    }

    public bool Equals(pastcourse course)
    {
        return this.Coursename.Substring(0, Coursename.Length - 3) == course.Coursename.Substring(0, course.Coursename.Length - 3);
    }
}
