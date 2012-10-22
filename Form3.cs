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

        public Form3(List<courseinfo> cl, string userName)
        {
            InitializeComponent();
            CourseList = cl;
            this.Text = userName;
            dataGridView1.DataSource = CourseList;
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

    }
}
