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
    public partial class FacultyForm : Form
    {
        Faculty faculty;
        List<Student> StudentList = new List<Student>();
        List<courseinfo> NextCourses = new List<courseinfo>();
        List<courseinfo> PrevCourses = new List<courseinfo>();

        public FacultyForm(Faculty fac, List<Student> studs, List<courseinfo> next, List<courseinfo> prev)
        {
            InitializeComponent();
            faculty = fac;
            StudentList = studs;
            NextCourses = next;
            PrevCourses = prev;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm lgn = new LoginForm();
            lgn.Show();
            this.Close();
        }

        private void teachingScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<courseinfo> schedule = new List<courseinfo>();

            foreach (courseinfo course in NextCourses)
            {
                if(course.Instructor == faculty.UserName)
                    schedule.Add(course);
            }
            dataGridView1.Hide();
            dataGridView1.DataSource = schedule;
            dataGridView1.Refresh();
            dataGridView1.Show();
        }

        private void viewAdvisees()
        {
            List<Student> advis = new List<Student>();

            foreach (Student stud in StudentList)
            {
                if (stud.Status == faculty.UserName)
                    advis.Add(stud);
            }

            dataGridView1.Hide();
            dataGridView1.DataSource = advis;
            dataGridView1.Refresh();
            dataGridView1.Show();
        }
    }
}
