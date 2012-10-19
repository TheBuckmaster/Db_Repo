using System;
using System.Collections.Generic;



public class User
{
    private string userName;
    private string password;
    private string fstName;
    private string midName;
    private string lstName;
    private string status;

    public List<courseinfo> schedule = new List<courseinfo>();
    public List<pastcourse> history = new List<courseinfo>();
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

    public double enrolledCredits()
    {
        double credits = 0.00;
        foreach (courseinfo course in schedule)
            credits += course.Credit;
        return credits;
    }

    public double earnedCredits()
    {
        double credits = 0.00;
        foreach (courseinfo course in history)
            credits += course.Credit;
        return credits;
    }

    void enrollCourse(ref courseinfo course, ref User student)
    {
        if ((student.Status != "faculty") && (student.Status != "admin"))   // check if student
        {
            if (course.Enrolled < course.Seats)     // check if room in section
            {
                if (!student.schedule.Contains(course))     // check if student already enrolled
                {
                    if ((status == "admin") || ((student.enrolledCredits() + course.Credit) < 5.0)) // only let enrolled credits be >= 5 if admin
                    {
                        bool conflict = false;
                        foreach (coursetime time in course.Times)
                        {
                            foreach (courseinfo crs in student.schedule)
                            {
                                foreach (coursetime time2 in crs.Times)
                                {
                                    if (time.day == time2.day)
                                    {
                                        // if either starts in the middle of the other, throw warning
                                        if (((time.start <= time2.start)&&(time2.start <= time.end)) || ((time2.start <= time.start)&&(time.start <= time2.end)))
                                        {
                                            conflict = true;
                                            // throw scheduling conflict warning
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
                        if (student.history.Contains(course))
                        {
                            // throw retaking warning
                        }

                        pastcourse newCourse;
                        newCourse.coursename = course.Coursename;
                        newCourse.term = "S13";
                        newCourse.credit = course.Credit;
                        newCourse.grade = "N";
                        student.history.Add(newCourse);

                        student.schedule.Add(course);
                        ++course.Enrolled;
                    }
                    else ; // throw "enrolled in too many credits" error
                }
                else ; // throw "already enrolled in a section" error
            }
            else ; // throw "section is full" error
        }
        else ; // throw "can only enroll students" error
    }

    void unenrollCourse(ref courseinfo course, ref User student)
    {
        if((status != "faculty") && (status != "admin") && (!schedule.Remove(course)))
            Console.WriteLine("Unenroll failed. Were you enrolled?");
    }

    public static bool operator ==(User a, User b) { return a.UserName == b.UserName; }

    public static bool operator !=(User a, User b) { return a.UserName != b.UserName; }
}
