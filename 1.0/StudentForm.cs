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
            
            if (S.Current.Contains(C.Coursename))
                MessageBox.Show("You've Already Registered for this Course!");

            if (C.Enrolled >= C.Seats)
                MessageBox.Show("Class is Full!");
            else
                Add(S, C);

        }

        public void Add(Student S, courseinfo C)
        {
            S.Next.Add(C.Coursename);
            S.EnrolledCredits += C.Credit;
            C.Enrolled++;
        }

        public void RemoveStudentfromCourse(Student S, courseinfo C)
        {
            C.Enrolled--;
            S.Current.Remove(C.Coursename);
            MessageBox.Show("You are no longer registered for " + C.Coursename + " .");

        }

    }
}
