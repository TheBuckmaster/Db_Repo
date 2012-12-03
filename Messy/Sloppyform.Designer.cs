namespace BensCRS
{
    partial class Sloppyform
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.std = new System.Windows.Forms.TextBox();
            this.fac = new System.Windows.Forms.TextBox();
            this.adm = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "std";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "fac";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "adm";
            // 
            // std
            // 
            this.std.Location = new System.Drawing.Point(5, 86);
            this.std.Name = "std";
            this.std.Size = new System.Drawing.Size(100, 20);
            this.std.TabIndex = 3;
            // 
            // fac
            // 
            this.fac.Location = new System.Drawing.Point(85, 45);
            this.fac.Name = "fac";
            this.fac.Size = new System.Drawing.Size(100, 20);
            this.fac.TabIndex = 4;
            // 
            // adm
            // 
            this.adm.Location = new System.Drawing.Point(172, 84);
            this.adm.Name = "adm";
            this.adm.Size = new System.Drawing.Size(100, 20);
            this.adm.TabIndex = 5;
            // 
            // Sloppyform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.adm);
            this.Controls.Add(this.fac);
            this.Controls.Add(this.std);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Sloppyform";
            this.Text = "Sloppyform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox std;
        private System.Windows.Forms.TextBox fac;
        private System.Windows.Forms.TextBox adm;
    }
}