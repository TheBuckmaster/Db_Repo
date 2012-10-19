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
    private int userID; 

    public List<courseinfo> schedule = new List<courseinfo>();
    public List<pastcourse> history = new List<pastcourse>();
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
        foreach (pastcourse course in history)
        {
            if(course.term != "F12")    // if not in progress
                credits += course.credit;
        }
        return credits;
    }

    void enrollCourse(ref courseinfo course, ref User student)
    {
        if ((student.Status != "faculty") && (student.Status != "admin"))   // check if student
        {
            if (course.enrolled < course.Seats)     // check if room in section
            {
                if (!student.schedule.Contains(course))     // check if student already enrolled
                {
                    if ((status == "admin") || ((student.enrolledCredits() + course.Credit) < 5.0)) // only let enrolled credits be >= 5 if admin
                    {
                        bool conflict = false;
                        foreach (coursetime time in course.Times)
                        {
                            foreach (courseinfo course2 in student.schedule)
                            {
                                foreach (coursetime time2 in crs.Times) // What should this be? There is no crs. 
                                {
                                    // if either starts in the middle of the other, check if same day
                                    if (((time.start <= time2.start) && (time2.start <= time.end)) || ((time2.start <= time.start) && (time.start <= time2.end)))
                                    {
                                        foreach (char day in time.days)
                                        {
                                            if (time2.days.Contains(day))
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
                            if (conflict)
                                break;
                        }
                        // This test doesn't work, comparing a current course and a past course isn't defined. 
                        //if (student.history.Contains(course))
                        //{
                        //    // throw retaking warning
                        //}

                        student.schedule.Add(course);
                        ++course.enrolled;
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
        if((status != "faculty") && (status != "admin"))
        {
            if((student.schedule.Remove(course)) & (student.history.Remove(new pastcourse(course.Coursename, "S13", course.Credit, "N"))))
            {
                
            }
            else ; // throw "Unenroll encountered an error. Were you enrolled?" error
        }
        else ; // throw "can only unenroll students" error
    }

    public static bool operator ==(User a, User b) { return a.UserName == b.UserName; }
    
    public static bool operator !=(User a, User b) { return a.UserName != b.UserName; }
}
