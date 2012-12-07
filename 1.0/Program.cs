using System;
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

            string line = "Yes";
            string nxtterm = "S13";

            while (line != null)
            {
            try
            {
                string username;
                string firstname;
                string lastname;
                string middlename;
                string status;
                string password;


                StreamReader freader = new StreamReader("UserInput.txt");

                line = freader.ReadLine();
                if (line != null)
                {
                    username = line.Substring(0, 10).Trim();
                    password = line.Substring(10, 10).Trim();
                    firstname = line.Substring(20, 15).Trim();
                    middlename = line.Substring(35, 15).Trim();
                    lastname = line.Substring(50, 15).Trim();
                    status = line.Substring(65).Trim();
                    if (status == "Admin")
                    {
                        Admin A = new Admin(username, password,
                            firstname, middlename, lastname, status);
                        AdminList.Add(A);
                    }
                    else if (status == "Faculty")
                    {
                        Faculty F = new Faculty(username, password,
                            firstname, middlename, lastname, status);
                        FacultyList.Add(F);
                    }
                    else
                    {
                        Student S = new Student(username, password, firstname,
                            middlename, lastname, status);
                        StudentList.Add(S);
                    }
                }
                else
                {
                    freader.Close();
                    //button1.Visible = false;
                    //MessageBox.Show("File is now complete."); 
                }

            }

            catch (EndOfStreamException)
            { }  
        
        
        
        }


            line = "Yes";
                    while (line != null)
                    {

                        try
                        {
                            string coursename;
                            string coursetitle;
                            string instructor;
                            double credit;
                            int seats;
                            int timeblocks;
                            List<coursetime> times = new List<coursetime>();

                            StreamReader sr = new StreamReader("ClassInput.txt");
                            {
                                while (line != null)
                                {
                                    coursename = line.Substring(0, 11).Trim();
                                    coursetitle = line.Substring(11, 16).Trim();
                                    instructor = line.Substring(27, 11).Trim();
                                    credit = double.Parse(line.Substring(38, 5).Trim());
                                    seats = int.Parse(line.Substring(43, 4).Trim());
                                    timeblocks = int.Parse(line.Substring(47, 2).Trim());
                                    string timeline = line.Substring(49).Trim();
                                    int numTimes = timeblocks;

                                    for (int i = 0; i < numTimes; i++)
                                    {
                                        int begin = (0 + (i * 5));
                                        coursetime c = new coursetime(timeline.Substring(begin, 5));
                                        times.Add(c);
                                    }

                                    courseinfo myCourse = new courseinfo(coursename, coursetitle, instructor,
                                        credit, seats, times);
                                    NextCourses.Add(myCourse);

                                    //MessageBox.Show("There are " + Courses.Count + " Courses.");



                                    line = sr.ReadLine();
                                }
                                sr.Close();
                                //MessageBox.Show("File is now complete.");

                            }
                        }
                        catch
                        {
                            MessageBox.Show("There was an Error");
                        }
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

                    line = "Yes";

                    try
                    {
                        string username;
                        int numcourses;
                        string coursename;
                        string term;
                        double credit;
                        string grade;

                        StreamReader sr = new StreamReader("HistoryInput.txt");
                            while (!sr.EndOfStream)
                            {
                                line = sr.ReadLine();
                                username = line.Substring(0, 10);
                                line.Remove(0, 10);
                                line = line.TrimStart();
                                numcourses = int.Parse(line.Substring(0, 2));
                                line.Remove(0, 2);
                                line = line.TrimStart();

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
                                    line = line.TrimStart();
                                    term = line.Substring(0, 3);
                                    line.Remove(0, 3);
                                    line = line.TrimStart();
                                    credit = double.Parse(line.Substring(0, 4));
                                    line.Remove(0, 4);
                                    line = line.TrimStart();
                                    grade = line.Substring(0, 3);
                                    line.Remove(0, 3);
                                    line = line.TrimStart();


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
                            {
                                stud.EnrolledCredits += course.Credit;
                                course.Students.Add(stud.UserName);
                                ++course.Enrolled;
                            }
                        }
                    }


                    // read course prereq database
                    line = "Yes";
                    try
                    {
                        string coursename;
                        int numprereq;
                        string prereq;

                        StreamReader sr = new StreamReader("PrereqInput.txt");
                            while (!sr.EndOfStream)
                            {
                                line = sr.ReadLine();

                                coursename = line.Substring(0, 7);
                                line.Remove(0, 7);
                                line = line.TrimStart();
                                numprereq = int.Parse(line.Substring(0, 2));
                                line.Remove(0, 2);
                                line = line.TrimStart();

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
                                    line = line.TrimStart();

                                    NextCourses[cndx].Prereqs.Add(prereq);
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

