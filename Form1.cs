using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public struct user
{
    public string name;
    public string password;
}

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        // should probably make 2d List for these, but that would really complicate authentication
        public List<string> CourseList = new List<string>();
        public List<string> UserList = new List<string>();
        public List<string> PasswordList = new List<string>();
        public List<string> FstNameList = new List<string>();
        public List<string> MidNameList = new List<string>();
        public List<string> LstNameList = new List<string>();
        public List<string> StatusList = new List<string>();
        const int total = 2000;

        //string[,] userPlusPass = new string userPlusPass[total,total]; //array for usernames and passwords
       
        public Form1()
        {
            InitializeComponent();
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
            int userndx = UserList.IndexOf(UsernameText.Text);

            if ((userndx != null) && (PasswordList.IndexOf(passwordText.Text) == userndx))
            {


                label1.Hide();
                label2.Hide();
                UsernameText.Hide();
                passwordText.Enabled = false;
                UsernameText.Enabled = false;
                passwordText.Hide();
                LoginButton.Hide();
                LoginButton.Enabled = false;
                ClassOfferings.Show();
                classOfferingsToolStripMenuItem.Enabled = true;
                classOfferingsToolStripMenuItem.ShowDropDown();
                if (StatusList[userndx] != "faculty")
                {
                    addClassesToolStripMenuItem.Enabled = true;
                    addClassesToolStripMenuItem.ShowDropDown();
                }
                if((StatusList[userndx] == "faculty") || (StatusList[userndx] == "admin"))
                {
                    scheduleToolStripMenuItem.Enabled = true;
                    scheduleToolStripMenuItem.ShowDropDown();
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

        private void BackToMainScreen_Click(object sender, EventArgs e)
        {
            CourseTextBox.Hide();
            CourseTextBox.Enabled = false;
            BackToMainScreen.Hide();
            BackToMainScreen.Enabled = false;
            ClassOfferings.Enabled = true;
            ClassOfferings.Show();
        }

        private void ClassOfferings_Click(object sender, EventArgs e)
        {
            CourseTextBox.Show();
            BackToMainScreen.Enabled = true;
            BackToMainScreen.Show();
            CourseTextBox.Enabled = true;
            ClassOfferings.Hide();
            ClassOfferings.Enabled = false;

            CourseTextBox.Text = "My milkshakes bring all the boys to the yard";
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //username = "";
            //password = "";
        }

        private void classOfferingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CourseTextBox.Show();
            BackToMainScreen.Enabled = true;
            BackToMainScreen.Show();
            CourseTextBox.Enabled = true;
            ClassOfferings.Hide();
            ClassOfferings.Enabled = false;

            CourseTextBox.Text = "My milkshakes bring all the boys to the yard";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //password = "";
            //username = "";
            Environment.Exit(0);
        }

        private void CourseTextBox_TextChanged(object sender, EventArgs e)
        {
        
        }
    }
}
