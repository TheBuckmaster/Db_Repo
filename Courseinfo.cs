using System;
using System.Collections.Generic;
using System.Text;

public class coursetime
{
    public List<char> days = new List<char>();    // MTWUF
    public int start;   // #tt format
    public int end;     // #tt format

    public coursetime()
    {
        days.Add('M');
        days.Add('W');
        days.Add('F');
        start = 10;
        end = 11;
    }

    public coursetime(string TerryString)
    {
        int dd = (int)TerryString[0] * 10 + (int)TerryString[1];
        int tt = (int)TerryString[2] * 10 + (int)TerryString[3];
        int l = (int)TerryString[4];

        start = tt;

        if (dd % 2 == 1)
            days.Add('M');
        if (dd % 4 == 2)
            days.Add('T');
        if (dd % 8 == 4)
            days.Add('W');
        if (dd % 16 == 8)
            days.Add('H');
        if (dd >= 16)
            days.Add('F');

        
        end = start + l; 
    }

    public string showtime(int time)
    {
        StringBuilder ReturnString = new StringBuilder(); 
        int hours = time/2;
        int minutes = (int)((time % 2.00) * 60);
        
        if (hours > 12)
            ReturnString.AppendFormat("{0}:{1} PM",hours, minutes);
        else
            ReturnString.AppendFormat("{0}:{1} AM",hours, minutes);
        
        return ReturnString.ToString();    
    }



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


    public bool Equals(courseinfo course) { return coursename == course.Coursename; }
}
