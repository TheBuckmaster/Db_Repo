﻿using System;
using System.Collections.Generic;
using System.Text;
using Registration;

public class courseinfo 
{
    public string Coursename { get; set; }
    public string Coursetitle { get; set; }
    public string Instructor { get; set; }
    public double Credit { get; set; }
    public int Seats { get; set; }
    public int Enrolled { get; set; }
    public List<coursetime> Times { get; set; }
    public List<string> Students = new List<string>();
    public List<string> Prereqs = new List<string>();
    public string SecLessName;
    public string Term { get; set; }



    public courseinfo(string name, string title, string prof, double cred, int seats,
        List<coursetime> timeslist)
    {
        Coursename = name;
        Coursetitle = title;
        Instructor = prof;
        Credit = cred;
        Seats = seats;
        Times = timeslist;
        Enrolled = 0;
        SecLessName = Coursename.Substring(0, Coursename.Length - 3);
    }

    public bool isFull()
    {
        return Seats <= Enrolled;
    }

    public bool isConflict(courseinfo course)
    {
        bool conflict = false;

        foreach (coursetime time in Times)   //Each time the course is offered
        {
            foreach (coursetime time2 in course.Times)     //And each time of that class. 
            {
                if (((time.start <= time2.start) && (time2.start <= time.end)) || ((time2.start <= time.start) && (time.start <= time2.end)))
                {   //Does this time overlap?
                    foreach (char day in time.daylist)
                    {   //Is it on the same day? 
                        if (time2.daylist.Contains(day))
                        {   
                            conflict = true;
                            break;
                        }
                    }
                }
                if (conflict)
                    break;
            }
            if (conflict)
                break;
        }

        return conflict;
    }

    public string CourseDatabaseString()
    {
        StringBuilder cdbstring = new StringBuilder(Term);
        cdbstring.Insert(5, Coursename);
        cdbstring.Insert(17, Coursetitle);
        cdbstring.Insert(34, Instructor);
        cdbstring.Insert(46, Credit.ToString());
        cdbstring.Insert(52, Seats.ToString());
        cdbstring.Insert(57, Times.Count);
        foreach (coursetime time in Times)
            cdbstring.Append(time.ToString() + "  ");

        return cdbstring.ToString();
    }

    //public bool Equals(courseinfo course)
    //{
    //    return this.Coursename.Substring(0, Coursename.Length - 3) == course.Coursename.Substring(0, course.Coursename.Length - 3);
    //}

    //public bool Equals(pastcourse course)
    //{
    //    return this.Coursename.Substring(0, Coursename.Length - 3) == course.Coursename.Substring(0, course.Coursename.Length - 3);
    //}
}
