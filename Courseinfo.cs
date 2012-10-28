using System;
using System.Collections.Generic;
using System.Text;

public class courseinfo
{
    private string coursename;
    private string coursetitle;
    private string instructor;
    private float credit;
    private int seats;
    private List<coursetime> times = new List<coursetime>(); // as initialized, these are ddttks in order of entry.
    public List<VStudent> students = new List<VStudent>(); // Becase we'll need this; 
    private int enrolled;

    public int Enrolled { get { return enrolled; } }
    public string Coursename { get { return coursename; } }
    public string Coursetitle { get { return coursetitle; } }
    public string Instructor { get { return instructor; } }
    public float Credit { get { return credit; } }
    public int Seats { get { return seats; } }
    public List<coursetime> Times { get { return times; } }


    //timeslist should be ddttk strings, later termed 'TerryStrings' after their creator.
    //See the one parameter constructor for coursetimes for more information. 
	public courseinfo(string name, string title, string prof, float cred, int spots, List<coursetime> timeslist)
	{   
        coursename = name;
        coursetitle = title;
        instructor = prof;
        credit = cred;
        seats = spots;
        times = timeslist;
        enrolled = 0;
	}


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
        enrolled = students.Count;
        students = new List<VStudent>(studs); 

    }

    public bool Equals(courseinfo course) { return coursename.Substring(0, coursename.Length - 2) == course.Coursename.Substring(0, course.Coursename.Length - 2); }
    public bool Equals(pastcourse course) { return coursename.Substring(0, coursename.Length - 2) == course.Coursename.Substring(0, course.Coursename.Length - 2); }
}
