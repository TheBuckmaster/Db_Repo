using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BensCRS
{
    public partial class LoginForm : Form
    {
        List<UserAdmin> Admins;
        List<UserFaculty> Faculty;
        List<UserStudent> Students;
        List<Course> Courses;
        List<PastCourse> Past;

        public LoginForm(List<UserAdmin> A, List<UserFaculty> F, List<UserStudent> S, List<Course> C, List<PastCourse> P)
        {
            Admins = A;
            Faculty = F;
            Students = S;
            Past = P;
            Courses = new List<Course>(C);
            InitializeComponent();
            textBox2.PasswordChar = '•';
        }



        private void button1_Click(object sender, EventArgs e)
        {
            foreach (UserAdmin a in Admins)
                if (textBox1.Text == a.UserName)
                { 
                    if (a.isPassword(textBox2.Text))
                    {

                        //launch admin form
                        //but for now:

                        Text = "Welcome " + a.UserName + ". " ; 

                        //end form.
                    } 

                    else 
                    {} //tell user login failed.
                }

            foreach (UserFaculty f in Faculty)
                if (textBox1.Text == f.UserName)
                {
                    if (f.isPassword(textBox2.Text))
                    {

                        //launch faculty form
                        Text = "Welcome " + f.UserName + ". ";

                        Form3 formm = new Form3(Students,f,Courses,0);
                        formm.Show();
                        //this.Close();
                        textBox1.Text = textBox2.Text = ""; 
 

                    }

                    else
                    { } //tell user login failed.
                }

            foreach (UserStudent s in Students)
                if (textBox1.Text == s.UserName)
                {
                    if (s.isPassword(textBox2.Text))
                    {

                        //launch student form
                        Text = "Welcome " + s.UserName + ". ";
                        Form2 SF = new Form2(Courses, s, 0, Past);
                        SF.Show();
                        textBox1.Text = textBox2.Text = ""; 
                        //this.Close(); 

                    }

                    else
                    { } //tell user login failed.
                }
             

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

    }
}
