using System;
using System.Collections.Generic;
using System.Text;

public class coursetime
{
    public List<char> days = new List<char>();    // MTWRF
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

        // should be like this according to proj-specs - apb
        if (dd & 1)
            days.Add('M');
        if (dd & 2)
            days.Add('T');
        if (dd & 4)
            days.Add('W');
        if (dd & 8)
            days.Add('R');
        if (dd & 16)
            days.Add('F');

        
        end = start + l; 
    }


    //This function required reading chapter 16, but I feel better for it.
    //Returns a string of the time passed in in tt format. Outputs resemble 10:00 AM
    public string showtime(int time)
    {
        StringBuilder ReturnString = new StringBuilder(); 
        int hours = time/2;
        int minutes = (int)((time % 2.00) * 60);
        
        if (hours > 12)
            ReturnString.AppendFormat("{0}:{1d2} PM",hours, minutes);
        else
            ReturnString.AppendFormat("{0}:{1d2} AM",hours, minutes);
        
        return ReturnString.ToString();    
    }

    public override string ToString()
    {
        StringBuilder TerryString = new StringBuilder();

        int dd = 0;
        if (days.Contains('M'))
            dd +=1;
        if (days.Contains('T'))
            dd +=2;
        if (days.Contains('W'))
            dd += 4;
        if (days.Contains('R'))
            dd += 8;
        if (days.Contains('F'))
            dd += 16;

        TerryString.Append(dd);
        TerryString.Append(start);
        TerryString.Append(end - start);
        
        return TerryString.ToString();
    }

}



public class courseinfo
{
    private string coursename;
    private string coursetitle;
    private string instructor;
    private float credit;
    private int seats;
    private List<coursetime> times = new List<coursetime>(); // as initialized, these are ddttks in order of entry.

    public int Enrolled;
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
        Enrolled = 0;
	}


    public bool Equals(courseinfo course) { return coursename == course.Coursename; }
    public bool Equals(pastcourse course) { return coursename == course.Coursename; }
}
