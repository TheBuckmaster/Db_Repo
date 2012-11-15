using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        List<courseinfo> CourseList = new List<courseinfo>();

        public Form3(string userName, List<courseinfo> course)
        {
            InitializeComponent();
            this.Text = userName;
            CourseList = course;
            CreateListView();
        }


        private void CreateListView()
        {
            listView.Columns.Add("Course Title", 120);
            listView.Columns.Add("Course Name", 150);
            listView.Columns.Add("Professer", 120);
            listView.Columns.Add("Days", 75);
            listView.Columns.Add("TIme", 120);

            listView.View = View.Details;
            listView.FullRowSelect = true;
            
            int i = 0;
            foreach (item in CourseList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = CourseList[i].Coursetitle.ToString();
                lvi.SubItems.Add(CourseList[i].Coursename.ToString());
                lvi.SubItems.Add(CourseList[i].Instructor.ToString());
                lvi.SubItems.Add(CourseList[i].Days.tostring());
                lvi.SubItems.Add(CourseList[i].Times.ToString();

                i++;
            }
        }
        private void AddCourseBttn_Click(object sender, EventArgs e)
        {
            int selectedCellCount =
                dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                
            }
            else
                MessageBox.Show("Select a course to add a course");
        }

        private void addCourseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddCourseBttn.Enabled = true;
            AddCourseBttn.Visible = true;
            dataGridView1.Enabled = true;
            dataGridView1.Visible = true;

            listView.Clear();

            listView.Columns.Add("Course Title", 120);
            listView.Columns.Add("Course Name", 150);
            listView.Columns.Add("Professer", 120);
            listView.Columns.Add("Seats", 75);
            listView.Columns.Add("Credit", 75);
            listView.Columns.Add("Days", 75);
            listView.Columns.Add("TIme", 120);
            int i = 0;

            foreach( Item in CourseList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = CourseList[i].Coursetitle.ToString();
                lvi.SubItems.Add(CourseList[i].Coursename.ToString());
                lvi.SubItems.Add(CourseList[i].Instructor.ToString());
                lvi.SubItems.Add(CourseList[i].Days.tostring());
                lvi.SubItems.Add(CourseList[i].Times.ToString();

                i++;
            }
        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form Form1 = new Form();
            Form1.Show();
            this.Close();
        }

        private void viewScheduleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView1.Enabled = true;

            //View Student's schedule
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
