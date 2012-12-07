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
    public partial class StudentForm : Form
    {
        Student student;
        List<courseinfo> coursesNextYear = new List<courseinfo>();
        List<courseinfo> prevCourses = new List<courseinfo>();

        public StudentForm( Student stud, List<courseinfo> nxt,
            List<courseinfo> his)
        {
            student = stud;
            coursesNextYear = nxt;
            prevCourses = his;
            CourseView();
        }
        public StudentForm()
        {
            InitializeComponent();
            CourseView();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm lgn = new LoginForm();
            lgn.Show();
            this.Close();
        }

        private void addCourseBtn_Click(object sender, EventArgs e)
        {
            AddStudenttoCourse(student, coursesNextYear[dataGridView1.SelectedRows[0].Index]);
            NextViewer();
        }

        private void CourseView()
        {
            dataGridView1.Hide();
            dataGridView1.DataSource = student.Current;
            dataGridView1.Refresh();
            dataGridView1.Show();
        }

        private void NextViewer()
        {
            dataGridView1.Hide();
            dataGridView1.DataSource = coursesNextYear;
            dataGridView1.Refresh();
            dataGridView1.Show();
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NextViewer();
        }

        public void AddStudenttoCourse(Student S, courseinfo C)
        {
            bool enroll = true;
            List<string> messages = new List<string>();

            foreach (string course in S.Current)
            {
                if (course.Substring(0, course.Length - 3) == C.SecLessName)
                {
                    messages.Add("You've Already Registered for this Course!");
                    enroll = false;
                    break;
                }
            }

            if (C.Enrolled >= C.Seats)
            {
                messages.Add("Class is Full!");
                enroll = false;
            }

            if (S.EnrolledCredits <= 5.0 - C.Credit)
            {
                messages.Add("Trying to Enroll for 5 Credits or More!");
                enroll = false;
            }

            foreach (string req in C.Prereqs)
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
                    messages.Add("You Don't Meet the Prerequisites!");
                    enroll = false;
                    break;
                }
            }

            bool retake = false;
            foreach (string course in S.Current)
            {
                if (C.SecLessName == course.Substring(0, course.Length - 3))
                {
                    retake = true;
                    break;
                }
            }

            foreach (courserecord course in S.Current)
            {
                if (C.SecLessName == course.SecLessName)
                {
                    retake = true;
                    break;
                }
            }
            if (retake)
                messages.Add("You're Retaking this Class!");

            foreach (courseinfo Course in coursesNextYear)    //Compare to each already added class
            {
                bool iscnflct = false;
                if (S.Next.Contains(Course.Coursename))
                {
                    foreach (coursetime time in C.Times)   //Each time the course is offered
                    {
                        foreach (coursetime time2 in Course.Times)     //And each time of that class. 
                        {
                            if (((time.start <= time2.start) && (time2.start <= time.end)) || ((time2.start <= time.start) && (time.start <= time2.end)))
                            {   //Does this time overlap?
                                foreach (char day in time.daylist)
                                {   //Is it on the same day? 
                                    if (time2.daylist.Contains(day))
                                    {   //Throw warning message. 
                                        messages.Add("Conflicts with Another Class!");
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

            if (enroll)
            {
                Add(S, C);
                messages.Add("Successfully Enrolled in Class.");
            }
            else messages.Add("Can't Enroll in Class.");

            string text = "";
            foreach (string str in messages)
                text += str + '\n';
            MessageBox.Show(text);
        }

        public void Add(Student S, courseinfo C)
        {
            S.Next.Add(C.Coursename);
            S.EnrolledCredits += C.Credit;
            C.Students.Add(S.UserName);
            ++C.Enrolled;
        }

        public void RemoveStudentfromCourse(Student S, courseinfo C)
        {
            S.Next.Remove(C.Coursename);
            S.EnrolledCredits -= C.Credit;
            C.Students.Remove(S.UserName);
            C.Enrolled--;
            MessageBox.Show("You are no longer registered for " + C.Coursename + ".");

        }

    }
}
