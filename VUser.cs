using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    //This is defined currently in User.cs
    //public struct errorReturn
    //{
    //    public bool wasError;  //true == error; false == warning
    //    public string errorWas;

    //    should there perhaps be a field for an eRType or wRType? 
    //}

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
        credits
    }

    public enum wRType
    {
        error,
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

    errorReturn unenrollCourse(ref courseinfo course, ref VStudent student)
    {
        //if (this.status == "faculty")
        //{
        //    //Depending on Future specs, we still might want to test for this. 
        //}

        if (this.status == "student")
        {
            //Is the user doing the edit the student being registered? 
            if (this != student) 
            {
                //We have a very clever student.
                errorReturn er;
                er.wasError = true;
                er.errorWas = "diffStudent";
                return er; //This is one where we might want to kick them out. 
            }
        }


        if (!student.Next.Remove(course))
            {
                errorReturn er;
                er.wasError = true;
                er.errorWas = "notenrolled";
                return er;
                // throw "Unenroll encountered an error. Were you enrolled?" error 
            }
        

        errorReturn er1;
        er1.wasError = false;
        er1.errorWas = "notError";
        return er1;
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
    public virtual List<errorReturn> enrollCourse(courseinfo course, VStudent student)
    {
        List<errorReturn> errlist  = new List<errorReturn>();
        List<errorReturn> warnlist = new List<errorReturn>();
        errorReturn eN; // Always use this to add errors and warnings. 
     
        //Generate list of Errors.
        if (course.Enrolled == course.Seats) //Is the course full? Return an error. 
        {
            eN.wasError = true;
            eN.errorWas = "CourseIsFull";
            errlist.Add(eN);
        }

        if (student.Next.Contains(course)) //Is the student already registered for this course? Return an error. 
        {
            eN.wasError = true;
            eN.errorWas = "AlreadyHere";
            errlist.Add(eN);
        }

        if ((student.enrolledCredits() + course.Credit) > 5.0) //Would this put the student over 5.0 credits?
        {
            eN.errorWas = ">5.0";
            if (this.usertype == VType.admin)                   //If Admin, warn, but allow. 
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
        
        
        
        //Generate list of Warnings. 


        //Warnings for class conflict
        foreach (coursetime time in course.Times)   //Each time the course is offered
        {
            foreach (courseinfo course2 in student.Next)    //Compare to each already added class
            {
                foreach (coursetime time2 in course2.Times)     //And each time of that class. 
                {
                    if (((time.start <= time2.start) && (time2.start <= time.end)) || ((time2.start <= time.start) && (time.start <= time2.end)))
                    {   //Does this time overlap?
                        foreach (char day in time.days)
                        {   //Is it on the same day? 
                            if (time2.days.Contains(day))
                            {   //Throw warning message. 
                                eN.wasError = false;
                                StringBuilder errorstring = new StringBuilder(course.Coursetitle + "xx" + course2.Coursetitle);
                                eN.errorWas = errorstring.ToString();
                                warnlist.Add(eN);
                            }
                        }
                    }
                }
            }
        }
        //Warning if the course is being retaken. 
        foreach (pastcourse oldcourse in student.History)
        {
            if (course.Coursename == oldcourse.Coursename)
            {
                StringBuilder estring = new StringBuilder(course.Coursename + "RT" + oldcourse.Coursename);
                eN.wasError = false;
                eN.errorWas = estring.ToString();
                warnlist.Add(eN); 
            }
        }

        //If there were no errors. 
        if (errlist.Count == 0)
        {
            //Beyond here, no new errors and no new warnings. 
            student.Next.Add(course);       //The student has a course.
            course.students.Add(student);   //The course has a student.
        }

        //Finalizing. Determine whether to return errlist or warnlist. 
        if (errlist.Count > 0)
        //If there was an error, we'll return that list. 
        {
            return errlist;
        }
        //Otherwise, we'll return the list of warnings. The only way to have returned an empty list is
        //If there are no warnings. 
        else
        {   
            return warnlist;
        }
    }


}


public class VFaculty : VUser
{

    List<VStudent> advisees = new List<VStudent>();
    List<courseinfo> taught = new List<courseinfo>();

    VFaculty(string uname, string pswd, string fname, string mname, string lname) 
        : base(uname, pswd, fname, mname, lname, "faculty")
    {

    }


    VFaculty(string uname, string pswd, string fname, string mname, string lname,
        List<VStudent> advs, List<courseinfo> mycourses)
        : base(uname, pswd, fname, mname, lname, "faculty")
    {
        advisees = new List<VStudent>(advs);
        taught = new List<courseinfo>(mycourses);
    }

}

public class VAdmin : VUser
{
    public VAdmin(string uname, string pswd, string fname, string mname, string lname) 
        : base(uname, pswd, fname, mname, lname, "admin")
    {

    }

    //An admin may add any student to any class. 
    public override List<errorReturn> enrollCourse(courseinfo course, VStudent student)
    {
        return base.enrollCourse(course, student);
    }
}

public class VStudent : VUser
{
        public List<courseinfo> Next = new List<courseinfo>();
        public List<pastcourse> Current = new List<pastcourse>();
        public List<pastcourse> History = new List<pastcourse>();

        new public string UserName { get { return base.UserName; } }
        public string FirstName { get { return base.FstName; } }
        public string MiddleName { get { return base.MidName; } }
        public string LastName { get { return base.LstName; } }
        
         

        public VStudent(string uname, string pswd, string fname, string mname, string lname,
            List<pastcourse> histterms, List<pastcourse> thisterm, List<courseinfo> nextterm)
            : base(uname, pswd, fname, mname, lname, "student")
        {
            History = histterms;
            Current = thisterm;
            Next = nextterm;
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
            {
                //I don't think this line is needed anymore, since we don't have current courses in history anymore. 
                //if (course.Term != "F12")    // if not in progress
                    credits += course.Credit;
            }
            return credits;
        }
        
        //A student may only enroll itself. 
        public List<errorReturn> enrollCourse(courseinfo course)
        {
                return base.enrollCourse(course, this);
        }


}