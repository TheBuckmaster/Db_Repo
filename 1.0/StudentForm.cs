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

            foreach (string course in S.Current)
            {
                if (course.Substring(0, course.Length - 3) == C.SecLessName)
                {
                    MessageBox.Show("You've Already Registered for this Course!");
                    enroll = false;
                    break;
                }
            }

            if (C.Enrolled >= C.Seats)
            {
                MessageBox.Show("Class is Full!");
                enroll = false;
            }

            if (S.EnrolledCredits <= 5.0 - C.Credit)
            {
                MessageBox.Show("Can't enroll for 5 credits or more");
                enroll = false;
            }

            if(enroll)
                Add(S, C);

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
            C.Enrolled--;
            S.Current.Remove(C.Coursename);
            MessageBox.Show("You are no longer registered for " + C.Coursename + " .");

        }

    }
}
