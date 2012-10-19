using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
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
            Form1 OurForm = new Form1();
          


            string filename = "ClassInput.txt";
            if (File.Exists(filename))
            {
                string currstring;
                string coursename;
                string coursetitle;
                string instructor;
                float credit;
                int seats;
                int timeblocks;
                List<coursetime> times;
                
                FileStream input = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader filereader = new StreamReader(input);
                try
                {
                    
                    while (!filereader.EndOfStream)
                    {
                        
                        currstring = filereader.ReadLine();
                        coursename = currstring.Substring(0, 10);
                        currstring.Remove(0, 10);
                        currstring.TrimStart();
                        coursetitle = currstring.Substring(0, 15);
                        currstring.Remove(0, 15);
                        currstring.TrimStart();
                        instructor = currstring.Substring(0, 10);
                        currstring.Remove(0, 10);
                        currstring.TrimStart();
                        credit = float.Parse(currstring.Substring(0, 4));
                        currstring.Remove(0, 4);
                        currstring.TrimStart();
                        seats = int.Parse(currstring.Substring(0, 3));
                        currstring.Remove(0, 3);
                        currstring.TrimStart();
                        timeblocks = int.Parse(currstring.Substring(0, 1));
                        currstring.Remove(0, 1);
                        currstring.TrimStart();

                        times = new List<coursetime>();
                        for (int counter = 0; counter < timeblocks; counter++)
                        {
                            string littlestring = currstring.Substring(0, 5);
                            times.Add(new coursetime(littlestring));
                            
                            currstring.Remove(0, 5);
                            currstring.TrimStart();
                        }
                        OurForm.Courses.Add(new courseinfo(coursename, coursetitle, instructor, credit, seats, times));
                        //OurForm.Courses[howmanycourses] = new courseinfo(coursename, coursetitle, instructor, credit, seats, times);
                        //howmanycourses += 1;
                        //OurForm.numCourses = howmanycourses;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input File");
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Your File does not Exist."); 
            }

            Application.Run(OurForm);
        }
    }
}


