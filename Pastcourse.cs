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

    public bool Equals(pastcourse course) { return coursename.Substring(0, coursename.Length - 2) == course.Coursename.Substring(0, Coursename.Length - 2); }
    public bool Equals(courseinfo course) { return coursename.Substring(0, coursename.Length - 2) == course.Coursename.Substring(0, Coursename.Length - 2); }
}
