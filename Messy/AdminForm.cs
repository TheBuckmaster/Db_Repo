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
    public partial class AdminForm : Form
    {
        UserAdmin admin;
        List<UserFaculty> FacultyList = new List<UserFaculty>();
        List<UserStudent> StudentList = new List<UserStudent>();
        List<Course> Courses = new List<Course>();

        public AdminForm(List<UserFaculty> fl, List<UserStudent> sl, List<Course> cl, UserAdmin adm)
        {
            InitializeComponent();
            admin = adm;
            FacultyList = fl;
            StudentList = sl;
            Courses = cl;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
