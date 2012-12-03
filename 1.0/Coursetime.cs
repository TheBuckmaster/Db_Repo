using System;
using System.Text;
using System.Collections.Generic;

public class coursetime
{
    public string Days
    {
        get { return DayString(); }
    }
    public string StartTime
    {
        get { return showtime(start); }
    }
    public string EndTime
    {
        get { return showtime(end); }
    }

    public List<char> daylist = new List<char>();    // MTWRF
    public int start;   // #tt format
    public int end;     // #tt format

    public coursetime()
    {
        daylist.Add('M');
        daylist.Add('W');
        daylist.Add('F');
        start = 10;
        end = 11;
    }

    public coursetime(string TerryString)
    {

        int dd = int.Parse(TerryString.Substring(0, 2), 10);
        int tt = int.Parse(TerryString.Substring(2, 2), 10);
        int l = int.Parse(TerryString.Substring(4, 1), 10);

        start = tt;


        //this should do it 
        if ((dd & 1) == 1)
            daylist.Add('M');
        if ((dd & 2) == 2)
            daylist.Add('T');
        if ((dd & 4) == 4)
            daylist.Add('W');
        if ((dd & 8) == 8)
            daylist.Add('R');
        if ((dd & 16) == 16)
            daylist.Add('F');


        end = start + l;
    }


    //This function required reading chapter 16, but I feel better for it.
    //Returns a string of the time passed in in tt format. Outputs resemble 10:00 AM
    public string showtime(int time)
    {
        StringBuilder ReturnString = new StringBuilder();
        int hours = time / 2;
        int minutes = (int)((time % 2.00) * 60);

        if (hours > 12)
            ReturnString.AppendFormat("{0}:{1d2} PM", hours, minutes);
        else
            ReturnString.AppendFormat("{0}:{1d2} AM", hours, minutes);

        return ReturnString.ToString();
    }

    public string DayString()
    {
        string daystring = "";

        foreach (char d in daylist)
            daystring += d;

        return daystring;
    }


    public override string ToString()
    {
        StringBuilder TerryString = new StringBuilder();

        int dd = 0;
        if (daylist.Contains("M"))
            dd += 1;
        if (daylist.Contains("T"))
            dd += 2;
        if (daylist.Contains("W"))
            dd += 4;
        if (daylist.Contains("R"))
            dd += 8;
        if (daylist.Contains("F"))
            dd += 16;

        TerryString.Append(dd);
        TerryString.Append(start);
        TerryString.Append(end - start);

        return TerryString.ToString();
    }

}