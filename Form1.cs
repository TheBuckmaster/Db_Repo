using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//public class User
//{
//    private string userName;
//    private string fstName;
//    private string midName;
//    private string lstName;
//    private string password;
//    private string status;

//    public bool validLogin(string name, string word)
//    {
//        return ((name == userName) && (word == password));
//    }
//}

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        // should probably make 2d List for these, but that would really complicate authentication
        public List<string> CourseList = new List<string>();
        public List<User> UserList = new List<string>();
        //public List<string> PasswordList = new List<string>();
        //public List<string> FstNameList = new List<string>();
        //public List<string> MidNameList = new List<string>();
        //public List<string> LstNameList = new List<string>();
        //public List<string> StatusList = new List<string>();
        const int total = 2000;
        public int numCourses = 0;

        public struct courseinfo
        {
            public string coursename;
            public string coursetitle;
            public string instructor;
            public float credit; 
            public int seats;
            public int timeblocks;  // how many timeblocks? 
            public Stack<string> times; // as initialized, these are ddttks in reverse order of entry. 
        }

        public courseinfo[] Courses = new courseinfo[50];

        //string[,] userPlusPass = new string userPlusPass[total,total]; //array for usernames and passwords
       
        public Form1()
        {
            InitializeComponent();
        }

        private string CourseShow()
        {
            //Chris, this is where your graphic design skills go wild. 
            //
            //
            //
            //
            return "Thine Milkshake doth bringeth all thine fellowman to thine schoolyard enclosure!";              
            //
            //
            //How much can you do with one string? 
  
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
            User login;
            login(UsernameText.Text, passwordText.Text, "","","","")

            
            bool valid = false;
            int userNdx;
            int legnth = UserList.Count;
            for(int i = 0; i < length; ++i)
            {
                if(login == UserList[i])
                {
                    valid = true;
                    userNdx = i;
                    i = length;
                }
            }

            if (valid)
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
                if (UserList[userNdx].Status != "faculty")
                {
                    addClassesToolStripMenuItem.Enabled = true;
                    addClassesToolStripMenuItem.ShowDropDown();
                }
                if((UserList[userNdx].Status == "faculty") || (UserList[userNdx].Status == "admin"))
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

            CourseTextBox.Text = CourseShow(); 
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

            CourseTextBox.Text = CourseShow();
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
