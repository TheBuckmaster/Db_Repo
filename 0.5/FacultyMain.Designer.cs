﻿namespace WindowsFormsApplication1
{
    partial class FacultyMain
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
            this.teachingScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentSemesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextSemesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ViewEnrolledStudents = new System.Windows.Forms.Button();
            this.mainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(867, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuToolStripMenuItem,
            this.teachingScheduleToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // teachingScheduleToolStripMenuItem
            // 
            this.teachingScheduleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentSemesterToolStripMenuItem,
            this.nextSemesterToolStripMenuItem});
            this.teachingScheduleToolStripMenuItem.Name = "teachingScheduleToolStripMenuItem";
            this.teachingScheduleToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.teachingScheduleToolStripMenuItem.Text = "Teaching Schedule";
            // 
            // currentSemesterToolStripMenuItem
            // 
            this.currentSemesterToolStripMenuItem.Name = "currentSemesterToolStripMenuItem";
            this.currentSemesterToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.currentSemesterToolStripMenuItem.Text = "Current Semester";
            this.currentSemesterToolStripMenuItem.Click += new System.EventHandler(this.currentSemesterToolStripMenuItem_Click);
            // 
            // nextSemesterToolStripMenuItem
            // 
            this.nextSemesterToolStripMenuItem.Name = "nextSemesterToolStripMenuItem";
            this.nextSemesterToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.nextSemesterToolStripMenuItem.Text = "Next Semester";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 43);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(810, 336);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // ViewEnrolledStudents
            // 
            this.ViewEnrolledStudents.Location = new System.Drawing.Point(662, 385);
            this.ViewEnrolledStudents.Name = "ViewEnrolledStudents";
            this.ViewEnrolledStudents.Size = new System.Drawing.Size(160, 23);
            this.ViewEnrolledStudents.TabIndex = 2;
            this.ViewEnrolledStudents.Text = "View Enrolled Students";
            this.ViewEnrolledStudents.UseVisualStyleBackColor = true;
            this.ViewEnrolledStudents.Click += new System.EventHandler(this.ViewEnrolledStudents_Click);
            // 
            // mainMenuToolStripMenuItem
            // 
            this.mainMenuToolStripMenuItem.Name = "mainMenuToolStripMenuItem";
            this.mainMenuToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.mainMenuToolStripMenuItem.Text = "Main Menu";
            this.mainMenuToolStripMenuItem.Click += new System.EventHandler(this.mainMenuToolStripMenuItem_Click);
            // 
            // FacultyMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 432);
            this.Controls.Add(this.ViewEnrolledStudents);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FacultyMain";
            this.Text = "+";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teachingScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button ViewEnrolledStudents;
        private System.Windows.Forms.ToolStripMenuItem currentSemesterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextSemesterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainMenuToolStripMenuItem;
    }
}