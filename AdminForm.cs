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
    public partial class AdminForm : Form
    {
        List<VUser> userList = new List<VUser>();
        List<courseinfo> Courses = new List<courseinfo>();
        VUser admin;
        public AdminForm(ref List<courseinfo> crslist, ref List<VUsers> usrlist, ref VUser admn)
        {
            InitializeComponent();
            userList = usrlist;
            Courses = crslist;
            admin = admn;
        }

        public AdminForm(List<VUser> usr)
        {
            InitializeComponent();
            userList = usr;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm1 = new Form1(ref Courses, ref userList);
            frm1.Show();
            this.Close();
        }

        private void DleteCourseBtn_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
