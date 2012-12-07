namespace Registration
{
    partial class FacultyForm
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
            this.vwEnroldStudBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teachingScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextSemesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adviseesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // vwEnroldStudBtn
            // 
            this.vwEnroldStudBtn.Location = new System.Drawing.Point(687, 299);
            this.vwEnroldStudBtn.Name = "vwEnroldStudBtn";
            this.vwEnroldStudBtn.Size = new System.Drawing.Size(143, 23);
            this.vwEnroldStudBtn.TabIndex = 0;
            this.vwEnroldStudBtn.Text = "View Enrolled Students";
            this.vwEnroldStudBtn.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(842, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuToolStripMenuItem,
            this.teachingScheduleToolStripMenuItem,
            this.adviseesToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mainMenuToolStripMenuItem
            // 
            this.mainMenuToolStripMenuItem.Name = "mainMenuToolStripMenuItem";
            this.mainMenuToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.mainMenuToolStripMenuItem.Text = "Main Menu";
            // 
            // teachingScheduleToolStripMenuItem
            // 
            this.teachingScheduleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentToolStripMenuItem,
            this.nextSemesterToolStripMenuItem});
            this.teachingScheduleToolStripMenuItem.Name = "teachingScheduleToolStripMenuItem";
            this.teachingScheduleToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.teachingScheduleToolStripMenuItem.Text = "Teaching Schedule";
            this.teachingScheduleToolStripMenuItem.Click += new System.EventHandler(this.teachingScheduleToolStripMenuItem_Click);
            // 
            // currentToolStripMenuItem
            // 
            this.currentToolStripMenuItem.Name = "currentToolStripMenuItem";
            this.currentToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.currentToolStripMenuItem.Text = "Current";
            // 
            // nextSemesterToolStripMenuItem
            // 
            this.nextSemesterToolStripMenuItem.Name = "nextSemesterToolStripMenuItem";
            this.nextSemesterToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.nextSemesterToolStripMenuItem.Text = "Next Semester";
            // 
            // adviseesToolStripMenuItem
            // 
            this.adviseesToolStripMenuItem.Name = "adviseesToolStripMenuItem";
            this.adviseesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.adviseesToolStripMenuItem.Text = "Advisees";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(818, 266);
            this.dataGridView1.TabIndex = 3;
            // 
            // FacultyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 334);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.vwEnroldStudBtn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FacultyForm";
            this.Text = "FacultyForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button vwEnroldStudBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teachingScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextSemesterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adviseesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}