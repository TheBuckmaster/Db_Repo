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
    public partial class AdminForm : Form
    {
        List<Admin> AdminList = new List<Admin>();
        List<Faculty> FacultyList = new List<Faculty>();
        List<Student> StudentList = new List<Student>();
        List<courseinfo> NextCourses = new List<courseinfo>();
        List<courseinfo> PrevCourses = new List<courseinfo>();

        public AdminForm()
        {
            InitializeComponent();
        }

        private void RemoveCourse(courseinfo course)
        {
            foreach (Faculty prof in FacultyList)
            {
                foreach (string course2 in prof.Next)
                {
                    if (course.Coursename == course2)
                        prof.Next.Remove(course2);
                }
            }

            foreach (Student stud in StudentList)
            {
                foreach (string course2 in stud.Next)
                {
                    if (course.Coursename == course2)
                        stud.Next.Remove(course2);
                }
            }

            foreach (courseinfo course2 in NextCourses)
            {
                if (course.Coursename == course2.Coursename)
                    NextCourses.Remove(course2);
            }
        }

        private void RemoveStudent(Student stud)
        {
            foreach (Student stud2 in StudentList)
            {
                if (stud.UserName == stud2.UserName)
                    StudentList.Remove(stud2);
            }

            foreach(Faculty prof in FacultyList)
            {
                foreach (string stud2 in prof.Advisees)
                {
                    if (stud.UserName == stud2)
                        prof.Advisees.REmove(stud2);
                }
            }
        }


    }
}
