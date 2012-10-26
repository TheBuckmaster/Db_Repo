using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FacultyMain : Form
    {
        public FacultyMain()
        {
            InitializeComponent();
        }

        List<courseinfo> CourseList = new List<courseinfo>();
        List<User> UserList = new List<User>();

        public FacultyMain(List<courseinfo> cl, List<User> usrlst)
        {
            InitializeComponent();
            CourseList = cl;
            UserList = usrlst;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Close();
        }
    }
}
