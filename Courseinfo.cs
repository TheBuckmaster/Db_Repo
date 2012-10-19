using System;
using System.Collections.Generic;

public struct coursetime
{
    public char day;    // MTWUF
    public int start;   // #tt format
    public int end;     // #tt format
}



public class courseinfo
{
    private string coursename;
    private string coursetitle;
    private string instructor;
    private float credit;
    private int seats;
    private string term;
    private List<coursetime> times; // as initialized, these are ddttks in reverse order of entry.

    public string Coursename { get { return coursename; } }
    public string Coursetitle { get { return coursetitle; } }
    public string Instructor { get { return instructor; } }
    public float Credit { get { return credit; } }
    public int Seats { get { return seats; } }
    public int enrolled;
    public string Term { get { return term; } }
    public List<coursetime> Times { get { return times; } }

	public courseinfo(string name, string title, string prof, float cred, int spots, List<coursetime> timeslist)
	{   
        coursename = name;
        coursetitle = title;
        instructor = prof;
        credit = cred;
        seats = spots;
        times = timeslist;
	}

    public static coursetime makeCourseTime(string TerryString)
    {

        // This function should take a TerryString and return a CourseTime struct. Obviously this is filler code. 

        coursetime mycoursetime;
        mycoursetime.day = 'M';
        mycoursetime.start = 10;
        mycoursetime.end = 11;

        return mycoursetime;
    }

    public bool Equals(courseinfo course) { return coursename == course.Coursename; }
}
