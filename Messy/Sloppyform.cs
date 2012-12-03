using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BensCRS
{
    public partial class Sloppyform : Form
    {
        public Sloppyform(List<UserAdmin> a, List<UserStudent> s, List<UserFaculty> f)
        {
            InitializeComponent();
            std.Text = s.Count.ToString();
            adm.Text = a.Count.ToString();
            fac.Text = f.Count.ToString();

        }
    }
}
