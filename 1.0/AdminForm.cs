using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Registration
{
    public partial class AdminForm : Form
    {
        List<Admin> AdminList = new List<Admin>();
        List<Faculty> FacultyList = new List<Faculty>();
        List<Student> StudentList = new List<Student>();
        List<courseinfo> NextCourses = new List<courseinfo>();
        List<courseinfo> PrevCourses = new List<courseinfo>();

        public AdminForm(List<Admin> admins, List<Faculty> profs, List<Student> studs, List<courseinfo> next, List<courseinfo> prev)
        {
            InitializeComponent();
            AdminList = admins;
            FacultyList = profs;
            StudentList = studs;
            NextCourses = next;
            PrevCourse = prev;
        }

        private void EnrollStudent(Student S, courseinfo C)
        {
            bool enroll = true;
            List<string> messages = new List<string>();

            foreach (string course in S.Current)
            {
                if (course.Substring(0, course.Length - 3) == c.SecLessName)
                {
                    message.Add("Student Already Registered for this Course!");
                    enroll = false;
                    break;
                }
            }

            if (enroll)
            {
                if (c.Enrolled >= c.Seats)
                    message.Add("Class is Full!");

                if (S.EnrolledCredits <= 5.0 - c.Credit)
                    message.Add("Trying to Enroll for 5 Credits or More!");

                foreach (string req in c.Prereqs)
                {
                    bool taken = false;
                    foreach (courserecord pastcourse in S.History)
                    {
                        if (pastcourse.SecLessName == req)
                        {
                            taken = true;
                            break;
                        }
                    }
                    foreach (string curcourse in S.Current)
                    {
                        if (curcourse.Substring(0, curcourse.Length - 3) == req)
                        {
                            taken = true;
                            break;
                        }
                    }
                    if (!taken)
                    {
                        message.Add("Student Meet the Prerequisites!");
                        break;
                    }
                }

                bool retake = false;
                foreach (string course in S.Current)
                {
                    if (c.SecLessName == course.Substring(0, cuorse.Length - 3))
                    {
                        retake = true;
                        break;
                    }
                }
                foreach (courserecord course in S.Current)
                {
                    if (c.SecLessName == course.SecLessName)
                    {
                        retake = true;
                        break;
                    }
                }
                if (retake)
                    message.Add("Student Retaking this Class!");

                foreach (courseinfo course in coursesNextYear)    //Compare to each already added class
                {
                    bool iscnflct = false;
                    if (S.Next.Contains(course.CourseName))
                    {
                        foreach (coursetime time in c.Times)   //Each time the course is offered
                        {
                            foreach (coursetime time2 in course.Times)     //And each time of that class. 
                            {
                                if (((time.start <= time2.start) && (time2.start <= time.end)) || ((time2.start <= time.start) && (time.start <= time2.end)))
                                {   //Does this time overlap?
                                    foreach (char day in time.days)
                                    {   //Is it on the same day? 
                                        if (time2.days.Contains(day))
                                        {   //Throw warning message. 
                                            message.Add("Conflicts with Another Class!");
                                            iscnflct = true;
                                            break;
                                        }
                                    }
                                    if (iscnflct)
                                        break;
                                }
                            }
                            if (iscnflct)
                                break;
                        }
                        if (iscnflct)
                            break;
                    }
                }

                Add(S, C);
                message.Add("Successfully Enrolled in Class.");
            }
            else message.Add("Can't Enroll in Class.");

            string text = "";
            foreach (string str in message)
                text += str + '\n';
            MessageBox.Show(text);
        }

        private void Add(Student S, courseinfo C)
        {
            S.Next.Add(c.Coursename);
            S.EnrolledCredits += c.Credit;
            c.Students.Add(S.UserName);
            ++c.Enrolled;
        }

        private void RemoveStudentfromCourse(Student S, courseinfo C)
        {
            S.Next.Remove(c.Coursename);
            S.EnrolledCredits -= c.Credit;
            c.Students.Remove(S.UserName);
            --c.Enrolled;
            MessageBox.Show("Student is no longer registered for " + c.Coursename + ".");

        }

        private void ChangeInstructor(courseinfo course, Faculty prof)
        {
            foreach (Faculty oldProf in FacultyList)
                oldProf.Next.Remove(course.Coursename);

            course.Instructor = prof.UserName;
            prof.Next.Add(course.Coursename);
        }

        private void ChangeAdvisor(Student stud, Faculty prof)
        {
            foreach (Faculty oldProf in FacultyList)
                oldProf.Advisees.Remove(stud.UserName);

            stud.Status = prof.UserName;
            prof.Advisees.Add(stud.UserName);
        }

        private void RemoveCourse(courseinfo course)
        {
            foreach (Student stud in StudentList)
            {
                foreach (string course2 in stud.Next)
                {
                    if (course.Coursename == course2)
                        stud.Next.Remove(course2);
                }
            }

            foreach (Faculty prof in FacultyList)
            {
                foreach (string course2 in prof.Next)
                {
                    if (course.Coursename == course2)
                        prof.Next.Remove(course2);
                }
            }

            foreach (courseinfo course2 in NextCourses)
            {
                if (course.Coursename == course2.Coursename)
                    NextCourses.Remove(course2);
            }
        }

        private void RemoveStudent(Student stud)
        {
            foreach (Faculty prof in FacultyList)
            {
                foreach (string stud2 in prof.Advisees)
                {
                    if (stud.UserName == stud2)
                        prof.Advisees.Remove(stud2);
                }
            }

            foreach (courseinfo course in NextCourses)
            {
                if (stud.Next.Contains(course.Coursename))
                    --course.Enrolled;
            }

            foreach (Student stud2 in StudentList)
            {
                if (stud.UserName == stud2.UserName)
                    StudentList.Remove(stud2);
            }
        }

        private void RemoveFaculty(Faculty prof)
        {
            foreach (Student stud in StudentList)
            {
                if(prof.UserName == stud.Status)
                    stud.Status = "Staff";
            }

            foreach(courseinfo course in NextCourses)
            {
                if (prof.UserName == course.Instructor)
                    course.Instructor = "Staff";
            }

            foreach (Faculty prof2 in FacultyList)
            {
                if (prof.UserName == prof2.UserName)
                    FacultyList.Remove(prof2);
            }
        }


    }
}
