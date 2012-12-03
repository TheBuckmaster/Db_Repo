using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Registration
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // our "databases"
            List<Admin> AdminList = new List<Admin>();
            List<Faculty> FacultyList = new List<Faculty>();
            List<Student> StudentList = new List<Student>();
            List<courseinfo> NextCourses = new List<courseinfo>();
            List<courseinfo> PrevCourses = new List<courseinfo>();
            string nxtterm = "S13";



            // read in UserDatabase
            string filename = "UserInput.txt";
            if (File.Exists(filename))
            {
                FileStream input = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(input);
                try
                {
                    string line;
                    string username;
                    string pswd;
                    string fname;
                    string mname;
                    string lname;
                    string stat;

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();

                        // username
                        line.TrimStart();
                        username = line.Substring(0, 10);
                        username.TrimEnd();
                        line.Remove(0, 10);

                        // password
                        line.TrimStart();
                        pswd = line.Substring(0, 10);
                        pswd.TrimEnd();
                        line.Remove(0, 10);

                        // first name
                        line.TrimStart();
                        fname = line.Substring(0, 15);
                        fname.TrimEnd();
                        line.Remove(0, 15);

                        // middle name
                        line.TrimStart();
                        mname = line.Substring(0, 15);
                        mname.TrimEnd();
                        line.Remove(0, 15);

                        // last name
                        line.TrimStart();
                        lname = line.Substring(0, 15);
                        lname.TrimEnd();
                        line.Remove(0, 15);

                        // status
                        line.TrimStart();
                        stat = line.Substring(0, 10);
                        stat.TrimEnd();
                        line.Remove(0, 10);

                        // add user info
                        if (stat == "admin")
                            AdminList.Add(new Admin(username, pswd, fname, mname, lname, stat));
                        else if (stat == "faculty")
                            FacultyList.Add(new Faculty(username, pswd, fname, mname, lname, stat));
                        else StudentList.Add(new Student(username, pswd, fname, mname, lname, stat));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid User Input File");
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("User file does not Exist.");
            }




            filename = "ClassInput.txt";
            if (File.Exists(filename))
            {
                FileStream input = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(input);
                try
                {
                    string line;
                    string term;
                    string coursename;
                    string coursetitle;
                    string instructor;
                    float credit;
                    int seats;
                    int timeblocks;
                    List<coursetime> times = new List<coursetime>();

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();

                        term = line.Substring(0, 3);
                        term.TrimEnd();
                        line.Remove(0, 3);

                        line.TrimStart();
                        coursename = line.Substring(0, 10);
                        coursename.TrimEnd();
                        line.Remove(0, 10);

                        line.TrimStart();
                        coursetitle = line.Substring(0, 15);
                        coursetitle.TrimEnd();
                        line.Remove(0, 15);

                        line.TrimStart();
                        instructor = line.Substring(0, 10);
                        instructor.TrimEnd();
                        line.Remove(0, 10);

                        line.TrimStart();
                        credit = double.Parse(line.Substring(0, 4));
                        line.Remove(0, 4);

                        line.TrimStart();
                        seats = int.Parse(line.Substring(0, 3));
                        line.Remove(0, 3);

                        line.TrimStart();
                        timeblocks = int.Parse(line.Substring(0, 1));
                        line.Remove(0, 1);
                        line.TrimStart();

                        times = new List<coursetime>();
                        for (int i = 0; i < timeblocks; ++i)
                        {
                            string littlestring = line.Substring(0, 5);
                            times.Add(new coursetime(littlestring));

                            line.Remove(0, 5);
                            line.TrimStart();
                        }

                        if (term == nxtterm)
                            NextCourses.Add(new courseinfo(coursename, coursetitle, instructor, credit, seats, times));
                        else PrevCourses.Add(new courseinfo(coursename, coursetitle, instructor, credit, seats, times));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Class Input File");
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Class file does not Exist.");
            }

            //add advisees/schedule to faculty
            foreach (Faculty prof in FacultyList)
            {
                foreach (Student stud in StudentList)
                {
                    if (prof.UserName == stud.Status)
                        prof.Advisees.Add(stud.UserName);
                }
                foreach (courseinfo course in NextCourses)
                {
                    if (prof.UserName == course.Instructor)
                        prof.Next.Add(course.Coursename);
                }
            }


            filename = "HistoryInput.txt";
            if (File.Exists(filename))
            {
                FileStream input = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(input);

                try
                {
                    string line;
                    string username;
                    int numcourses;
                    string coursename;
                    string term;
                    double credit;
                    string grade;

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        username = line.Substring(0, 10);
                        line.Remove(0, 10);
                        line.TrimStart();
                        numcourses = int.Parse(line.Substring(0, 2));
                        line.Remove(0, 2);
                        line.TrimStart();

                        // find index of student
                        int undx = 0;
                        foreach (Student stud in StudentList)
                        {
                            if (stud.UserName == username)
                                break;
                            ++undx;
                        }

                        for (int i = 0; i < numcourses; ++i)
                        {
                            coursename = line.Substring(0, 10);
                            line.Remove(0, 10);
                            line.TrimStart();
                            term = line.Substring(0, 3);
                            line.Remove(0, 3);
                            line.TrimStart();
                            credit = double.Parse(line.Substring(0, 4));
                            line.Remove(0, 4);
                            line.TrimStart();
                            grade = line.Substring(0, 3);
                            line.Remove(0, 3);
                            line.TrimStart();


                            // fixed maybe?
                            if (grade.Contains("N"))
                            {
                                if (term == curterm)
                                    StudentList[undx].Current.Add(coursename);
                                // Users[undx].Add(new courserecord(coursename, term, credit, grade);
                                else StudentList[undx].Next.Add(coursename);
                            }
                            else StudentList[undx].History.Add(new courserecord(coursename, term, credit, grade));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid History Input File");
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("History file does not Exist.");
            }


            // read course prereq database
            filename = "PrereqInput.txt";
            if (File.Exists(filename))
            {
                FileStream input = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(input);

                try
                {
                    string line;
                    string coursename;
                    int numprereq;
                    string prereq;

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();

                        course = line.Substring(0, 7);
                        line.Remove(0, 7);
                        line.TrimStart();
                        numprereq = int.Parse(line.Substring(0, 2));
                        line.Remove(0, 2);
                        line.TrimStart();

                        int cndx = 0;
                        foreach (courseinfo course in NextCourses)
                        {
                            if (course.SecLessName == coursename)
                                break;
                            ++cndx;
                        }

                        for (int i = 0; i < numprereq; ++i)
                        {
                            prereq = line.Substring(0, 7);
                            line.Remove(0, 7);
                            line.TrimStart();

                            NextCourses[cndx].Prereqs.Add(prereq);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Prereq Input File");
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Prereq file does not Exist.");
            }

            //LAUNCH FORMS AND THINGS HERE
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(AdminList, FacultyList, StudentList, NextCourses, PrevCourses));

        }


        //    //output new databases
        //    filename = "UserInput.txt";
        //    FileStream userdata = new FileStream(filename, FileMode.Truncate, FileAccess.Write);
        //    try
        //    {
        //        using (StreamWriter sw = new StreamWriter(userdata))
        //        {
        //            foreach(Admin adm in AdminList)
        //                sw.WriteLine(adm.UserDatabaseString(), true);

        //            foreach(Faculty prof in FacultyList)
        //                sw.WriteLine(prof.UserDatabaseString(), true);

        //            foreach(Student stud in StudentList)
        //                sw.WriteLine(stud.UserDatabaseString(), true);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("The user database could not be written:");
        //        Console.WriteLine(e.Message);
        //    }
            
        //    filename = "ClassInput.txt";
        //    FileStream classdata = new FileStream(filename, FileMode.Truncate, FileAccess.Write);
        //    try
        //    {
        //        using (StreamWriter sw = new StreamWriter(classdata))
        //        {
        //            foreach(courseinfo course in NextCourses)
        //                sw.WriteLine(course.CourseDatabaseString());
        //            foreach(courseinfo course in PrevCourses)
        //                sw.WriteLine(course.CourseDatabaseString());
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("The course database could not be written:");
        //        Console.WriteLine(e.Message);
        //    }
            
        //    filename = "HistoryInput.txt";
        //    FileStream historydata = new FileStream(filename, FileMode.Truncate, FileAccess.Write);
        //    try
        //    {
        //        using (StreamWriter sw = new StreamWriter(historydata))
        //        {
        //            foreach(Student stud in StudentList)
        //                sw.WriteLine(stud.HistoryDatabaseString());
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("The history database could not be written:");
        //        Console.WriteLine(e.Message);
        //    }  

        //    LoginForm lgn = new LoginForm(AdminList, FacultyList, StudentList, NextCourses,
        //    PrevCourses);
        //    lgn.Show();
        //}


    }
    
}