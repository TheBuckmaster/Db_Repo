using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
                        UserList.Add(substring);
                        line.Remove(0, 10);

                        // password
                        line.TrimStart();
                        substring = line.Substring(0, 10);
                        substring.TrimEnd();
                        PasswordList.Add(substring);
                        line.Remove(0, 10);

                        // first name
                        line.TrimStart();
                        substring = line.Substring(0, 15);
                        substring.TrimEnd();
                        FstNameList.Add(substring);
                        line.Remove(0, 15);

                        // middle name
                        line.TrimStart();
                        substring = line.Substring(0, 15);
                        MidNameList.Add(substring);
                        line.Remove(0, 15);

                        // last name
                        line.TrimStart();
                        substring = line.Substring(0, 15);
                        substring.TrimEnd();
                        LstNameList.Add(substring);
                        line.Remove(0, 15);

                        // status
                        line.TrimStart();
                        substring = line.Substring(0, 10);
                        substring.TrimEnd();
                        StatusList.Add(substring);
                        line.Remove(0, 10);

                        String line = sr.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }


            Form1 OurForm = new Form1();
            OurForm.CourseList = new List<string>();
            OurForm.CourseList.Add("This is where a list would go"); 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(OurForm);
        }
    }
}

