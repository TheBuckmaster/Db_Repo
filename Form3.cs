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

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(List<courseinfo> cl)
        {
            InitializeComponent();
            CourseList = cl;
            dataGridView1.DataSource = CourseList;
        }


        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void viewScheduleToolStripMenuItem_Click(object sender, EventArgs e)//Student, tries to put the stuff in the data
            //view
        {
            dataGridView1.Visible = true;
            dataGridView1.Enabled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form();
            Form1.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
               int selectedCellCount =
        dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
         {
                
         }
            else
            MessageBox.Show("Select a course to add a course");
        }

        private void deleteCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourseBttn.Enabled = true;
            AddCourseBttn.Visible = true;
            dataGridView1.Enabled = true;
            dataGridView1.Visible = true;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
