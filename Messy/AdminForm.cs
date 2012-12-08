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
        private UserStudent asthisstudent;
        List<UserFaculty> FacultyList = new List<UserFaculty>();
        List<UserStudent> StudentList = new List<UserStudent>();
        List<Course> Courses = new List<Course>();
        private adminstate state; 

        private enum adminstate 
        { 
            asadmin,
            asfaculty,
            asstudent 
        }

        public AdminForm(List<UserFaculty> fl, List<UserStudent> sl, List<Course> cl, UserAdmin adm)
        {
            state = adminstate.asadmin; 
            InitializeComponent();
            admin = adm;
            FacultyList = fl;
            StudentList = sl;
            Courses = cl;
            initdgv(); 
            
        }

        private AdminForm(List<UserFaculty> fl, List<UserStudent> sl, List<Course> cl, UserAdmin adm, UserStudent std)
        {

            state = adminstate.asstudent;
            asthisstudent = std;
            button1.Text = "Add " + std.UserName + " to Course."; 
            InitializeComponent();
            admin = adm;
            FacultyList = fl;
            StudentList = sl;
            Courses = cl;
            initdgv(); 
            
        
        }
        private void initdgv()
        {
            if (state == adminstate.asadmin)
                dataGridView1.DataSource = StudentList; 
            if (state == adminstate.asstudent)
                dataGridView1.DataSource = Courses;                 
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (state == adminstate.asadmin)
            //    //call private adminform with student username
            //    ;
            //if (state == adminstate.asstudent)
            //    benutil.AddStudenttoCourse(asthisstudent, ,admin); 


        }



    }
}
