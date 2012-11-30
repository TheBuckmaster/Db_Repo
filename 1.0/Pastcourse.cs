using System;

public class pastcourse : ICourse<pastcourse>
{
    public string Coursename;
    public string Term;
    public float Credit;
    public bool Earned;
    public float Gpoints;
    public string Grade;
    public string Marks;

	public pastcourse(string coursename, string term, float credit, string grade)
	{
        Coursename = coursename;
        Term = term;
        Credit = credit;
        Grade = grade;

        if (Grade.Contains("F") || Grade.Contains("W") || Grade.Contains("U") || Grade.Contains("X") || Grade.Contains("I") || Grade.Contains("O"))
        {
            Earned = false;
            Gpoints = 0.0;
        }
        else if (Grade.Contains("S")
        else
        {
            Earned = true;

            if (Grade.Contains("A-"))
                Gpoints = 4.0;
            else if (Grade.Contains("A"))
                Gpoints = 3.7;

            if (Grade.Contains("B+"))
                Gpoints = 3.3;
            else if (Grade.Contains("B-"))
                Gpoints = 2.7;
            else if (Grade.Contains("B"))
                Gpoints = 3.0;

            if (Grade.Contains("C+"))
                Gpoints = 2.3;
            else if (Grade.Contains("C-"))
                Gpoints = 1.7;
            else if (Grade.Contains("C"))
                Gpoints = 2.0;

            if (Grade.Contains("D+"))
                Gpoints = 1.3;
            else if (Grade.Contains("D-"))
                Gpoints = 0.7;
            else if (Grade.Contains("D"))
                Gpoints = 1.0;

            else if(Grade.Contains("F"))
                Gpoints = 0.0
        }
	}

    public bool Equals(pastcourse course)
    {
        return this.Coursename.Substring(0, Coursename.Length - 3) == course.Coursename.Substring(0, course.Coursename.Length - 3);
    }

    public bool Equals(courseinfo course)
    {
        return this.Coursename.Substring(0, Coursename.Length - 3) == course.Coursename.Substring(0, course.Coursename.Length - 3);
    }
}
