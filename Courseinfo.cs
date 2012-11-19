using System;
using System.Collections.Generic;
using System.Text;

public class courseinfo : ICourse<courseinfo>
{
    private string coursename;
    private string coursetitle;
    private string instructor;
    private float credit;
    private int seats;
    private List<coursetime> times = new List<coursetime>(); // as initialized, these are ddttks in order of entry.
    private List<VStudent> students = new List<VStudent>(); // Becase we'll need this; 

    public string Coursename { get { return coursename; } }
    public string Coursetitle { get { return coursetitle; } }
    public string Instructor { get { return instructor; } }
    public float Credit { get { return credit; } }
    public int Seats { get { return seats; } }
    public List<coursetime> Times { get { return times; } }
    public List<VStudent> Students { get { return students; } }


    //timeslist should be ddttk strings, later termed 'TerryStrings' after their creator.
    //See the one parameter constructor for coursetimes for more information. 
    //public courseinfo(string name, string title, string prof, float cred, int spots, List<coursetime> timeslist)
    //{   
    //    coursename = name;
    //    coursetitle = title;
    //    instructor = prof;
    //    credit = cred;
    //    seats = spots;
    //    times = timeslist;
    //}


    //VUser/VStudent constructor for this class. 
    public courseinfo(string name, string title, string prof, float cred, int spots,
        List<coursetime> timeslist, List<VStudent> studs)
    {
        coursename = name;
        coursetitle = title;
        instructor = prof;
        credit = cred;
        seats = spots;
        times = timeslist;
        students = new List<VStudent>(studs);
    }

    //// psuedo-casting
    //public courseinfo(pastcourse course)
    //{
    //    coursename = course.Coursename;
    //    coursetitle = "";
    //    instructor = "";
    //    credit = 0.0f;
    //    seats = 0;
    //}

    public int Enrolled()
    { 
        return students.Count;
    }

    public bool isFull()
    {
        return seats <= students.Count;
    }

    public bool enrollStudent(ref VStudent student)
    {   // returns true is successful, false otherwise (ex. already enrolled)
        if (!students.Contains(student))
        {
            students.Add(student);
            return true;
        }
        else return false;
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
