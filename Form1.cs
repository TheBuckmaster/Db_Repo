﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public List<courseinfo> Courses = new List<courseinfo>();
        private List<VUser> UserList = new List<VUser>();
        const int total = 2000;
        public int numCourses = 0;

        //public courseinfo[] Courses = new courseinfo[50];

        //string[,] userPlusPass = new string userPlusPass[total,total]; //array for usernames and passwords
       
        
        public Form1(string message)
        {
            InitializeComponent();
            User Friend = new User("Ben", "Buck", "Benjamin", "P", "Buckmaster", "student");
            UserList.Add(Friend);

        }            
        public Form1()
        {
            InitializeComponent();
        }

        private string CourseShow()
        {
            StringBuilder returnstring = new StringBuilder();

            foreach (courseinfo course in Courses)
            {
                returnstring.Append(course.Coursename);
                returnstring.Append(" ");
                for(int i = 0; i < course.Times.First().days.Count; i++)
                    returnstring.Append(course.Times.First().days[i]);
                returnstring.Append(course.Times.First().start);
                
                if (course.Times.Count > 1)
                {

                    for (int newCount=1; newCount < course.Times.Count; newCount++)
                    {
                        returnstring.Append(", ");
                        for ( int i = 0; i < course.Times.ElementAt(newCount).days.Count; i++)
                            returnstring.Append(course.Times.ElementAt(newCount).days[i]);
                        returnstring.Append(course.Times.ElementAt(newCount).start);
                    }

                }
                             

            }

            return returnstring.ToString();              
            
        }


        private void textBox1_TextChanged(object sender, EventArgs e) // Username textbox
        {
            this.Text = UsernameText.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e) // password textbox
        {
            passwordText.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool valid = false;
            int userNdx = -1;
            int length = UserList.Count;
            for(int i = 0; i < length; ++i)
            {
                if (UsernameText.Text == UserList[i].UserName)
                {
                    valid = true;
                    userNdx = i;
                    i = length;
                }
            }

            if (valid && (UserList[userNdx].isPassword(passwordText.Text)))
            {

                if (UserList[userNdx].Status == "faculty")
                {
                    FacultyMain fctmain = new FacultyMain(UserList);
                    fctmain.Show();
                    this.Hide();
                }

                else if (UserList[userNdx].Status == "admin")
                {

                }
                else
                {
                    Form3 frm3 = new Form3( UsernameText.Text, Courses);
                    frm3.Show();
                    this.Hide();
                }
            }
            else
            {
                UsernameText.Text = "";
                UsernameText.Focus();
                passwordText.Text = "";
                IncorrectLabel.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //password = "";
            //username = "";
            Environment.Exit(0);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
