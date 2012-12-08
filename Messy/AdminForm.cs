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

        private void ChangeInstructor(Course C, UserFaculty prof)
        {
            foreach (UserFaculty oldProf in FacultyList)
                oldProf.MyClasses.Remove(C.CourseName);

            C.Instructor = prof.UserName;
            prof.MyClasses.Add(C.CourseName);
        }

        private void ChangeAdvisor(UserStudent stud, UserFaculty prof)
        {
            stud.Advisor = prof.UserName;
        }

        private void RemoveFaculty(UserFaculty prof)
        {
            foreach (UserStudent stud in StudentList)
                if (prof.UserName == stud.Advisor)
                    stud.Advisor = "Staff";

            foreach (Course C in Courses)
                if (prof.UserName == C.Instructor)
                    C.Instructor = "Staff";

            FacultyList.Remove(prof);
        }

        private void RemoveCourse(Course C)
        {
            foreach (UserStudent stud in StudentList)
                foreach (string C2 in stud.MyCourses)
                    if (C.CourseName == C2)
                        stud.MyCourses.Remove(C2);

            foreach (UserFaculty prof in FacultyList)
                foreach (string C2 in prof.MyClasses)
                    if (C.CourseName == C2)
                        prof.MyClasses.Remove(C2);

            Courses.Remove(C);
        }

        private void RemoveStudent(UserStudent stud)
        {
            foreach (Course C in Courses)
                C.RemoveStudent(stud);

            StudentList.Remove(stud);
        }

    }
}
