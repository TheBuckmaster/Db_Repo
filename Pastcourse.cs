using System;

public class pastcourse
{
    public string Coursename;
    public string Term;
    public float Credit;
    public string Grade;

	public pastcourse(string coursename, string term, float credit, string grade)
	{
        Coursename = coursename;
        Term = term;
        Credit = credit;
        Grade = grade;
	}

    public bool Equals(pastcourse course) { return Coursename.Substring(0, Coursename.Length - 3) == course.Coursename.Substring(0, course.Coursename.Length - 3); }
    public bool Equals(courseinfo course) { return Coursename.Substring(0, Coursename.Length - 3) == course.Coursename.Substring(0, course.Coursename.Length - 3); }
}
