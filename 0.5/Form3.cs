﻿using System;
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
        List<VUser> UserList = new List<VUser>();
        VUser student;

        public Form3(ref List<courseinfo> course, ref List<VUser> usrlist, ref VUser stud)
        {
            InitializeComponent();
            this.Text = stud.FstName + " " + stud.LstName;
            student = stud;
            CourseList = course;
            UserList = usrlist;
            CreateListView();
        }


        private void CreateListView()
        {
            listView.Columns.Add("Course Title", 120);
            listView.Columns.Add("Course Name", 150);
            listView.Columns.Add("Professer", 120);
            listView.Columns.Add("Days", 75);
            listView.Columns.Add("Time", 120);

            listView.View = View.Details;
            listView.FullRowSelect = true;
          
            foreach (courseinfo course in student)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = course.Coursetitle.ToString();
                lvi.SubItems.Add(course.Coursename.ToString());
                lvi.SubItems.Add(course.Instructor.ToString());
                lvi.SubItems.Add(course.Times.days.ToString());
                lvi.SubItems.Add(course.Times.showtime(course.Times.start) + "-" + course.Times.showtime(course.Times.end));
               // lvi.SubItems.Add(Item.Times.showtime(Item.Times.start) + "-" + Item.Times.showtime(Item.Times.end));
            }
        }
        private void AddCourseBttn_Click(object sender, EventArgs e)
        {
            listView.Focus();
            listView.Items[0].Selected = true;
            //if (selectedCellCount > 0)
            //{
                
            //}
            //else
            //    MessageBox.Show("Select a course to add a course");
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
            listView.Columns.Add("Time", 120);
            
            foreach(var Item in CourseList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = Item.Coursetitle.ToString();
                lvi.SubItems.Add(Item.Coursename.ToString());
                lvi.SubItems.Add(Item.Instructor.ToString());
                lvi.SubItems.Add(Item.Seats.ToString());
                lvi.SubItems.Add(Item.Credit.ToString());
                lvi.SubItems.Add(Item.Times.days.ToString());
                lvi.SubItems.Add(Item.Times.showtime(Item.Times.start) + "-" + Item.Times.showtime(Item.Times.end));
                //lvi.SubItems.Add(CourseList[i].Days.tostring());
                //lvi.SubItems.Add(CourseList[i].Times.ToString());
            }
        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form1 Frm1 = new Form1(ref CourseList, ref UserList);
            Frm1.Show();
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
