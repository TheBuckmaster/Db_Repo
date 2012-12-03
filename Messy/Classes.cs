using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BensCRS
{
    public class UserFaculty
    {
        public String UserName = "BobF";
        private string password = "FUCK";
        public String FirstName;
        public String LastName;
        public String MiddleName;

        public List<String> MyClasses = new List<String>();  //CourseNames of my classes

        public UserFaculty(String UN, String PW, String FN, String MN, String LN)
        {
            UserName = UN;
            password = PW;
            FirstName = FN;
            MiddleName = MN;
            LastName = LN; 
        }

        public UserFaculty(UserFaculty F)
        {
            UserName = F.UserName;
            password = F.password;         
        }

        public bool isPassword(String maybePWD)
        {
            return (maybePWD == password);
        }

        public void classesFinder(List<Course> crs)
        {
            foreach (Course c in crs)
            {
                if (c.Instructor == UserName)
                    MyClasses.Add(c.CourseName);
            }
        }
    }

    public class UserStudent
    {
        public String UserName = "BobS";
        private string password = "FUCK";
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MiddleName { get; set; }
        public String Advisor;

        public List<String> MyCourses = new List<String>(); 

        public UserStudent(String UN, String PW, String FN, String MN, String LN, String ADV)
        {
            UserName = UN;
            password = PW;
            FirstName = FN;
            MiddleName = MN;
            LastName = LN;
            Advisor = ADV; 
        }

        public UserStudent()
        { }

        public UserStudent(UserStudent A)
        {
            UserName = A.UserName;
            password = A.password; 
        }

        public bool isPassword(String maybePWD)
        {
            return (maybePWD == password);
        }
    
    }

    public class UserAdmin
    {
        public String UserName = "BobA";
        private string password = "FUCK";
        public String FirstName;
        public String LastName;
        public String MiddleName; 

        public UserAdmin(String UN, String PW, String FN, String MN, String LN)
        {
            UserName = UN;
            password = PW;
            FirstName = FN;
            MiddleName = MN;
            LastName = LN; 
        }

        public bool isPassword(String maybePWD)
        {
            return (maybePWD == password);
        }
    }

    public class Course
    {
        private struct Meeting
        {
            public List<Char> days; //dd, translated
            public String time; //ttk, translated
        }
        private string coursename; 
        public String CourseTitle { get; set; }
        public String CourseName { get {return coursename;} }
        public String Instructor { get; set; }
        public double credits { get; set; } 
        private List<Meeting> Meetings = new List<Meeting>();
        private int seats;
        public int Seats { get { return seats; } }
        private List<String> studentNames = new List<String>();
        public int Students { get { return studentNames.Count; } }
        public string Enrollment { get { return Students + " / " + Seats; } }
        
        public string BaseClass { get { return coursename.Substring(0, coursename.Length - 3); } }
        public string Section { get { return coursename.Substring(coursename.Length - 2); } }


        public Course()
        {
            Meeting meeting1;
            meeting1.days = new List<char>();
            meeting1.days.Add('M');
            meeting1.days.Add('W');
            meeting1.days.Add('F');
            meeting1.time = "201";
            Meetings.Add(meeting1);

            CourseTitle = "Special Topics";
            coursename = "MTH-000-00";
            Instructor = "Staff";
            credits = 1.0;
            seats = 20; 

            studentNames.Add("JWhite");
            studentNames.Add("CVanNiewaal");
            studentNames.Add("DCurtis"); 

        
        }

        public Course(String cName, String cTitle, String cInst, Double cCred,
            int cSeat, List<String> timeblocks)
        {
            coursename = cName;
            CourseTitle = cTitle;
            Instructor = cInst;
            credits = cCred;
            seats = cSeat;
            makeMeetings(timeblocks); 
        
        }

        public bool AddStudent(UserStudent S)
        {
            if (Students > Seats)
                return false; 
            if (studentNames.Contains(S.UserName))
                return false;
            if (S.MyCourses.Contains(CourseName))
                return false;

            studentNames.Add(S.UserName);
            return true;         
        }

        public bool AddStudent(UserStudent S, UserAdmin A)
        {
            if (studentNames.Contains(S.UserName))
                return false;

            studentNames.Add(S.UserName);
            return true; 
        }

        public void RemoveStudent(UserStudent S)
        {
            if (studentNames.Contains(S.UserName))
                studentNames.Remove(S.UserName);
        }

        private void makeMeetings(List<String> ddttks)
        {

        }

    }

    public class PastCourse
    { 
    
    
    }

}
