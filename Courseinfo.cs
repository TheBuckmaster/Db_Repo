using System;
using System.Collections.Generic;

public class courseinfo
{
    private string coursename;
    private string coursetitle;
    private string instructor;
    private float credit;
    private int seats;
    private int timeblocks;  // how many timeblocks? 
    private Stack<string> times; // as initialized, these are ddttks in reverse order of entry.

    public string Coursename { get { return coursename; } }
    public string Coursetitle { get { return coursetitle; } }
    public string Instructor { get { return instructor; } }
    public float Credit { get { return credit; } }
    public int Seats { get { return seats; } }
    public int Timeblocks { get { return timeblocks; } }
    public Stack<string> Times { get { return times; } }

	public courseinfo(string name, string title, string prof, float cred, int spots, int timeblks)
	{   
        coursename = name;
        coursetitle = title;
        instructor = prof;
        credit = cred;
        seats = spots;
        timeblocks = timeblks;
	}

    public void addTime(string time) { times.Push(time); }
}
