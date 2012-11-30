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

        public LoginForm()
        {
            InitializeComponent();
        }

        public LoginForm(ref List<Admin> adm, ref List<Faculty> fac, ref List<Student> stud, ref List<courseinfo> crs)
        {
            InitializeComponent();
            AdminList = adm;
            FacultyList = fac;
            StudentList = stud;
            Courses = crs;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                Application.Run(new AdminForm());
                AdminForm adm = new AdminForm();
                adm.Show();
                this.Hide();
            }
            else if (faculty)
            {
                Application.Run(new FacultyForm());
                FacultyForm fac = new FacultyForm();
                fac.Show();
                this.Hide();
            }
            else
            {
                Application.Run(new StudentForm());
                StudentForm stud = new StudentForm();
                stud.Show();
                this.Hide();
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
