﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

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

            try
            {
                string line;
                string username;
                string pswd;
                string fname;
                string mname;
                string lname;
                string stat;
                // this is apparently how reading files works. whatever
                using (Stream input = Assembly.GetExecutingAssembly()
                           .GetManifestResourceStream("UserInput.txt"))
                using (StreamReader sr = new StreamReader(input))
                {

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();

                        // username
                        line = line = line = line.TrimStart();
                        username = line.Substring(0, 10);
                        username = username.Trim();
                        line.Remove(0, 10);

                        // password
                        line = line = line = line.TrimStart();
                        pswd = line.Substring(0, 10);
                        pswd = pswd.Trim();
                        line.Remove(0, 10);

                        // first name
                        line = line = line = line.TrimStart();
                        fname = line.Substring(0, 15);
                        fname = fname.Trim();
                        line.Remove(0, 15);

                        // middle name
                        line = line = line = line.TrimStart();
                        mname = line.Substring(0, 15);
                        mname = mname.Trim();
                        line.Remove(0, 15);

                        // last name
                        line = line = line = line.TrimStart();
                        lname = line.Substring(0, 15);
                        lname = lname.Trim();
                        line.Remove(0, 15);

                        // status
                        line = line = line = line.TrimStart();
                        stat = line.Substring(0, 10);
                        stat = stat.Trim();
                        line.Remove(0, 10);

                        // add user info
                        if (stat == "admin")
                            AdminList.Add(new Admin(username, pswd, fname, mname, lname, stat));
                        else if (stat == "faculty")
                            FacultyList.Add(new Faculty(username, pswd, fname, mname, lname, stat));
                        else StudentList.Add(new Student(username, pswd, fname, mname, lname, stat));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid User Input File");
                Console.WriteLine(e.Message);
            }






            try
            {
                string line;
                string term;
                string coursename;
                string coursetitle;
                string instructor;
                double credit;
                int seats;
                int timeblocks;
                List<coursetime> times = new List<coursetime>();

                using (Stream input = Assembly.GetExecutingAssembly()
                           .GetManifestResourceStream("ClassInput.txt"))
                using (StreamReader sr = new StreamReader(input))
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();

                        term = line.Substring(0, 3);
                        term = term.Trim();
                        line.Remove(0, 3);

                        line = line = line.TrimStart();
                        coursename = line.Substring(0, 10);
                        coursename = coursename.Trim();
                        line.Remove(0, 10);

                        line = line = line.TrimStart();
                        coursetitle = line.Substring(0, 15);
                        coursetitle = coursetitle.Trim();
                        line.Remove(0, 15);

                        line = line = line.TrimStart();
                        instructor = line.Substring(0, 10);
                        instructor.Trim();
                        line.Remove(0, 10);

                        line = line = line.TrimStart();
                        credit = double.Parse(line.Substring(0, 4));
                        line.Remove(0, 4);

                        line = line = line.TrimStart();
                        seats = int.Parse(line.Substring(0, 3));
                        line.Remove(0, 3);

                        line = line = line.TrimStart();
                        timeblocks = int.Parse(line.Substring(0, 1));
                        line.Remove(0, 1);
                        line = line = line.TrimStart();

                        times = new List<coursetime>();
                        for (int i = 0; i < timeblocks; ++i)
                        {
                            string littlestring = line.Substring(0, 5);
                            times.Add(new coursetime(littlestring));

                            line.Remove(0, 5);
                            line = line = line.TrimStart();
                        }

                        if (term == nxtterm)
                            NextCourses.Add(new courseinfo(coursename, coursetitle, instructor, credit, seats, times));
                        else PrevCourses.Add(new courseinfo(coursename, coursetitle, instructor, credit, seats, times));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Class Input File");
                Console.WriteLine(e.Message);
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



            try
            {
                string line;
                string username;
                int numcourses;
                string coursename;
                string term;
                double credit;
                string grade;

                using (Stream input = Assembly.GetExecutingAssembly()
                           .GetManifestResourceStream("HistoryInput.txt"))
                using (StreamReader sr = new StreamReader(input))
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        username = line.Substring(0, 10);
                        line.Remove(0, 10);
                        line = line = line.TrimStart();
                        numcourses = int.Parse(line.Substring(0, 2));
                        line.Remove(0, 2);
                        line = line = line.TrimStart();

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
                            line = line = line.TrimStart();
                            term = line.Substring(0, 3);
                            line.Remove(0, 3);
                            line = line = line.TrimStart();
                            credit = double.Parse(line.Substring(0, 4));
                            line.Remove(0, 4);
                            line = line = line.TrimStart();
                            grade = line.Substring(0, 3);
                            line.Remove(0, 3);
                            line = line = line.TrimStart();


                            // fixed maybe?
                            if (grade.Contains("N"))
                            {
                                if (term == nxtterm)
                                    StudentList[undx].Current.Add(coursename);
                                // Users[undx].Add(new courserecord(coursename, term, credit, grade);
                                else StudentList[undx].Next.Add(coursename);
                            }
                            else StudentList[undx].History.Add(new courserecord(coursename, term, credit, grade));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid History Input File");
                Console.WriteLine(e.Message);
            }

            foreach (courseinfo course in NextCourses)
            {
                foreach (Student stud in StudentList)
                {
                    if (stud.Next.Contains(course.Coursename))
                        ++course.Enrolled;
                }
            }


            // read course prereq database

            try
            {
                string line;
                string coursename;
                int numprereq;
                string prereq;

                using (Stream input = Assembly.GetExecutingAssembly()
                           .GetManifestResourceStream("PrereqInput.txt"))
                using (StreamReader sr = new StreamReader(input))
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();

                        coursename = line.Substring(0, 7);
                        line.Remove(0, 7);
                        line = line = line.TrimStart();
                        numprereq = int.Parse(line.Substring(0, 2));
                        line.Remove(0, 2);
                        line = line = line.TrimStart();

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
                            line = line = line.TrimStart();

                            NextCourses[cndx].Prereqs.Add(prereq);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Prereq Input File");
                Console.WriteLine(e.Message);
            }

            //LAUNCH FORMS AND THINGS HERE
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(AdminList, FacultyList, StudentList, NextCourses, PrevCourses));

        }

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
