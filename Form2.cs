using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        List<courseinfo> CourseList = new List<courseinfo>();

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(List<courseinfo> cl)
        {
            CourseList = cl; 
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void viewScheduleToolStripMenuItem_Click(object sender, EventArgs e)//Student, tries to put the stuff in the data
            //view
        {
            int x;

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                DataGridViewCell cell = row.Cells[x];  
                if (cell.Value == null || cell.Value.Equals(""))
                {
                    continue;
                }
            }

             // my attempt to make it workish
            for (x = 0; x < CourseList.Count; x++)
            {
                DataGridViewCell cell = row.Cells[x]; // what does this mean? 

                int i = 1; //starts at course Title then moves on
                cell.Value = CourseList[x].Coursetitle;
                i++;
                cell[i].Value = CourseList[x].Coursename;
                i++;
                cell[i].Value = CourseList[x].Instructor;
                i++;
                cell[i].Value = CourseList[x].Credit;
                i++;
                cell[i].Value = CourseList[x].Seats;
                i++;
                cell[i].Value = CourseList[x].Times;
                i++;
                //  cell[i].Value = CourseList[x].Timeblks;     I think this is no longer necessary. 
            }
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

        }

        private void deleteCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourseBttn.Enabled = true;
            AddCourseBttn.Show();
        }

    }
}
