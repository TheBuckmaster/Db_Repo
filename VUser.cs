using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    //public struct errorReturn
    //{
    //    public bool wasError;
    //    public string errorWas;
    //}    
    
    public class VUser
    {
        private string userName;
        private string password;
        private string fstName;
        private string midName;
        private string lstName;
        private string status;

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
        }

        public VUser(string uname, string pswd, string fname, string mname, string lname, string stat)
    {
        userName = uname;
        password = pswd;
        fstName = fname;
        midName = mname;
        lstName = lname;
        status = stat;
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