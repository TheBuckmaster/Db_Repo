namespace WindowsFormsApplication1
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeCourseBtn = new System.Windows.Forms.Button();
            this.viewStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VwStudentSchedbtn = new System.Windows.Forms.Button();
            this.viewFacultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VwFacultySchedBtn = new System.Windows.Forms.Button();
            this.DleteCourseBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 41);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(686, 302);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(710, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewStudentsToolStripMenuItem,
            this.viewFacultyToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // ChangeCourseBtn
            // 
            this.ChangeCourseBtn.Location = new System.Drawing.Point(591, 368);
            this.ChangeCourseBtn.Name = "ChangeCourseBtn";
            this.ChangeCourseBtn.Size = new System.Drawing.Size(107, 23);
            this.ChangeCourseBtn.TabIndex = 2;
            this.ChangeCourseBtn.Text = "Change Course";
            this.ChangeCourseBtn.UseVisualStyleBackColor = true;
            // 
            // viewStudentsToolStripMenuItem
            // 
            this.viewStudentsToolStripMenuItem.Name = "viewStudentsToolStripMenuItem";
            this.viewStudentsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewStudentsToolStripMenuItem.Text = "View Students";
            // 
            // VwStudentSchedbtn
            // 
            this.VwStudentSchedbtn.Location = new System.Drawing.Point(487, 368);
            this.VwStudentSchedbtn.Name = "VwStudentSchedbtn";
            this.VwStudentSchedbtn.Size = new System.Drawing.Size(98, 23);
            this.VwStudentSchedbtn.TabIndex = 3;
            this.VwStudentSchedbtn.Text = "View Schedule";
            this.VwStudentSchedbtn.UseVisualStyleBackColor = true;
            // 
            // viewFacultyToolStripMenuItem
            // 
            this.viewFacultyToolStripMenuItem.Name = "viewFacultyToolStripMenuItem";
            this.viewFacultyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewFacultyToolStripMenuItem.Text = "View Faculty";
            // 
            // VwFacultySchedBtn
            // 
            this.VwFacultySchedBtn.Location = new System.Drawing.Point(385, 368);
            this.VwFacultySchedBtn.Name = "VwFacultySchedBtn";
            this.VwFacultySchedBtn.Size = new System.Drawing.Size(96, 23);
            this.VwFacultySchedBtn.TabIndex = 4;
            this.VwFacultySchedBtn.Text = "View Schedule";
            this.VwFacultySchedBtn.UseVisualStyleBackColor = true;
            // 
            // DleteCourseBtn
            // 
            this.DleteCourseBtn.Location = new System.Drawing.Point(280, 368);
            this.DleteCourseBtn.Name = "DleteCourseBtn";
            this.DleteCourseBtn.Size = new System.Drawing.Size(99, 23);
            this.DleteCourseBtn.TabIndex = 5;
            this.DleteCourseBtn.Text = "Delete Course";
            this.DleteCourseBtn.UseVisualStyleBackColor = true;
            this.DleteCourseBtn.Click += new System.EventHandler(this.DleteCourseBtn_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 403);
            this.Controls.Add(this.DleteCourseBtn);
            this.Controls.Add(this.VwFacultySchedBtn);
            this.Controls.Add(this.VwStudentSchedbtn);
            this.Controls.Add(this.ChangeCourseBtn);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewFacultyToolStripMenuItem;
        private System.Windows.Forms.Button ChangeCourseBtn;
        private System.Windows.Forms.Button VwStudentSchedbtn;
        private System.Windows.Forms.Button VwFacultySchedBtn;
        private System.Windows.Forms.Button DleteCourseBtn;
    }
}