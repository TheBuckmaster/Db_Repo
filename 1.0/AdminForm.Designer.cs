namespace Registration
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewFacultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.DelCourseBtn = new System.Windows.Forms.Button();
            this.vwSchedFacBtn = new System.Windows.Forms.Button();
            this.vwSchedStudBtn = new System.Windows.Forms.Button();
            this.changeCourseBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(841, 24);
            this.menuStrip1.TabIndex = 0;
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
            // viewStudentsToolStripMenuItem
            // 
            this.viewStudentsToolStripMenuItem.Name = "viewStudentsToolStripMenuItem";
            this.viewStudentsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewStudentsToolStripMenuItem.Text = "View Students";
            // 
            // viewFacultyToolStripMenuItem
            // 
            this.viewFacultyToolStripMenuItem.Name = "viewFacultyToolStripMenuItem";
            this.viewFacultyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewFacultyToolStripMenuItem.Text = "View Faculty";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 27);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(817, 243);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // DelCourseBtn
            // 
            this.DelCourseBtn.Location = new System.Drawing.Point(511, 276);
            this.DelCourseBtn.Name = "DelCourseBtn";
            this.DelCourseBtn.Size = new System.Drawing.Size(75, 23);
            this.DelCourseBtn.TabIndex = 2;
            this.DelCourseBtn.Text = "button1";
            this.DelCourseBtn.UseVisualStyleBackColor = true;
            // 
            // vwSchedFacBtn
            // 
            this.vwSchedFacBtn.Location = new System.Drawing.Point(592, 276);
            this.vwSchedFacBtn.Name = "vwSchedFacBtn";
            this.vwSchedFacBtn.Size = new System.Drawing.Size(75, 23);
            this.vwSchedFacBtn.TabIndex = 3;
            this.vwSchedFacBtn.Text = "button2";
            this.vwSchedFacBtn.UseVisualStyleBackColor = true;
            // 
            // vwSchedStudBtn
            // 
            this.vwSchedStudBtn.Location = new System.Drawing.Point(673, 276);
            this.vwSchedStudBtn.Name = "vwSchedStudBtn";
            this.vwSchedStudBtn.Size = new System.Drawing.Size(75, 23);
            this.vwSchedStudBtn.TabIndex = 4;
            this.vwSchedStudBtn.Text = "button3";
            this.vwSchedStudBtn.UseVisualStyleBackColor = true;
            // 
            // changeCourseBtn
            // 
            this.changeCourseBtn.Location = new System.Drawing.Point(754, 276);
            this.changeCourseBtn.Name = "changeCourseBtn";
            this.changeCourseBtn.Size = new System.Drawing.Size(75, 23);
            this.changeCourseBtn.TabIndex = 5;
            this.changeCourseBtn.Text = "button4";
            this.changeCourseBtn.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 333);
            this.Controls.Add(this.changeCourseBtn);
            this.Controls.Add(this.vwSchedStudBtn);
            this.Controls.Add(this.vwSchedFacBtn);
            this.Controls.Add(this.DelCourseBtn);
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

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewFacultyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button DelCourseBtn;
        private System.Windows.Forms.Button vwSchedFacBtn;
        private System.Windows.Forms.Button vwSchedStudBtn;
        private System.Windows.Forms.Button changeCourseBtn;
    }
}