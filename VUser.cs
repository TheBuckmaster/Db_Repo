using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//This is defined currently in User.cs
public struct errorReturn
{
    public bool wasError;  //true == error; false == warning
    public string errorWas;
    //public eRType errortype;
    //public wRType warningtype;
}

public enum VType
{
    notmade,
    student,
    faculty,
    admin
};

public enum eRType
{ 
    warning,   
    full,
    twice,
    credits,
    baduser
}

public enum wRType
{
    error,
    credits,
    conflict,
    retake
}


public class VUser
{
    private string userName;
    private string password;
    private string fstName;
    private string midName;
    private string lstName;
    private string status;
    VType usertype = VType.notmade;


    public string UserName { get { return userName; } }
    public string FstName { get { return fstName; } }
    public string MidName { get { return midName; } }
    public string LstName { get { return lstName; } }
    public string Status { get { return status; } }

    //Apparently having a constructor (not using; having!) that takes no arguments 
    //is important for inheritance purposes. 
    public VUser()
    {
        status = "notmade";
        usertype = VType.notmade;
    }

    public VUser(string uname)
    {
        userName = uname;
        status = "notmade";
        usertype = VType.notmade;
    }

    public VUser(string uname, string pswd, string fname, string mname, string lname, string stat)
    {
        stat = stat.ToLower();
        userName = uname;
        password = pswd;
        fstName = fname;
        midName = mname;
        lstName = lname;
        status = stat;
        usertype = (stat == "admin") ? VType.admin : //if
            (stat == "faculty") ? VType.faculty : //elseif
            (stat == "student") ? VType.student : VType.notmade; //elseif, else. 
    }

    public bool isPassword(string pswd)
    {
        return password == pswd;
    }

    public void checkConflicts(ref VStudent student)
    {
        student.Conflicts.Clear();
        for (int i = 0; i < student.Next.Count; ++i)
        {
            foreach (coursetime time in student.Next[i].Times)
            {
                for (int j = i + 1; j < student.Next.Count; ++j)
                {
                    foreach (coursetime time2 in student.Next[j].Times)
                    {
                        if ((!student.Conflicts.Contains(student.Next[i].Coursetitle)) && (!student.Conflicts.Contains(student.Next[j].Coursetitle)))
                        {
                            bool iscnflct = false;
                            if (((time.start <= time2.start) && (time2.start <= time.end)) || ((time2.start <= time.start) && (time.start <= time2.end)))
                            {   //Does this time overlap?
                                foreach (char day in time.days)
                                {   //Is it on the same day? 
                                    if (time2.days.Contains(day))
                                    {
                                        if (!student.Conflicts.Contains(Next[i]))
                                            student.Conflicts.Add(Next[i].Coursetitle);
                                        if (!student.Conflicts.Contains(Next[j]))
                                            student.Conflicts.Add(Next[j].Coursetitle);
                                        iscnflct = true;
                                        break;
                                    }
                                }
                                if (iscnflct)
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }

    public virtual errorReturn unenrollCourse(ref courseinfo course, ref VStudent student)
    {
        errorReturn er;
        //if (this.status == "faculty")
        //{
        //    //Depending on Future specs, we still might want to test for this. 
        //}
        // shouldn't be needed
        //if ((this.status == "student") || (this.usertype == VType.student))
        //{
        //    //Is the user doing the edit the student being registered? 
        //    if (this != student)
        //    {
        //        //We have a very clever student.                
        //        er.wasError = true;
        //        er.errorWas = "diffStudent";
        //        return er; //This is one where we might want to kick them out. 
        //    }
        //}


        if (!student.Next.Remove(course))
        {
            er.wasError = true;
            er.errorWas = "notenrolled";
            return er;
            // throw "Unenroll encountered an error. Were you enrolled?" error 
        }

        //recheck conflicts
        checkConflicts(student);

        er.wasError = false;
        er.errorWas = "notError";
        return er;
    }

    //Because usernames must be unique, this is accaptable. 
    public override bool Equals(object obj)
    {
        VUser You = (VUser)obj;
        if (userName == You.userName)
            return true;
        else
            return false;
    }

    //Because usernames must be unique, we can hash by them. 
    public override int GetHashCode()
    {
        return userName.GetHashCode();
    }

    public static bool operator ==(VUser a, VUser b) { return a.Equals(b); }
    public static bool operator !=(VUser a, VUser b) { return !a.Equals(b); }



    //Returns a list of errorReturns. Warnings are errorList objects with wasError = false; 
    //Returns an empty list if there were neither errors nor warnings.
    //Test for success by List<errorReturn> i = enrollCourse(c,s); ((i.Count == 0) || (i[0].wasError == false));
    public virtual List<errorReturn> enrollCourse(ref courseinfo course, ref VStudent student)
    {
        List<errorReturn> errlist = new List<errorReturn>();
        List<errorReturn> warnlist = new List<errorReturn>();
        errorReturn eN; // Always use this to add errors and warnings. 

        if (student.Next.Contains(course)) //Is the student already registered for this course? Return an error. 
        {
            if (course.Students.Contains(student))
            {
                eN.wasError = true;
                eN.errorWas = "AlreadyHere";
                errlist.Add(eN);
                return errlist;
            }
            else student.Next.Remove(course);   //if out of sync, course has priority
        }

        //Generate list of Errors.
        if (course.isFull()) //Is the course full? Return an error. 
        {
            eN.wasError = true;
            eN.errorWas = "CourseIsFull";
            errlist.Add(eN);
        }

        if ((student.enrolledCredits() + course.Credit) > 5.0) //Would this put the student over 5.0 credits?
        {
            eN.errorWas = ">5.0";
            if (status == "admin")                   //If Admin, warn, but allow. 
            {
                eN.wasError = false;
                warnlist.Add(eN);
            }
            else                                                //If not Admin, return error. 
            {
                eN.wasError = true;
                errlist.Add(eN);
            }
        }

        if (errlist.Count == 0)
        {   //Generate list of Warnings.

            //Warnings for class conflict
            foreach (courseinfo course2 in student.Next)    //Compare to each already added class
            {
                foreach (coursetime time in course.Times)   //Each time the course is offered
                {
                    foreach (coursetime time2 in course2.Times)     //And each time of that class. 
                    {
                        bool iscnflct = false;
                        if (((time.start <= time2.start) && (time2.start <= time.end)) || ((time2.start <= time.start) && (time.start <= time2.end)))
                        {   //Does this time overlap?
                            foreach (char day in time.days)
                            {   //Is it on the same day? 
                                if (time2.days.Contains(day))
                                {   //Throw warning message. 
                                    eN.wasError = false;
                                    eN.errorWas = "!" + course2.Coursetitle;
                                    warnlist.Add(eN);
                                    if (!student.Conflicts.Containts(course))
                                        student.Conflicts.Add(course.Coursetitle);
                                    if (!student.Conflicts.Contains(course2))
                                        student.Conflicts.Add(course2.Coursetitle);
                                    iscnflct = true;
                                    break;
                                }
                            }
                            if (iscnflct)
                                break;
                        }
                    }
                }
            }
            //Warning if the course is being retaken. 
            if(student.History.Contains(course) || student.Current.Contains(course))
            {
                eN.wasError = false;
                en.errorWas = "?" + oldcourse.Coursetitle;
                warnlist.Add(eN);
            }

            //Beyond here, no new errors and no new warnings. 
            student.Next.Add(course);       //The student has a course.
            course.enrollStudent(student);   //The course has a student.
            //Otherwise, we'll return the list of warnings. The only way to have returned an empty list is
            //If there are no warnings. 
            return warnlist;
        }
        else return errlist;
    }
}


public class VFaculty : VUser
{

    //enum tReq
    //{
    //    curr,
    //    next
    //}

    private List<VStudent> advisees = new List<VStudent>();
    private List<courseinfo> currentClasses = new List<courseinfo>();
    private List<courseinfo> nextClasses = new List<courseinfo>();

    public List<VStudent> Advisees { get { return advisees; } }
    public List<courseinfo> CurrentClasses { get { return currentClasses; } }
    public List<courseinfo> NextClasses { get { return nextClasses; } }

    VFaculty(string uname, string pswd, string fname, string mname, string lname)
        : base(uname, pswd, fname, mname, lname, "faculty")
    {

    }


    VFaculty(string uname, string pswd, string fname, string mname, string lname,
        List<VStudent> advs, List<courseinfo> curcourses, List<courseinfo> nxtcourses)
        : base(uname, pswd, fname, mname, lname, "faculty")
    {
        advisees = new List<VStudent>(advs);
        currentClasses = new List<courseinfo>(curcourses);
        nextClasses = new List<courseinfo>(nxtcourses);
    }


    // we only need a list of students in a specific course, not all, so this doesn't need to be a function
 
    //public List<VStudent> futureStudents(ref courseinfo course)
    //{
    //    List<VStudent> nextStudents = new List<VStudent>();

    //    foreach (courseinfo course in NextClasses)
    //    {
    //        foreach (VStudent student in course.Students)
    //        {
    //            if (!nextStudents.Contains(student))
    //                nextStudents.Add(student);
    //        }
    //    }

    //    return nextStudents;
    //}

    public List<courseinfo> VerifyAdviseeCurrentSchedule(ref VStudent advisee)
    {
        return advisee.Current;
    }

    //Should return the schedule for the advisee with a list of warnings for conflicts. 
    public List<courseinfo> VerifyAdviseeNextSchedule(ref VStudent advisee, out List<string> conflicts)
    {
        conflicts = new List<string>(advisee.Conflicts);
        return advisee.Next;
    }
}

public class VAdmin : VUser
{
    public VAdmin(string uname, string pswd, string fname, string mname, string lname)
        : base(uname, pswd, fname, mname, lname, "admin")
    {

    }

    //An admin may add any student to any class. 
    public override List<errorReturn> enrollCourse(ref courseinfo course, ref VStudent student)
    {
        return base.enrollCourse(course, student);
    }

    public override errorReturn unenrollCourse(ref courseinfo course, ref VStudent student)
    {
        return base.unenrollCourse(course, student);
    }
}

public class VStudent : VUser
{
    public List<courseinfo> Next = new List<courseinfo>();
    public List<pastcourse> Current = new List<pastcourse>();
    public List<pastcourse> History = new List<pastcourse>();
    public List<string> Conflicts = new List<string>();

    new public string UserName { get { return base.UserName; } }
    public string FirstName { get { return base.FstName; } }
    public string MiddleName { get { return base.MidName; } }
    public string LastName { get { return base.LstName; } }



    public VStudent(string uname, string pswd, string fname, string mname, string lname,
        List<pastcourse> pstterms, List<pastcourse> thisterm, List<courseinfo> nextterm)
        : base(uname, pswd, fname, mname, lname, "student")
    {
        History = new List<pastcourse>(pstterms);
        Current = new List<pastcourse>(thisterm);
        Next = new List<courseinfo>(nextterm);

        //find conflicts
        checkConflicts(this);
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

    //A student may only enroll itself. 
    public override List<errorReturn> enrollCourse(ref courseinfo course)
    {
        return base.enrollCourse(course, this);
    }

    public override errorReturn unenrollCourse(ref courseinfo course)
    {
        return base.unenrollCourse(course, this);
    }
}