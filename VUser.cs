using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    //public struct errorReturn
    //{
    //    public bool wasError;
    //    public string errorWas;
    //}

    public enum VType
    {
        notmade,
        student,
        faculty,
        admin
    };

    
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
        usertype = (stat == "admin") ? VType.admin : (stat == "faculty") ? VType.faculty : (stat == "student") ? VType.student : VType.notmade; 
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

    public bool Equals(VUser user)
    {
        if ((object)user == null)
            return false;

        return userName == user.UserName;
    }


    public static bool operator ==(VUser a, VUser b) { return a.Equals(b); }
    public static bool operator !=(VUser a, VUser b) { return !a.Equals(b); }



    //Returns a list of errorReturns. Warnings are errorList objects with wasError = false; 
    //Returns an empty list if there were neither errors nor warnings. 
    public virtual List<errorReturn> enrollCourse(ref courseinfo course, ref VStudent student)
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
        foreach (coursetime time in course.Times)
        {
            foreach (courseinfo course2 in student.Next)
            {
                foreach (coursetime time2 in course2.Times)
                {
                    if (((time.start <= time2.start) && (time2.start <= time.end)) || ((time2.start <= time.start) && (time.start <= time2.end)))
                    {
                        foreach (char day in time.days)
                        {
                            if (time2.days.Contains(day))
                            {
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

        foreach (pastcourse oldcourse in student.History)
        {
            if (course.Coursename == oldcourse.Coursename)
            {
                StringBuilder estring = new StringBuilder(course.Coursename + "RT" + oldcourse.Coursename + oldcourse.Term);
                eN.wasError = false;
                eN.errorWas = estring.ToString();
                warnlist.Add(eN); 
            }
        }

        if (errlist.Count == 0)
        {
            //Beyond here, no new errors and no new warnings. 
            student.Next.Add(course);
            course.students.Add(student);
        }

        //Finalizing. Determine whether to return errlist or warnlist. 
        if (errlist.Count > 0)
        {
            return errlist;
        }

        else
        {   
            return warnlist;
        }
    }


}


public class VFaculty : VUser
{
    VUser Me;
    List<VStudent> advisees = new List<VStudent>();
    List<courseinfo> taught = new List<courseinfo>();

    VFaculty(string uname, string pswd, string fname, string mname, string lname)
    {
        Me = new VUser(uname, pswd, fname, mname, lname, "faculty");
    }


}

public class VAdmin : VUser
{
    VUser Me;

    public VAdmin(string uname, string pswd, string fname, string mname, string lname)
    {
        Me = new VUser(uname, pswd, fname, mname, lname, "admin");
    }

}

public class VStudent : VUser
{
        VUser Me;
        public List<courseinfo> Next = new List<courseinfo>();
        public List<pastcourse> Current = new List<pastcourse>();
        public List<pastcourse> History = new List<pastcourse>();

        new public string UserName { get { return Me.UserName; } }
        public string FirstName { get { return Me.FstName; } }
        public string MiddleName { get { return Me.MidName; } }
        public string LastName { get { return Me.LstName; } }
        
         

        public VStudent(string uname, string pswd, string fname, string mname, string lname,
            List<pastcourse> histterms, List<pastcourse> thisterm, List<courseinfo> nextterm)
        {
            Me = new VUser(uname, pswd, fname, mname, lname, "student");
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


}