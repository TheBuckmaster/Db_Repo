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
            Form1 OurForm = new Form1();

            
            try
            {
                using (StreamReader sr = new StreamReader("UserInput.txt"))
                {
                    String line = sr.ReadLine();

                    while(line != null)
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
                        User guy = new User(uname, pswd, fname, mname, lname, stat);
                        OurForm.UserList.Add(guy);

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
                int howmanycourses = 0;
                string currstring;
                string coursename;
                string coursetitle;
                string instructor;
                float credit;
                int seats;
                int timeblocks;
                Stack<string> times;
                
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

                        times = new Stack<string>();
                        for (int counter = 0; counter < timeblocks; counter++)
                        {
                            string littlestring = currstring.Substring(0, 5);
                            times.Push(littlestring);
                            currstring.Remove(0, 5);
                            currstring.TrimStart();
                        }

                        OurForm.Courses[howmanycourses].coursename = coursename;
                        OurForm.Courses[howmanycourses].coursetitle = coursetitle;
                        OurForm.Courses[howmanycourses].instructor = instructor;
                        OurForm.Courses[howmanycourses].credit = credit;
                        OurForm.Courses[howmanycourses].seats  = seats;
                        OurForm.Courses[howmanycourses].timeblocks = timeblocks;
                        OurForm.Courses[howmanycourses].times = times;
                        howmanycourses +=1;
                        OurForm.numCourses = howmanycourses;
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
            
            OurForm.CourseList = new List<string>();
            OurForm.CourseList.Add("This is where a list would go");
            Application.Run(OurForm);
        }
    }
}


