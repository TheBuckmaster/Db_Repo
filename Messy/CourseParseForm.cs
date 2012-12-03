using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BensCRS
{
    public partial class CourseParseForm : Form
    {
        List<String> timeblocks = new List<string>();

        List<Course> Courses = new List<Course>();

        private StreamReader filereader;
        DialogResult result;
        private string filename;
        FileStream input;
        private string line;


        public CourseParseForm(List<Course> C)
        {
            InitializeComponent();
            Courses = C;

            try
            {
                using (OpenFileDialog filechooser = new OpenFileDialog())
                {
                    result = filechooser.ShowDialog();
                    filename = filechooser.FileName;
                }

                if (result == DialogResult.OK)
                {
                    input = new FileStream(filename, FileMode.Open, FileAccess.Read);
                    filereader = new StreamReader(input);

                }

                line = filereader.ReadLine();
                while (line != null)
                {
                    cName.Text = line.Substring(0, 11).Trim();
                    cTitle.Text = line.Substring(11, 16).Trim();
                    cInst.Text = line.Substring(27, 11).Trim();
                    cCred.Text = line.Substring(38, 5).Trim();
                    cSeat.Text = line.Substring(43, 4).Trim();
                    cNumTimes.Text = line.Substring(47, 2).Trim();
                    string timeline = line.Substring(49).Trim();
                    int numTimes = Convert.ToInt16(cNumTimes.Text);

                    for (int i = 0; i < numTimes; i++)
                    {
                        int begin = (0 + (i * 5));
                        timeblocks.Add(timeline.Substring(begin, 5));
                    }

                    Course myCourse = new Course(cName.Text, cTitle.Text, cInst.Text,
                        Convert.ToDouble(cCred.Text), Convert.ToInt16(cSeat.Text), timeblocks);
                    Courses.Add(myCourse);

                    //MessageBox.Show("There are " + Courses.Count + " Courses.");



                    line = filereader.ReadLine();
                }
                filereader.Close();
                MessageBox.Show("File is now complete.");
                 
            }
            catch
            {
                MessageBox.Show("There was an Error"); 
            }
        }

    }
}
