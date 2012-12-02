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
        List<courseinfo> Courses = new List<courseinfo>();
        List<courserecord> crsRecord = new List<courserecord>();
        List<coursetime> crsTime = new List<coursetime>();
        List<PastCourse> pastCourse = new List<PastCourse>();

        public LoginForm()
        {
            InitializeComponent();
        }

        public LoginForm( List<Admin> adm, List<Faculty> fac,
            List<Student> stud, List<courseinfo> crs, List<courserecord> crecord,
            List<coursetime> ctime, List<PastCourse> pcourse )
        {
            InitializeComponent();
            AdminList = adm;
            FacultyList = fac;
            StudentList = stud;
            Courses = crs;
            crsRecord = crecord;
            crsTime = ctime;
            pastCourse = pcourse;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            foreach(Admin adm in AdminList)
            {
                if (usrNmeTxtBx == Adm.UserName)
                {
                    if(passTxtBx == Adm.password)
                    {
                        Application.Run(new AdminForm());
                        AdminForm ad = new AdminForm();
                        ad.Show();
                        this.Hide();
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
                        Application.Run(new StudentForm(std, Courses,
                            crsRecord,crsTime ));
                        StudentForm stud = new StudentForm();
                        stud.Show();
                        this.Hide();
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
