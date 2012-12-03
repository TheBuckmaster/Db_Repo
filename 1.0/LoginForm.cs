using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Registration
{
    public partial class LoginForm : Form
    {
        List<Admin> AdminList = new List<Admin>();
        List<Faculty> FacultyList = new List<Faculty>();
        List<Student> StudentList = new List<Student>();
        List<courseinfo> PrevCourses = new List<courseinfo>();
        List<courseinfo> NextCourses = new List<courseinfo>();

        public LoginForm()
        {
            InitializeComponent();
        }
        
        public LoginForm(List<Admin> adm,List<Faculty> fac, List<Student> stud,
            List<courseinfo> nxt, List<courseinfo> PrevC)
        {
            InitializeComponent();
            AdminList = adm;
            FacultyList = fac;
            StudentList = stud;
            NextCourses = nxt;
            PrevCourses = PrevC;
            passTxtBx.PasswordChar = '•';
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            foreach(Admin adm in AdminList)
            {
                if (usrNmeTxtBx.Text == adm.UserName)
                {
                    if(passTxtBx.Text == adm.Password)
                    {
                        Application.Run(new AdminForm());
                        AdminForm ad = new AdminForm();
                        ad.Show();
                        this.Hide();
                        break;
                    }
                    else
                        incorrectLabel.Visible = true;
                }
            }
            foreach(Faculty fac in FacultyList)
            {
                if(fac.UserName == usrNmeTxtBx.Text)
                {
                    if(fac.Password == passTxtBx.Text)
                    {
                        Application.Run(new FacultyForm());
                        FacultyForm fc = new FacultyForm();
                        fc.Show();
                        this.Hide();
                        break;
                    }
                    else
                        incorrectLabel.Visible = true;
                }
            }
                    
            foreach(Student std in StudentList)
            {
                if (std.UserName == usrNmeTxtBx.Text)
                {
                    if (std.Password == passTxtBx.Text)
                    {
                        Application.Run(new StudentForm(std, NextCourses, PrevCourses));
                        this.Hide();
                        break;
                    }
                    else
                        incorrectLabel.Visible = true;
                }
            }
            incorrectLabel.Visible = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
