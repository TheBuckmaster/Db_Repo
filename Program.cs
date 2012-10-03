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

            Application.Run(OurForm);
            try
            {
                using (StreamReader sr = new StreamReader("input file goes here"))
                {
                    String line = sr.ReadLine();

                    while(line != null)
                    {
                        // username
                        line.TrimStart();
                        string substring = line.Substring(0, 10);
                        substring.TrimEnd();
                        OurForm.UserList.Add(substring);
                        line.Remove(0, 10);

                        // password
                        line.TrimStart();
                        substring = line.Substring(0, 10);
                        substring.TrimEnd();
                        OurForm.PasswordList.Add(substring);
                        line.Remove(0, 10);

                        // first name
                        line.TrimStart();
                        substring = line.Substring(0, 15);
                        substring.TrimEnd();
                        OurForm.FstNameList.Add(substring);
                        line.Remove(0, 15);

                        // middle name
                        line.TrimStart();
                        substring = line.Substring(0, 15);
                        OurForm.MidNameList.Add(substring);
                        line.Remove(0, 15);

                        // last name
                        line.TrimStart();
                        substring = line.Substring(0, 15);
                        substring.TrimEnd();
                        OurForm.LstNameList.Add(substring);
                        line.Remove(0, 15);

                        // status
                        line.TrimStart();
                        substring = line.Substring(0, 10);
                        substring.TrimEnd();
                        OurForm.StatusList.Add(substring);
                        line.Remove(0, 10);

                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            


            string filename = "Classinput.txt";
            if (File.Exists(filename))
            {
                int localcharred = 0;
                FileStream input = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader filereader = new StreamReader(input); 
                
            }
            else
            {
                //Invalid File Configuration. 
            }
            
            OurForm.CourseList = new List<string>();
            OurForm.CourseList.Add("This is where a list would go"); 
        }
    }
}


