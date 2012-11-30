using System;
using System.Collections.Generic;
using System.Text;

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

    //// psuedo-casting
    //public courseinfo(pastcourse course)
    //{
    //    coursename = course.Coursename;
    //    coursetitle = "";
    //    instructor = "";
    //    credit = 0.0f;
    //    seats = 0;
    //}

    public bool isFull()
    {
        return Seats <= Enrolled;
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
