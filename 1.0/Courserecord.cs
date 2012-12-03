using System;
using System.Text;
using Registration;

public class courserecord
{
    public string Coursename { get; set; }
    public string Term { get; set; }
    public double Credit { get; set; }
    public string Grade { get; set; }
    public char Semester;
    public int Year;
    public string SecLessName;
    public double GPoints;
    public bool Earned;
    public bool GPAble;

	public courserecord(string coursename, string term, double credit, string grade)
	{
        Coursename = coursename;
        Term = term;
        Semester = term[0];
        Year = int.Parse(term.Substring(1));
        Credit = credit;
        Grade = grade;
        SecLessName = Coursename.Substring(0, 7);



        if (Grade.Contains("F"))
        {
            Earned = false;
            GPAble = true;
            GPoints = 0.0;
        }
        else if ( Grade.Contains("N") ||Grade.Contains("W") || Grade.Contains("U") || Grade.Contains("X") || Grade.Contains("I") || Grade.Contains("O") || Grade.Contains("EQ") )
        {
            Earned = false;
            GPAble = false;
            GPoints = 0.0;
        }
        else if (Grade.Contains("S"))
        {
            Earned = true;
            GPAble = false;
            GPoints = 0.0;
        }
        else
        {
            Earned = true;
            GPAble = true;

            if (Grade.Contains("A-"))
                GPoints = Credit * 3.7;
            else if (Grade.Contains("A"))
                GPoints = Credit * 4.0;

            else if (Grade.Contains("B+"))
                GPoints = Credit * 3.3;
            else if (Grade.Contains("B-"))
                GPoints = Credit * 2.7;
            else if (Grade.Contains("B"))
                GPoints = Credit * 3.0;

            else if (Grade.Contains("C+"))
                GPoints = Credit * 2.3;
            else if (Grade.Contains("C-"))
                GPoints = Credit * 1.7;
            else if (Grade.Contains("C"))
                GPoints = Credit * 2.0;

            else if (Grade.Contains("D+"))
                GPoints = Credit * 1.3;
            else if (Grade.Contains("D-"))
                GPoints = Credit * 0.7;
            else if (Grade.Contains("D"))
                GPoints = Credit * 1.0;
        }
	}

    public string HistoryDatabseString()
    {
        StringBuilder hdbstring = new StringBuilder(Coursename);
        hdbstring.Insert(12, Term.ToString() + Year.ToString());
        hdbstring.Insert(17, Credit.ToString());
        hdbstring.Insert(23, Grade);

        return hdbstring.ToString();
    }

    public bool Equals(courserecord course)
    {
        return this.Coursename.Substring(0, Coursename.Length - 3) == course.Coursename.Substring(0, course.Coursename.Length - 3);
    }

    public bool Equals(courseinfo course)
    {
        return this.Coursename.Substring(0, Coursename.Length - 3) == course.Coursename.Substring(0, course.Coursename.Length - 3);
    }
}
