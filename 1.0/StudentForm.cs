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
        List<courseinfo> courseHistory = new List<courseinfo>();
        List<coursetime> crsTime = new List<coursetime>();

        public StudentForm( Student stud, List<courseinfo> nxt,
            List<courseinfo> his)
        {
            student = stud;
            coursesNextYear = nxt;
            courseHistory = his;
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
            
        }
        private void CourseView()
        {
            dataGridView1.Hide();
            dataGridView1.DataSource = coursesNextYear;
            dataGridView1.Refresh();
            dataGridView1.Show();
            dataGridView1.Hide(); 
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView1.DataSource = courseHistory;
        }

    }
}
