namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.UsernameText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.IncorrectLabel = new System.Windows.Forms.Label();
            this.ClassOfferings = new System.Windows.Forms.Button();
            this.CourseTextBox = new System.Windows.Forms.TextBox();
            this.BackToMainScreen = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classOfferingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addClassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UsernameText
            // 
            this.UsernameText.Location = new System.Drawing.Point(128, 120);
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(151, 20);
            this.UsernameText.TabIndex = 0;
            this.UsernameText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(128, 181);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(151, 20);
            this.passwordText.TabIndex = 1;
            this.passwordText.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(128, 224);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // IncorrectLabel
            // 
            this.IncorrectLabel.AutoSize = true;
            this.IncorrectLabel.Location = new System.Drawing.Point(125, 77);
            this.IncorrectLabel.Name = "IncorrectLabel";
            this.IncorrectLabel.Size = new System.Drawing.Size(161, 13);
            this.IncorrectLabel.TabIndex = 5;
            this.IncorrectLabel.Text = "Incorrect Username or Password";
            this.IncorrectLabel.Visible = false;
            // 
            // ClassOfferings
            // 
            this.ClassOfferings.Location = new System.Drawing.Point(38, 67);
            this.ClassOfferings.Name = "ClassOfferings";
            this.ClassOfferings.Size = new System.Drawing.Size(108, 23);
            this.ClassOfferings.TabIndex = 6;
            this.ClassOfferings.Text = "Class Offerings";
            this.ClassOfferings.UseVisualStyleBackColor = true;
            this.ClassOfferings.Visible = false;
            this.ClassOfferings.Click += new System.EventHandler(this.ClassOfferings_Click);
            // 
            // CourseTextBox
            // 
            this.CourseTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CourseTextBox.Location = new System.Drawing.Point(69, 33);
            this.CourseTextBox.Multiline = true;
            this.CourseTextBox.Name = "CourseTextBox";
            this.CourseTextBox.ReadOnly = true;
            this.CourseTextBox.Size = new System.Drawing.Size(321, 231);
            this.CourseTextBox.TabIndex = 7;
            this.CourseTextBox.Visible = false;
            this.CourseTextBox.TextChanged += new System.EventHandler(this.CourseTextBox_TextChanged);
            // 
            // BackToMainScreen
            // 
            this.BackToMainScreen.Location = new System.Drawing.Point(287, 297);
            this.BackToMainScreen.Name = "BackToMainScreen";
            this.BackToMainScreen.Size = new System.Drawing.Size(75, 23);
            this.BackToMainScreen.TabIndex = 9;
            this.BackToMainScreen.Text = "Back";
            this.BackToMainScreen.UseVisualStyleBackColor = true;
            this.BackToMainScreen.Visible = false;
            this.BackToMainScreen.Click += new System.EventHandler(this.BackToMainScreen_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(451, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classOfferingsToolStripMenuItem,
            this.scheduleToolStripMenuItem,
            this.addClassesToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // classOfferingsToolStripMenuItem
            // 
            this.classOfferingsToolStripMenuItem.Enabled = false;
            this.classOfferingsToolStripMenuItem.Name = "classOfferingsToolStripMenuItem";
            this.classOfferingsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.classOfferingsToolStripMenuItem.Text = "Class Offerings";
            this.classOfferingsToolStripMenuItem.Click += new System.EventHandler(this.classOfferingsToolStripMenuItem_Click);
            // 
            // scheduleToolStripMenuItem
            // 
            this.scheduleToolStripMenuItem.Enabled = false;
            this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            this.scheduleToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.scheduleToolStripMenuItem.Text = "Schedule";
            // 
            // addClassesToolStripMenuItem
            // 
            this.addClassesToolStripMenuItem.Enabled = false;
            this.addClassesToolStripMenuItem.Name = "addClassesToolStripMenuItem";
            this.addClassesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.addClassesToolStripMenuItem.Text = "Add Classes";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 365);
            this.Controls.Add(this.BackToMainScreen);
            this.Controls.Add(this.CourseTextBox);
            this.Controls.Add(this.ClassOfferings);
            this.Controls.Add(this.IncorrectLabel);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.UsernameText);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Database";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsernameText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label IncorrectLabel;
        private System.Windows.Forms.Button ClassOfferings;
        private System.Windows.Forms.TextBox CourseTextBox;
        private System.Windows.Forms.Button BackToMainScreen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classOfferingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addClassesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

