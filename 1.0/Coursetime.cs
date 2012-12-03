using System;
using System.Text;
using System.Collections.Generic;

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

        int dd = int.Parse(TerryString.Substring(0, 2), 10);
        int tt = int.Parse(TerryString.Substring(2, 2), 10);
        int l = int.Parse(TerryString.Substring(4, 1), 10);

        start = tt;


        //this should do it 
        if ((dd & 1) == 1)
            days.Add('M');
        if ((dd & 2) == 2)
            days.Add('T');
        if ((dd & 4) == 4)
            days.Add('W');
        if ((dd & 8) == 8)
            days.Add('R');
        if ((dd & 16) == 16)
            days.Add('F');


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

        foreach (char d in days)
            daystring += d;

        return daystring;
    }

    public string StartTime()
    {
        return showtime(start);
    }

    public string EndTime()
    {
        return showtime(end);
    }

    public override string ToString()
    {
        StringBuilder TerryString = new StringBuilder();

        int dd = 0;
        if (days.Contains("M"))
            dd += 1;
        if (days.Contains("T"))
            dd += 2;
        if (days.Contains("W"))
            dd += 4;
        if (days.Contains("R"))
            dd += 8;
        if (days.Contains("F"))
            dd += 16;

        TerryString.Append(dd);
        TerryString.Append(start);
        TerryString.Append(end - start);

        return TerryString.ToString();
    }

}