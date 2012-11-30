using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Registration
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                Application.Run(new AdminForm());
                AdminForm adm = new AdminForm();
                adm.Show();
                this.Hide();
            }
            else if (faculty)
            {
                Application.Run(new FacultyForm());
                FacultyForm fac = new FacultyForm();
                fac.Show();
                this.Hide();
            }
            else
            {
                Application.Run(new StudentForm());
                StudentForm stud = new StudentForm();
                stud.Show();
                this.Hide();
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
