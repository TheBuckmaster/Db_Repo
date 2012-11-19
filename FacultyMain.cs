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
    public partial class FacultyMain : Form
    {
        public FacultyMain()
        {
            InitializeComponent();
        }

        List<courseinfo> CourseList = new List<courseinfo>();
        List<VUser> UserList = new List<VUser>();
        VUser faculty;

        public FacultyMain(ref List<courseinfo> crs, ref List<VUser> usrlst, ref VUser fac)
        {
            InitializeComponent();
            faculty = fac;
            UserList = usrlst;
            CourseList = crs;
            CurrentSchedule();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1(ref CourseList, ref UserList);
            frm1.Show();
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //listView1.FullRowSelect = true;

            //foreach (DataRow row in DataBindings.ToString())
            //{
            //    var item = new ListViewItem(row[0].ToString());
            //    item.Tag = row;


                //listView1.Items.Add(item);
            //}

        }

        private void ViewEnrolledStudents_Click(object sender, EventArgs e)
        {
            listView1.FullRowSelect = true;
            ViewStudentsInOneClass();
        }

        private void ViewStudentsInOneClass()
        {
            ListViewItem lvi = new ListViewItem();
            listView1.Focus();
            listView1.Items[0].Selected = true;
            string selCourse = listView1.Items[0].Text.ToString();
            listView1.Columns.Add("First Name");
            listView1.Columns.Add("Last Name");

            foreach (courseinfo crs in faculty.Next)
            {
                if (crs.Coursetitle == selCourse)
                {
                    foreach (VStudent stud in crs.Students)
                    {
                        lvi.Text = stud.FirstName.ToString();
                        lvi.SubItems.Add(stud.LastName.ToString());
                    }
                    break;
                }
            }
        }

        //if we need this, which we don't
        private void ViewAllStudents ()
        {
            ListViewItem lvi = new ListViewItem();

            listView1.Columns.Add("Course");
            listView1.Columns.Add("First Name");
            listView1.Columns.Add("Last Name");

            foreach (courseinfo crs in faculty.Next)
            {
                foreach(VStudent stud in crs.Students)
                {    
                    lvi.Text = crs.ToString();
                    lvi.SubItems.Add(stud.FirstName.ToString());
                    lvi.SubItems.Add(stud.LastName.ToString());
                }
            }
        }


        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentSchedule();
        }

        private void CurrentSchedule()
        {
            listView1.Columns.Add("Course Title" , 120);
            listView1.Columns.Add("Course Name" , 120);
            listView1.Columns.Add("Days", 120);
            listView1.Columns.Add("Time",120);
            listView1.Columns.Add("Enrolled", 25);

            foreach (courseinfo crs in faculty.Next)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = crs.Coursetitle.ToString();
                lvi.SubItems.Add(crs.Coursename.ToString());
                lvi.SubItems.Add(crs.Times.days.ToString());
                lvi.SubItems.Add(crs.Times.showtime(crs.Times.start) + "-" + crs.Times.showtime(crs.Times.end));
                lvi.SubItems.Add(crs.Enrolled().ToString());
            }
        }
    }   

}
