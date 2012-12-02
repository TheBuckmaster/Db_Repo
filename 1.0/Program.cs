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

            // our "databases
            List<Admin> AdminList = new List<Admin>();
            List<Faculty> FacultyList = new List<Faculty>();
            List<Student> StudentList = new List<Student>();
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
                        if (stat == "admin")
                            AdminList.Add(new Admin(uname, pswd, fname, mname, lname, stat));
                        else if (stat == "faculty")
                            FacultyList.Add(new Faculty(uname, pswd, fname, mname, lname, stat));
                        else StudentList.Add(new Student(uname, pswd, fname, mname, lname, stat));

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
                        credit = double.Parse(currstring.Substring(0, 4));
                        currstring.Remove(0, 4);
                        currstring.TrimStart();
                        seats = int.Parse(currstring.Substring(0, 3));
                        currstring.Remove(0, 3);
                        currstring.TrimStart();
                        timeblocks = int.Parse(currstring.Substring(0, 1));
                        currstring.Remove(0, 1);
                        currstring.TrimStart();

                        times = new List<coursetime>();
                        for (int i = 0; i < timeblocks; ++i)
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
            foreach (Faculty prof in FacultyList)
            {
                foreach (Student stud in StudentList)
                {

                    //Application.Run(frm3);
                    //Application.Run(FctMn);
                }
            }
        }
    }
}



