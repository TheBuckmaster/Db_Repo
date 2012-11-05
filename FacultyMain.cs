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

        public FacultyMain(List<User> usrlst)
        {
            InitializeComponent();
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            listView1.FullRowSelect = true;

            foreach (DataRow row in DataBindings.Rows)
            {
                var item = new ListViewItem(row[0].ToString());
                item.Tag = row;


                listView1.Items.Add(item);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.FullRowSelect = true;

            foreach (DataRow row in DataBindings.Rows)
            {
                var item = new ListViewItem(row[0].ToString());
                item.Tag = row;


                listView1.Items.Add(item);
            }
            viewEnrolledStudents(item)
        }
    }
}
