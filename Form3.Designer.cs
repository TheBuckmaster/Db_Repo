namespace WindowsFormsApplication1
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            this.AddCourseBttn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CheckBoxes = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CrsTtle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CrsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prof = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tmie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseOfferings1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView = new System.Windows.Forms.ListView();
            this.LVCourseTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LVCourseName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LVProfesser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LVSeats = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LVCredit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LVDays = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LVTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseOfferings1BindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddCourseBttn
            // 
            this.AddCourseBttn.Location = new System.Drawing.Point(619, 326);
            this.AddCourseBttn.Name = "AddCourseBttn";
            this.AddCourseBttn.Size = new System.Drawing.Size(75, 23);
            this.AddCourseBttn.TabIndex = 5;
            this.AddCourseBttn.Text = "Add Course";
            this.AddCourseBttn.UseVisualStyleBackColor = true;
            this.AddCourseBttn.Visible = false;
            this.AddCourseBttn.Click += new System.EventHandler(this.AddCourseBttn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBoxes,
            this.CrsTtle,
            this.CrsName,
            this.Prof,
            this.seets,
            this.Credt,
            this.Dys,
            this.Tmie});
            this.dataGridView1.DataSource = this.courseOfferings1BindingSource;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(682, 275);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Visible = false;
            // 
            // CheckBoxes
            // 
            this.CheckBoxes.Frozen = true;
            this.CheckBoxes.HeaderText = "";
            this.CheckBoxes.Name = "CheckBoxes";
            this.CheckBoxes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CheckBoxes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CheckBoxes.Width = 50;
            // 
            // CrsTtle
            // 
            this.CrsTtle.Frozen = true;
            this.CrsTtle.HeaderText = "Course Title";
            this.CrsTtle.MinimumWidth = 50;
            this.CrsTtle.Name = "CrsTtle";
            this.CrsTtle.ReadOnly = true;
            this.CrsTtle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CrsTtle.Width = 50;
            // 
            // CrsName
            // 
            this.CrsName.Frozen = true;
            this.CrsName.HeaderText = "Course Name";
            this.CrsName.MinimumWidth = 150;
            this.CrsName.Name = "CrsName";
            this.CrsName.ReadOnly = true;
            this.CrsName.Width = 150;
            // 
            // Prof
            // 
            this.Prof.HeaderText = "Professer";
            this.Prof.Name = "Prof";
            this.Prof.ReadOnly = true;
            this.Prof.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // seets
            // 
            this.seets.HeaderText = "Seats";
            this.seets.Name = "seets";
            this.seets.Width = 50;
            // 
            // Credt
            // 
            this.Credt.HeaderText = "Credit";
            this.Credt.Name = "Credt";
            this.Credt.Width = 40;
            // 
            // Dys
            // 
            this.Dys.HeaderText = "Date";
            this.Dys.Name = "Dys";
            this.Dys.ReadOnly = true;
            this.Dys.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Tmie
            // 
            this.Tmie.HeaderText = "Time";
            this.Tmie.Name = "Tmie";
            this.Tmie.ReadOnly = true;
            this.Tmie.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(719, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCourseToolStripMenuItem,
            this.deleteCourseToolStripMenuItem,
            this.viewScheduleToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addCourseToolStripMenuItem
            // 
            this.addCourseToolStripMenuItem.Name = "addCourseToolStripMenuItem";
            this.addCourseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addCourseToolStripMenuItem.Text = "Add Course";
            this.addCourseToolStripMenuItem.Click += new System.EventHandler(this.addCourseToolStripMenuItem_Click_1);
            // 
            // deleteCourseToolStripMenuItem
            // 
            this.deleteCourseToolStripMenuItem.Name = "deleteCourseToolStripMenuItem";
            this.deleteCourseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteCourseToolStripMenuItem.Text = "Delete Course";
            // 
            // viewScheduleToolStripMenuItem
            // 
            this.viewScheduleToolStripMenuItem.Name = "viewScheduleToolStripMenuItem";
            this.viewScheduleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewScheduleToolStripMenuItem.Text = "View Schedule";
            this.viewScheduleToolStripMenuItem.Click += new System.EventHandler(this.viewScheduleToolStripMenuItem_Click_1);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click_1);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LVCourseTitle,
            this.LVCourseName,
            this.LVProfesser,
            this.LVSeats,
            this.LVCredit,
            this.LVDays,
            this.LVTime});
            this.listView.DataBindings.Add(new System.Windows.Forms.Binding("GridLines", global::WindowsFormsApplication1.Properties.Settings.Default, "GridLines", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.listView.Location = new System.Drawing.Point(12, 64);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(682, 275);
            this.listView.TabIndex = 6;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // LVCourseTitle
            // 
            this.LVCourseTitle.Text = "Course Title";
            // 
            // LVCourseName
            // 
            this.LVCourseName.Text = "Course Name";
            this.LVCourseName.Width = 120;
            // 
            // LVProfesser
            // 
            this.LVProfesser.Text = "Professer";
            this.LVProfesser.Width = 120;
            // 
            // LVSeats
            // 
            this.LVSeats.Text = "Seats";
            this.LVSeats.Width = 75;
            // 
            // LVCredit
            // 
            this.LVCredit.Text = "Credit";
            // 
            // LVDays
            // 
            this.LVDays.Text = "Days";
            this.LVDays.Width = 90;
            // 
            // LVTime
            // 
            this.LVTime.Text = "Time";
            this.LVTime.Width = 120;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 361);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.AddCourseBttn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseOfferings1BindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddCourseBttn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBoxes;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrsTtle;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prof;
        private System.Windows.Forms.DataGridViewTextBoxColumn seets;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dys;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tmie;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader LVCourseTitle;
        private System.Windows.Forms.ColumnHeader LVCourseName;
        private System.Windows.Forms.ColumnHeader LVProfesser;
        private System.Windows.Forms.ColumnHeader LVSeats;
        private System.Windows.Forms.ColumnHeader LVCredit;
        private System.Windows.Forms.ColumnHeader LVDays;
        private System.Windows.Forms.ColumnHeader LVTime;
        private CourseOfferings courseOfferings1;
        private System.Windows.Forms.BindingSource courseOfferings1BindingSource;
    }
}