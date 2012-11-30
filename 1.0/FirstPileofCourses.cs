using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Registration
{
    //Administrative Library of Course and Program-Related Helper Functions
    public static class CourseAdmin
    {
        /// <summary>
        /// Reads in input from the named file. Adds to existing lists with content from file. 
        /// </summary>
        /// <param name="filename"> The name of a local file to read from. </param>
        //public static void readDB(string filename,
        //    List<Student> s,// List<Faculty> f, List<Admins> a,
        //    List<Course> courses) 
        //{
        
            


        //}

        public static String MeetingDecoder(String MeetingTime)
        {
            StringBuilder OutString = new StringBuilder();

            int dd = Convert.ToInt32(MeetingTime.Substring(0, 2), 10);
            int tt = Convert.ToInt32(MeetingTime.Substring(2, 2), 10);
            int l = Convert.ToInt32(MeetingTime.Substring(4, 1), 10);

            //day decode
            if ((dd & 1) == 1)
                OutString.Append("M");
            if ((dd & 2) == 2)
                OutString.Append("T");
            if ((dd & 4) == 4)
                OutString.Append("W");
            if ((dd & 8) == 8)
                OutString.Append("H");
            if ((dd & 16) == 16)
                OutString.Append("F");

            OutString.Append("  "); 
            //time decode
            String StartTime = "10:00 AM";
            String EndTime = "11:00 AM";

            //Actual decode here. 
            
            OutString.Append(StartTime);
            OutString.Append("-");
            OutString.Append(EndTime); 
            
            return OutString.ToString(); 
        }


    
    }
    

    public class Course
    {
        private String coursetitle;
        private String coursename;
        private String teacher = "Staff";
        private int maxSeats;
        private List<String> students; //List of Student Usernames
        private List<String> Meetings = new List<String>();
        private List<String> PreReqs = new List<String>();


        public String CourseTitle
        {
            get 
            { 
                return coursetitle; 
            } 
        }
        public String CourseName 
        { 
            get 
            { 
                return coursename; 
            } 
        }
        public String Teacher 
        {
            get
            {
                return teacher;
            }
        }
        public int MaxSeats 
        {
            get
            {
                return maxSeats;
            }
        }
        public int CurrSeats
        {
            get
            {
                return students.Count;
            }
        }
        public bool Full
        {
            get
            {
                return (CurrSeats > MaxSeats);
            }
        }
        public List<String> Students
        {
            get
            {
                return students;
            }
        }     
        public int numMeetings
        {
            get
            {
                return Meetings.Count;
            }
        }
        
        
        
        public Course()
        {
            coursetitle = "No Title";
            coursename = "No Name"; 
            Meetings = new List<String>();
            students = new List<String>();

        }

        public Course(String Title, String Name, List<String> propMeetings)
        {
    
            coursetitle = Title;
            coursename = Name;
            Meetings = new List<String>(propMeetings);
            students = new List<String>();

        }

        public Course(String Title, String Name, List<String> propMeetings, String fac)
        {
            coursetitle = Title;
            coursename = Name;
            Meetings = new List<String>(propMeetings);
            students = new List<String>();
            teacher = fac; 
        
        }

        public List<String> MeetingTimes()
        {
            List<String> OutList = new List<String>(); 

            foreach (String time in Meetings)
                OutList.Add(CourseAdmin.MeetingDecoder(time)); 

            return OutList; 
        }






    }


    public class PastCourse
    {
        private String cName;
        private double credits = 1.0;
        private String sg = "N";
        private String term; 
 
        

        public String CourseName { get { return cName; } }
        public double Credits { get { return credits; } }
        public String Grade { get { return sg; } }
        public String Term { get { return term; } } 
 


        public PastCourse()
        {
            cName = "No Name";
        }

        public PastCourse(String cn, String Trm, String Grd)
        {
            cName = cn;
            sg = Grd;
            term = Trm; 
        }

        public PastCourse(String cn, String trm, String grd, double pts)
            : this(cn, trm, grd)
        {
            credits = pts; 
        }


    }



}
