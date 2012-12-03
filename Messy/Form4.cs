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
    public partial class Form4 : Form
    {
        private StreamReader filereader;
        List<UserAdmin> AL = new List<UserAdmin>();
        List<UserFaculty> FL = new List<UserFaculty>();
        List<UserStudent> SL = new List<UserStudent>();
        DialogResult result;
        private string filename;
        FileStream input;
        private string line; 


        public Form4(List<UserAdmin> a, List<UserStudent> s, List<UserFaculty> f)
        {
            InitializeComponent();
            AL = a;
            FL = f;
            SL = s; 

            using (OpenFileDialog filechooser = new OpenFileDialog())
            {
                result = filechooser.ShowDialog();
                filename = filechooser.FileName; 
            }

            if (result == DialogResult.OK)
            {
                input = new FileStream(filename, FileMode.Open, FileAccess.Read);
                filereader = new StreamReader(input);

                readnextline();
            }

        }

        private void readnextline()
        {

            try
            {

                line = filereader.ReadLine();
                if (line != null)
                {
                    usernamelabel.Text = line.Substring(0, 10).Trim();
                    passwordlabel.Text = line.Substring(10, 10).Trim();
                    firstnlabel.Text = line.Substring(20, 15).Trim();
                    middlenlabel.Text = line.Substring(35, 15).Trim();
                    lastnlabel.Text = line.Substring(50, 15).Trim();
                    statuslabel.Text = line.Substring(65).Trim();
                }
                else
                {
                    filereader.Close();
                    button1.Visible = false;
                    MessageBox.Show("File is now complete."); 
                }

            }

            catch (EndOfStreamException)
            { }  
        
        
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (statuslabel.Text.Contains("admin"))
            {
                UserAdmin A = new UserAdmin(usernamelabel.Text, passwordlabel.Text,
                    firstnlabel.Text, middlenlabel.Text, lastnlabel.Text);
                AL.Add(A);
                manyadm.Value++; 
            }
            else if (statuslabel.Text.Contains("faculty"))
            {
                UserFaculty F = new UserFaculty(usernamelabel.Text, passwordlabel.Text,
                    firstnlabel.Text, middlenlabel.Text, lastnlabel.Text);
                FL.Add(F);
                manyfac.Value++; 
            }
            else
            {
                UserStudent S = new UserStudent(usernamelabel.Text, passwordlabel.Text, firstnlabel.Text,
                    middlenlabel.Text, lastnlabel.Text, statuslabel.Text);
                SL.Add(S);
                manystd.Value++;
            }

            readnextline(); 


        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
