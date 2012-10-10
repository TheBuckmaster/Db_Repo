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
        public List<string> CourseList = new List<string>();
        private List<User> UserList = new List<User>();
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

            // read in UserDatabase
            try
            {
                using (StreamReader sr = new StreamReader("UserInput.txt"))
                {
                    String line = sr.ReadLine();

                    while (line != null)
                    {
                        string uname, fname, mname, lname, pswd, stat;

                        // username
                        line.TrimStart();
                        uname = line.Substring(0, 10);
                        uname.TrimEnd();
                        line.Remove(0, 10);

                        // password
                        line.TrimStart();
                        pswd = line.Substring(0, 10);
                        pswd.TrimEnd();
                        line.Remove(0, 10);

                        // first name
                        line.TrimStart();
                        fname = line.Substring(0, 15);
                        fname.TrimEnd();
                        line.Remove(0, 15);

                        // middle name
                        line.TrimStart();
                        mname = line.Substring(0, 15);
                        mname.TrimEnd();
                        line.Remove(0, 15);

                        // last name
                        line.TrimStart();
                        lname = line.Substring(0, 15);
                        lname.TrimEnd();
                        line.Remove(0, 15);

                        // status
                        line.TrimStart();
                        stat = line.Substring(0, 10);
                        stat.TrimEnd();
                        line.Remove(0, 10);

                        // add user info
                        User guy = new User(uname, pswd, fname, mname, lname, stat);
                        OurForm.UserList.Add(guy);

                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }

        private string CourseShow()
        {
            //Chris, this is where your graphic design skills go wild. 
            //
            //
            //
            //
            return "In which one may be instructed on the proper method to Douglas";              
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
            User login = new User(UsernameText.Text, passwordText.Text, "", "", "", "");

            
            bool valid = false;
            int userNdx = -1;
            int length = UserList.Count;
            for(int i = 0; i < length; ++i)
            {
                if(login == UserList[i])
                {
                    valid = true;
                    userNdx = i;
                    i = length;
                }
            }

            if (valid && (UserList[userNdx].isPassword(passwordText.Text)))
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
