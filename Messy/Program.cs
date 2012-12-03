using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BensCRS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //UserAdmin u1 = new UserAdmin();
            //UserFaculty u2 = new UserFaculty();
            //UserStudent u3 = new UserStudent();

            List<UserAdmin> ads = new List<UserAdmin>();
            //ads.Add(u1);
            List<UserFaculty> fcs = new List<UserFaculty>();
            //fcs.Add(u2);
            List<UserStudent> std = new List<UserStudent>();
            //std.Add(u3);

            List<Course> crs = new List<Course>();
            crs.Add(new Course()); 


            Application.Run(new Form4(ads, std,fcs));
            Application.Run(new CourseParseForm(crs));
            //Application.Run(new Sloppyform(ads, std, fcs)); 
            Application.Run(new LoginForm(ads,fcs,std,crs));
        }
    }

    static class benutil
    {
        public static void AddStudenttoCourse(UserStudent S, Course C)
        {
            if (C.AddStudent(S))
            {
                S.MyCourses.Add(C.CourseName);
                MessageBox.Show("You've successfully registered for " + C.CourseName + " ."); 
            }
            else
            {
                if (C.Students >= C.Seats)
                    MessageBox.Show("Class is Full!");
                if (S.MyCourses.Contains(C.CourseName))
                    MessageBox.Show("You've Already Registered for this Course!");
            }
        }

        public static void AddStudenttoCourse(UserStudent S, Course C, UserAdmin Me)
        { 
        
        }

        public static void RemoveStudentfromCourse(UserStudent S, Course C)
        {
            MessageBox.Show("Removing " + S.UserName + " from " + C.CourseName + " ."); 
            C.RemoveStudent(S);
            S.MyCourses.Remove(C.CourseName);
            MessageBox.Show("You are no longer registered for " + C.CourseName + " ."); 
        
        }
    }

}
