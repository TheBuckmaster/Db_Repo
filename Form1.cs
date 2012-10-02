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
    public partial class Form1 : Form
    {
        public List<string> CourseList;
        const int total = 2000;
        bool usernameCheck;
        bool passwordCheck;
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
            usernameCheck = true;
            passwordCheck = true;

            if (usernameCheck && passwordCheck)
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
                addClassesToolStripMenuItem.Enabled = true;
                addClassesToolStripMenuItem.ShowDropDown();
                classOfferingsToolStripMenuItem.Enabled = true;
                classOfferingsToolStripMenuItem.ShowDropDown();
                scheduleToolStripMenuItem.Enabled = true;
                scheduleToolStripMenuItem.ShowDropDown();

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
