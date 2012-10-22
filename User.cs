using System;
using System.Collections.Generic;

struct errorReturn 
{
    public bool wasError;
    public string errorWas; 
}


public class User
{
    private string userName;
    private string password;
    private string fstName;
    private string midName;
    private string lstName;
    private string status;
    private int userID; 

    public List<courseinfo> Schedule = new List<courseinfo>();
    public List<pastcourse> History = new List<pastcourse>();
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
        foreach (courseinfo course in Schedule)
            credits += course.Credit;
        return credits;
    }

    public double earnedCredits()
    {
        double credits = 0.00;
        foreach (pastcourse course in History)
        {
            if(course.Term != "F12")    // if not in progress
                credits += course.Credit;
        }
        return credits;
    }

    errorReturn enrollCourse(ref courseinfo course, ref User student)
    {
        if ((student.Status != "faculty") && (student.Status != "admin"))   // check if student
        {
            if (course.Enrolled < course.Seats)     // check if room in section
            {
                if (!student.Schedule.Contains(course))     // check if student already enrolled
                {
                    if ((status == "admin") || ((student.enrolledCredits() + course.Credit) < 5.0)) // only let enrolled credits be >= 5 if admin
                    {
                        bool conflict = false;
                        foreach (coursetime time in course.Times)
                        {
                            foreach (courseinfo course2 in student.Schedule)
                            {
                                foreach (coursetime time2 in course2.Times) //Removed ref. to crs. I think this is what you wanted.  
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
                        // should work now; Your == operator is not working, but this compiles. -BPB
                        bool retake = false;

                        for (int i = 0; i < student.History.Count; i++)
                            if (student.History[i].Coursename == course.Coursename)
                                retake = true;

                        if (retake)
                        {
                            // throw retaking warning
                        }

                        student.Schedule.Add(course);
                        ++course.Enrolled;
                    }
                    else {

                        errorReturn er;
                        er.wasError = true;
                        er.errorWas = "credits";
                        return er;

                         } // throw "enrolled in too many credits" error
                }
                else
                {

                    errorReturn er;
                    er.wasError = true;
                    er.errorWas = "2enroll";
                    return er;

                } // throw "already enrolled in a section" error
            }
            else
            {

                errorReturn er;
                er.wasError = true;
                er.errorWas = "isfull";
                return er;

            } // throw "section is full" error
        }
        else
        {

            errorReturn er;
            er.wasError = true;
            er.errorWas = "nonstudent";
            return er;

        } // throw "can only enroll students" error

        errorReturn er1;
        er1.wasError = false;
        er1.errorWas = "none";
        return er1;
    }

    errorReturn unenrollCourse(ref courseinfo course, ref User student)
    {
        if ((status != "faculty") && (status != "admin"))
        {
            if (!student.Schedule.Remove(course))
            {
                errorReturn er;
                er.wasError = true;
                er.errorWas = "notenrolled";
                return er;
                // throw "Unenroll encountered an error. Were you enrolled?" error 
            }
        }
        else
        {
            errorReturn er;
            er.wasError = true;
            er.errorWas = "nonstudent";
            return er; // throw "can only unenroll students" error
        }

        errorReturn er1 = new errorReturn();
        return er1;
    }

    public static bool operator ==(User a, User b) { return a.UserName == b.UserName; }
    
    public static bool operator !=(User a, User b) { return a.UserName != b.UserName; }
}
