using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{

    

    public class Course
    {
        public String CourseTitle {get; set;}
        public String CourseName { get; set;}
        List<String> Meetings;
        List<String> Students; //List of Student Usernames
        String Teacher = "Staff"; 

        public Course()
        {
            CourseTitle = "No Title";
            CourseName = "No Name"; 
            Meetings = new List<String>();
            Students = new List<String>();

        }

        Course(String Title, String Name);
        {
    


        }




    }


    class PastCourse
    {
 

    }



}
