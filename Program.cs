﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
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

            // our "databases
            List<VUser> Users = new List<VUser>();
            List<courseinfo> Courses = new List<courseinfo>();
            string curterm = "F12";


            // read in UserDatabase
            try
            {
                using (StreamReader sr = new StreamReader("UserInput.txt"))
                {
                    String line = sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        string uname, fname, mname, lname, pswd, stat;

                        // username
                        line.TrimStart();
                        uname = line.Substring(0, 10);
                        uname.TrimEnd();
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
                        Users.Add(new VUser(uname, pswd, fname, mname, lname, stat));

                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }


            string filename = "ClassInput.txt";
            if (File.Exists(filename))
            {
                string currstring;
                string coursename;
                string coursetitle;
                string instructor;
                float credit;
                int seats;
                int timeblocks;
                List<coursetime> times = new List<coursetime>();

                FileStream input = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader filereader = new StreamReader(input);
                try
                {

                    while (!filereader.EndOfStream)
                    {

                        currstring = filereader.ReadLine();
                        coursename = currstring.Substring(0, 10);
                        currstring.Remove(0, 10);
                        currstring.TrimStart();
                        coursetitle = currstring.Substring(0, 15);
                        currstring.Remove(0, 15);
                        currstring.TrimStart();
                        instructor = currstring.Substring(0, 10);
                        currstring.Remove(0, 10);
                        currstring.TrimStart();
                        credit = float.Parse(currstring.Substring(0, 4));
                        currstring.Remove(0, 4);
                        currstring.TrimStart();
                        seats = int.Parse(currstring.Substring(0, 3));
                        currstring.Remove(0, 3);
                        currstring.TrimStart();
                        timeblocks = int.Parse(currstring.Substring(0, 1));
                        currstring.Remove(0, 1);
                        currstring.TrimStart();

                        times = new List<coursetime>();
                        for (int counter = 0; counter < timeblocks; counter++)
                        {
                            string littlestring = currstring.Substring(0, 5);
                            times.Add(new coursetime(littlestring));

                            currstring.Remove(0, 5);
                            currstring.TrimStart();
                        }
                        Courses.Add(new courseinfo(coursename, coursetitle, instructor, credit, seats, times));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input File");
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Your File does not Exist.");
            }

            //add advisees/schedule to faculty
            foreach (VFaculty prof in Users)
            {
                foreach (VStudent stud in Users)
                {
                    if (prof.Username == stud.Status)
                        prof.Advisees.Add(stud);
                }
                foreach (courseinfo course in Courses)
                {
                    if (prof.Username == course.Instructor)
                        prof.Next.Add(course);
                }
            }



            filename = "HistoryInput.txt";
            if (File.Exists(filename))
            {
                string currstring;
                string username;
                int numcourses;
                int undx;
                string coursename;
                string term;
                float credit;
                string grade;

                FileStream input = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader filereader = new StreamReader(input);
                try
                {

                    while (!filereader.EndOfStream)
                    {
                        currstring = filereader.ReadLine();
                        username = currstring.Substring(0, 10);
                        currstring.Remove(0, 10);
                        currstring.TrimStart();
                        numcourses = int.Parse(currstring.Substring(0, 2));
                        currstring.Remove(0, 2);
                        currstring.TrimStart();

                        undx = Users.IndexOf(new VUser(username));
                        for(int i = 0; i < numcourses; ++i)
                        {
                            coursename = currstring.Substring(0, 10);
                            currstring.Remove(0, 10);
                            currstring.TrimStart();
                            term = currstring.Substring(0, 3);
                            currstring.Remove(0, 3);
                            currstring.TrimStart();
                            credit = float.Parse(currstring.Substring(0, 4));
                            currstring.Remove(0, 4);
                            currstring.TrimStart();
                            grade = currstring.Substring(0, 3);
                            currstring.Remove(0, 3);
                            currstring.TrimStart();


                            // fixed maybe?
                            if(grade == "N")
                            {
                                if(term == curterm)
                                    Users[undx].Current.Add(new pastcourse(coursename, term, credit, grade));
                                else
                                {
                                    int cndx = Courses.IndexOf(new pastcourse(coursename, term, credit, grade));
                                    Users[undx].enrollCourse(ref Courses[cndx], ref Users[undx]);
                                }
                            }
                            else Users[undx].History.Add(new pastcourse(coursename, term, credit, grade));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input File");
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Your File does not Exist.");
            }


            //The following is democode.
 
            //coursename = "CS-125-00";
            //coursetitle = "Computer Science 1";
            //instructor = "THostetler";
            //credit = 1.00f;
            //seats = 20;
            //timeblocks = 1;
            //coursetime newtime = new coursetime("21102");
            //times.Add(newtime);

            //courseinfo CSI = new courseinfo(coursename, coursetitle, instructor, credit, seats, times);
            //courseinfo CSII = new courseinfo("CS-225-00", "Computer Science 2", "DCurtis", 1.00f, 15, times);
            //OurForm.Courses.Add(CSI);
            //OurForm.Courses.Add(CSII);

            //newtime = new coursetime("05103");
            //times.Clear();
            //times = new List<coursetime>();
            //times.Add(newtime);

            //courseinfo CALCI = new courseinfo("MTH-125-00", "Calculus I", "JWhite", 1.00f, 20, times);
            //OurForm.Courses.Add(CALCI);
                        
            //Form1 OurForm = new Form1();
            //Modify Form constructors to accept ref to lists?
            Form1 OurForm = new Form1(ref Courses, ref Users);
            //Form3 frm3 = new Form3("ben", Courses);
            //FacultyMain FctMn = new FacultyMain();


            Application.Run(OurForm);
            //Application.Run(frm3);
            //Application.Run(FctMn);
        }
    }
}


