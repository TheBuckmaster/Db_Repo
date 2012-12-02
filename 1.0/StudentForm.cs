﻿using System;
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
        List<courseinfo> crsInfo = new List<courseinfo>();
        List<courserecord> crsRecord = new List<courserecord>();
        List<coursetime> crsTime = new List<coursetime>();

        public StudentForm( Student stud, List<courseinfo> cinfo,
            List<courserecord> crecord, List<coursetime> ctime)
        {
        }
        public StudentForm()
        {
            InitializeComponent();
            CreateListView();
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
        private void CreateListView()
        {
            listView1.Columns.Clear();
            listView1.Clear();

            listView1.Columns.Add("Course Title", 120);
            listView1.Columns.Add("Course Name", 150);
            listView1.Columns.Add("Professer", 120);
            listView1.Columns.Add("Days", 75);
            listView1.Columns.Add("Time", 120);

            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            foreach (courseinfo course in student)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = course.Coursetitle.ToString();
                lvi.SubItems.Add(course.Coursename.ToString());
                lvi.SubItems.Add(course.Instructor.ToString());
                lvi.SubItems.Add(course.Times.ToString());
            }
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addCourseBtn.Enabled = true;
            addCourseBtn.Visible = true;

            listView1.Columns.Clear();
            listView1.Clear();

            listView1.Columns.Add("Course Title", 120);
            listView1.Columns.Add("Course Name", 150);
            listView1.Columns.Add("Professer", 120);
            listView1.Columns.Add("Days", 75);
            listView1.Columns.Add("Time", 120);
            listView1.Columns.Add("Seats", 50);
            listView1.Columns.Add("Credit", 75);

            foreach (courseinfo course in student)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = course.Coursetitle.ToString();
                lvi.SubItems.Add(course.Coursename.ToString());
                lvi.SubItems.Add(course.Instructor.ToString());
                lvi.SubItems.Add(course.Times.ToString());
                //lvi.SubItems.Add(course.Times.showtime(course.Times.start) + "-" + course.Times.showtime(course.Times.end));
                lvi.SubItems.Add(course.Enrolled.ToString() + "/" + course.Seats.ToString());
                lvi.SubItems.Add(course.Credit.ToString());
            }
        }

    }
}